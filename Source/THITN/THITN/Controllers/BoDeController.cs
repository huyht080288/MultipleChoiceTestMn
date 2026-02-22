using System;
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

        public List<BoDe> GetBoDeByMaGV(string maGV)
        {
            if (string.IsNullOrEmpty(maGV)) return new List<BoDe>();
            return BoDeDAO.GetBoDeByMaGV(maGV);
        }

        public bool LuuBoDe(BoDe bd, bool isAdding, out string errorMessage)
        {
            errorMessage = "";

            // 1. Kiểm tra (Validate) dữ liệu
            if (string.IsNullOrWhiteSpace(bd.MAMH)) { errorMessage = "Vui lòng chọn Môn học!"; return false; }
            if (string.IsNullOrWhiteSpace(bd.TRINHDO)) { errorMessage = "Vui lòng chọn Trình độ!"; return false; }
            if (string.IsNullOrWhiteSpace(bd.NOIDUNG)) { errorMessage = "Nội dung câu hỏi không được để trống!"; return false; }
            if (string.IsNullOrWhiteSpace(bd.A) || string.IsNullOrWhiteSpace(bd.B))
            {
                errorMessage = "Phải nhập ít nhất 2 đáp án A và B!"; return false;
            }
            if (string.IsNullOrWhiteSpace(bd.DAPAN)) { errorMessage = "Vui lòng chọn Đáp án đúng!"; return false; }

            // 2. Thực thi Ghi
            try
            {
                if (isAdding)
                {
                    return BoDeDAO.Insert(bd);
                }
                else
                {
                    return BoDeDAO.Update(bd);
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi CSDL: " + ex.Message;
                return false;
            }
        }

        public bool XoaBoDe(int cauHoi, string maGV, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                return BoDeDAO.Delete(cauHoi, maGV);
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xử lý lưu hàng loạt (Batch Save) các thao tác Thêm, Sửa, Xóa từ giao diện
        /// </summary>
        public static bool SaveBatch(List<BoDe> lstThem, List<BoDe> lstSua, List<int> lstXoa, string maGV)
        {
            bool bResult = false;
            try
            {
                return BoDeDAO.SaveBatch(lstThem, lstSua, lstXoa, maGV);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}