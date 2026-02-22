using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using THITN.Controllers; // Import Controller
using THITN.Core;
using THITN.DAO;
using THITN.Models;      // Import Models

namespace THITN.Views
{
    public partial class frmDiemThi : Form
    {
        public frmDiemThi()
        {
            InitializeComponent();

            // Đăng ký các sự kiện
            this.Load += FrmDiemThi_Load;
            btnXem.Click += BtnXem_Click;
            btnInBaoCao.Click += BtnInBaoCao_Click;
            btnThoat.Click += (s, e) => this.Close();
        }

        private void FrmDiemThi_Load(object sender, EventArgs e)
        {
            LoadDataIntoComboBox();
            cbbLanThi.SelectedIndex = 0; // Mặc định chọn Lần thi = 1
        }

        /// <summary>
        /// Nạp dữ liệu danh mục Lớp và Môn Học vào ComboBox
        /// </summary>
        private void LoadDataIntoComboBox()
        {
            try
            {
                // 1. Nạp Môn Học (Sử dụng Controller/DAO đã có)
                cbbMonHoc.DataSource = MonHocDAO.GetAllMonHoc();
                cbbMonHoc.DisplayMember = "TENMH";
                cbbMonHoc.ValueMember = "MAMH";

                // 2. Nạp Lớp
                // (Gợi ý: Tương lai bạn nên tạo LopController và LopDAO tương tự như trên)
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

        private void BtnXem_Click(object sender, EventArgs e)
        {
            if (cbbLop.SelectedValue == null || cbbMonHoc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Lớp và Môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maLop = cbbLop.SelectedValue.ToString().Trim();
            string maMH = cbbMonHoc.SelectedValue.ToString().Trim();
            short lanThi = short.Parse(cbbLanThi.SelectedItem.ToString());

            HienThiBangDiem(maLop, maMH, lanThi);
        }

        /// <summary>
        /// Gọi thông qua Controller để hiển thị dữ liệu (MVC Pattern)
        /// </summary>
        private void HienThiBangDiem(string maLop, string maMH, short lan)
        {
            try
            {
                // Gọi Controller để lấy dữ liệu đã được xử lý nghiệp vụ (bao gồm cả Điểm chữ)
                BangDiemController controller = new BangDiemController();
                List<ChiTietBangDiem> lstKetQua = controller.GetBangDiemMonHoc(maLop, maMH, lan);

                // Gán trực tiếp List object vào DataGridView thay vì dùng DataTable thủ công
                dgvBangDiem.DataSource = lstKetQua;

                // Tùy chỉnh HeaderText của các cột cho đẹp
                if (dgvBangDiem.Columns["MASV"] != null)
                {
                    dgvBangDiem.Columns["MASV"].HeaderText = "Mã Sinh Viên";
                    dgvBangDiem.Columns["HO"].HeaderText = "Họ";
                    dgvBangDiem.Columns["TEN"].HeaderText = "Tên";
                    dgvBangDiem.Columns["NGAYTHI"].HeaderText = "Ngày thi";
                    dgvBangDiem.Columns["DIEM"].HeaderText = "Điểm";
                    dgvBangDiem.Columns["DIEMCHU"].HeaderText = "Điểm Chữ";
                    if (dgvBangDiem.Columns["NGAYTHI"] != null)
                    {
                        dgvBangDiem.Columns["NGAYTHI"].DefaultCellStyle.Format = "yyyy-MM-dd";
                    }
                    // Định dạng cột điểm
                    dgvBangDiem.Columns["DIEM"].DefaultCellStyle.Format = "N1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy chi tiết bảng điểm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnInBaoCao_Click(object sender, EventArgs e)
        {
            if (dgvBangDiem.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để in báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // TODO: Ở bước tiếp theo, bạn sẽ truyền lstKetQua vào Report (Ví dụ: XtraReport)
            MessageBox.Show("Chức năng đang được tích hợp. Vui lòng thiết kế file Report (DevExpress/Crystal) trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}