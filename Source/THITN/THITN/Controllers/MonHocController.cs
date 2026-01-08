using System.Collections.Generic;
using THITN.DAO;     // Sử dụng namespace THITN.DAO
using THITN.Models;  // Sử dụng namespace THITN.Models

namespace THITN.Controllers
{
    public class MonHocController
    {
        /// <summary>
        /// Lấy danh sách tất cả môn học
        /// Gọi xuống tầng DAO để truy xuất dữ liệu
        /// </summary>
        /// <returns>List<MonHoc></returns>
        public List<MonHoc> GetAllMonHocThi()
        {
            // Gọi phương thức tĩnh từ DAO
            return MonHocDAO.GetAllMonHocThi();
        }
    }
}