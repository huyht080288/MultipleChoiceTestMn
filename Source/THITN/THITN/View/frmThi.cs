using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using THITN.Controllers;
using THITN.Helper;
using THITN.Models;
using THITN.Views;

namespace THITN.View
{
    public partial class frmThi : Form
    {
        public string MAMH { get; set; }
        public string MALOP { get; set; }
        public string TENMH { get; set; }
        public short LAN { get; set; }
        public short THOIGIANTHI { get; set; } // Phút

        public Lop objLop { get; set; }
        public GiaoVien_DangKy objGiaoVien_DangKy { get; set; }

        // Biến toàn cục
        private List<BoDe> danhSachCauHoi;
        private int currentCauHoiIndex = 0;
        private int thoiGianConLai = 0; // Giây
        private bool isBindingData = false; // Cờ chặn sự kiện khi đang load dữ liệu lên UI

        public frmThi()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.frmThi_Load);
        }
        private void frmThi_Load(object sender, EventArgs e)
        {
            LoadLop();
            LoadDangKy();

            DisplayHeader();
            DangKySuKien();



            // 1. Tạo Mockup Data (50 câu, Trình độ A)
            TaoDuLieuGia(50);

            // 2. Thiết lập thời gian thi (90 phút)
            thoiGianConLai = THOIGIANTHI * 60;
            CapNhatHienThiDongHo();
            timerThi.Start();

            // 3. Tạo các nút câu hỏi trên thanh bên phải
            KhoiTaoThanhDieuHuong();

            // 4. Load câu hỏi đầu tiên
            LoadCauHoiLenUI(0);
        }


        private void DisplayHeader()
        {
            lblLop.Text = $"Lớp: {objLop.MALOP.Trim()} - {objLop.TENLOP.Trim()}";
            lblThongTinSV.Text = $"Sinh viên: {SystemInfo.CurrentSinhVien.MASV.Trim()} - {SystemInfo.CurrentSinhVien.HO.Trim()} {SystemInfo.CurrentSinhVien.TEN.Trim()}";
            lblMonThi.Text = $"Môn thi: {TENMH} (Lần {LAN})";
        }
        private void LoadLop()
        {
            objLop = new LopController().GetLop(MALOP);
        }
        private void LoadDangKy()
        {
            objGiaoVien_DangKy = new GiaoVien_DangKyController().GetDangKy(MALOP, MAMH, LAN);
        }
        private void DangKySuKien()
        {
            // Đăng ký sự kiện Click cho các nút điều hướng
            btnTruoc.Click += BtnTruoc_Click;
            btnSau.Click += BtnSau_Click;
            btnNopBai.Click += BtnNopBai_Click;
            timerThi.Tick += TimerThi_Tick;

            // Đăng ký sự kiện chọn đáp án
            rdoA.CheckedChanged += Rdo_CheckedChanged;
            rdoB.CheckedChanged += Rdo_CheckedChanged;
            rdoC.CheckedChanged += Rdo_CheckedChanged;
            rdoD.CheckedChanged += Rdo_CheckedChanged;
        }



        #region Xử lý Dữ liệu & UI

        private void TaoDuLieuGia(int soCau)
        {
            danhSachCauHoi = new BoDeController().GetBoDe(MALOP, MAMH, objGiaoVien_DangKy.TRINHDO, soCau);
            if(danhSachCauHoi.Count == 0)
            {
                pnlHeader.Enabled = false;
                this.Close();
            }
            return;

            Random rnd = new Random();
            string[] cacDapAn = { "A", "B", "C", "D" };

            for (int i = 1; i <= soCau; i++)
            {
                danhSachCauHoi.Add(new BoDe
                {
                    CAUHOI = i,
                    STT = i,
                    NOIDUNG = $"Đây là nội dung câu hỏi số {i}. Cấu trúc bảng BODE phân tán như thế nào trong SQL Server? (Dữ liệu giả lập để test giao diện)",
                    A = $"Lựa chọn A cho câu {i}",
                    B = $"Lựa chọn B cho câu {i}",
                    C = $"Lựa chọn C cho câu {i}",
                    D = $"Lựa chọn D cho câu {i}",
                    DAPAN = cacDapAn[rnd.Next(0, 4)], // Random đáp án đúng
                    DapAnDaChon = "" // Mặc định chưa chọn
                });
            }
        }

        private void KhoiTaoThanhDieuHuong()
        {
            flowDanhSachCauHoi.Controls.Clear();
            danhSachCauHoi = danhSachCauHoi.OrderBy(x => x.STT).ToList();
            foreach (var cauHoi in danhSachCauHoi)
            {
                Button btn = new Button();
                btn.Text = cauHoi.STT.ToString();
                btn.Width = 45;
                btn.Height = 40;
                btn.Margin = new Padding(3);
                btn.BackColor = Color.WhiteSmoke;
                btn.Tag = cauHoi.STT - 1; // Lưu index vào Tag để truy xuất nhanh

                // Sự kiện khi bấm vào nút số
                btn.Click += (s, args) =>
                {
                    int index = (int)((Button)s).Tag;
                    LoadCauHoiLenUI(index);
                };

                flowDanhSachCauHoi.Controls.Add(btn);
            }
        }

        private void LoadCauHoiLenUI(int index)
        {
            if (index < 0 || index >= danhSachCauHoi.Count) return;

            // Bật cờ binding để chặn sự kiện CheckedChanged chạy lung tung
            isBindingData = true;
            currentCauHoiIndex = index;

            BoDe cauHoi = danhSachCauHoi[index];

            // Hiển thị nội dung
            lblCauHoiSo.Text = $"Câu số {cauHoi.STT}:";
            lblNoiDungCauHoi.Text = cauHoi.NOIDUNG;
            rdoA.Text = cauHoi.A;
            rdoB.Text = cauHoi.B;
            rdoC.Text = cauHoi.C;
            rdoD.Text = cauHoi.D;

            // Reset Radio buttons
            rdoA.Checked = false;
            rdoB.Checked = false;
            rdoC.Checked = false;
            rdoD.Checked = false;

            // Restore đáp án đã chọn (nếu có)
            if (cauHoi.DapAnDaChon == "A") rdoA.Checked = true;
            else if (cauHoi.DapAnDaChon == "B") rdoB.Checked = true;
            else if (cauHoi.DapAnDaChon == "C") rdoC.Checked = true;
            else if (cauHoi.DapAnDaChon == "D") rdoD.Checked = true;

            // Cập nhật trạng thái nút điều hướng (Disable nếu ở đầu/cuối)
            btnTruoc.Enabled = (index > 0);
            btnSau.Enabled = (index < danhSachCauHoi.Count - 1);

            // Highlight nút hiện tại trên thanh bên phải
            CapNhatMauSacThanhDieuHuong();

            isBindingData = false;
        }

        private void CapNhatMauSacThanhDieuHuong()
        {
            foreach (Control c in flowDanhSachCauHoi.Controls)
            {
                if (c is Button btn)
                {
                    int idx = (int)btn.Tag;

                    // Logic màu sắc:
                    // 1. Nếu đang chọn: Viền đậm hoặc màu cam (Ở đây dùng màu nền tạm)
                    // 2. Nếu đã làm: Màu Xanh
                    // 3. Chưa làm: Màu Trắng/Xám

                    if (danhSachCauHoi[idx].DapAnDaChon != "")
                    {
                        btn.BackColor = Color.LightGreen; // Đã làm
                    }
                    else
                    {
                        btn.BackColor = Color.WhiteSmoke; // Chưa làm
                    }

                    if (idx == currentCauHoiIndex)
                    {
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderColor = Color.Red;
                        btn.FlatAppearance.BorderSize = 2;
                    }
                    else
                    {
                        btn.FlatStyle = FlatStyle.Standard;
                    }
                }
            }
        }

        #endregion

        #region Xử lý Sự kiện (Events)

        private void BtnTruoc_Click(object sender, EventArgs e)
        {
            LoadCauHoiLenUI(currentCauHoiIndex - 1);
        }

        private void BtnSau_Click(object sender, EventArgs e)
        {
            LoadCauHoiLenUI(currentCauHoiIndex + 1);
        }

        private void Rdo_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu đang load dữ liệu từ code thì không xử lý logic này
            if (isBindingData) return;

            RadioButton rdo = sender as RadioButton;
            if (rdo == null || !rdo.Checked) return;

            // Lưu đáp án vào list
            string dapAnChon = rdo.Text; // Lưu ý: Ở đây rdo.Text đang là nội dung câu trả lời. 
                                         // Cách tốt hơn là check rdo name hoặc tag.

            if (rdo == rdoA) dapAnChon = "A";
            if (rdo == rdoB) dapAnChon = "B";
            if (rdo == rdoC) dapAnChon = "C";
            if (rdo == rdoD) dapAnChon = "D";

            danhSachCauHoi[currentCauHoiIndex].DapAnDaChon = dapAnChon;

            // Cập nhật màu xanh cho nút bên phải ngay lập tức
            CapNhatMauSacThanhDieuHuong();
        }

        private void TimerThi_Tick(object sender, EventArgs e)
        {
            thoiGianConLai--;
            CapNhatHienThiDongHo();

            if (thoiGianConLai <= 0)
            {
                timerThi.Stop();
                MessageBox.Show("Đã hết thời gian làm bài!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KetThucBaiThi();
            }
        }

        private void CapNhatHienThiDongHo()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(thoiGianConLai);
            lblTime.Text = timeSpan.ToString(@"mm\:ss");

            // Cảnh báo khi còn ít hơn 5 phút
            if (thoiGianConLai < 300)
            {
                lblTime.ForeColor = Color.Red;
            }
            else
            {
                lblTime.ForeColor = Color.Green;
            }
        }

        private void BtnNopBai_Click(object sender, EventArgs e)
        {
            // Đếm số câu chưa làm
            int soCauChuaLam = danhSachCauHoi.Count(x => x.DapAnDaChon == "");

            string canhBao = "";
            if (soCauChuaLam > 0)
            {
                canhBao = $"\nBạn còn {soCauChuaLam} câu chưa trả lời.";
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn nộp bài?{canhBao}",
                                              "Xác nhận nộp bài",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                timerThi.Stop();
                KetThucBaiThi();
            }
        }

        private void KetThucBaiThi()
        {
            // Tính điểm
            int soCauDung = 0;
            foreach (var cauHoi in danhSachCauHoi)
            {
                if (cauHoi.DapAnDaChon == cauHoi.DAPAN)
                {
                    soCauDung++;
                }
            }

            double diem = (double)soCauDung * 10 / danhSachCauHoi.Count;
            // Làm tròn 1 chữ số thập phân
            diem = Math.Round(diem, 1);

            BangDiem objBangDiem = new BangDiem
            {
                MASV = SystemInfo.CurrentSinhVien.MASV,
                MAMH = MAMH,
                LAN = LAN,
                NGAYTHI = DateTime.Now,
                DIEM = diem
            };
            if(SystemInfo.Role == DatabaseRole.SINHVIEN)
            {
                // Lưu kết quả thi vào bảng BANGDIEM
                bool luuThanhCong = LuuKetQuaThi(objBangDiem);
                if (!luuThanhCong)
                {
                    return;
                }
            }
 
            frmKetQua f = new frmKetQua();
            f.Lop = lblLop.Text;
            f.MonThi = lblMonThi.Text;    // Lấy từ Label
            f.Diem = diem;
            f.LanThi = LAN.ToString();
            f.KetQuaThi = this.danhSachCauHoi; // Truyền toàn bộ list câu hỏi sang
            f.MaximizeBox = true;
            f.WindowState = FormWindowState.Maximized;
            this.Hide(); // Ẩn form thi
            f.ShowDialog(); // Hiện form kết quả
            this.Close(); // Đóng form thi sau khi xem xong

        }
        private bool LuuKetQuaThi(BangDiem objBangDiem)
        {
            BangDiemController objBangDiemController = new BangDiemController();
            if (!objBangDiemController.Insert(objBangDiem))
            {
                MessageBox.Show($"Lưu kết quả thất bại! Vui lòng kiểm tra lại kết nối",
                "KẾT QUẢ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        #endregion
    }
}