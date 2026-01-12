using System.Collections.Generic;
using THITN.DAO;
using THITN.Models;

namespace THITN.Controllers
{
    public class BangDiemController
    {
        private readonly BangDiemDAO _dao = new BangDiemDAO();

        // Returns true when insert succeeded
        public bool Insert(BangDiem bd)
        {
            int rows = _dao.Insert(bd);
            return rows > 0;
        }

        public List<BangDiem> GetBangDiemTheoMaSV(string masv)
        {
            return _dao.GetBangDiemTheoMaSV(masv);
        }
    }
}