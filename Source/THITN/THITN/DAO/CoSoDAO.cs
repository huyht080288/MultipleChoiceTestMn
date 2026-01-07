using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using THITN.Models; // Thêm Model CoSo
using System.Collections.Generic; // Thêm thư viện List

namespace THITN.DAO
{
    public class CosoDAO
    {
        /// <summary>
        /// Lấy danh sách cơ sở từ Server tra cứu (Server 3)
        /// </summary>
        /// <returns>List các đối tượng CoSo</returns>
        public static List<Coso> GetDanhSachCoSo()
        {
            List<Coso> coSoList = new List<Coso>(); // 1. Tạo List
            string connString = ConfigurationManager.ConnectionStrings["db.cs0"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    // Gọi Stored Procedure SP_GetDanhSachCoSo
                    SqlCommand command = new SqlCommand("SP_GetDanhSachCoSo", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // 2. Dùng SqlDataReader thay vì SqlDataAdapter
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // 3. Tạo đối tượng CoSo từ dữ liệu đọc được
                        Coso cs = new Coso
                        {
                            TENCS = reader["TENCS"].ToString(),
                            SERVER_NAME = reader["SERVER_NAME"].ToString()
                        };
                        coSoList.Add(cs); // 4. Add vào List
                    }
                    reader.Close();
                }
                catch
                {
                    return null; // Trả về null nếu có lỗi
                }
            }
            return coSoList; // 5. Trả về List Model
        }
    }
}

