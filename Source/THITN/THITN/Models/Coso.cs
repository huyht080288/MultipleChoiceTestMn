namespace THITN.Models
{
    /// <summary>
    /// Model (Lớp đối tượng) đại diện cho bảng CoSo.
    /// Dùng để vận chuyển dữ liệu giữa DAO, Controller và View.
    /// </summary>
    public class Coso
    {
        // Tên hiển thị (ví dụ: "Cơ sở 1")
        public string TENCS { get; set; }

        // Giá trị ẩn (ví dụ: "MAYCHU_CS1")
        public string SERVER_NAME { get; set; }
    }
}
