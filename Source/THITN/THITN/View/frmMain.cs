using System;
using System.Threading;
using System.Windows.Forms;
using THITN.Views;
using THITN.Helper;
using System.Linq.Expressions;

namespace THITN.View
{
    public partial class frmMain : Form
    {


        public frmMain()
        {
            InitializeComponent();
            // Ensure main form can host MDI children
            this.IsMdiContainer = true;

            this.Load += FrmMain_Load;
            this.FormClosing += FrmMain_FormClosing;
            this.btnThi.Click += btnThi_Click;
        }
        private void RefreshScreenStatus()
        {
            if (SystemInfo.IsLoggedIn)
            {
                mnLogin.Enabled = false;
                mnLogout.Enabled = true;
                if (SystemInfo.Role == DatabaseRole.SINHVIEN)
                {
                    lblFooter.Text = "Đăng nhập với tư cách Sinh Viên: " + SystemInfo.CurrentSinhVien.TEN + " - Mã SV: " + SystemInfo.CurrentSinhVien.MASV;
                }
                else
                {
                    lblFooter.Text = "Đăng nhập với tư cách Giáo Viên: " + SystemInfo.CurrentGiaoVien.TEN + " - Mã SV: " + SystemInfo.CurrentGiaoVien.MAGV;
                }


                btnNhapMonHoc.Enabled = false;
                btnNhapKhoaLop.Enabled = false;
                btnNhapSinhVien.Enabled = false;
                btnNhapGiaoVien.Enabled = false;
                btnNhapDe.Enabled = false;
                btnChuanBiThi.Enabled = false;
                btnThi.Enabled = false;

                btnKetQua.Enabled = false;
                btnBangDiem.Enabled = false;
                btnDanhSachDangKy.Enabled = false;

                switch (SystemInfo.Role)
                {
                    case DatabaseRole.TRUONG:
                        btnNhapMonHoc.Enabled = true;
                        btnNhapKhoaLop.Enabled = true;
                        btnNhapSinhVien.Enabled = true;
                        btnNhapGiaoVien.Enabled = true;
                        btnNhapDe.Enabled = true;

                        btnKetQua.Enabled = true;
                        btnBangDiem.Enabled = true;
                        btnDanhSachDangKy.Enabled = true;
                        break;
                    case DatabaseRole.COSO:
                        btnNhapMonHoc.Enabled = true;
                        btnNhapKhoaLop.Enabled = true;
                        btnNhapSinhVien.Enabled = true;
                        btnNhapGiaoVien.Enabled = true;
                        btnNhapDe.Enabled = true;
                        btnChuanBiThi.Enabled = true;

                        btnKetQua.Enabled = true;
                        btnBangDiem.Enabled = true;
                        btnDanhSachDangKy.Enabled = true;
                        break;
                    case DatabaseRole.GIANGVIEN:
                        btnNhapDe.Enabled = true;
                        btnChuanBiThi.Enabled = true;
                        btnBangDiem.Enabled = true;
                        break;
                    case DatabaseRole.SINHVIEN:
                        btnThi.Enabled = true;
                        btnKetQua.Enabled = true;
                        break;
                    default:
                        break;
                }

                this.Text = "Ứng dụng Thi Trắc Nghiệm - Nhóm: " + SystemInfo.Role.ToString();
            }
            else
            {
                mnLogin.Enabled = true;
                mnLogout.Enabled = false;
                lblFooter.Text = "Chưa đăng nhập";
                this.Text = "Ứng dụng Thi Trắc Nghiệm";
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            RefreshScreenStatus();
            StartLoginForm();
        }



        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {

        }



        private void Login_LoginSucceeded(object sender, EventArgs e)
        {
            RefreshScreenStatus();
        }

        #region DanhMuc
        private void mnLogin_Click(object sender, EventArgs e)
        {
            StartLoginForm();
        }

        private void mnLogout_Click(object sender, EventArgs e)
        {
            SystemInfo.Reset();
            StartLoginForm();
        }

        private void StartLoginForm()
        {
            var login = new frmLogin
            {
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                WindowState = FormWindowState.Maximized

            };
            login.ShowDialog(this);
            RefreshScreenStatus();
        }


        private void mnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region ChucNang
        private void btnThi_Click(object sender, EventArgs e)
        {
            StartChonMonThiForm();
        }

        private void StartChonMonThiForm()
        {
            // Đảm bảo form cha là MDI Container
            this.IsMdiContainer = true;

            // 1. Tìm xem form con đã mở chưa
            foreach (var child in this.MdiChildren)
            {
                if (child is frmChonMonThi)
                {
                    // Nếu tìm thấy: Đóng form cũ lại
                    child.Close();
                    // child.Dispose(); // Close() tự động Dispose form con, nhưng gọi thêm cũng không sao
                    break; // Thoát vòng lặp sau khi đóng
                }
            }

            // 2. Luôn khởi tạo instance mới và hiển thị
            var chonMonThi = new frmChonMonThi
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterParent,
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.Sizable
            };

            chonMonThi.Show();
        }

        #endregion
    }
}