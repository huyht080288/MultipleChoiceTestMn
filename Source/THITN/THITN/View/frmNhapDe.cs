using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using THITN.Controllers;
using THITN.DAO;
using THITN.Models;
using THITN.Core; // Chứa thông tin Session / Database chung

namespace THITN.View
{
    public partial class frmNhapDe : Form
    {
        // Sử dụng BindingList để UI tự động cập nhật khi list thay đổi
        private BindingList<BoDe> listBoDeHienTai;

        // Sử dụng BindingSource để quản lý vị trí con trỏ và DataBinding giữa DataGridView và các TextBox
        private BindingSource bdsBoDe = new BindingSource();

        // Danh sách lưu trữ các CAUHOI (ID) đã bị người dùng xóa trên lưới nhưng chưa Ghi vào CSDL
        private List<int> listCauHoiBiXoa = new List<int>();

        // Giả sử lấy mã GV từ hệ thống khi đăng nhập (THITN.Core.Session.Username)
        private string _maGVDangNhap;

        public frmNhapDe()
        {
            InitializeComponent();

            // Lấy mã GV hiện tại (Bạn có thể điều chỉnh lại biến này theo cấu trúc Class SystemInfo của bạn)
            _maGVDangNhap = Session.Username ?? "GV001"; // Fallback tạm nếu null

            // Đăng ký sự kiện
            this.Load += FrmNhapDe_Load;
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            btnGhi.Click += BtnGhi_Click;
            btnPhucHoi.Click += BtnPhucHoi_Click;
            btnReload.Click += BtnReload_Click;
            btnThoat.Click += (s, e) => this.Close();
        }

        private void FrmNhapDe_Load(object sender, EventArgs e)
        {
            // 1. Tải danh mục Môn Học vào ComboBox
            LoadComboboxMonHoc();

            // 2. Tải dữ liệu Bộ đề của GV hiện tại
            LoadDataBoDe();

            // 3. Liên kết dữ liệu (DataBindings) giữa BindingSource và các Input Controls
            SetupDataBindings();
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
                // Lấy dữ liệu từ Database
                var lstBoDeFromDB = new BoDeController().GetBoDeByMaGV(_maGVDangNhap);

                // Chuyển sang BindingList và nạp vào BindingSource
                listBoDeHienTai = new BindingList<BoDe>(lstBoDeFromDB);
                bdsBoDe.DataSource = listBoDeHienTai;

                // Gán BindingSource vào DataGridView
                dgvBoDe.DataSource = bdsBoDe;

                // Xóa danh sách các câu đã bị xóa lưu tạm
                listCauHoiBiXoa.Clear();

                // Format lại lưới cho dễ nhìn
                FormatDataGridView();
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

            if (dgvBoDe.Columns["CAUHOI"] != null) { dgvBoDe.Columns["CAUHOI"].HeaderText = "Mã Câu"; dgvBoDe.Columns["CAUHOI"].Width = 60; }
            if (dgvBoDe.Columns["MAMH"] != null) { dgvBoDe.Columns["MAMH"].HeaderText = "Môn học"; dgvBoDe.Columns["MAMH"].Width = 80; }
            if (dgvBoDe.Columns["TRINHDO"] != null) { dgvBoDe.Columns["TRINHDO"].HeaderText = "Độ khó"; dgvBoDe.Columns["TRINHDO"].Width = 60; }
            if (dgvBoDe.Columns["NOIDUNG"] != null) dgvBoDe.Columns["NOIDUNG"].HeaderText = "Nội dung câu hỏi";
            if (dgvBoDe.Columns["DAPAN"] != null) { dgvBoDe.Columns["DAPAN"].HeaderText = "Đáp án"; dgvBoDe.Columns["DAPAN"].Width = 60; }
        }

        private void SetupDataBindings()
        {
            // Clear bindings cũ để tránh lỗi khi reload form
            cbbMAMH.DataBindings.Clear();
            cbbTRINHDO.DataBindings.Clear();
            txtNOIDUNG.DataBindings.Clear();
            txtA.DataBindings.Clear();
            txtB.DataBindings.Clear();
            txtC.DataBindings.Clear();
            txtD.DataBindings.Clear();
            cbbDAPAN.DataBindings.Clear();

            // Cơ chế đồng bộ: Khi người dùng chọn 1 dòng trên Grid, BindingSource sẽ thay đổi Position.
            // Các TextBox sẽ tự động lấy dữ liệu của Object ở Position đó hiển thị lên.
            // Khi người dùng gõ vào TextBox, dữ liệu sẽ tự động lưu ngược lại vào Object trong list.
            cbbMAMH.DataBindings.Add("SelectedValue", bdsBoDe, "MAMH", true, DataSourceUpdateMode.OnPropertyChanged);
            cbbTRINHDO.DataBindings.Add("Text", bdsBoDe, "TRINHDO", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNOIDUNG.DataBindings.Add("Text", bdsBoDe, "NOIDUNG", true, DataSourceUpdateMode.OnPropertyChanged);
            txtA.DataBindings.Add("Text", bdsBoDe, "A", true, DataSourceUpdateMode.OnPropertyChanged);
            txtB.DataBindings.Add("Text", bdsBoDe, "B", true, DataSourceUpdateMode.OnPropertyChanged);
            txtC.DataBindings.Add("Text", bdsBoDe, "C", true, DataSourceUpdateMode.OnPropertyChanged);
            txtD.DataBindings.Add("Text", bdsBoDe, "D", true, DataSourceUpdateMode.OnPropertyChanged);
            cbbDAPAN.DataBindings.Add("Text", bdsBoDe, "DAPAN", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        #region Xử lý Sự kiện Nút (Thêm, Xóa, Ghi, Phục Hồi, Reload)

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi BindingSource sinh ra 1 object mới và nhảy tới dòng mới đó
                bdsBoDe.AddNew();

                // Gán các giá trị mặc định cho Object mới thêm
                if (bdsBoDe.Current is BoDe newBoDe)
                {
                    newBoDe.CAUHOI = -1; // Cờ hiệu: ID < 0 nghĩa là câu hỏi chưa có trong DB (Mới thêm)
                    newBoDe.MAGV = _maGVDangNhap;
                    newBoDe.MAMH = cbbMAMH.Items.Count > 0 ? cbbMAMH.SelectedValue.ToString() : "";
                    newBoDe.TRINHDO = "A";
                    newBoDe.DAPAN = "A";

                    // Cập nhật lại UI để hiển thị giá trị mặc định vừa set
                    bdsBoDe.ResetCurrentItem();
                }

                txtNOIDUNG.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (bdsBoDe.Count == 0 || bdsBoDe.Current == null) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa câu hỏi này khỏi lưới không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                BoDe currentBoDe = bdsBoDe.Current as BoDe;

                // Nếu câu hỏi có CAUHOI > 0 tức là nó đã từng được ghi xuống Database
                // Ta cần lưu ID lại để tí nữa bấm [Ghi] thì mới xóa thật dưới DB
                if (currentBoDe != null && currentBoDe.CAUHOI > 0)
                {
                    listCauHoiBiXoa.Add(currentBoDe.CAUHOI);
                }

                // Xóa khỏi BindingSource (sẽ tự mất trên Grid)
                bdsBoDe.RemoveCurrent();
            }
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            // Kết thúc chỉnh sửa đang dang dở trên lưới / ô nhập
            bdsBoDe.EndEdit();

            if (listBoDeHienTai.Count == 0 && listCauHoiBiXoa.Count == 0)
            {
                MessageBox.Show("Không có thay đổi nào để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 1. Chuẩn bị phân tách List Thêm, Sửa
            List<BoDe> lstThem = new List<BoDe>();
            List<BoDe> lstSua = new List<BoDe>();

            // Lặp qua danh sách trên lưới để kiểm tra và phân loại
            foreach (var item in listBoDeHienTai)
            {
                // Validate cơ bản
                if (string.IsNullOrWhiteSpace(item.NOIDUNG))
                {
                    MessageBox.Show("Có câu hỏi đang để trống Nội dung. Vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (item.CAUHOI <= 0) // Cờ hiệu lúc Thêm: -1
                {
                    lstThem.Add(item);
                }
                else
                {
                    // Với list Sửa, trong thực tế có thể bắt cờ isModified, 
                    // nhưng ở đồ án ta có thể pass qua hàm Update hết cũng được
                    lstSua.Add(item);
                }
            }

            // 2. Gọi DAO thực hiện lưu hàng loạt
            try
            {
                bool kq = BoDeController.SaveBatch(lstThem, lstSua, listCauHoiBiXoa, _maGVDangNhap);

                if (kq)
                {
                    MessageBox.Show("Đã GHI toàn bộ thay đổi thành công vào CSDL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại lưới để cập nhật lại CAUHOI (ID) do Database tự sinh cho những câu vừa Thêm Mới
                    LoadDataBoDe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Quá trình GHI thất bại. Lỗi: \n" + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPhucHoi_Click(object sender, EventArgs e)
        {
            // Hủy chỉnh sửa trên dòng hiện tại
            bdsBoDe.CancelEdit();

            DialogResult dr = MessageBox.Show("Hủy toàn bộ các thao tác Thêm/Sửa/Xóa chưa ghi và tải lại bản gốc từ CSDL?", "Xác nhận Phục hồi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                LoadDataBoDe();
            }
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            // Tải lại dữ liệu (Mất các thay đổi chưa Lưu)
            LoadDataBoDe();
        }

        #endregion
    }
}