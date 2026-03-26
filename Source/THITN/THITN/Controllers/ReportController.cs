using System;
using System.Collections.Generic;
using THITN.DAO;
using THITN.Models;

namespace THITN.Controllers
{
    public class ReportController
    {
        public List<ReportDanhSachDangKy> GetDanhSachDangKyThi(DateTime tuNgay, DateTime denNgay, out string errorMessage)
        {
            errorMessage = "";

            // Validate Logic
            if (tuNgay > denNgay)
            {
                errorMessage = "Ngày bắt đầu (Từ ngày) không được lớn hơn Ngày kết thúc (Đến ngày).";
                return null;
            }

            try
            {
                return ReportDAO.GetDanhSachDangKyThi(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                // Bắt lỗi nếu LINK1 bị tạch (Máy cơ sở kia tắt, rớt mạng...)
                errorMessage = "Lỗi truy xuất dữ liệu phân tán (Kiểm tra lại kết nối LINK1): \n" + ex.Message;
                return null;
            }
        }
    }
}