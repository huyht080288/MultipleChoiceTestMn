using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using THITN.Controllers;
using THITN.Helper;
using THITN.Models;
using THITN.View;

namespace THITN.Views
{
    public partial class frmChonMonThi : Form
    {
        MonHocController objMonHocController = new MonHocController();
        GiaoVien_DangKyController objGiaoVien_DangKyController = new GiaoVien_DangKyController();

        List<GiaoVien_DangKy> lstDangKy = new List<GiaoVien_DangKy>();
        List<MonHoc> lstMonHoc = new List<MonHoc>();

        public frmChonMonThi()
        {
            InitializeComponent();

            // Đăng ký sự kiện
            this.Load += FrmChonMonThi_Load;
        }
        private void DisplayHeader()
        {
            string strSV = $"{SystemInfo.CurrentSinhVien.HO} {SystemInfo.CurrentSinhVien.TEN}";
            lblSinhVien.Text = $"Sinh viên: {strSV} - Mã SV: {SystemInfo.CurrentSinhVien.MASV} - Lớp: {SystemInfo.CurrentSinhVien.MALOP}";
        }

        private void FrmChonMonThi_Load(object sender, EventArgs e)
        {
            DisplayHeader();
            LoadDSMonHoc();
            LoadDSDangKy();

            cbbLanThi.SelectedIndex = 0;
            dtpNgayThi.Value = DateTime.Now;

            DisplayDSMonHoc();
            DisplayDangKyOnGrid();

            // Đăng ký sự kiện
            this.cbbMonHoc.SelectedIndexChanged += new System.EventHandler(this.FilterValueChanged);
            this.dtpNgayThi.ValueChanged += new System.EventHandler(this.FilterValueChanged);
            this.cbbLanThi.SelectedIndexChanged += new System.EventHandler(this.FilterValueChanged);
            btnBatDauThi.Click += BtnBatDauThi_Click;
            btnThoat.Click += (a,b) => this.Close();
        }

        private void LoadDSDangKy()
        {
            lstDangKy = objGiaoVien_DangKyController.GetAllDangKy();

            if (lstDangKy == null || lstDangKy.Count == 0)
            {
                MessageBox.Show("Không thể tải danh sách môn thi. Vui lòng liên hệ quản trị viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void DisplayDangKyOnGrid()
        {
            if (lstDangKy == null || lstDangKy.Count == 0)
            {
                dgvLichThi.DataSource = null;
                lstDangKy = objGiaoVien_DangKyController.GetAllDangKy();
                return;
            }
            if (lstDangKy == null || lstDangKy.Count == 0)
            {
                dgvLichThi.DataSource = null;
                return;
            }
            string maMH = cbbMonHoc.SelectedValue.ToString();
            DateTime ngayThi = dtpNgayThi.Value.Date;
            int lanThi = int.Parse(cbbLanThi.SelectedItem.ToString());
            List<GiaoVien_DangKy> lst = lstDangKy.Where(t => t.MAMH == maMH && t.NGAYTHI == ngayThi && t.LAN == lanThi).ToList();

            var dtLichThiGoc = ToDatatable(lst);
            dgvLichThi.DataSource = dtLichThiGoc;

            FormatLuoi();
        }

        private void LoadDSMonHoc()
        {
            lstMonHoc = objMonHocController.GetAllMonHocThi();

            if (lstMonHoc == null || lstMonHoc.Count == 0)
            {
                MessageBox.Show("Không thể tải danh sách môn học. Vui lòng liên hệ quản trị viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cbbMonHoc.DataSource = lstMonHoc;
            cbbMonHoc.DisplayMember = "TENMH";
            cbbMonHoc.ValueMember = "MAMH";
            cbbMonHoc.SelectedIndex = 0;
        }

        private void DisplayDSMonHoc()
        {
            cbbMonHoc.DataSource = lstMonHoc;
            cbbMonHoc.DisplayMember = "TENMH";
            cbbMonHoc.ValueMember = "MAMH";
            cbbMonHoc.SelectedIndex = 0;
        }

        private DataTable ToDatatable(List<GiaoVien_DangKy> lst)
        {
            // Build dtLichThiGoc from lstDangKy instead of hardcoded rows
            var dtLichThiGoc = new DataTable();
            dtLichThiGoc.Columns.Add("MAMH", typeof(string));
            dtLichThiGoc.Columns.Add("TENMH", typeof(string));
            dtLichThiGoc.Columns.Add("MALOP", typeof(string));
            dtLichThiGoc.Columns.Add("TENLOP", typeof(string));
            dtLichThiGoc.Columns.Add("NGAYTHI", typeof(DateTime));
            dtLichThiGoc.Columns.Add("LAN", typeof(int));
            dtLichThiGoc.Columns.Add("SOCAUTHI", typeof(int));
            dtLichThiGoc.Columns.Add("THOIGIAN", typeof(int));
            dtLichThiGoc.Columns.Add("TRINHDO", typeof(string));

            if (lst == null || lst.Count == 0)
            {
                // leave empty table (no hardcoded sample data)
                return null;
            }

            foreach (var dk in lst)
            {
                string tenmh = string.Empty;
                if (lstMonHoc != null)
                {
                    var mh = lstMonHoc.FirstOrDefault(m => string.Equals(m.MAMH?.Trim(), dk.MAMH?.Trim(), StringComparison.OrdinalIgnoreCase));
                    if (mh != null) tenmh = mh.TENMH;
                }
                LopController objLopController = new LopController();
                string strMaLop = dk.MALOP;
                var objLop = objLopController.GetLop(strMaLop);
                DateTime ngaythi = dk.NGAYTHI.Date;
                int lan = dk.LAN;
                int socau = dk.SOCAUTHI;
                int thoigian = dk.THOIGIAN;
                string trinhdo = dk.TRINHDO;

                dtLichThiGoc.Rows.Add(dk.MAMH, tenmh, strMaLop, objLop.TENLOP, ngaythi, lan, socau, thoigian, trinhdo);
            }
            return dtLichThiGoc;
        }

        private void FormatLuoi()
        {
            if (dgvLichThi.Columns["MAMH"] != null)
            {
                dgvLichThi.Columns["MAMH"].HeaderText = "Mã MH";
                dgvLichThi.Columns["TENMH"].HeaderText = "Tên Môn Học";
                dgvLichThi.Columns["TENLOP"].HeaderText = "Tên Lớp";
                dgvLichThi.Columns["NGAYTHI"].HeaderText = "Ngày Thi";
                dgvLichThi.Columns["LAN"].HeaderText = "Lần Thi";
                dgvLichThi.Columns["SOCAUTHI"].HeaderText = "Số Câu";
                dgvLichThi.Columns["THOIGIAN"].HeaderText = "Thời Gian (Phút)";
                dgvLichThi.Columns["TRINHDO"].HeaderText = "Trình Độ";

                // Format cột ngày
                if (dgvLichThi.Columns["NGAYTHI"] != null)
                    dgvLichThi.Columns["NGAYTHI"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvLichThi.Columns["MALOP"].Visible = false;
                dgvLichThi.Columns["MAMH"].Visible = false;
            }
        }

        private void BtnBatDauThi_Click(object sender, EventArgs e)
        {
            if (dgvLichThi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn môn thi từ danh sách tìm được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu dòng đang chọn
            DataGridViewRow row = dgvLichThi.SelectedRows[0];
            string maMH = row.Cells["MAMH"].Value.ToString();
            string tenMH = row.Cells["TENMH"].Value.ToString();
            string maLop = row.Cells["MALOP"].Value.ToString();
            string tenLop = row.Cells["TENLOP"].Value.ToString();
            int lan = int.Parse(row.Cells["LAN"].Value.ToString());
            int soCau = int.Parse(row.Cells["SOCAUTHI"].Value.ToString());
            int thoiGian = int.Parse(row.Cells["THOIGIAN"].Value.ToString());
            string trinhDo = row.Cells["TRINHDO"].Value.ToString();
            DateTime ngayThi = (DateTime)row.Cells["NGAYTHI"].Value;

            // --- KIỂM TRA RÀNG BUỘC ---

            // 1. Kiểm tra ngày thi (Quan trọng)
            if (ngayThi.Date != DateTime.Now.Date)
            {
                MessageBox.Show($"Môn này đăng ký thi ngày {ngayThi:dd/MM/yyyy}. Hôm nay chưa được thi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmThi f = new frmThi()
            {
                MALOP = maLop,
                MAMH = maMH,
                TENMH = tenMH,
                LANTHI = (short)lan,
                THOIGIANTHI = (short)thoiGian,
            };
            this.Hide(); // Ẩn form chọn môn
            f.ShowDialog();
            this.Show(); // Hiện lại khi form thi đóng

            // Reset tìm kiếm sau khi thi xong (để tránh thi lại ngay lập tức)
            dgvLichThi.DataSource = null;
        }

        private void FilterValueChanged(object sender, EventArgs e)
        {
            DisplayDangKyOnGrid();
        }
    }
}