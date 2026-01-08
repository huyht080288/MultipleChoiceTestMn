using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THITN.Models
{
    public class BoDe
    {
        public int CAUHOI { get; set; }         // int, Tu tang
        public string MAMH { get; set; }        // nchar(5)
        public string TRINHDO { get; set; }     // nchar(1)
        public string NOIDUNG { get; set; }     // ntext
        public string A { get; set; }           // ntext
        public string B { get; set; }           // ntext
        public string C { get; set; }           // ntext (allow null)
        public string D { get; set; }           // ntext (allow null)
        public string DAPAN { get; set; }       // nchar(1) (allow null)
        public string MAGV { get; set; }        // nchar(8)
        public Guid RowGuid { get; set; }
    }
}
