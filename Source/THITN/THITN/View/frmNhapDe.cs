using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using THITN.Controllers;
using THITN.Core;
using THITN.DAO;
using THITN.Helper;
using THITN.Models;

namespace THITN.View
{
    public partial class frmNhapDe : Form
    {
        #region Cấu trúc dữ liệu cho tính năng Undo (Phục Hồi)

        private enum LoaiThaoTac { Them, Xoa, Sua }

        private class UndoAction
        {
            public LoaiThaoTac Loai { get; set; }
            public int ViTriGrid { get; set; } // Vị trí dòng trên lưới
            public BoDe DuLieuCu { get; set; } // Dùng cho Xóa và Sửa (Lưu bản sao cũ)
            public BoDe DuLieuMoi { get; set; } // Dùng cho Thêm và Sửa (Tham chiếu đến object hiện tại)
            public bool DaCoTrongDB { get; set; } // Đánh dấu câu hỏi Xóa đã từng lưu DB chưa
        }

        // Ngăn xếp lưu lịch sử thao tác
        private Stack<UndoAction> undoStack = new Stack<UndoAction>();

        // Các biến phục vụ việc bắt sự kiện Sửa (Update)
        private BoDe _trangThaiCuCuaDong = null;
        private int _dongDangChon = -1;
        private bool _dongDaBThayDoi = false;

        #endregion

        // Danh sách chính lưu trên RAM
        private BindingList<BoDe> listBoDeHienTai;
        private List<int> listCauHoiBiXoa = new List<int>();
        private string _maGVDangNhap;
        private bool _isPopulatingUI = false;

        public frmNhapDe()
        {
            InitializeComponent();

            _maGVDangNhap = SystemInfo.CurrentGiaoVien.MAGV;
            this.Load += FrmNhapDe_Load;

            // Đăng ký sự kiện các nút
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            btnGhi.Click += BtnGhi_Click;
            btnPhucHoi.Click += BtnPhucHoi_Click;
            btnReload.Click += BtnReload_Click;
            btnThoat.Click += (s, e) => this.Close();

            // Đăng ký sự kiện lưới
            dgvBoDe.SelectionChanged += DgvBoDe_SelectionChanged;

            // Đăng ký sự kiện PUSH dữ liệu
            DangKySuKienDongBoNguoc();
        }

        private void FrmNhapDe_Load(object sender, EventArgs e)
        {
            LoadComboboxMonHoc();
            LoadDataBoDe();
        }

        private void LoadComboboxMonHoc()
        {
            try
            {
                var lstMonHoc = new MonHocController().GetAllMonHoc();
                cbbMAMH.DataSource = lstMonHoc;
                cbbMAMH.DisplayMember = "TENMH";
                cbbMAMH.ValueMember = "MAMH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục môn học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataBoDe()
        {
            try
            {
                var lstBoDeFromDB = new BoDeController().GetBoDeByMaGV(_maGVDangNhap);
                listBoDeHienTai = new BindingList<BoDe>(lstBoDeFromDB);

                dgvBoDe.DataSource = listBoDeHienTai;

                // Reset toàn bộ trạng thái Undo & Xóa
                listCauHoiBiXoa.Clear();
                undoStack.Clear();
                _dongDaBThayDoi = false;
                _dongDangChon = -1;

                FormatDataGridView();

                if (listBoDeHienTai.Count > 0)
                    HienThiChiTietCauHoi(0);
                else
                    ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách bộ đề: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dgvBoDe.Columns["RowGuid"] != null) dgvBoDe.Columns["RowGuid"].Visible = false;
            if (dgvBoDe.Columns["MAGV"] != null) dgvBoDe.Columns["MAGV"].Visible = false;
            if (dgvBoDe.Columns["DapAnDaChon"] != null) dgvBoDe.Columns["DapAnDaChon"].Visible = false;
            if (dgvBoDe.Columns["STT"] != null) dgvBoDe.Columns["STT"].Visible = false;

            if (dgvBoDe.Columns["CAUHOI"] != null) { dgvBoDe.Columns["CAUHOI"].HeaderText = "Mã Câu"; dgvBoDe.Columns["CAUHOI"].Width = 60; }
            if (dgvBoDe.Columns["MAMH"] != null) { dgvBoDe.Columns["MAMH"].HeaderText = "Môn học"; dgvBoDe.Columns["MAMH"].Width = 80; }
            if (dgvBoDe.Columns["TRINHDO"] != null) { dgvBoDe.Columns["TRINHDO"].HeaderText = "Độ khó"; dgvBoDe.Columns["TRINHDO"].Width = 60; }
            if (dgvBoDe.Columns["NOIDUNG"] != null) dgvBoDe.Columns["NOIDUNG"].HeaderText = "Nội dung câu hỏi";
            if (dgvBoDe.Columns["DAPAN"] != null) { dgvBoDe.Columns["DAPAN"].HeaderText = "Đáp án"; dgvBoDe.Columns["DAPAN"].Width = 60; }
        }

        #region Helper Functions (Clone Object)

        // Tạo một bản sao độc lập của đối tượng để lưu vào History Stack
        private BoDe CloneBoDe(BoDe source)
        {
            if (source == null) return null;
            return new BoDe
            {
                CAUHOI = source.CAUHOI,
                MAMH = source.MAMH,
                TRINHDO = source.TRINHDO,
                NOIDUNG = source.NOIDUNG,
                A = source.A,
                B = source.B,
                C = source.C,
                D = source.D,
                DAPAN = source.DAPAN,
                MAGV = source.MAGV
            };
        }

        // Copy thuộc tính (Dùng để Undo chức năng Sửa)
        private void CopyProperties(BoDe source, BoDe destination)
        {
            if (source == null || destination == null) return;
            destination.MAMH = source.MAMH;
            destination.TRINHDO = source.TRINHDO;
            destination.NOIDUNG = source.NOIDUNG;
            destination.A = source.A; destination.B = source.B; destination.C = source.C; destination.D = source.D;
            destination.DAPAN = source.DAPAN;
        }

        #endregion

        #region Cơ chế Cập nhật thủ công (Manual Mapping) & Bắt sự kiện Undo

        private void DgvBoDe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBoDe.CurrentRow != null && dgvBoDe.CurrentRow.Index >= 0)
            {
                int newIndex = dgvBoDe.CurrentRow.Index;

                // Nếu di chuyển khỏi một dòng ĐÃ BỊ SỬA -> Ghi nhận thao tác SỬA vào Stack
                if (_dongDaBThayDoi && _dongDangChon >= 0 && _dongDangChon < listBoDeHienTai.Count && _dongDangChon != newIndex)
                {
                    undoStack.Push(new UndoAction
                    {
                        Loai = LoaiThaoTac.Sua,
                        ViTriGrid = _dongDangChon,
                        DuLieuCu = _trangThaiCuCuaDong, // Dữ liệu trước khi gõ phím
                        DuLieuMoi = listBoDeHienTai[_dongDangChon] // Reference tới object hiện tại
                    });
                }

                // Cập nhật trạng thái cho dòng mới được chọn
                _dongDangChon = newIndex;
                _trangThaiCuCuaDong = CloneBoDe(listBoDeHienTai[_dongDangChon]); // Snapshot dữ liệu gốc
                _dongDaBThayDoi = false;

                HienThiChiTietCauHoi(_dongDangChon);
            }
        }

        private void HienThiChiTietCauHoi(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= listBoDeHienTai.Count) return;

            _isPopulatingUI = true;

            BoDe bd = listBoDeHienTai[rowIndex];
            if (cbbMAMH.Items.Count > 0 && !string.IsNullOrEmpty(bd.MAMH)) cbbMAMH.SelectedValue = bd.MAMH;
            cbbTRINHDO.Text = bd.TRINHDO;
            txtNOIDUNG.Text = bd.NOIDUNG;
            txtA.Text = bd.A; txtB.Text = bd.B; txtC.Text = bd.C; txtD.Text = bd.D;
            cbbDAPAN.Text = bd.DAPAN;

            _isPopulatingUI = false;
        }

        private void DangKySuKienDongBoNguoc()
        {
            txtNOIDUNG.TextChanged += Control_ValueChanged;
            txtA.TextChanged += Control_ValueChanged; txtB.TextChanged += Control_ValueChanged;
            txtC.TextChanged += Control_ValueChanged; txtD.TextChanged += Control_ValueChanged;
            cbbMAMH.SelectedIndexChanged += Control_ValueChanged;
            cbbTRINHDO.SelectedIndexChanged += Control_ValueChanged;
            cbbDAPAN.SelectedIndexChanged += Control_ValueChanged;
        }

        private void Control_ValueChanged(object sender, EventArgs e)
        {
            if (_isPopulatingUI) return;
            if (dgvBoDe.CurrentRow == null || dgvBoDe.CurrentRow.Index < 0) return;

            // Đánh dấu là dòng này đã bị chỉnh sửa
            if (!_dongDaBThayDoi) _dongDaBThayDoi = true;

            int index = dgvBoDe.CurrentRow.Index;
            BoDe bd = listBoDeHienTai[index];

            if (cbbMAMH.SelectedValue != null) bd.MAMH = cbbMAMH.SelectedValue.ToString();
            bd.TRINHDO = cbbTRINHDO.Text;
            bd.NOIDUNG = txtNOIDUNG.Text;
            bd.A = txtA.Text; bd.B = txtB.Text; bd.C = txtC.Text; bd.D = txtD.Text;
            bd.DAPAN = cbbDAPAN.Text;

            dgvBoDe.InvalidateRow(index);
        }

        private void ClearTextBoxes()
        {
            _isPopulatingUI = true;
            if (cbbMAMH.Items.Count > 0) cbbMAMH.SelectedIndex = 0;
            cbbTRINHDO.SelectedIndex = 0;
            txtNOIDUNG.Text = "";
            txtA.Text = ""; txtB.Text = ""; txtC.Text = ""; txtD.Text = "";
            cbbDAPAN.SelectedIndex = 0;
            _isPopulatingUI = false;
        }

        #endregion

        #region Xử lý Sự kiện Nút (Thêm, Xóa, Ghi, Phục Hồi, Reload)

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // XỬ LÝ QUAN TRỌNG: Tắt sự kiện lưới trước khi thêm để tránh lỗi cascade vòng lặp
                dgvBoDe.SelectionChanged -= DgvBoDe_SelectionChanged;

                // Lưu lại dòng đang gõ dở (nếu có) trước khi chuyển sang dòng mới
                if (_dongDaBThayDoi && _dongDangChon >= 0 && _dongDangChon < listBoDeHienTai.Count)
                {
                    undoStack.Push(new UndoAction
                    {
                        Loai = LoaiThaoTac.Sua,
                        ViTriGrid = _dongDangChon,
                        DuLieuCu = _trangThaiCuCuaDong,
                        DuLieuMoi = listBoDeHienTai[_dongDangChon]
                    });
                }

                BoDe newBoDe = new BoDe
                {
                    CAUHOI = -1,
                    MAGV = _maGVDangNhap,
                    MAMH = cbbMAMH.Items.Count > 0 ? cbbMAMH.SelectedValue.ToString() : "",
                    TRINHDO = "A",
                    DAPAN = "A",
                    NOIDUNG = "",
                    A = "",
                    B = "",
                    C = "",
                    D = ""
                };

                listBoDeHienTai.Add(newBoDe);

                // --- GHI NHẬN LỊCH SỬ THÊM ---
                undoStack.Push(new UndoAction
                {
                    Loai = LoaiThaoTac.Them,
                    ViTriGrid = listBoDeHienTai.Count - 1,
                    DuLieuMoi = newBoDe
                });

                int lastIndex = listBoDeHienTai.Count - 1;

                // Thiết lập hiển thị lưới và chuyển con trỏ chuột một cách tường minh
                dgvBoDe.ClearSelection();

                // Tìm cột đầu tiên đang hiển thị để focus Cell
                foreach (DataGridViewColumn col in dgvBoDe.Columns)
                {
                    if (col.Visible)
                    {
                        dgvBoDe.CurrentCell = dgvBoDe.Rows[lastIndex].Cells[col.Index];
                        break;
                    }
                }

                dgvBoDe.Rows[lastIndex].Selected = true;
                dgvBoDe.FirstDisplayedScrollingRowIndex = lastIndex;

                // Cập nhật lại các biến quản lý trạng thái bằng tay (vì ta đã tắt sự kiện SelectionChanged)
                _dongDangChon = lastIndex;
                _trangThaiCuCuaDong = CloneBoDe(newBoDe);
                _dongDaBThayDoi = false;

                // Ép hiển thị chi tiết lên TextBox (sẽ làm trắng toàn bộ ô nhập)
                HienThiChiTietCauHoi(lastIndex);

                // Bật lại sự kiện
                dgvBoDe.SelectionChanged += DgvBoDe_SelectionChanged;

                txtNOIDUNG.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Đảm bảo mở lại sự kiện nếu gặp lỗi
                dgvBoDe.SelectionChanged += DgvBoDe_SelectionChanged;
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvBoDe.CurrentRow == null || listBoDeHienTai.Count == 0) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa câu hỏi này khỏi danh sách không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                int index = dgvBoDe.CurrentRow.Index;
                BoDe bdXoa = listBoDeHienTai[index];

                // --- GHI NHẬN LỊCH SỬ XÓA ---
                undoStack.Push(new UndoAction
                {
                    Loai = LoaiThaoTac.Xoa,
                    ViTriGrid = index,
                    DuLieuCu = CloneBoDe(bdXoa), // Clone lại để phục hồi
                    DaCoTrongDB = (bdXoa.CAUHOI > 0)
                });

                if (bdXoa.CAUHOI > 0) listCauHoiBiXoa.Add(bdXoa.CAUHOI);

                listBoDeHienTai.RemoveAt(index);

                // Nếu đang xóa ngay cái dòng đang edit dở thì reset cờ
                if (index == _dongDangChon)
                {
                    _dongDaBThayDoi = false;
                    _dongDangChon = -1;
                }

                if (listBoDeHienTai.Count == 0) ClearTextBoxes();
            }
        }

        private void BtnPhucHoi_Click(object sender, EventArgs e)
        {
            // BƯỚC 1: Nếu người dùng đang gõ dở 1 dòng, thì nút Undo sẽ Phục hồi lại dòng đó trước
            if (_dongDaBThayDoi && _dongDangChon >= 0 && _dongDangChon < listBoDeHienTai.Count)
            {
                CopyProperties(_trangThaiCuCuaDong, listBoDeHienTai[_dongDangChon]); // Trả về text cũ
                _dongDaBThayDoi = false;
                dgvBoDe.InvalidateRow(_dongDangChon);
                HienThiChiTietCauHoi(_dongDangChon);
                return; // Xong 1 bước Undo
            }

            // BƯỚC 2: Rút thao tác từ Ngăn Xếp (Stack)
            if (undoStack.Count == 0)
            {
                MessageBox.Show("Không còn thao tác nào để phục hồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UndoAction action = undoStack.Pop();
            _isPopulatingUI = true;

            if (action.Loai == LoaiThaoTac.Them)
            {
                // Undo lệnh Thêm -> Xóa nó đi
                listBoDeHienTai.Remove(action.DuLieuMoi);
            }
            else if (action.Loai == LoaiThaoTac.Xoa)
            {
                // Undo lệnh Xóa -> Chèn lại vào vị trí cũ
                int insertPos = Math.Min(action.ViTriGrid, listBoDeHienTai.Count);
                listBoDeHienTai.Insert(insertPos, action.DuLieuCu);

                if (action.DaCoTrongDB) listCauHoiBiXoa.Remove(action.DuLieuCu.CAUHOI);

                dgvBoDe.ClearSelection();
                dgvBoDe.Rows[insertPos].Selected = true;
            }
            else if (action.Loai == LoaiThaoTac.Sua)
            {
                // Undo lệnh Sửa -> Trả lại Data cũ cho Object hiện tại
                CopyProperties(action.DuLieuCu, action.DuLieuMoi);

                int idx = listBoDeHienTai.IndexOf(action.DuLieuMoi);
                if (idx >= 0)
                {
                    dgvBoDe.InvalidateRow(idx);
                    dgvBoDe.ClearSelection();
                    dgvBoDe.Rows[idx].Selected = true;
                }
            }

            // Reset trạng thái sau khi phục hồi
            _dongDaBThayDoi = false;
            if (dgvBoDe.CurrentRow != null)
            {
                _dongDangChon = dgvBoDe.CurrentRow.Index;
                _trangThaiCuCuaDong = CloneBoDe(listBoDeHienTai[_dongDangChon]);
                HienThiChiTietCauHoi(_dongDangChon);
            }
            else
            {
                ClearTextBoxes();
            }

            _isPopulatingUI = false;
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            // Push nốt dữ liệu nếu đang gõ dở
            Control_ValueChanged(null, null);

            if (listBoDeHienTai.Count == 0 && listCauHoiBiXoa.Count == 0)
            {
                MessageBox.Show("Không có thay đổi nào để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<BoDe> lstThem = new List<BoDe>();
            List<BoDe> lstSua = new List<BoDe>();

            foreach (var item in listBoDeHienTai)
            {
                if (string.IsNullOrWhiteSpace(item.NOIDUNG) || string.IsNullOrWhiteSpace(item.A) || string.IsNullOrWhiteSpace(item.B))
                {
                    MessageBox.Show("Câu hỏi phải có Nội dung và ít nhất đáp án A, B!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (item.CAUHOI <= 0) lstThem.Add(item);
                else lstSua.Add(item);
            }

            try
            {
                bool kq = BoDeController.SaveBatch(lstThem, lstSua, listCauHoiBiXoa, _maGVDangNhap);

                if (kq)
                {
                    MessageBox.Show("Đã GHI toàn bộ thay đổi thành công vào CSDL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataBoDe(); // Tải lại sẽ tự động Clear Undo Stack
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Quá trình GHI thất bại. Lỗi: \n" + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Hủy toàn bộ thao tác chưa ghi và tải lại gốc?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                LoadDataBoDe();
            }
        }

        #endregion
    }
}