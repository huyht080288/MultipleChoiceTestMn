using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using THITN.Controllers;
using THITN.Core; // Import namespace chứa lớp Database
using THITN.Helper;
using THITN.Models;

namespace THITN.DAO
{
    public class GiaoVien_DangkyDAO
    {
        public static List<GiaoVien_DangKy> GetAllGiaoVienDangKy()
        {
            var list = new List<GiaoVien_DangKy>();

            using (var conn = new SqlConnection(SystemInfo.DB.ConnectionString))
            using (var cmd = new SqlCommand("SP_GetAllGiaoVienDangKy", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    // Helper local function để kiểm tra tồn tại cột
                    bool HasColumn(IDataRecord r, string name)
                    {
                        for (int i = 0; i < r.FieldCount; i++)
                            if (string.Equals(r.GetName(i), name, StringComparison.OrdinalIgnoreCase))
                                return true;
                        return false;
                    }

                    while (reader.Read())
                    {
                        var mh = new GiaoVien_DangKy();

                        if (HasColumn(reader, "MAGV") && !reader.IsDBNull(reader.GetOrdinal("MAGV")))
                        {
                            mh.MAGV = reader["MAGV"].ToString().Trim();
                        }

                        if (HasColumn(reader, "MALOP") && !reader.IsDBNull(reader.GetOrdinal("MALOP")))
                        {
                            mh.MALOP = reader["MALOP"].ToString().Trim();
                        }

                        if (HasColumn(reader, "MAMH") && !reader.IsDBNull(reader.GetOrdinal("MAMH")))
                        {
                            mh.MAMH = reader["MAMH"].ToString().Trim();
                        }

                        if (HasColumn(reader, "TRINHDO") && !reader.IsDBNull(reader.GetOrdinal("TRINHDO")))
                        {
                            mh.TRINHDO = reader["TRINHDO"].ToString().Trim();
                        }

                        if (HasColumn(reader, "NGAYTHI") && !reader.IsDBNull(reader.GetOrdinal("NGAYTHI")))
                        {
                            // Prefer GetDateTime if possible
                            try
                            {
                                mh.NGAYTHI = reader.GetDateTime(reader.GetOrdinal("NGAYTHI"));
                            }
                            catch
                            {
                                mh.NGAYTHI = Convert.ToDateTime(reader["NGAYTHI"]);
                            }
                        }

                        if (HasColumn(reader, "LAN") && !reader.IsDBNull(reader.GetOrdinal("LAN")))
                        {
                            try
                            {
                                mh.LAN = reader.GetInt16(reader.GetOrdinal("LAN"));
                            }
                            catch
                            {
                                mh.LAN = Convert.ToInt16(reader["LAN"]);
                            }
                        }

                        if (HasColumn(reader, "SOCAUTHI") && !reader.IsDBNull(reader.GetOrdinal("SOCAUTHI")))
                        {
                            try
                            {
                                mh.SOCAUTHI = reader.GetInt16(reader.GetOrdinal("SOCAUTHI"));
                            }
                            catch
                            {
                                mh.SOCAUTHI = Convert.ToInt16(reader["SOCAUTHI"]);
                            }
                        }

                        if (HasColumn(reader, "THOIGIAN") && !reader.IsDBNull(reader.GetOrdinal("THOIGIAN")))
                        {
                            try
                            {
                                mh.THOIGIAN = reader.GetInt16(reader.GetOrdinal("THOIGIAN"));
                            }
                            catch
                            {
                                mh.THOIGIAN = Convert.ToInt16(reader["THOIGIAN"]);
                            }
                        }

                        if (HasColumn(reader, "RowGuid") && !reader.IsDBNull(reader.GetOrdinal("RowGuid")))
                        {
                            try
                            {
                                mh.RowGuid = reader.GetGuid(reader.GetOrdinal("RowGuid"));
                            }
                            catch
                            {
                                mh.RowGuid = Guid.Parse(reader["RowGuid"].ToString());
                            }
                        }

                        list.Add(mh);
                    }
                }
            }

            return list;
        }

        public static GiaoVien_DangKy GetDangKy(string strMaLop, string strMaMH, short sLan)
        {
            using (var conn = new SqlConnection(SystemInfo.DB.ConnectionString))
            using (var cmd = new SqlCommand("SP_GetGiaoVienDangKy", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MALOP", SqlDbType.NChar, 8) { Value = strMaLop });
                cmd.Parameters.Add(new SqlParameter("@MAMH", SqlDbType.NChar, 5) { Value = strMaMH });
                cmd.Parameters.Add(new SqlParameter("@LAN", SqlDbType.SmallInt) { Value = sLan });
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    // Helper local function để kiểm tra tồn tại cột
                    bool HasColumn(IDataRecord r, string name)
                    {
                        for (int i = 0; i < r.FieldCount; i++)
                            if (string.Equals(r.GetName(i), name, StringComparison.OrdinalIgnoreCase))
                                return true;
                        return false;
                    }
                    if (!reader.Read())
                        return null;


                    var dk = new GiaoVien_DangKy();

                    if (HasColumn(reader, "MAGV") && !reader.IsDBNull(reader.GetOrdinal("MAGV")))
                    {
                        dk.MAGV = reader["MAGV"].ToString().Trim();
                    }

                    if (HasColumn(reader, "MALOP") && !reader.IsDBNull(reader.GetOrdinal("MALOP")))
                    {
                        dk.MALOP = reader["MALOP"].ToString().Trim();
                    }

                    if (HasColumn(reader, "MAMH") && !reader.IsDBNull(reader.GetOrdinal("MAMH")))
                    {
                        dk.MAMH = reader["MAMH"].ToString().Trim();
                    }

                    if (HasColumn(reader, "TRINHDO") && !reader.IsDBNull(reader.GetOrdinal("TRINHDO")))
                    {
                        dk.TRINHDO = reader["TRINHDO"].ToString().Trim();
                    }

                    if (HasColumn(reader, "NGAYTHI") && !reader.IsDBNull(reader.GetOrdinal("NGAYTHI")))
                    {
                        // Prefer GetDateTime if possible
                        try
                        {
                            dk.NGAYTHI = reader.GetDateTime(reader.GetOrdinal("NGAYTHI"));
                        }
                        catch
                        {
                            dk.NGAYTHI = Convert.ToDateTime(reader["NGAYTHI"]);
                        }
                    }

                    if (HasColumn(reader, "LAN") && !reader.IsDBNull(reader.GetOrdinal("LAN")))
                    {
                        try
                        {
                            dk.LAN = reader.GetInt16(reader.GetOrdinal("LAN"));
                        }
                        catch
                        {
                            dk.LAN = Convert.ToInt16(reader["LAN"]);
                        }
                    }

                    if (HasColumn(reader, "SOCAUTHI") && !reader.IsDBNull(reader.GetOrdinal("SOCAUTHI")))
                    {
                        try
                        {
                            dk.SOCAUTHI = reader.GetInt16(reader.GetOrdinal("SOCAUTHI"));
                        }
                        catch
                        {
                            dk.SOCAUTHI = Convert.ToInt16(reader["SOCAUTHI"]);
                        }
                    }

                    if (HasColumn(reader, "THOIGIAN") && !reader.IsDBNull(reader.GetOrdinal("THOIGIAN")))
                    {
                        try
                        {
                            dk.THOIGIAN = reader.GetInt16(reader.GetOrdinal("THOIGIAN"));
                        }
                        catch
                        {
                            dk.THOIGIAN = Convert.ToInt16(reader["THOIGIAN"]);
                        }
                    }

                    if (HasColumn(reader, "RowGuid") && !reader.IsDBNull(reader.GetOrdinal("RowGuid")))
                    {
                        try
                        {
                            dk.RowGuid = reader.GetGuid(reader.GetOrdinal("RowGuid"));
                        }
                        catch
                        {
                            dk.RowGuid = Guid.Parse(reader["RowGuid"].ToString());
                        }
                    }

                    return dk;
                }
            }
            return null;
        }


        // =====================================================================
        // CÁC HÀM BỔ SUNG MỚI (INSERT, UPDATE, DELETE, GET, CHECK)
        // =====================================================================

        public static bool Insert(GiaoVien_DangKy gvdk)
        {
            return Database.ExecuteNonQuery(
                "SP_InsertGiaoVienDangKy",
                CommandType.StoredProcedure,
                new SqlParameter("@MAGV", SqlDbType.NChar, 8) { Value = gvdk.MAGV },
                new SqlParameter("@MALOP", SqlDbType.NChar, 8) { Value = gvdk.MALOP },
                new SqlParameter("@MAMH", SqlDbType.NChar, 5) { Value = gvdk.MAMH },
                new SqlParameter("@TRINHDO", SqlDbType.NChar, 1) { Value = gvdk.TRINHDO },
                new SqlParameter("@NGAYTHI", SqlDbType.DateTime) { Value = gvdk.NGAYTHI },
                new SqlParameter("@LAN", SqlDbType.SmallInt) { Value = gvdk.LAN },
                new SqlParameter("@SOCAUTHI", SqlDbType.SmallInt) { Value = gvdk.SOCAUTHI },
                new SqlParameter("@THOIGIAN", SqlDbType.SmallInt) { Value = gvdk.THOIGIAN }) > 0;
        }

        public static bool Update(GiaoVien_DangKy gvdk)
        {
            return Database.ExecuteNonQuery(
                "SP_UpdateGiaoVienDangKy",
                CommandType.StoredProcedure,
                new SqlParameter("@MAGV", SqlDbType.NChar, 8) { Value = gvdk.MAGV },
                new SqlParameter("@MALOP", SqlDbType.NChar, 8) { Value = gvdk.MALOP },
                new SqlParameter("@MAMH", SqlDbType.NChar, 5) { Value = gvdk.MAMH },
                new SqlParameter("@TRINHDO", SqlDbType.NChar, 1) { Value = gvdk.TRINHDO },
                new SqlParameter("@NGAYTHI", SqlDbType.DateTime) { Value = gvdk.NGAYTHI },
                new SqlParameter("@LAN", SqlDbType.SmallInt) { Value = gvdk.LAN },
                new SqlParameter("@SOCAUTHI", SqlDbType.SmallInt) { Value = gvdk.SOCAUTHI },
                new SqlParameter("@THOIGIAN", SqlDbType.SmallInt) { Value = gvdk.THOIGIAN }) > 0;
        }

        public static bool Delete(string maLop, string maMH, short lan)
        {
            return Database.ExecuteNonQuery(
                "SP_DeleteGiaoVienDangKy",
                CommandType.StoredProcedure,
                new SqlParameter("@MALOP", SqlDbType.NChar, 8) { Value = maLop },
                new SqlParameter("@MAMH", SqlDbType.NChar, 5) { Value = maMH },
                new SqlParameter("@LAN", SqlDbType.SmallInt) { Value = lan }) > 0;
        }

        public static List<GiaoVien_DangKy> GetByMaGV(string maGV)
        {
            List<GiaoVien_DangKy> list = new List<GiaoVien_DangKy>();

            SqlParameter pMaGV = new SqlParameter("@MAGV", SqlDbType.NChar, 8) { Value = maGV };
            SqlDataReader reader = Database.ExecuteReader("SP_GetGiaoVienDangKyTheoMaGV", CommandType.StoredProcedure, pMaGV);

            if (reader != null)
            {
                try
                {
                    // Helper local function để kiểm tra tồn tại cột
                    bool HasColumn(IDataRecord r, string name)
                    {
                        for (int i = 0; i < r.FieldCount; i++)
                            if (string.Equals(r.GetName(i), name, StringComparison.OrdinalIgnoreCase))
                                return true;
                        return false;
                    }

                    while (reader.Read())
                    {
                        var mh = new GiaoVien_DangKy();

                        if (HasColumn(reader, "MAGV") && !reader.IsDBNull(reader.GetOrdinal("MAGV")))
                            mh.MAGV = reader["MAGV"].ToString().Trim();

                        if (HasColumn(reader, "MALOP") && !reader.IsDBNull(reader.GetOrdinal("MALOP")))
                            mh.MALOP = reader["MALOP"].ToString().Trim();

                        if (HasColumn(reader, "MAMH") && !reader.IsDBNull(reader.GetOrdinal("MAMH")))
                            mh.MAMH = reader["MAMH"].ToString().Trim();

                        if (HasColumn(reader, "TRINHDO") && !reader.IsDBNull(reader.GetOrdinal("TRINHDO")))
                            mh.TRINHDO = reader["TRINHDO"].ToString().Trim();

                        if (HasColumn(reader, "NGAYTHI") && !reader.IsDBNull(reader.GetOrdinal("NGAYTHI")))
                        {
                            try { mh.NGAYTHI = reader.GetDateTime(reader.GetOrdinal("NGAYTHI")); }
                            catch { mh.NGAYTHI = Convert.ToDateTime(reader["NGAYTHI"]); }
                        }

                        if (HasColumn(reader, "LAN") && !reader.IsDBNull(reader.GetOrdinal("LAN")))
                        {
                            try { mh.LAN = reader.GetInt16(reader.GetOrdinal("LAN")); }
                            catch { mh.LAN = Convert.ToInt16(reader["LAN"]); }
                        }

                        if (HasColumn(reader, "SOCAUTHI") && !reader.IsDBNull(reader.GetOrdinal("SOCAUTHI")))
                        {
                            try { mh.SOCAUTHI = reader.GetInt16(reader.GetOrdinal("SOCAUTHI")); }
                            catch { mh.SOCAUTHI = Convert.ToInt16(reader["SOCAUTHI"]); }
                        }

                        if (HasColumn(reader, "THOIGIAN") && !reader.IsDBNull(reader.GetOrdinal("THOIGIAN")))
                        {
                            try { mh.THOIGIAN = reader.GetInt16(reader.GetOrdinal("THOIGIAN")); }
                            catch { mh.THOIGIAN = Convert.ToInt16(reader["THOIGIAN"]); }
                        }

                        if (HasColumn(reader, "RowGuid") && !reader.IsDBNull(reader.GetOrdinal("RowGuid")))
                        {
                            try { mh.RowGuid = reader.GetGuid(reader.GetOrdinal("RowGuid")); }
                            catch { mh.RowGuid = Guid.Parse(reader["RowGuid"].ToString()); }
                        }

                        list.Add(mh);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return list;
        }

        /// <summary>
        /// Hàm hỗ trợ: Kiểm tra xem Lớp và Môn này đã có đăng ký thi Lần 1 chưa?
        /// Sử dụng ExecuteReader để đọc dòng đầu tiên thay vì ExecuteScalar.
        /// </summary>
        public static DateTime CheckNgayThiLan1(string maLop, string maMH)
        {
            SqlParameter pMaLop = new SqlParameter("@MALOP", SqlDbType.NChar, 8) { Value = maLop };
            SqlParameter pMaMH = new SqlParameter("@MAMH", SqlDbType.NChar, 5) { Value = maMH };

            SqlDataReader reader = Database.ExecuteReader("SP_CheckNgayThiLan1", CommandType.StoredProcedure, pMaLop, pMaMH);

            if (reader != null)
            {
                try
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            try { return reader.GetDateTime(0); }
                            catch { return Convert.ToDateTime(reader[0]); }
                        }
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return DateTime.MinValue;
        }

        /// <summary>
        /// Hàm hỗ trợ: Kiểm tra xem đã tồn tại lịch đăng ký cho Khóa chính này chưa
        /// Sử dụng ExecuteReader đọc kết quả của COUNT(*)
        /// </summary>
        public static bool KiemTraTonTai(string maLop, string maMH, short lan)
        {
            SqlParameter pMaLop = new SqlParameter("@MALOP", SqlDbType.NChar, 8) { Value = maLop };
            SqlParameter pMaMH = new SqlParameter("@MAMH", SqlDbType.NChar, 5) { Value = maMH };
            SqlParameter pLan = new SqlParameter("@LAN", SqlDbType.SmallInt) { Value = lan };

            SqlDataReader reader = Database.ExecuteReader("SP_KiemTraTonTaiGiaoVienDangKy", CommandType.StoredProcedure, pMaLop, pMaMH, pLan);

            if (reader != null)
            {
                try
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            int count = Convert.ToInt32(reader[0]);
                            return count > 0;
                        }
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return false;
        }
    }
}