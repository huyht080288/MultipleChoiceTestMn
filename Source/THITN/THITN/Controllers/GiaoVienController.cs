using System.Collections.Generic;
using THITN.DAO;
using THITN.Models;
using THITN.Core; // Để sử dụng Core.Database và Core.Session
using System.Data.SqlClient;
using System.Data;
using THITN.Helper;

namespace THITN.Controllers
{
    /// <summary>
    /// Controller xử lý tất cả logic nghiệp vụ cho Form Đăng nhập
    /// </summary>
    public class GiaoVienController
    {
        /// <summary>
        /// Lấy danh sách cơ sở để View hiển thị lên ComboBox
        /// </summary>
        /// <returns>Danh sách các đối tượng CoSo</returns>
        public GiaoVien GetGiaoVienFromLoginUser(string strLoginUser)
        {
            return GiaoVienDAO.GetThongTinGiaoVienTuLoginUser(strLoginUser);
        }
    }
}
