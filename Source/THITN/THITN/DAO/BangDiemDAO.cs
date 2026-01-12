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
    }
}