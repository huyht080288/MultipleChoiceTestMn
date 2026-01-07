using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace THITN.Core
{
    /// <summary>
    /// Lớp tĩnh (static) quản lý kết nối CSDL và thực thi truy vấn
    /// </summary>
    public static class Database
    {
        // --- KHAI BÁO CÁC BIẾN TĨNH ---
        // Biến này sẽ giữ kết nối CSDL trong suốt quá trình chạy
        public static SqlConnection connection = new SqlConnection();
        // Biến lưu chuỗi kết nối hiện tại
        public static string connectionString = "";

        // --- CÁC PHƯƠ...NG THỨC ---

        /// <summary>
        /// Mở kết nối đến CSDL
        /// </summary>
        /// <param name="serverName">Tên server (lấy từ ComboBox)</param>
        /// <param name="login">Tài khoản (SQL Login hoặc SV Login)</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public static bool Connect(string serverName, string login, string password)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close(); // Đóng kết nối cũ nếu có
            }

            try
            {
                // Cấu hình chuỗi kết nối dựa trên thông tin đăng nhập
                connectionString = $"Data Source={serverName};Initial Catalog=THITN;User ID={login};Password={password}";
                connection.ConnectionString = connectionString;

                connection.Open();
                return true; // Kết nối thành công
            }
            catch (SqlException ex)
            {
                //MessageBox.Show("Lỗi kết nối CSDL.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Kết nối thất bại
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi không xác định khi kết nối CSDL.\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Kết nối thất bại
            }
        }

        /// <summary>
        /// Đóng kết nối CSDL
        /// </summary>
        public static void Disconnect()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connectionString = ""; // Xóa chuỗi kết nối
            }
        }

        /// <summary>
        /// Thực thi một Stored Procedure hoặc câu lệnh SQL và trả về một SqlDataReader.
        /// (Dùng cho SELECT)
        /// </summary>
        public static SqlDataReader ExecuteReader(string commandText, CommandType type = CommandType.StoredProcedure, params SqlParameter[] parameters)
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Chưa kết nối CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            try
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = type;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                SqlDataReader reader = command.ExecuteReader();
                return reader; // CHÚ Ý: Cần .Close() reader này sau khi sử dụng xong
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi truy vấn:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Thực thi một Stored Procedure hoặc câu lệnh SQL (INSERT, UPDATE, DELETE)
        /// </summary>
        public static int ExecuteNonQuery(string commandText, CommandType type = CommandType.StoredProcedure, params SqlParameter[] parameters)
        {
            if (connection == null || connection.State != ConnectionState.Open)
            {
                MessageBox.Show("Chưa kết nối CSDL!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            try
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = type;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi lệnh:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
    }
}

