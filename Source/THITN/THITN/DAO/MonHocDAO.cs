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
    public class MonHocDAO
    {
        /// <summary>
        /// Lấy toàn bộ danh sách môn học từ bảng MonHoc
        /// Sử dụng lớp THITN.Core.Database để thực thi truy vấn
        /// </summary>
        /// <returns>Danh sách đối tượng MonHoc</returns>
        public static List<MonHoc> GetAllMonHoc()
        {
            var list = new List<MonHoc>();

            using (var conn = new SqlConnection(SystemInfo.DB.ConnectionString))
            using (var cmd = new SqlCommand("SP_GetAllMonHoc", conn))
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
                        var mh = new MonHoc();

                        if (HasColumn(reader, "MAMH") && !reader.IsDBNull(reader.GetOrdinal("MAMH")))
                            mh.MAMH = reader["MAMH"].ToString().Trim();

                        if (HasColumn(reader, "TENMH") && !reader.IsDBNull(reader.GetOrdinal("TENMH")))
                            mh.TENMH = reader["TENMH"].ToString().Trim();

                        list.Add(mh);
                    }
                }
            }

            return list;
        }

        public static List<MonHoc> GetAllMonHocThi()
        {
            var list = new List<MonHoc>();

            using (var conn = new SqlConnection(SystemInfo.DB.ConnectionString))
            using (var cmd = new SqlCommand("SP_GetAllMonHocThi", conn))
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
                        var mh = new MonHoc();

                        if (HasColumn(reader, "MAMH") && !reader.IsDBNull(reader.GetOrdinal("MAMH")))
                            mh.MAMH = reader["MAMH"].ToString().Trim();

                        if (HasColumn(reader, "TENMH") && !reader.IsDBNull(reader.GetOrdinal("TENMH")))
                            mh.TENMH = reader["TENMH"].ToString().Trim();

                        list.Add(mh);
                    }
                }
            }

            return list;
        }

        public static MonHoc GetMonHocTuMaMH(string strMaMH)
        {
            if (string.IsNullOrWhiteSpace(strMaMH)) throw new ArgumentNullException(nameof(strMaMH));

            using (var conn = new SqlConnection(SystemInfo.DB.ConnectionString))
            using (var cmd = new SqlCommand("SP_GetMonHocTuMaMH", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MAMH", SqlDbType.NChar, 5) { Value = strMaMH });

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;
                    var mh = new MonHoc();

                    if (!reader.IsDBNull(reader.GetOrdinal("MAMH")))
                        mh.MAMH = reader["MAMH"].ToString().Trim();

                    if (!reader.IsDBNull(reader.GetOrdinal("TENMH")))
                        mh.TENMH = reader["TENMH"].ToString().Trim();
                    return mh;
                }
            }
        }
    }
}