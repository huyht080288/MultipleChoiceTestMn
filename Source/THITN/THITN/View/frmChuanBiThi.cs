using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using THITN.Controllers;
using THITN.Core;
using THITN.DAO;
using THITN.Models;
using THITN.Helper; // Chứa SystemInfo

namespace THITN.Views
{
    public partial class frmChuanBiThi : Form
    {
        private List<GiaoVien_DangKy> lstDangKy;
        private bool _isAdding = false;
        private string _maGVDangNhap;

        public frmChuanBiThi()
        {
            InitializeComponent();
            _maGVDangNhap = SystemInfo.CurrentGiaoVien?.MAGV ?? "GV001"; // Fallback nếu chưa login

            this.Load += FrmChuanBiThi_Load;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnGhi.Click += BtnGhi_Click;
            btnPhucHoi.Click += BtnPhucHoi_Click;
            btnReload.Click += BtnReload_Click;
            dgvDangKy.SelectionChanged += DgvDangKy_SelectionChanged;
        }

        private void FrmChuanBiThi_Load(object sender, EventArgs e)
        {
            LoadCombobox();
            LoadData();
            SetState(false); // Trạng thái ban đầu: Xem (Khóa input)
        }

        private void LoadCombobox()
        {
            try
            {
                // Load Môn Học
                cbbMonHoc.DataSource = new MonHocController().GetAllMonHoc();
                cbbMonHoc.DisplayMember = "TENMH";
                cbbMonHoc.ValueMember = "MAMH";

                // Load Lớp (Dùng SqlDataReader trực tiếp nếu chưa có LopDAO)
                SqlDataReader readerLop = Database.ExecuteReader("SELECT MALOP, TENLOP FROM LOP", CommandType.Text);
                if (readerLop != null)
                {
                    DataTable dtLop = new DataTable();
                    dtLop.Load(readerLop);
                    readerLop.Close();
                    cbbLop.DataSource = dtLop;
                    cbbLop.DisplayMember = "TENLOP";
                    cbbLop.ValueMember = "MALOP";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                lstDangKy = new GiaoVien_DangKyController().GetByMaGV(_maGVDangNhap);
                dgvDangKy.DataSource = lstDangKy;
                FormatGrid();

                if (lstDangKy.Count == 0)
                {
                    ClearInputs();
                }
                else
                {
                    // Lưới tự chọn dòng 0, nên SelectionChanged sẽ tự map data lên TextBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatGrid()
        {
            if (dgvDangKy.Columns["RowGuid"] != null) dgvDangKy.Columns["RowGuid"].Visible = false;
            if (dgvDangKy.Columns["MAGV"] != null) dgvDangKy.Columns["MAGV"].Visible = false;

            if (dgvDangKy.Columns["MALOP"] != null) dgvDangKy.Columns["MALOP"].HeaderText = "Lớp";
            if (dgvDangKy.Columns["MAMH"] != null) dgvDangKy.Columns["MAMH"].HeaderText = "Môn học";
            if (dgvDangKy.Columns["TRINHDO"] != null) dgvDangKy.Columns["TRINHDO"].HeaderText = "Trình độ";
            if (dgvDangKy.Columns["NGAYTHI"] != null)
            {
                dgvDangKy.Columns["NGAYTHI"].HeaderText = "Ngày thi";
                dgvDangKy.Columns["NGAYTHI"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvDangKy.Columns["LAN"] != null) dgvDangKy.Columns["LAN"].HeaderText = "Lần thi";
            if (dgvDangKy.Columns["SOCAUTHI"] != null) dgvDangKy.Columns["SOCAUTHI"].HeaderText = "Số câu";
            if (dgvDangKy.Columns["THOIGIAN"] != null) dgvDangKy.Columns["THOIGIAN"].HeaderText = "Thời gian";
        }

        /// <summary>
        /// Hàm quản lý trạng thái form (State Machine)
        /// </summary>
        private void SetState(bool isEditing)
        {
            // Nút bấm
            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing && lstDangKy != null && lstDangKy.Count > 0;
            btnXoa.Enabled = !isEditing && lstDangKy != null && lstDangKy.Count > 0;
            btnReload.Enabled = !isEditing;

            btnGhi.Enabled = isEditing;
            btnPhucHoi.Enabled = isEditing;

            // Khóa/Mở lưới
            dgvDangKy.Enabled = !isEditing;

            // Khóa/Mở Input Form
            grpNhapLieu.Enabled = isEditing;

            // Xử lý đặc biệt cho chức năng SỬA (Khóa không cho sửa Primary Key)
            if (isEditing && !_isAdding)
            {
                cbbLop.Enabled = false;
                cbbMonHoc.Enabled = false;
                cbbLanThi.Enabled = false;
            }
            else
            {
                cbbLop.Enabled = true;
                cbbMonHoc.Enabled = true;
                cbbLanThi.Enabled = true;
            }
        }

        private void DgvDangKy_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDangKy.CurrentRow != null && dgvDangKy.CurrentRow.Index >= 0)
            {
                MapDataToInput(dgvDangKy.CurrentRow.Index);
            }
        }

        private void MapDataToInput(int index)
        {
            if (index < 0 || index >= lstDangKy.Count) return;

            GiaoVien_DangKy gvdk = lstDangKy[index];
            if (cbbLop.Items.Count > 0) cbbLop.SelectedValue = gvdk.MALOP;
            if (cbbMonHoc.Items.Count > 0) cbbMonHoc.SelectedValue = gvdk.MAMH;
            cbbTrinhDo.Text = gvdk.TRINHDO;
            dtpNgayThi.Value = gvdk.NGAYTHI;
            cbbLanThi.Text = gvdk.LAN.ToString();
            nudSoCau.Value = gvdk.SOCAUTHI;
            nudThoiGian.Value = gvdk.THOIGIAN;
        }

        private void ClearInputs()
        {
            if (cbbLop.Items.Count > 0) cbbLop.SelectedIndex = 0;
            if (cbbMonHoc.Items.Count > 0) cbbMonHoc.SelectedIndex = 0;
            cbbTrinhDo.SelectedIndex = 0;
            dtpNgayThi.Value = DateTime.Now;
            cbbLanThi.SelectedIndex = 0;
            nudSoCau.Value = 10;
            nudThoiGian.Value = 15;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            _isAdding = true;
            ClearInputs();
            SetState(true);
            cbbLop.Focus();
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvDangKy.CurrentRow == null) return;
            _isAdding = false;
            SetState(true);
            dtpNgayThi.Focus();
        }

        private void BtnPhucHoi_Click(object sender, EventArgs e)
        {
            SetState(false);
            if (lstDangKy.Count > 0 && dgvDangKy.CurrentRow != null)
            {
                // Trả lại dữ liệu từ dòng đang chọn trên lưới
                MapDataToInput(dgvDangKy.CurrentRow.Index);
            }
            else
            {
                ClearInputs();
            }
        }

        private void BtnGhi_Click(object sender, EventArgs e)
        {
            GiaoVien_DangKy gvdk = new GiaoVien_DangKy
            {
                MAGV = _maGVDangNhap,
                MALOP = cbbLop.SelectedValue?.ToString() ?? "",
                MAMH = cbbMonHoc.SelectedValue?.ToString() ?? "",
                TRINHDO = cbbTrinhDo.Text,
                NGAYTHI = dtpNgayThi.Value,
                LAN = short.Parse(cbbLanThi.Text),
                SOCAUTHI = (short)nudSoCau.Value,
                THOIGIAN = (short)nudThoiGian.Value
            };

            string errorMsg;
            bool kq = new GiaoVien_DangKyController().LuuDangKy(gvdk, _isAdding, out errorMsg);

            if (kq)
            {
                MessageBox.Show("Lưu lịch thi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                SetState(false);
            }
            else
            {
                MessageBox.Show(errorMsg, "Lỗi Ghi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDangKy.CurrentRow == null) return;

            string maLop = dgvDangKy.CurrentRow.Cells["MALOP"].Value.ToString();
            string maMH = dgvDangKy.CurrentRow.Cells["MAMH"].Value.ToString();
            short lan = short.Parse(dgvDangKy.CurrentRow.Cells["LAN"].Value.ToString());

            DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa lịch thi Môn {maMH} Lần {lan} của lớp {maLop}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string errorMsg;
                bool kq = new GiaoVien_DangKyController().XoaDangKy(maLop, maMH, lan, out errorMsg);

                if (kq)
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show(errorMsg, "Lỗi Xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}