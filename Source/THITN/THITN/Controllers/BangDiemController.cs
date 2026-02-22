using System;
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

        public List<ChiTietBangDiem> GetBangDiemMonHoc(string maLop, string maMH, short lan)
        {
            // 1. Lấy dữ liệu thô từ DAO
            List<ChiTietBangDiem> lstKetQua = BangDiemDAO.GetBangDiemMonHoc(maLop, maMH, lan);

            // 2. Xử lý Logic Nghiệp vụ (Tính điểm chữ)
            foreach (var item in lstKetQua)
            {
                if (!item.DIEM.HasValue)
                {
                    item.DIEMCHU = "Vắng thi";
                }
                else
                {
                    item.DIEMCHU = DocDiemSoThanhChu(item.DIEM.Value);
                }
            }

            // 3. Trả về kết quả đã hoàn thiện cho View
            return lstKetQua;
        }

        /// <summary>
        /// Logic chuyển đổi điểm (Chỉ Controller mới cần biết thuật toán này)
        /// </summary>
        private string DocDiemSoThanhChu(double diem)
        {
            double roundedDiem = Math.Round(diem, 1);
            int phanNguyen = (int)Math.Truncate(roundedDiem);
            int phanThapPhan = (int)Math.Round((roundedDiem - phanNguyen) * 10);

            string[] mangSo = { "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín", "Mười" };

            if (phanNguyen < 0 || phanNguyen > 10) return "Lỗi điểm";

            string chu = mangSo[phanNguyen];
            if (phanThapPhan > 0)
            {
                chu += " phẩy " + mangSo[phanThapPhan].ToLower();
            }

            return chu;
        }
    }
}