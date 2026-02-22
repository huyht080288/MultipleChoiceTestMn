using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using THITN.Core;
using THITN.Helper;
using THITN.Models;

namespace THITN.DAO
{
    public class BangDiemDAO
    {
        // Returns number of rows affected (or -1 on error)
        public int Insert(BangDiem bd)
        {
            return Database.ExecuteNonQuery(
            "SP_InsertBangDiem",
            CommandType.StoredProcedure,
            new SqlParameter("@MASV", SqlDbType.NChar, 8) { Value = bd.MASV },
            new SqlParameter("@MAMH", SqlDbType.NChar, 5) { Value = bd.MAMH },
            new SqlParameter("@LAN", SqlDbType.SmallInt) { Value = bd.LAN },
            new SqlParameter("@DIEM", SqlDbType.Float) { Value = bd.DIEM },
            new SqlParameter("@NGAYTHI", SqlDbType.DateTime) { Value = bd.NGAYTHI });
        }

        public List<BangDiem> GetBangDiemTheoMaSV(string masv)
        {
            List<BangDiem> list = new List<BangDiem>();
            using (var conn = new SqlConnection(SystemInfo.DB.ConnectionString))
            using (var cmd = new SqlCommand("SP_GetBangDiemTheoMaSV", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MASV", SqlDbType.NChar, 8) { Value = masv });

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    var bd = new BangDiem
                    {
                        MASV = reader["MASV"] != DBNull.Value ? reader["MASV"].ToString().Trim() : null,
                        MAMH = reader["MAMH"] != DBNull.Value ? reader["MAMH"].ToString().Trim() : null,
                        LAN = reader["LAN"] != DBNull.Value ? Convert.ToInt16(reader["LAN"]) : (short)0,
                        DIEM = reader["DIEM"] != DBNull.Value ? Convert.ToDouble(reader["DIEM"]) : 0.0,
                        NGAYTHI = reader["NGAYTHI"] != DBNull.Value ? Convert.ToDateTime(reader["NGAYTHI"]) : DateTime.MinValue,
                        RowGuid = reader["RowGuid"] != DBNull.Value ? (Guid)reader["RowGuid"] : Guid.Empty
                    };

                    list.Add(bd);
                }
            }
            return list;
        }

        /// <summary>
        /// Lấy chi tiết điểm thi của cả lớp (Dùng cho Báo Cáo)
        /// </summary>
        public static List<ChiTietBangDiem> GetBangDiemMonHoc(string maLop, string maMH, short lan)
        {
            List<ChiTietBangDiem> listKetQua = new List<ChiTietBangDiem>();

            SqlParameter pMaLop = new SqlParameter("@MALOP", SqlDbType.NChar, 15) { Value = maLop };
            SqlParameter pMaMH = new SqlParameter("@MAMH", SqlDbType.NChar, 5) { Value = maMH };
            SqlParameter pLan = new SqlParameter("@LAN", SqlDbType.SmallInt) { Value = lan };

            SqlDataReader reader = Database.ExecuteReader("SP_GetBangDiemTheoLopMonLan", CommandType.StoredProcedure, pMaLop, pMaMH, pLan);

            if (reader != null)
            {
                try
                {
                    while (reader.Read())
                    {
                        ChiTietBangDiem item = new ChiTietBangDiem();
                        item.MASV = reader["MASV"].ToString().Trim();
                        item.HO = reader["HO"].ToString().Trim();
                        item.TEN = reader["TEN"].ToString().Trim();
                        item.NGAYTHI = reader["NGAYTHI"] != DBNull.Value ? Convert.ToDateTime(reader["NGAYTHI"]) : DateTime.MinValue;
                        // Kiểm tra vắng thi (NULL)
                        if (reader.IsDBNull(reader.GetOrdinal("DIEM")))
                        {
                            item.DIEM = null;
                        }
                        else
                        {
                            item.DIEM = Convert.ToDouble(reader["DIEM"]);
                        }

                        listKetQua.Add(item);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            return listKetQua;
        }


    }
}