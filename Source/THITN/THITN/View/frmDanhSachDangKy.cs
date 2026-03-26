using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using THITN.Controllers;
using THITN.Helper;
using THITN.Models;

namespace THITN.Views
{
    public partial class frmDanhSachDangKy : Form
    {
        private List<ReportDanhSachDangKy> currentData;

        public frmDanhSachDangKy()
        {
            InitializeComponent();

            this.Load += FrmDanhSachDangKy_Load;
            btnXemTruoc.Click += BtnXemTruoc_Click;
            btnInBaoCao.Click += BtnInBaoCao_Click;
            btnThoat.Click += (s, e) => this.Close();
        }

        private void FrmDanhSachDangKy_Load(object sender, EventArgs e)
        {
            // Thiết lập mặc định: Xem từ 30 ngày trước đến hiện tại
            dtpTuNgay.Value = DateTime.Now.AddMonths(-1);
            dtpDenNgay.Value = DateTime.Now;
        }

        private void BtnXemTruoc_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;

            // Lấy đến hết ngày hôm đó (23:59:59) để đảm bảo không rớt dữ liệu nếu lưu có giờ phút
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

            string errorMsg;
            currentData = new ReportController().GetDanhSachDangKyThi(tuNgay, denNgay, out errorMsg);

            if (currentData == null && !string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg, "Lỗi truy xuất", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SystemInfo.Role == DatabaseRole.COSO)
            {
                currentData = currentData.Where(x => x.MaCoSo == SystemInfo.MaCoSo).ToList();
            }
            dgvReport.DataSource = currentData;
            FormatGrid();

            if (currentData.Count == 0)
            {
                MessageBox.Show("Không có lịch thi nào được đăng ký trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormatGrid()
        {
            if (dgvReport.Columns["MaCoSo"] != null) dgvReport.Columns["MaCoSo"].Visible = false;
            if (dgvReport.Columns["TenCoSo"] != null) dgvReport.Columns["TenCoSo"].HeaderText = "Cơ Sở";
            if (dgvReport.Columns["TenLop"] != null) { dgvReport.Columns["TenLop"].HeaderText = "Tên Lớp"; dgvReport.Columns["TenLop"].Width = 150; }
            if (dgvReport.Columns["TenMonHoc"] != null) { dgvReport.Columns["TenMonHoc"].HeaderText = "Tên Môn Học"; dgvReport.Columns["TenMonHoc"].Width = 150; }
            if (dgvReport.Columns["TenGiaoVien"] != null) { dgvReport.Columns["TenGiaoVien"].HeaderText = "Giáo Viên Đăng Ký"; dgvReport.Columns["TenGiaoVien"].Width = 150; }

            if (dgvReport.Columns["TrinhDo"] != null) { dgvReport.Columns["TrinhDo"].HeaderText = "Trình Độ"; dgvReport.Columns["TrinhDo"].Width = 70; }
            if (dgvReport.Columns["SoCau"] != null) { dgvReport.Columns["SoCau"].HeaderText = "Số Câu"; dgvReport.Columns["SoCau"].Width = 70; }
            if (dgvReport.Columns["ThoiGian"] != null) { dgvReport.Columns["ThoiGian"].HeaderText = "Thời Gian (p)"; dgvReport.Columns["ThoiGian"].Width = 90; }
            if (dgvReport.Columns["LanThi"] != null) { dgvReport.Columns["LanThi"].HeaderText = "Lần"; dgvReport.Columns["LanThi"].Width = 60; }

            if (dgvReport.Columns["NgayThi"] != null)
            {
                dgvReport.Columns["NgayThi"].HeaderText = "Ngày Thi";
                dgvReport.Columns["NgayThi"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }

        private void BtnInBaoCao_Click(object sender, EventArgs e)
        {
            if (currentData == null || currentData.Count == 0)
            {
                MessageBox.Show("Vui lòng nhấn 'Xem Trước' để nạp dữ liệu trước khi in báo cáo!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: TÍCH HỢP CÔNG CỤ IN (DevExpress XtraReport, Microsoft RDLC, hoặc Crystal Report)
            // Vì hiện tại chưa biết bạn dùng thư viện nào để thiết kế bản in A4,
            // Tôi để sẵn điểm neo (Hook) ở đây. 
            // 
            // CÁCH LÀM:
            // 1. Tạo 1 file Report (ví dụ rptDanhSachDangKy.cs)
            // 2. Gán dữ liệu: rpt.DataSource = currentData;
            // 3. Hiển thị: ReportPrintTool printTool = new ReportPrintTool(rpt); printTool.ShowPreviewDialog();

            MessageBox.Show("Đã lấy thành công " + currentData.Count + " dòng.\nTính năng in ra trang A4 đang chờ tích hợp thư viện Report (DevExpress/RDLC).", "Tính năng In", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}