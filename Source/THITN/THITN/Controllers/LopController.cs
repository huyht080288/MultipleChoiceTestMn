using System.Collections.Generic;
using THITN.DAO;     // Sử dụng namespace THITN.DAO
using THITN.Models;  // Sử dụng namespace THITN.Models

namespace THITN.Controllers
{
    public class LopController
    {
        /// <summary>
        /// Lấy danh sách tất cả môn học
        /// Gọi xuống tầng DAO để truy xuất dữ liệu
        /// </summary>
        /// <returns>List<MonHoc></returns>
        public List<Lop> GetAllLop()
        {
            return LopDAO.GetAllLop();
        }

        public Lop GetLop(string strMaLop)
        {
            return LopDAO.GetLop(strMaLop);
        }
    }
}