using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THITN.Models
{
    // 1. Model cho bảng BangDiem
    public class BangDiem
    {
        public string MASV { get; set; }        // nchar(8)
        public string MAMH { get; set; }        // nchar(5)
        public short LAN { get; set; }          // smallint
        public DateTime NGAYTHI { get; set; }   // datetime
        public double DIEM { get; set; }        // float
        public Guid RowGuid { get; set; }       // uniqueidentifier
    }

    public class ChiTietBangDiem
    {
        public string MASV { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }

        // Sử dụng double? (nullable) vì sinh viên có thể vắng thi (không có điểm)
        public double? DIEM { get; set; }

        public string DIEMCHU { get; set; }
        public DateTime? NGAYTHI { get; set; }
    }

}
