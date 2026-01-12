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
                        CAUHOI = reader["CAUHOI"] != DBNull.Value ? Convert.ToInt32(reader["CAUHOI"]) : 0,
                        MAMH = reader["MAMH"] != DBNull.Value ? reader["MAMH"].ToString().Trim() : null,
                        TRINHDO = reader["TRINHDO"] != DBNull.Value ? reader["TRINHDO"].ToString().Trim() : null,
                        NOIDUNG = reader["NOIDUNG"] != DBNull.Value ? reader["NOIDUNG"].ToString() : null,
                        A = reader["A"] != DBNull.Value ? reader["A"].ToString() : null,
                        B = reader["B"] != DBNull.Value ? reader["B"].ToString() : null,
                        C = reader["C"] != DBNull.Value ? reader["C"].ToString() : null,
                        D = reader["D"] != DBNull.Value ? reader["D"].ToString() : null,
                        DAPAN = reader["DAPAN"] != DBNull.Value ? reader["DAPAN"].ToString().Trim() : null,
                        MAGV = reader["MAGV"] != DBNull.Value ? reader["MAGV"].ToString().Trim() : null,
                        RowGuid = reader["RowGuid"] != DBNull.Value ? (Guid)reader["RowGuid"] : Guid.Empty
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
    }
}
