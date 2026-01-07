// Plan / Pseudocode:
// 1. Create a DAO class `SinhvienDAO` with a constructor that accepts a connection string.
// 2. Implement a method `GetThongTinSinhVien(string maSV, string password)` that:
//    - Creates a `SqlConnection` using the provided connection string.
//    - Creates a `SqlCommand` with CommandType = StoredProcedure and the name `SP_GetThongTinSinhVien`.
//    - Adds parameters `@MASV` (NCHAR(8)) and `@PASSWORD`.
//    - Opens the connection and executes the command with `ExecuteReader()`.
//    - If a row is returned, create a `SinhVien` instance and map columns to properties on `SinhVien`.
//      - Use case-insensitive property lookup.
//      - Handle DBNull and nullable target property types.
//    - Return the populated `SinhVien` instance or `null` if not found.
// 3. Let exceptions propagate (or rethrow with more info) so caller can handle them.
// Notes:
// - This implementation assumes a `SinhVien` class exists in the project with public writable properties
//   whose names match the column names returned by the stored procedure.
// - The DAO does not hard-code a connection string; pass it when constructing `SinhvienDAO`.
//
// Implementation follows the above plan.

using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using THITN.Helper;
using THITN.Models;

namespace THITN.DAO
{
    public class SinhvienDAO
    {
        private readonly string _connectionString;

        public SinhvienDAO(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("connectionString must not be null or empty", nameof(connectionString));

            _connectionString = connectionString;
        }

        /// <summary>
        /// Calls stored procedure `SP_GetThongTinSinhVien` and returns a `SinhVien` object populated from the first row.
        /// Returns null if no matching row is found.
        /// </summary>
        public static SinhVien GetThongTinSinhVien(string maSV, string password)
        {
            if (maSV == null) throw new ArgumentNullException(nameof(maSV));

            using (var conn = new SqlConnection(SystemInfo.DB.ConnectionString))
            using (var cmd = new SqlCommand("SP_GetThongTinSinhVien", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                var pMasv = new SqlParameter("@MASV", SqlDbType.NChar, 8) { Value = (object)maSV };
                cmd.Parameters.Add(pMasv);

                // PASSWORD length in proc is nvarchar(30)
                cmd.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.NVarChar, 30) { Value = (object)password ?? DBNull.Value });

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    // Create instance of SinhVien. Assumes a parameterless constructor exists.
                    var sv = new SinhVien();

                    var svType = typeof(SinhVien);

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var colName = reader.GetName(i);
                        var prop = svType.GetProperty(colName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                        if (prop == null || !prop.CanWrite) continue;

                        object value = reader.IsDBNull(i) ? null : reader.GetValue(i);

                        try
                        {
                            if (value == null)
                            {
                                prop.SetValue(sv, null);
                            }
                            else
                            {
                                var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                                // Handle enums
                                if (targetType.IsEnum)
                                {
                                    var enumVal = Enum.ToObject(targetType, value);
                                    prop.SetValue(sv, enumVal);
                                }
                                else
                                {
                                    var safeValue = Convert.ChangeType(value, targetType);
                                    prop.SetValue(sv, safeValue);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }

                    return sv;
                }
            }
        }
    }
}