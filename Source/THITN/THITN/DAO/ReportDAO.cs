using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using THITN.Core;
using THITN.Models;

namespace THITN.DAO
{
    public class ReportDAO
    {
        public static List<ReportDanhSachDangKy> GetDanhSachDangKyThi(DateTime tuNgay, DateTime denNgay)
        {
            List<ReportDanhSachDangKy> list = new List<ReportDanhSachDangKy>();

            SqlParameter pTuNgay = new SqlParameter("@TUNGAY", SqlDbType.DateTime) { Value = tuNgay };
            SqlParameter pDenNgay = new SqlParameter("@DENNGAY", SqlDbType.DateTime) { Value = denNgay };

            SqlDataReader reader = Database.ExecuteReader("SP_ReportDanhSachDangKyThi", CommandType.StoredProcedure, pTuNgay, pDenNgay);

            if (reader != null)
            {
                try
                {
                    while (reader.Read())
                    {
                        ReportDanhSachDangKy rp = new ReportDanhSachDangKy();
                        rp.MaCoSo = reader["MaCoSo"].ToString();
                        rp.TenCoSo = reader["TenCoSo"].ToString();
                        rp.TenGiaoVien = reader["TenGiaoVien"].ToString();
                        rp.TenLop = reader["TenLop"].ToString();
                        rp.TenMonHoc = reader["TenMonHoc"].ToString();
                        rp.TrinhDo = reader["TrinhDo"].ToString();
                        rp.NgayThi = Convert.ToDateTime(reader["NgayThi"]);
                        rp.LanThi = Convert.ToInt16(reader["LanThi"]);
                        rp.SoCau = Convert.ToInt16(reader["SoCau"]);
                        rp.ThoiGian = Convert.ToInt16(reader["ThoiGian"]);

                        list.Add(rp);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return list;
        }
    }
}