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
using THITN.Models; // Thêm thư viện Models

namespace THITN.Views
{
    public partial class frmLogin : Form
    {
        // 1. Tạo một thể hiện (instance) của LoginController
        private LoginController controller;

        public frmLogin()
        {
            InitializeComponent();
            // 2. Khởi tạo Controller
            controller = new LoginController();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
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

            cmbCoSo.SelectedIndex = 0; // Chọn CS1 làm mặc định
            rbGiangVien.Checked = true; // Chọn vai trò Giảng viên làm mặc định
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Đóng toàn bộ ứng dụng
            Application.Exit();
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

            // --- 3. GỌI CONTROLLER XỬ LÝ ---
            // Bỏ comment đoạn code này

            // LoginController controller = new LoginController(); // Đã khởi tạo ở constructor
            bool loginSuccess = controller.HandleLogin(serverName, login, password, isSinhVien);

            if (loginSuccess)
            {
                // Đăng nhập thành công, mở Form Main
                // TODO: Bạn cần tạo frmMain
                // frmMain f = new frmMain();
                // f.Show();
                MessageBox.Show("Đăng nhập thành công! (Form Main chưa được tạo)");
                // this.Hide(); // Ẩn form đăng nhập
            }
            else
            {
                // Controller đã xử lý và thông báo lỗi
                MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*
            // --- XÓA DÒNG NÀY KHI CÓ CONTROLLER ---
            MessageBox.Show("Đang chờ xử lý logic đăng nhập...\n" +
                            $"ServerName: {serverName}\nLogin: {login}\nSinhVien: {isSinhVien}");
            // --- HẾT PHẦN XÓA ---
            */
        }
    }
}

