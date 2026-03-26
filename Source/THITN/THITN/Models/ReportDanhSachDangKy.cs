using System;

namespace THITN.Models
{
    public class ReportDanhSachDangKy
    {
        public string MaCoSo { get; set; }
        public string TenCoSo { get; set; }
        public string TenGiaoVien { get; set; }
        public string TenLop { get; set; }
        public string TenMonHoc { get; set; }
        public string TrinhDo { get; set; }
        public DateTime NgayThi { get; set; }
        public short LanThi { get; set; }
        public short SoCau { get; set; }
        public short ThoiGian { get; set; }
    }
}