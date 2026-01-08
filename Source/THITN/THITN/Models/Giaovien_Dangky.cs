using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THITN.Models
{
    public class GiaoVien_DangKy
    {
        public string MAGV { get; set; }        // nchar(8)
        public string MALOP { get; set; }       // nchar(8)
        public string MAMH { get; set; }        // nchar(5)
        public string TRINHDO { get; set; }     // nchar(1)
        public DateTime NGAYTHI { get; set; }   // datetime
        public short LAN { get; set; }          // smallint
        public short SOCAUTHI { get; set; }     // smallint
        public short THOIGIAN { get; set; }     // smallint
        public Guid RowGuid { get; set; }
    }
}
