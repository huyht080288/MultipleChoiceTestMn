using System.Collections.Generic;
using THITN.DAO;
using THITN.Models;
using THITN.Core; // Để sử dụng Core.Database và Core.Session
using System.Data.SqlClient;
using System.Data;

namespace THITN.Controllers
{
    /// <summary>
    /// Controller xử lý tất cả logic nghiệp vụ cho Form Đăng nhập
    /// </summary>
    public class LoginController
    {
        /// <summary>
        /// Lấy danh sách cơ sở để View hiển thị lên ComboBox
        /// </summary>
        /// <returns>Danh sách các đối tượng CoSo</returns>
        public List<Coso> LoadCoSoList()
        {
            // Controller gọi DAO
            return CosoDAO.GetDanhSachCoSo();
        }

        /// <summary>
        /// Xử lý logic đăng nhập chính
        /// </summary>
        public bool HandleLogin(string serverName, string login, string password, bool isSinhVien)
        {
            if (isSinhVien)
            {
                // 1. LÀ SINH VIÊN: Xác thực bằng Bảng SinhVien
                // Sinh viên phải kết nối bằng tài khoản tra cứu (Server 3)
                string lookupConnString = System.Configuration.ConfigurationManager.ConnectionStrings["THITN.Properties.Settings.Server0ConnectionString"].ConnectionString;

                // TODO: Tạo SinhVienDAO để kiểm tra
                // bool svHopLe = SinhVienDAO.CheckLogin(lookupConnString, login, password);
                bool svHopLe = true; // Giả sử SV hợp lệ (Cần code DAO)

                if (svHopLe)
                {
                    // Xác thực thành công.
                    // Bây giờ, kết nối CSDL bằng tài khoản DÙNG CHUNG của SinhVien
                    // (Lấy từ 1 file config hoặc hard-code)
                    string svLogin = "LOGIN_SV_CHUNG";
                    string svPass = "abc@123"; // Mật khẩu của tài khoản SQL chung

                    if (Database.Connect(serverName, svLogin, svPass))
                    {
                        // Lấy thông tin SV (Họ tên, Lớp)
                        // TODO: Gọi SinhVienDAO.GetInfo(login)
                        Session.Username = login; // MASV
                        Session.FullName = "Nguyễn Văn A (Fake)"; // Lấy từ DB
                        Session.UserRole = "SINHVIEN";
                        return true;
                    }
                }
            }
            else
            {
                // 2. LÀ GIẢNG VIÊN / COSO / TRUONG: Xác thực bằng SQL Login
                if (Database.Connect(serverName, login, password))
                {
                    // Đăng nhập thành công, lấy thông tin Role và HoTen
                    SqlDataReader reader = Database.ExecuteReader("SP_LayThongTinGiaoVienTuLogin");
                    if (reader.Read())
                    {
                        Session.Username = login;
                        Session.FullName = reader["HOTEN"].ToString();
                        Session.UserRole = reader["ROLE"].ToString();
                        reader.Close();
                        return true;
                    }
                    reader.Close();
                }
            }

            // Nếu mọi thứ thất bại
            Database.Disconnect();
            return false;
        }
    }
}
