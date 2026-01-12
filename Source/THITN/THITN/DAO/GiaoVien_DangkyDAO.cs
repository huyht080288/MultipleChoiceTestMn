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

    }
}