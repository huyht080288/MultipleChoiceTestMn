using System;

namespace THITN.Models
{
    public class GiaoVien
    {
        /// <summary>
        /// MAGV nchar(8)
        /// </summary>
        public string MAGV { get; set; }

        /// <summary>
        /// HO nvarchar(50)
        /// </summary>
        public string HO { get; set; }

        /// <summary>
        /// TEN nvarchar(10)
        /// </summary>
        public string TEN { get; set; }

        /// <summary>
        /// HOCVI nvarchar(40)
        /// </summary>
        public string HOCVI { get; set; }

        /// <summary>
        /// MAKH nchar(8)
        /// </summary>
        public string MAKH { get; set; }

        /// <summary>
        /// rowguid uniqueidentifier
        /// </summary>
        public Guid RowGuid { get; set; }

        /// <summary>
        /// ROLE
        /// </summary>
        public string Role { get; set; }
        
    }
}