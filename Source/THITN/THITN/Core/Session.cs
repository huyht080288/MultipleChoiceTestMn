using System;

namespace THITN.Core
{
    /// <summary>
    /// Lớp tĩnh lưu trữ thông tin phiên đăng nhập của người dùng hiện tại
    /// </summary>
    public static class Session
    {
        public static string Username { get; set; } // Tên Login (ví dụ: "PGV_CS1" hoặc "N15DCCN100")
        public static string FullName { get; set; } // Họ tên đầy đủ (ví dụ: "Trần Văn A")
        public static string UserRole { get; set; } // Vai trò (TRUONG, COSO, GIANGVIEN, SINHVIEN)
        public static int SelectedBranchIndex { get; set; } // 0 = CS1, 1 = CS2 (dựa trên ComboBox)
    }
}
