using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using THITN.View;

namespace THITN.Views
{
    public partial class frmKetQua : Form
    {
        // Nhận dữ liệu từ form Thi
        public List<frmThi.CauHoi> KetQuaThi { get; set; }
        public string HoTen { get; set; }
        public string MonThi { get; set; }
        public double Diem { get; set; }
        public string NgayThi { get; set; }
        public string LanThi { get; set; }
        public string Lop { get; set; }

        public frmKetQua()
        {
            InitializeComponent();
            this.Load += FrmKetQua_Load;
            btnThoat.Click += (s, e) => this.Close();

            // Xử lý tô màu dòng đúng/sai
            dgvKetQua.CellFormatting += DgvKetQua_CellFormatting;
        }

        private void FrmKetQua_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin chung
            LblLop.Text = Lop;
            lblHoTen.Text = HoTen;
            lblMonThi.Text = MonThi;
            lblDiemSo.Text = $"{Diem} ĐIỂM";
            lblNgayThi.Text = $"Ngày thi: {NgayThi}";
            lblLanThi.Text = $"Lần thi: {LanThi}";
            lblNgayThi.Text = DateTime.Now.ToString("dd/mm/yyyy");
            // Hiển thị danh sách câu hỏi
            LoadDanhSachKetQua();
        }

        private void LoadDanhSachKetQua()
        {
            if (KetQuaThi == null) return;

            // Tạo DataTable để bind lên lưới (cho dễ custom cột)
            DataTable dt = new DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("NoiDung");
            dt.Columns.Add("CacLuaChon");
            dt.Columns.Add("DapAn");
            dt.Columns.Add("DaChon");
            dt.Columns.Add("KetQua"); // Cột ẩn dùng để tô màu

            foreach (var cau in KetQuaThi)
            {
                // Format cột "Các lựa chọn" theo yêu cầu đề (A., B., C., D.)
                string cacLuaChon = $"A. {cau.A}\nB. {cau.B}\nC. {cau.C}\nD. {cau.D}";

                string ketQua = (cau.DapAnDaChon == cau.DapAnDung) ? "Đúng" : "Sai";

                dt.Rows.Add(
                    cau.STT,
                    cau.NoiDung,
                    cacLuaChon,
                    cau.DapAnDung,
                    cau.DapAnDaChon,
                    ketQua
                );
            }

            dgvKetQua.DataSource = dt;

            // Format hiển thị cột
            dgvKetQua.Columns["STT"].Width = 50;
            dgvKetQua.Columns["DapAn"].Width = 80;
            dgvKetQua.Columns["DaChon"].Width = 80;
            dgvKetQua.Columns["KetQua"].Visible = false; // Ẩn cột trạng thái

            dgvKetQua.Columns["NoiDung"].HeaderText = "Nội dung câu hỏi";
            dgvKetQua.Columns["CacLuaChon"].HeaderText = "Các lựa chọn";
            dgvKetQua.Columns["DapAn"].HeaderText = "Đáp án";
            dgvKetQua.Columns["DaChon"].HeaderText = "Đã chọn";

            // Wrap text cho các cột nội dung dài
            dgvKetQua.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvKetQua.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void DgvKetQua_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Tô màu dựa trên kết quả Đúng/Sai
            if (dgvKetQua.Rows[e.RowIndex].Cells["KetQua"].Value.ToString() == "Sai")
            {
                // Nếu sai thì tô nền hồng nhạt
                e.CellStyle.BackColor = Color.MistyRose;
                e.CellStyle.SelectionBackColor = Color.Red;
            }
            else
            {
                // Nếu đúng tô nền xanh nhạt
                e.CellStyle.BackColor = Color.Honeydew;
                e.CellStyle.SelectionBackColor = Color.Green;
            }
        }
    }
}