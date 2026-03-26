using System;
using System.Collections.Generic;
using THITN.DAO;
using THITN.Models;

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

        // =====================================================================
        // CÁC HÀM BỔ SUNG MỚI (Lấy theo GV, Validate, Thêm, Sửa, Xóa)
        // =====================================================================

        /// <summary>
        /// Lấy danh sách đăng ký thi do chính giáo viên đó tạo
        /// </summary>
        public List<GiaoVien_DangKy> GetByMaGV(string maGV)
        {
            return GiaoVien_DangkyDAO.GetByMaGV(maGV);
        }

        /// <summary>
        /// Xử lý Validate và Ghi dữ liệu (Single Save)
        /// </summary>
        public bool LuuDangKy(GiaoVien_DangKy gvdk, bool isAdding, out string errorMessage)
        {
            errorMessage = "";

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(gvdk.MALOP)) { errorMessage = "Vui lòng chọn Lớp!"; return false; }
            if (string.IsNullOrWhiteSpace(gvdk.MAMH)) { errorMessage = "Vui lòng chọn Môn học!"; return false; }
            if (string.IsNullOrWhiteSpace(gvdk.TRINHDO)) { errorMessage = "Vui lòng chọn Trình độ!"; return false; }

            // 2. Validate ràng buộc (Số câu, Thời gian, Ngày thi)
            if (gvdk.SOCAUTHI < 10 || gvdk.SOCAUTHI > 100)
            {
                errorMessage = "Số câu thi phải từ 10 đến 100 câu.";
                return false;
            }

            if (gvdk.THOIGIAN < 2 || gvdk.THOIGIAN > 60)
            {
                errorMessage = "Thời gian thi phải từ 2 đến 60 phút.";
                return false;
            }

            if (gvdk.NGAYTHI.Date < DateTime.Now.Date)
            {
                errorMessage = "Ngày thi không được nhỏ hơn ngày hiện tại.";
                return false;
            }

            if (gvdk.LAN != 1 && gvdk.LAN != 2)
            {
                errorMessage = "Lần thi chỉ được phép là 1 hoặc 2.";
                return false;
            }

            // 3. Logic: Ràng buộc Lần 1 phải thi trước Lần 2 (Chỉ chạy lúc Thêm Mới)
            if (isAdding)
            {
                // Kiểm tra Khóa chính đã tồn tại chưa
                if (GiaoVien_DangkyDAO.KiemTraTonTai(gvdk.MALOP, gvdk.MAMH, gvdk.LAN))
                {
                    errorMessage = $"Lớp {gvdk.MALOP} đã đăng ký thi môn {gvdk.MAMH} lần {gvdk.LAN} rồi!";
                    return false;
                }

                DateTime ngayThiLan1 = GiaoVien_DangkyDAO.CheckNgayThiLan1(gvdk.MALOP, gvdk.MAMH);

                if (gvdk.LAN == 2)
                {
                    // Đăng ký lần 2 nhưng chưa có lần 1
                    if (ngayThiLan1 == DateTime.MinValue)
                    {
                        errorMessage = "Chưa đăng ký thi Lần 1, không thể đăng ký thi Lần 2!";
                        return false;
                    }
                    // Đăng ký lần 2 nhưng ngày thi <= ngày thi lần 1
                    if (gvdk.NGAYTHI.Date <= ngayThiLan1.Date)
                    {
                        errorMessage = $"Ngày thi Lần 2 phải lớn hơn Ngày thi Lần 1 ({ngayThiLan1.ToString("dd/MM/yyyy")}).";
                        return false;
                    }
                }
            }

            // 4. Thực thi Lưu
            try
            {
                if (isAdding)
                {
                    GiaoVien_DangkyDAO.Insert(gvdk);
                    return true;
                }
                else
                {
                    GiaoVien_DangkyDAO.Update(gvdk);
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi Database: " + ex.Message;
                return false;
            }
        }

        public bool XoaDangKy(string maLop, string maMH, short lan, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                // TODO: Bổ sung kiểm tra xem Sinh Viên đã thi chưa (Bảng BANGDIEM).
                // Nếu đã thi rồi thì KHÔNG được xóa lịch thi. 
                // Tạm thời cho phép xóa.
                return GiaoVien_DangkyDAO.Delete(maLop, maMH, lan);
            }
            catch (Exception ex)
            {
                errorMessage = "Không thể xóa lịch thi: " + ex.Message;
                return false;
            }
        }
    }
}