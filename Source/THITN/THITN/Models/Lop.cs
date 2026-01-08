using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THITN.Models
{
    public class Lop
    {
        public string MALOP { get; set; }       // nchar(8)
        public string TENLOP { get; set; }      // nvarchar(40)
        public string MAKH { get; set; }        // nchar(8)
        public Guid RowGuid { get; set; }
    }
}
