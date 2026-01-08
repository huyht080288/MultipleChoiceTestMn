using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THITN.Models
{
    public class Khoa
    {
        public string MAKH { get; set; }        // nchar(8)
        public string TENKH { get; set; }       // nvarchar(50)
        public string MACS { get; set; }        // nchar(3)
        public Guid RowGuid { get; set; }
    }
}
