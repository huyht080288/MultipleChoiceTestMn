using System;

namespace THITN.Models
{
    /// <summary>
    /// Model representing a SinhVien (Student) row from the database table.
    /// Column mapping:
    /// - MASV    : nchar(8)          -> string (not null)
    /// - HO      : nvarchar(50)      -> string (not null)
    /// - TEN     : nvarchar(10)      -> string (not null)
    /// - NGAYSINH: datetime          -> DateTime? (nullable)
    /// - DIACHI  : nvarchar(100)     -> string (nullable)
    /// - MALOP   : nchar(8)          -> string (not null)
    /// - PASSWORD: nvarchar(30)      -> string (not null)
    /// - rowguid : uniqueidentifier  -> Guid (not null)
    /// </summary>
    public class SinhVien
    {
        public string MASV { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public DateTime? NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        public string MALOP { get; set; }
        public string PASSWORD { get; set; }
        public Guid rowguid { get; set; }

        public SinhVien()
        {
        }

        public override string ToString()
        {
            return $"{MASV} - {HO} {TEN}";
        }
    }
}