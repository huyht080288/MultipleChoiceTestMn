namespace THITN.Views
{
    partial class frmChuanBiThi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.grpNhapLieu = new System.Windows.Forms.GroupBox();
            this.nudThoiGian = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudSoCau = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbLanThi = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpNgayThi = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbTrinhDo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbMonHoc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbLop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDangKy = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpNhapLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiGian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoCau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.btnThoat);
            this.pnlTop.Controls.Add(this.btnReload);
            this.pnlTop.Controls.Add(this.btnPhucHoi);
            this.pnlTop.Controls.Add(this.btnGhi);
            this.pnlTop.Controls.Add(this.btnSua);
            this.pnlTop.Controls.Add(this.btnXoa);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(712, 49);
            this.pnlTop.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Location = new System.Drawing.Point(420, 10);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(60, 28);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReload.Location = new System.Drawing.Point(356, 10);
            this.btnReload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(60, 28);
            this.btnReload.TabIndex = 5;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPhucHoi.Location = new System.Drawing.Point(278, 10);
            this.btnPhucHoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(71, 28);
            this.btnPhucHoi.TabIndex = 4;
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.UseVisualStyleBackColor = true;
            // 
            // btnGhi
            // 
            this.btnGhi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGhi.ForeColor = System.Drawing.Color.Blue;
            this.btnGhi.Location = new System.Drawing.Point(213, 10);
            this.btnGhi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(60, 28);
            this.btnGhi.TabIndex = 3;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSua.Location = new System.Drawing.Point(148, 10);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(60, 28);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.Red;
            this.btnXoa.Location = new System.Drawing.Point(84, 10);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(60, 28);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.Green;
            this.btnThem.Location = new System.Drawing.Point(20, 10);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(60, 28);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // grpNhapLieu
            // 
            this.grpNhapLieu.Controls.Add(this.nudThoiGian);
            this.grpNhapLieu.Controls.Add(this.label7);
            this.grpNhapLieu.Controls.Add(this.nudSoCau);
            this.grpNhapLieu.Controls.Add(this.label6);
            this.grpNhapLieu.Controls.Add(this.cbbLanThi);
            this.grpNhapLieu.Controls.Add(this.label5);
            this.grpNhapLieu.Controls.Add(this.dtpNgayThi);
            this.grpNhapLieu.Controls.Add(this.label4);
            this.grpNhapLieu.Controls.Add(this.cbbTrinhDo);
            this.grpNhapLieu.Controls.Add(this.label3);
            this.grpNhapLieu.Controls.Add(this.cbbMonHoc);
            this.grpNhapLieu.Controls.Add(this.label2);
            this.grpNhapLieu.Controls.Add(this.cbbLop);
            this.grpNhapLieu.Controls.Add(this.label1);
            this.grpNhapLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNhapLieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNhapLieu.Location = new System.Drawing.Point(0, 49);
            this.grpNhapLieu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpNhapLieu.Name = "grpNhapLieu";
            this.grpNhapLieu.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpNhapLieu.Size = new System.Drawing.Size(712, 122);
            this.grpNhapLieu.TabIndex = 1;
            this.grpNhapLieu.TabStop = false;
            this.grpNhapLieu.Text = "Thông tin Đăng ký Lịch Thi";
            // 
            // nudThoiGian
            // 
            this.nudThoiGian.Location = new System.Drawing.Point(465, 77);
            this.nudThoiGian.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudThoiGian.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudThoiGian.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudThoiGian.Name = "nudThoiGian";
            this.nudThoiGian.Size = new System.Drawing.Size(90, 23);
            this.nudThoiGian.TabIndex = 13;
            this.nudThoiGian.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(405, 80);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Thời gian:";
            // 
            // nudSoCau
            // 
            this.nudSoCau.Location = new System.Drawing.Point(285, 77);
            this.nudSoCau.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudSoCau.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSoCau.Name = "nudSoCau";
            this.nudSoCau.Size = new System.Drawing.Size(90, 23);
            this.nudSoCau.TabIndex = 11;
            this.nudSoCau.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Số câu:";
            // 
            // cbbLanThi
            // 
            this.cbbLanThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLanThi.FormattingEnabled = true;
            this.cbbLanThi.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbbLanThi.Location = new System.Drawing.Point(75, 77);
            this.cbbLanThi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbLanThi.Name = "cbbLanThi";
            this.cbbLanThi.Size = new System.Drawing.Size(91, 23);
            this.cbbLanThi.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Lần thi:";
            // 
            // dtpNgayThi
            // 
            this.dtpNgayThi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayThi.Location = new System.Drawing.Point(555, 28);
            this.dtpNgayThi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpNgayThi.Name = "dtpNgayThi";
            this.dtpNgayThi.Size = new System.Drawing.Size(106, 23);
            this.dtpNgayThi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(495, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ngày thi:";
            // 
            // cbbTrinhDo
            // 
            this.cbbTrinhDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTrinhDo.FormattingEnabled = true;
            this.cbbTrinhDo.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cbbTrinhDo.Location = new System.Drawing.Point(405, 28);
            this.cbbTrinhDo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbTrinhDo.Name = "cbbTrinhDo";
            this.cbbTrinhDo.Size = new System.Drawing.Size(61, 23);
            this.cbbTrinhDo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trình độ:";
            // 
            // cbbMonHoc
            // 
            this.cbbMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMonHoc.FormattingEnabled = true;
            this.cbbMonHoc.Location = new System.Drawing.Point(240, 28);
            this.cbbMonHoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbMonHoc.Name = "cbbMonHoc";
            this.cbbMonHoc.Size = new System.Drawing.Size(91, 23);
            this.cbbMonHoc.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Môn học:";
            // 
            // cbbLop
            // 
            this.cbbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLop.FormattingEnabled = true;
            this.cbbLop.Location = new System.Drawing.Point(75, 28);
            this.cbbLop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbLop.Name = "cbbLop";
            this.cbbLop.Size = new System.Drawing.Size(91, 23);
            this.cbbLop.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lớp:";
            // 
            // dgvDangKy
            // 
            this.dgvDangKy.AllowUserToAddRows = false;
            this.dgvDangKy.AllowUserToDeleteRows = false;
            this.dgvDangKy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDangKy.BackgroundColor = System.Drawing.Color.White;
            this.dgvDangKy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDangKy.Location = new System.Drawing.Point(0, 171);
            this.dgvDangKy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDangKy.MultiSelect = false;
            this.dgvDangKy.Name = "dgvDangKy";
            this.dgvDangKy.ReadOnly = true;
            this.dgvDangKy.RowHeadersVisible = false;
            this.dgvDangKy.RowHeadersWidth = 51;
            this.dgvDangKy.RowTemplate.Height = 24;
            this.dgvDangKy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDangKy.Size = new System.Drawing.Size(712, 235);
            this.dgvDangKy.TabIndex = 2;
            // 
            // frmChuanBiThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 406);
            this.Controls.Add(this.dgvDangKy);
            this.Controls.Add(this.grpNhapLieu);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmChuanBiThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Lịch Thi (Giáo Viên Đăng Ký)";
            this.pnlTop.ResumeLayout(false);
            this.grpNhapLieu.ResumeLayout(false);
            this.grpNhapLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiGian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoCau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnPhucHoi;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox grpNhapLieu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbLop;
        private System.Windows.Forms.ComboBox cbbMonHoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayThi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbTrinhDo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSoCau;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbLanThi;
        private System.Windows.Forms.NumericUpDown nudThoiGian;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvDangKy;
    }
}