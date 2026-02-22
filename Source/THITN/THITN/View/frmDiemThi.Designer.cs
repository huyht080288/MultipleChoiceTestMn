namespace THITN.Views
{
    partial class frmDiemThi
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.cbbLanThi = new System.Windows.Forms.ComboBox();
            this.lblLanThi = new System.Windows.Forms.Label();
            this.cbbMonHoc = new System.Windows.Forms.ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.cbbLop = new System.Windows.Forms.ComboBox();
            this.lblLop = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvBangDiem = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(712, 57);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(17, 13);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(252, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BẢNG ĐIỂM MÔN HỌC";
            // 
            // grpFilter
            // 
            this.grpFilter.BackColor = System.Drawing.Color.White;
            this.grpFilter.Controls.Add(this.btnInBaoCao);
            this.grpFilter.Controls.Add(this.btnXem);
            this.grpFilter.Controls.Add(this.cbbLanThi);
            this.grpFilter.Controls.Add(this.lblLanThi);
            this.grpFilter.Controls.Add(this.cbbMonHoc);
            this.grpFilter.Controls.Add(this.lblMonHoc);
            this.grpFilter.Controls.Add(this.cbbLop);
            this.grpFilter.Controls.Add(this.lblLop);
            this.grpFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFilter.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.Location = new System.Drawing.Point(0, 57);
            this.grpFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpFilter.Size = new System.Drawing.Size(712, 81);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Chọn thông tin báo cáo";
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.BackColor = System.Drawing.Color.ForestGreen;
            this.btnInBaoCao.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnInBaoCao.Location = new System.Drawing.Point(604, 29);
            this.btnInBaoCao.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(90, 32);
            this.btnInBaoCao.TabIndex = 7;
            this.btnInBaoCao.Text = "In Báo Cáo";
            this.btnInBaoCao.UseVisualStyleBackColor = false;
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.SteelBlue;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(507, 29);
            this.btnXem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(90, 32);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem Trước";
            this.btnXem.UseVisualStyleBackColor = false;
            // 
            // cbbLanThi
            // 
            this.cbbLanThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLanThi.FormattingEnabled = true;
            this.cbbLanThi.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbbLanThi.Location = new System.Drawing.Point(434, 34);
            this.cbbLanThi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbLanThi.Name = "cbbLanThi";
            this.cbbLanThi.Size = new System.Drawing.Size(50, 27);
            this.cbbLanThi.TabIndex = 5;
            // 
            // lblLanThi
            // 
            this.lblLanThi.AutoSize = true;
            this.lblLanThi.Location = new System.Drawing.Point(378, 37);
            this.lblLanThi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLanThi.Name = "lblLanThi";
            this.lblLanThi.Size = new System.Drawing.Size(54, 19);
            this.lblLanThi.TabIndex = 4;
            this.lblLanThi.Text = "Lần thi:";
            // 
            // cbbMonHoc
            // 
            this.cbbMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMonHoc.FormattingEnabled = true;
            this.cbbMonHoc.Location = new System.Drawing.Point(231, 34);
            this.cbbMonHoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbMonHoc.Name = "cbbMonHoc";
            this.cbbMonHoc.Size = new System.Drawing.Size(136, 27);
            this.cbbMonHoc.TabIndex = 3;
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(165, 37);
            this.lblMonHoc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(67, 19);
            this.lblMonHoc.TabIndex = 2;
            this.lblMonHoc.Text = "Môn học:";
            // 
            // cbbLop
            // 
            this.cbbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLop.FormattingEnabled = true;
            this.cbbLop.Location = new System.Drawing.Point(51, 34);
            this.cbbLop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbLop.Name = "cbbLop";
            this.cbbLop.Size = new System.Drawing.Size(102, 27);
            this.cbbLop.TabIndex = 1;
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(14, 37);
            this.lblLop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(35, 19);
            this.lblLop.TabIndex = 0;
            this.lblLop.Text = "Lớp:";
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBottom.Controls.Add(this.btnThoat);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 392);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(712, 57);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(620, 12);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 32);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // dgvBangDiem
            // 
            this.dgvBangDiem.AllowUserToAddRows = false;
            this.dgvBangDiem.AllowUserToDeleteRows = false;
            this.dgvBangDiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBangDiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvBangDiem.ColumnHeadersHeight = 29;
            this.dgvBangDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBangDiem.Location = new System.Drawing.Point(0, 138);
            this.dgvBangDiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvBangDiem.Name = "dgvBangDiem";
            this.dgvBangDiem.ReadOnly = true;
            this.dgvBangDiem.RowHeadersVisible = false;
            this.dgvBangDiem.RowHeadersWidth = 51;
            this.dgvBangDiem.RowTemplate.Height = 24;
            this.dgvBangDiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBangDiem.Size = new System.Drawing.Size(712, 254);
            this.dgvBangDiem.TabIndex = 3;
            // 
            // frmDiemThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 449);
            this.Controls.Add(this.dgvBangDiem);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmDiemThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo Bảng Điểm";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBangDiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cbbLanThi;
        private System.Windows.Forms.Label lblLanThi;
        private System.Windows.Forms.ComboBox cbbMonHoc;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.ComboBox cbbLop;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvBangDiem;
    }
}