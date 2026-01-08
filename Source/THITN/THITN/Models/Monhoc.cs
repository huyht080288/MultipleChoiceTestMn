using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THITN.Models
{
    public class MonHoc
    {
        public string MAMH { get; set; }        // nchar(5)
        public string TENMH { get; set; }       // nvarchar(50)
        public Guid RowGuid { get; set; }
    }
}
