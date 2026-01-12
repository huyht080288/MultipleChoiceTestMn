namespace THITN.Views
{
    partial class frmChonMonThi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.lblSinhVien = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvLichThi = new System.Windows.Forms.DataGridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnBatDauThi = new System.Windows.Forms.Button();
            this.grpBoLoc = new System.Windows.Forms.GroupBox();
            this.cbbLanThi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNgayThi = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbMonHoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThi)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.grpBoLoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.lblLop);
            this.pnlTop.Controls.Add(this.lblSinhVien);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(778, 91);
            this.pnlTop.TabIndex = 0;
            // 
            // lblSinhVien
            // 
            this.lblSinhVien.AutoSize = true;
            this.lblSinhVien.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinhVien.Location = new System.Drawing.Point(17, 62);
            this.lblSinhVien.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSinhVien.Name = "lblSinhVien";
            this.lblSinhVien.Size = new System.Drawing.Size(133, 19);
            this.lblSinhVien.TabIndex = 1;
            this.lblSinhVien.Text = "Sinh viên: ... - Lớp: ...";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(15, 7);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(288, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DANH SÁCH ĐĂNG KÝ THI";
            // 
            // dgvLichThi
            // 
            this.dgvLichThi.AllowUserToAddRows = false;
            this.dgvLichThi.AllowUserToDeleteRows = false;
            this.dgvLichThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichThi.ColumnHeadersHeight = 29;
            this.dgvLichThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichThi.Location = new System.Drawing.Point(0, 160);
            this.dgvLichThi.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLichThi.MultiSelect = false;
            this.dgvLichThi.Name = "dgvLichThi";
            this.dgvLichThi.ReadOnly = true;
            this.dgvLichThi.RowHeadersVisible = false;
            this.dgvLichThi.RowTemplate.Height = 24;
            this.dgvLichThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichThi.Size = new System.Drawing.Size(778, 281);
            this.dgvLichThi.TabIndex = 2;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnThoat);
            this.pnlBottom.Controls.Add(this.btnBatDauThi);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 441);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(778, 57);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(680, 12);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 32);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnBatDauThi
            // 
            this.btnBatDauThi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatDauThi.BackColor = System.Drawing.Color.ForestGreen;
            this.btnBatDauThi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatDauThi.ForeColor = System.Drawing.Color.White;
            this.btnBatDauThi.Location = new System.Drawing.Point(548, 12);
            this.btnBatDauThi.Margin = new System.Windows.Forms.Padding(2);
            this.btnBatDauThi.Name = "btnBatDauThi";
            this.btnBatDauThi.Size = new System.Drawing.Size(112, 32);
            this.btnBatDauThi.TabIndex = 0;
            this.btnBatDauThi.Text = "BẮT ĐẦU THI";
            this.btnBatDauThi.UseVisualStyleBackColor = false;
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.BackColor = System.Drawing.Color.White;
            this.grpBoLoc.Controls.Add(this.cbbLanThi);
            this.grpBoLoc.Controls.Add(this.label3);
            this.grpBoLoc.Controls.Add(this.dtpNgayThi);
            this.grpBoLoc.Controls.Add(this.label2);
            this.grpBoLoc.Controls.Add(this.cbbMonHoc);
            this.grpBoLoc.Controls.Add(this.label1);
            this.grpBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoLoc.Location = new System.Drawing.Point(0, 91);
            this.grpBoLoc.Margin = new System.Windows.Forms.Padding(2);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Padding = new System.Windows.Forms.Padding(2);
            this.grpBoLoc.Size = new System.Drawing.Size(778, 69);
            this.grpBoLoc.TabIndex = 1;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Thông tin đăng ký thi";
            // 
            // cbbLanThi
            // 
            this.cbbLanThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLanThi.FormattingEnabled = true;
            this.cbbLanThi.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbbLanThi.Location = new System.Drawing.Point(535, 24);
            this.cbbLanThi.Margin = new System.Windows.Forms.Padding(2);
            this.cbbLanThi.Name = "cbbLanThi";
            this.cbbLanThi.Size = new System.Drawing.Size(58, 23);
            this.cbbLanThi.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lần thi:";
            // 
            // dtpNgayThi
            // 
            this.dtpNgayThi.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayThi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayThi.Location = new System.Drawing.Point(334, 24);
            this.dtpNgayThi.Margin = new System.Windows.Forms.Padding(2);
            this.dtpNgayThi.Name = "dtpNgayThi";
            this.dtpNgayThi.Size = new System.Drawing.Size(126, 23);
            this.dtpNgayThi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày thi:";
            // 
            // cbbMonHoc
            // 
            this.cbbMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMonHoc.FormattingEnabled = true;
            this.cbbMonHoc.Location = new System.Drawing.Point(75, 24);
            this.cbbMonHoc.Margin = new System.Windows.Forms.Padding(2);
            this.cbbMonHoc.Name = "cbbMonHoc";
            this.cbbMonHoc.Size = new System.Drawing.Size(183, 23);
            this.cbbMonHoc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Môn học:";
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLop.Location = new System.Drawing.Point(17, 43);
            this.lblLop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(178, 19);
            this.lblLop.TabIndex = 3;
            this.lblLop.Text = "Lớp: CNTT1 - K23DTCNN02";
            // 
            // frmChonMonThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 498);
            this.Controls.Add(this.dgvLichThi);
            this.Controls.Add(this.grpBoLoc);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmChonMonThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Môn Thi";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThi)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblSinhVien;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvLichThi;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnBatDauThi;
        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.ComboBox cbbLanThi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayThi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbMonHoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLop;
    }
}