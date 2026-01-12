using System.Collections.Generic;
using THITN.DAO;     // Sử dụng namespace THITN.DAO
using THITN.Models;  // Sử dụng namespace THITN.Models

namespace THITN.Controllers
{
    public class GiaoVien_DangKyController
    {
        /// <summary>
        /// Lấy danh sách tất cả môn học
        /// Gọi xuống tầng DAO để truy xuất dữ liệu
        /// </summary>
        /// <returns>List<MonHoc></returns>
        public List<GiaoVien_DangKy> GetAllGiaoVienDangKy()
        {
            // Gọi phương thức tĩnh từ DAO
            return GiaoVien_DangkyDAO.GetAllGiaoVienDangKy();
        }

        public GiaoVien_DangKy GetDangKy(string strMaLop, string strMaMH, short sLan)
        {
            return GiaoVien_DangkyDAO.GetDangKy(strMaLop, strMaMH, sLan);   
        }
    }
}