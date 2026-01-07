// Plan / Pseudocode:
// 1. Create a DAO class `GiaoVienDAO` with a constructor that accepts a connection string.
// 2. Implement a method `GetThongTinGiaoVien(string strTenLogin)` that:
//    - Creates a `SqlConnection` using `SystemInfo.DB.ConnectionString` (consistent with other DAOs).
//    - Calls stored procedure `SP_GetThongTinGiaoVienTuLogin` with parameter `@TENLOGIN`.
//    - Reads first row and maps returned columns (`MAGV`, `HOTEN`, `TENNHOM`) to a `GiaoVien` object.
//      - `HOTEN` in SP is `HO + ' ' + TEN`; split into `HO` and `TEN` where possible.
//    - Returns populated `GiaoVien` or `null` if not found.
// Notes:
// - The stored procedure returns role name (`TENNHOM`) but `GiaoVien` model has no role property; it's ignored here.
// - Use trimming for nchar fields and handle DBNull.

using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using THITN.Helper;
using THITN.Models;

namespace THITN.DAO
{
    public class GiaoVienDAO
    {
        private readonly string _connectionString;

        public GiaoVienDAO(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("connectionString must not be null or empty", nameof(connectionString));

            _connectionString = connectionString;
        }

        /// <summary>
        /// Calls stored procedure `SP_GetThongTinGiaoVienTuLogin` and returns a `GiaoVien` object populated from the first row.
        /// Returns null if no matching row is found.
        /// </summary>
        public static GiaoVien GetThongTinGiaoVienTuLoginUser(string strTenLogin)
        {
            if (string.IsNullOrWhiteSpace(strTenLogin)) throw new ArgumentNullException(nameof(strTenLogin));

            using (var conn = new SqlConnection(SystemInfo.DB.ConnectionString))
            using (var cmd = new SqlCommand("SP_GetThongTinGiaoVienTuLogin", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TENLOGIN", SqlDbType.NVarChar, 50) { Value = strTenLogin });

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;


                    // MAGV
                    if (!reader.IsDBNull(reader.GetOrdinal("MAGV")))
                    {
                        string strMa = reader["MAGV"].ToString().Trim();
                        string strRole = reader["Role"].ToString().Trim();
                        var gv = GetThongTinGiaoVienTuMaGV(strMa);
                        if(gv != null)
                        {
                            gv.Role = strRole;
                            return gv;
                        }
                    }    
            
                    return null;
                }
            }
        }
        public static GiaoVien GetThongTinGiaoVienTuMaGV(string strMaGV)
        {
            if (string.IsNullOrWhiteSpace(strMaGV)) throw new ArgumentNullException(nameof(strMaGV));

            using (var conn = new SqlConnection(SystemInfo.DB.ConnectionString))
            using (var cmd = new SqlCommand("SP_GetThongTinGiaoVienTuMa", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MAGV", SqlDbType.NChar, 8) { Value = strMaGV });

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    var gv = new GiaoVien();

                    // MAGV
                    if (!reader.IsDBNull(reader.GetOrdinal("MAGV")))
                        gv.MAGV = reader["MAGV"].ToString().Trim();

                    if (!reader.IsDBNull(reader.GetOrdinal("HO")))
                        gv.HO = reader["HO"].ToString().Trim();

                    if (!reader.IsDBNull(reader.GetOrdinal("TEN")))
                        gv.TEN = reader["TEN"].ToString().Trim();

                    if (!reader.IsDBNull(reader.GetOrdinal("HOCVI")))
                        gv.HOCVI = reader["HOCVI"].ToString().Trim();

                    if (!reader.IsDBNull(reader.GetOrdinal("MAKH")))
                        gv.MAKH = reader["MAKH"].ToString().Trim();

                    return gv;
                }
            }
        }
    }
}