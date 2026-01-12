using System.Collections.Generic;
using THITN.DAO;
using THITN.Models;

namespace THITN.Controllers
{
    public class BoDeController
    {
        private readonly BoDeDAO _dao = new BoDeDAO();

        public List<BoDe> GetBoDe(string maLop, string maMH, string trinhDo, int soCauThi)
        {
            return _dao.GetBoDe(maLop, maMH, trinhDo, soCauThi);
        }
    }
}