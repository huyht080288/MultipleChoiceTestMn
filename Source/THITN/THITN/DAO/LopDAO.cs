using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THITN.Helper;
using THITN.Models;

namespace THITN.DAO
{
    public class LopDAO
    {
        /// <summary>
        /// Lấy toàn bộ danh sách môn học từ bảng MonHoc
        /// Sử dụng lớp THITN.Core.Database để thực thi truy vấn
        /// </summary>
        /// <returns>Danh sách đối tượng MonHoc</returns>
        public static List<Lop> GetAllLop()
        {
            var list = new List<Lop>();

            using (var conn = new SqlConnection(SystemInfo.DB.ConnectionString))
            using (var cmd = new SqlCommand("SP_GetAllLop", conn))
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
                        var mh = new Lop();

                        if (!reader.IsDBNull(reader.GetOrdinal("MALOP")))
                            mh.MALOP = reader["MALOP"].ToString().Trim();

                        if (!reader.IsDBNull(reader.GetOrdinal("TENLOP")))
                            mh.TENLOP = reader["TENLOP"].ToString().Trim();

                        list.Add(mh);
                    }
                }
            }

            return list;
        }

        public static Lop GetLop(string strLop)
        {
            if (string.IsNullOrWhiteSpace(strLop)) throw new ArgumentNullException(nameof(strLop));

            using (var conn = new SqlConnection(SystemInfo.DB.ConnectionString))
            using (var cmd = new SqlCommand("SP_GetLop", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MALOP", SqlDbType.NChar, 8) { Value = strLop });

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;
                    var mh = new Lop();

                    if (!reader.IsDBNull(reader.GetOrdinal("MALOP")))
                        mh.MALOP = reader["MALOP"].ToString().Trim();

                    if (!reader.IsDBNull(reader.GetOrdinal("TENLOP")))
                        mh.TENLOP = reader["TENLOP"].ToString().Trim();
                    return mh;
                }
            }
        }
    }
}
