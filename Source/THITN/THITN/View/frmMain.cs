using System;
using System.Threading;
using System.Windows.Forms;
using THITN.Views;
using THITN.Helper;

namespace THITN.View
{
    public partial class frmMain : Form
    {


        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
            this.FormClosing += FrmMain_FormClosing;
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
                this.Text = "Ứng dụng Thi Trắc Nghiệm - Role: " + SystemInfo.Role.ToString();
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


        private void mnLogout_Click(object sender, EventArgs e)
        {
            SystemInfo.Reset();
            StartLoginForm();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void mnLogin_Click(object sender, EventArgs e)
        {
            StartLoginForm();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {

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


        private void Login_LoginSucceeded(object sender, EventArgs e)
        {
            RefreshScreenStatus();
        }

        private void mnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}