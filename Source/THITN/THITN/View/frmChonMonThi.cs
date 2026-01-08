using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using THITN.View;

namespace THITN.Views
{
    public partial class frmChonMonThi : Form
    {
        // Thông tin sinh viên (Giả sử nhận từ Form Đăng Nhập)
        public string MaSV { get; set; } = "SV001";
        public string MaLop { get; set; } = "D19CQCN01";
        public string HoTen { get; set; } = "Nguyễn Văn A";

        // Biến lưu dữ liệu gốc để giả lập Database
        private DataTable dtLichThiGoc;

        public frmChonMonThi()
        {
            InitializeComponent();

            // Đăng ký sự kiện
            this.Load += FrmChonMonThi_Load;
            btnTimKiem.Click += BtnTimKiem_Click;
            btnBatDauThi.Click += BtnBatDauThi_Click;
            btnThoat.Click += (s, e) => this.Close();
        }

        private void FrmChonMonThi_Load(object sender, EventArgs e)
        {
            // 1. Hiển thị thông tin sinh viên
            lblSinhVien.Text = $"Sinh viên: {HoTen} - Mã SV: {MaSV} - Lớp: {MaLop}";

            // 2. Thiết lập mặc định cho các control lọc
            cbbLanThi.SelectedIndex = 0; // Mặc định Lần 1
            dtpNgayThi.Value = DateTime.Now; // Mặc định hôm nay

            // 3. Load danh sách Môn học vào ComboBox
            LoadDSMonHoc();

            // 4. Chuẩn bị dữ liệu giả (Mock Data) cho bảng lịch thi
            KhoiTaoDuLieuGia();

            // Mặc định load lưới rỗng hoặc load toàn bộ tùy ý
            // Ở đây ta để rỗng để bắt buộc sinh viên phải chọn và bấm Tìm kiếm
        }

        private void LoadDSMonHoc()
        {
            // TODO: Query: SELECT MAMH, TENMH FROM MONHOC
            // Ở đây tạo dữ liệu giả
            DataTable dtMonHoc = new DataTable();
            dtMonHoc.Columns.Add("MAMH");
            dtMonHoc.Columns.Add("TENMH");

            dtMonHoc.Rows.Add("CSDLPT", "Cơ sở dữ liệu phân tán");
            dtMonHoc.Rows.Add("MMT", "Mạng máy tính");
            dtMonHoc.Rows.Add("CTDL", "Cấu trúc dữ liệu");
            dtMonHoc.Rows.Add("LTM", "Lập trình mạng");

            cbbMonHoc.DataSource = dtMonHoc;
            cbbMonHoc.DisplayMember = "TENMH";
            cbbMonHoc.ValueMember = "MAMH";
            cbbMonHoc.SelectedIndex = 0;
        }

        private void KhoiTaoDuLieuGia()
        {
            // Giả lập dữ liệu trong bảng GIAOVIEN_DANGKY
            dtLichThiGoc = new DataTable();
            dtLichThiGoc.Columns.Add("MAMH", typeof(string));
            dtLichThiGoc.Columns.Add("TENMH", typeof(string));
            dtLichThiGoc.Columns.Add("TENLOP", typeof(string));
            dtLichThiGoc.Columns.Add("NGAYTHI", typeof(DateTime));
            dtLichThiGoc.Columns.Add("LAN", typeof(int));
            dtLichThiGoc.Columns.Add("SOCAUTHI", typeof(int));
            dtLichThiGoc.Columns.Add("THOIGIAN", typeof(int));
            dtLichThiGoc.Columns.Add("TRINHDO", typeof(string));

            // Thêm vài dòng dữ liệu mẫu
            // Lưu ý: Ngày thi nên để là hôm nay để test cho dễ
            dtLichThiGoc.Rows.Add("CSDLPT", "Cơ sở dữ liệu phân tán","CL1", DateTime.Now.Date, 1, 10, 15, "A");
            dtLichThiGoc.Rows.Add("CSDLPT", "Cơ sở dữ liệu phân tán", "CL2", DateTime.Now.Date, 2, 20, 30, "B");

            dtLichThiGoc.Rows.Add("MMT", "Mạng máy tính", "CL3", DateTime.Now.Date.AddDays(1), 1, 40, 45, "B");
            dtLichThiGoc.Rows.Add("CTDL", "Cấu trúc dữ liệu", "CL4", DateTime.Now.Date.AddDays(-2), 1, 60, 90, "C");
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            // 1. Lấy thông tin từ bộ lọc
            string maMH = cbbMonHoc.SelectedValue.ToString();
            DateTime ngayThi = dtpNgayThi.Value.Date;
            int lanThi = int.Parse(cbbLanThi.SelectedItem.ToString());

            // 2. Tìm kiếm (Trong thực tế sẽ gọi SP_TIM_LICH_THI @MaMH, @Ngay, @Lan)
            // Ở đây ta lọc trên DataTable giả
            DataView dv = new DataView(dtLichThiGoc);

            // Filter expression
            // Lưu ý: DateTime trong Filter Expression của DataView cần định dạng cẩn thận hoặc lọc thủ công
            // Cách đơn giản nhất cho Mockup là dùng LINQ hoặc Loop, nhưng ở đây ta dùng Select của DataTable

            string filter = $"MAMH = '{maMH}' AND LAN = {lanThi}";
            // Về ngày tháng, so sánh chính xác trong code sẽ dễ hơn string filter

            DataTable dtKetQua = dtLichThiGoc.Clone(); // Copy cấu trúc
            foreach (DataRow row in dtLichThiGoc.Rows)
            {
                if (row["MAMH"].ToString() == maMH &&
                    (int)row["LAN"] == lanThi &&
                    ((DateTime)row["NGAYTHI"]).Date == ngayThi)
                {
                    dtKetQua.ImportRow(row);
                }
            }

            // 3. Hiển thị kết quả lên lưới
            dgvLichThi.DataSource = dtKetQua;
            FormatLuoi();

            if (dtKetQua.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy lịch thi phù hợp với thông tin bạn chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormatLuoi()
        {
            if (dgvLichThi.Columns["MAMH"] != null)
            {
                dgvLichThi.Columns["MAMH"].HeaderText = "Mã MH";
                dgvLichThi.Columns["TENMH"].HeaderText = "Tên Môn Học";
                dgvLichThi.Columns["NGAYTHI"].HeaderText = "Ngày Thi";
                dgvLichThi.Columns["LAN"].HeaderText = "Lần Thi";
                dgvLichThi.Columns["SOCAUTHI"].HeaderText = "Số Câu";
                dgvLichThi.Columns["THOIGIAN"].HeaderText = "Thời Gian (Phút)";
                dgvLichThi.Columns["TRINHDO"].HeaderText = "Trình Độ";

                // Format cột ngày
                dgvLichThi.Columns["NGAYTHI"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void BtnBatDauThi_Click(object sender, EventArgs e)
        {
            if (dgvLichThi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn môn thi từ danh sách tìm được!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu dòng đang chọn
            DataGridViewRow row = dgvLichThi.SelectedRows[0];
            string maMH = row.Cells["MAMH"].Value.ToString();
            string tenMH = row.Cells["TENMH"].Value.ToString();
            int lan = int.Parse(row.Cells["LAN"].Value.ToString());
            int soCau = int.Parse(row.Cells["SOCAUTHI"].Value.ToString());
            int thoiGian = int.Parse(row.Cells["THOIGIAN"].Value.ToString());
            string trinhDo = row.Cells["TRINHDO"].Value.ToString();
            DateTime ngayThi = (DateTime)row.Cells["NGAYTHI"].Value;

            // --- KIỂM TRA RÀNG BUỘC ---

            // 1. Kiểm tra ngày thi (Quan trọng)
            if (ngayThi.Date != DateTime.Now.Date)
            {
                MessageBox.Show($"Môn này đăng ký thi ngày {ngayThi:dd/MM/yyyy}. Hôm nay chưa được thi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra đã thi chưa (Gọi Database thật)
            if (KiemTraDaThi(MaSV, maMH, lan))
            {
                MessageBox.Show("Bạn đã có điểm môn này lần thi này rồi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- MỞ FORM THI ---
            // Truyền tham số sang form Thi để form Thi biết cần load đề gì
            // Bạn cần cập nhật constructor của frmThi hoặc tạo Property bên đó

            frmThi f = new frmThi();
            // Giả sử frmThi có phương thức nhận thông tin (bạn cần viết thêm bên frmThi)
            // f.ThietLapThongTinBaiThi(maMH, tenMH, trinhDo, soCau, thoiGian, lan);

            this.Hide(); // Ẩn form chọn môn
            f.ShowDialog();
            this.Show(); // Hiện lại khi form thi đóng

            // Reset tìm kiếm sau khi thi xong (để tránh thi lại ngay lập tức)
            dgvLichThi.DataSource = null;
        }

        private bool KiemTraDaThi(string masv, string mamh, int lan)
        {
            // TODO: SELECT COUNT(*) FROM BANGDIEM WHERE MASV=... AND MAMH=... AND LAN=...
            // Trả về true nếu đã có điểm
            return false;
        }
    }
}