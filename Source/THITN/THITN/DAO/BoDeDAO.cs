using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using THITN.Core;
using THITN.Models;

namespace THITN.DAO
{
    public class BoDeDAO
    {
        /// <summary>
        /// Lấy danh sách đề (BoDe) theo MALOP, MAMH, TRINHDO và SOCAUTHI
        /// Gọi stored procedure: SP_GetBoDeTheoMaLopMaMHTrinhDoSoCau
        /// </summary>
        public List<BoDe> GetBoDe(string maLop, string maMH, string trinhDo, int soCauThi)
        {
            var list = new List<BoDe>();

            SqlDataReader reader = Database.ExecuteReader(
                "SP_GetBoDeTheoMaLopMaMHTrinhDoSoCau",
                CommandType.StoredProcedure,
                new SqlParameter("@MALOP", maLop ?? (object)DBNull.Value),
                new SqlParameter("@MAMH", maMH ?? (object)DBNull.Value),
                new SqlParameter("@TRINHDO", trinhDo ?? (object)DBNull.Value),
                new SqlParameter("@SOCAUTHI", soCauThi)
            );

            if (reader == null)
                return list;

            try
            {
                while (reader.Read())
                {
                    var bd = new BoDe
                    {
                        STT = reader["STT"] != DBNull.Value ? Convert.ToInt32(reader["STT"]) : 0,
                        CAUHOI = reader["CAUHOI"] != DBNull.Value ? Convert.ToInt32(reader["CAUHOI"]) : 0,
                        MAMH = reader["MAMH"] != DBNull.Value ? reader["MAMH"].ToString().Trim() : null,
                        TRINHDO = reader["TRINHDO"] != DBNull.Value ? reader["TRINHDO"].ToString().Trim() : null,
                        NOIDUNG = reader["NOIDUNG"] != DBNull.Value ? reader["NOIDUNG"].ToString() : null,
                        A = reader["A"] != DBNull.Value ? reader["A"].ToString() : null,
                        B = reader["B"] != DBNull.Value ? reader["B"].ToString() : null,
                        C = reader["C"] != DBNull.Value ? reader["C"].ToString() : null,
                        D = reader["D"] != DBNull.Value ? reader["D"].ToString() : null,
                        DAPAN = reader["DAPAN"] != DBNull.Value ? reader["DAPAN"].ToString().Trim() : null,
                        MAGV = reader["MAGV"] != DBNull.Value ? reader["MAGV"].ToString().Trim() : null
                    };

                    list.Add(bd);
                }
            }
            finally
            {
                reader.Close();
            }

            return list;
        }

        public static List<BoDe> GetBoDeByMaGV(string maGV)
        {
            List<BoDe> list = new List<BoDe>();
            string query = "SELECT CAUHOI, MAMH, TRINHDO, NOIDUNG, A, B, C, D, DAPAN, MAGV FROM BODE WHERE MAGV = @MAGV";

            SqlParameter pMaGV = new SqlParameter("@MAGV", SqlDbType.NChar, 8) { Value = maGV };
            SqlDataReader reader = Database.ExecuteReader(query, CommandType.Text, pMaGV);

            if (reader != null)
            {
                try
                {
                    while (reader.Read())
                    {
                        BoDe bd = new BoDe();
                        bd.CAUHOI = Convert.ToInt32(reader["CAUHOI"]);
                        bd.MAMH = reader["MAMH"].ToString().Trim();
                        bd.TRINHDO = reader["TRINHDO"].ToString().Trim();
                        bd.NOIDUNG = reader["NOIDUNG"].ToString();
                        bd.A = reader["A"].ToString();
                        bd.B = reader["B"].ToString();

                        if (!reader.IsDBNull(reader.GetOrdinal("C")))
                            bd.C = reader["C"].ToString();

                        if (!reader.IsDBNull(reader.GetOrdinal("D")))
                            bd.D = reader["D"].ToString();

                        if (!reader.IsDBNull(reader.GetOrdinal("DAPAN")))
                            bd.DAPAN = reader["DAPAN"].ToString().Trim();

                        bd.MAGV = reader["MAGV"].ToString().Trim();
                        list.Add(bd);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return list;
        }

        public static bool Insert(BoDe bd)
        {
            string query = @"INSERT INTO BODE (MAMH, TRINHDO, NOIDUNG, A, B, C, D, DAPAN, MAGV) 
                             VALUES (@MAMH, @TRINHDO, @NOIDUNG, @A, @B, @C, @D, @DAPAN, @MAGV)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MAMH", SqlDbType.NChar, 5) { Value = bd.MAMH },
                new SqlParameter("@TRINHDO", SqlDbType.NChar, 1) { Value = bd.TRINHDO },
                new SqlParameter("@NOIDUNG", SqlDbType.NText) { Value = bd.NOIDUNG },
                new SqlParameter("@A", SqlDbType.NText) { Value = bd.A },
                new SqlParameter("@B", SqlDbType.NText) { Value = bd.B },
                new SqlParameter("@C", SqlDbType.NText) { Value = string.IsNullOrEmpty(bd.C) ? (object)DBNull.Value : bd.C },
                new SqlParameter("@D", SqlDbType.NText) { Value = string.IsNullOrEmpty(bd.D) ? (object)DBNull.Value : bd.D },
                new SqlParameter("@DAPAN", SqlDbType.NChar, 1) { Value = bd.DAPAN },
                new SqlParameter("@MAGV", SqlDbType.NChar, 8) { Value = bd.MAGV }
            };

            // CAUHOI là IDENTITY tự tăng, không cần Insert. rowguid do Replication tự sinh.
            return Database.ExecuteNonQuery(query, CommandType.Text, parameters) > 0;
        }

        public static bool Update(BoDe bd)
        {
            string query = @"UPDATE BODE 
                             SET MAMH = @MAMH, TRINHDO = @TRINHDO, NOIDUNG = @NOIDUNG, 
                                 A = @A, B = @B, C = @C, D = @D, DAPAN = @DAPAN
                             WHERE CAUHOI = @CAUHOI AND MAGV = @MAGV";
            // Thêm AND MAGV = @MAGV để đảm bảo an toàn, không ai update chéo đề của người khác được

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CAUHOI", SqlDbType.Int) { Value = bd.CAUHOI },
                new SqlParameter("@MAMH", SqlDbType.NChar, 5) { Value = bd.MAMH },
                new SqlParameter("@TRINHDO", SqlDbType.NChar, 1) { Value = bd.TRINHDO },
                new SqlParameter("@NOIDUNG", SqlDbType.NText) { Value = bd.NOIDUNG },
                new SqlParameter("@A", SqlDbType.NText) { Value = bd.A },
                new SqlParameter("@B", SqlDbType.NText) { Value = bd.B },
                new SqlParameter("@C", SqlDbType.NText) { Value = string.IsNullOrEmpty(bd.C) ? (object)DBNull.Value : bd.C },
                new SqlParameter("@D", SqlDbType.NText) { Value = string.IsNullOrEmpty(bd.D) ? (object)DBNull.Value : bd.D },
                new SqlParameter("@DAPAN", SqlDbType.NChar, 1) { Value = bd.DAPAN },
                new SqlParameter("@MAGV", SqlDbType.NChar, 8) { Value = bd.MAGV }
            };

            return Database.ExecuteNonQuery(query, CommandType.Text, parameters) > 0;
        }

        public static bool Delete(int cauHoi, string maGV)
        {
            string query = "DELETE FROM BODE WHERE CAUHOI = @CAUHOI AND MAGV = @MAGV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CAUHOI", SqlDbType.Int) { Value = cauHoi },
                new SqlParameter("@MAGV", SqlDbType.NChar, 8) { Value = maGV }
            };

            return Database.ExecuteNonQuery(query, CommandType.Text, parameters) > 0;
        }

        /// <summary>
        /// Xử lý lưu hàng loạt (Batch Save) sử dụng Transaction để đảm bảo tính toàn vẹn (Atomicity)
        /// Nếu có lỗi, toàn bộ thao tác Thêm/Sửa/Xóa đều bị Rollback.
        /// </summary>
        public static bool SaveBatch(List<BoDe> lstThem, List<BoDe> lstSua, List<int> lstXoa, string maGV)
        {
            // Kiểm tra trạng thái kết nối từ lớp Database Core
            if (Database.connection == null || Database.connection.State != ConnectionState.Open)
            {
                throw new Exception("Chưa kết nối CSDL!");
            }

            // Mở Transaction (Giao tác)
            using (SqlTransaction trans = Database.connection.BeginTransaction())
            {
                try
                {
                    // 1. Thực hiện XÓA
                    if (lstXoa != null && lstXoa.Count > 0)
                    {
                        string queryXoa = "DELETE FROM BODE WHERE CAUHOI = @CAUHOI AND MAGV = @MAGV";
                        foreach (int idCauHoi in lstXoa)
                        {
                            using (SqlCommand cmd = new SqlCommand(queryXoa, Database.connection, trans))
                            {
                                cmd.Parameters.AddWithValue("@CAUHOI", idCauHoi);
                                cmd.Parameters.AddWithValue("@MAGV", maGV);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // 2. Thực hiện THÊM MỚI
                    if (lstThem != null && lstThem.Count > 0)
                    {
                        string queryThem = @"INSERT INTO BODE (MAMH, TRINHDO, NOIDUNG, A, B, C, D, DAPAN, MAGV) 
                                             VALUES (@MAMH, @TRINHDO, @NOIDUNG, @A, @B, @C, @D, @DAPAN, @MAGV)";
                        foreach (BoDe bd in lstThem)
                        {
                            using (SqlCommand cmd = new SqlCommand(queryThem, Database.connection, trans))
                            {
                                cmd.Parameters.AddWithValue("@MAMH", bd.MAMH);
                                cmd.Parameters.AddWithValue("@TRINHDO", bd.TRINHDO);
                                cmd.Parameters.AddWithValue("@NOIDUNG", bd.NOIDUNG);
                                cmd.Parameters.AddWithValue("@A", bd.A);
                                cmd.Parameters.AddWithValue("@B", bd.B);
                                cmd.Parameters.AddWithValue("@C", string.IsNullOrEmpty(bd.C) ? (object)DBNull.Value : bd.C);
                                cmd.Parameters.AddWithValue("@D", string.IsNullOrEmpty(bd.D) ? (object)DBNull.Value : bd.D);
                                cmd.Parameters.AddWithValue("@DAPAN", bd.DAPAN);
                                cmd.Parameters.AddWithValue("@MAGV", maGV); // Ép cứng mã GV đăng nhập
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // 3. Thực hiện CẬP NHẬT (SỬA)
                    if (lstSua != null && lstSua.Count > 0)
                    {
                        string querySua = @"UPDATE BODE 
                                            SET MAMH = @MAMH, TRINHDO = @TRINHDO, NOIDUNG = @NOIDUNG, 
                                                A = @A, B = @B, C = @C, D = @D, DAPAN = @DAPAN
                                            WHERE CAUHOI = @CAUHOI AND MAGV = @MAGV";
                        foreach (BoDe bd in lstSua)
                        {
                            using (SqlCommand cmd = new SqlCommand(querySua, Database.connection, trans))
                            {
                                cmd.Parameters.AddWithValue("@CAUHOI", bd.CAUHOI);
                                cmd.Parameters.AddWithValue("@MAMH", bd.MAMH);
                                cmd.Parameters.AddWithValue("@TRINHDO", bd.TRINHDO);
                                cmd.Parameters.AddWithValue("@NOIDUNG", bd.NOIDUNG);
                                cmd.Parameters.AddWithValue("@A", bd.A);
                                cmd.Parameters.AddWithValue("@B", bd.B);
                                cmd.Parameters.AddWithValue("@C", string.IsNullOrEmpty(bd.C) ? (object)DBNull.Value : bd.C);
                                cmd.Parameters.AddWithValue("@D", string.IsNullOrEmpty(bd.D) ? (object)DBNull.Value : bd.D);
                                cmd.Parameters.AddWithValue("@DAPAN", bd.DAPAN);
                                cmd.Parameters.AddWithValue("@MAGV", maGV);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // Nếu tất cả các lệnh Thêm/Sửa/Xóa đều chạy suôn sẻ -> Chốt thay đổi xuống DB
                    trans.Commit();
                    return true;
                }
                catch (Exception)
                {
                    // Nếu dính lỗi ở bất kỳ bước nào (ví dụ câu hỏi chứa ký tự lạ, rớt mạng...)
                    // -> Hủy toàn bộ tiến trình, DB trở về trạng thái y hệt trước khi bấm Ghi
                    trans.Rollback();
                    throw; // Đẩy lỗi ra ngoài để Controller/UI bắt và show thông báo
                }
            }
        }
    }
}
