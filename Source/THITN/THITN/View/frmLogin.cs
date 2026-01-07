using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using THITN.DAO; // Thư viện này không còn cần ở đây nữa
using THITN.Controllers; // Sẽ dùng khi bạn tạo Controller
using THITN.Core; // Sẽ dùng để truy cập Session
using THITN.Models;
using THITN.Helper; // Thêm thư viện Models

namespace THITN.Views
{
    public partial class frmLogin : Form
    {
        // 1. Tạo một thể hiện (instance) của LoginController
        private LoginController controller;
        public event EventHandler LoginSucceeded;
        public event EventHandler ExitRequested;
        public frmLogin()
        {
            InitializeComponent();
            // 2. Khởi tạo Controller
            controller = new LoginController();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            CenterPanel();
            // --- Tải dữ liệu cho ComboBox Cơ sở ---

            // 3. View gọi Controller để lấy dữ liệu
            List<Coso> coSoList = controller.LoadCoSoList();

            if (coSoList == null)
            {
                MessageBox.Show("Không thể tải danh sách cơ sở. Vui lòng liên hệ quản trị viên.", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            // 4. Gán List Model làm nguồn dữ liệu cho ComboBox
            cmbCoSo.DataSource = coSoList;
            cmbCoSo.DisplayMember = "TENCS";     // Hiển thị tên (ví dụ: "Cơ sở 1")
            cmbCoSo.ValueMember = "SERVER_NAME"; // Giá trị ẩn (ví dụ: "MAYCHU_CS1")

            cmbCoSo.SelectedIndex = 0;
            //rbGiangVien.Checked = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // --- 1. THU THẬP DỮ LIỆU TỪ VIEW ---
            int coSoIndex = cmbCoSo.SelectedIndex;
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            bool isSinhVien = rbSinhVien.Checked;

            // Lấy tên server thật từ ValueMember của ComboBox
            string serverName = cmbCoSo.SelectedValue.ToString();

            // --- 2. VALIDATE DỮ LIỆU ---
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Tài khoản không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLogin.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            SystemInfo.DB.ServerName = serverName;


            controller.HandleLogin(serverName, login, password, isSinhVien);

            if (SystemInfo.IsLoggedIn)
            {
                LoginSucceeded?.Invoke(this, EventArgs.Empty);
                this.Close();   
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            CenterPanel();
        }
        private void CenterPanel()
        {
            // Center trong client area của form
            int x = (this.ClientSize.Width - panel1.Width) / 2;
            int y = (this.ClientSize.Height - panel1.Height) / 2;
            panel1.Left = Math.Max(0, x);
            panel1.Top = Math.Max(0, y);
        }
    }
}

