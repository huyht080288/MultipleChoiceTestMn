namespace THITN.View
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNhapMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNhapKhoaLop = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNhapSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNhapGiaoVien = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNhapDe = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChuanBiThi = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThi = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnKetQua = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBangDiem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDanhSachDangKy = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblFooter = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.mnManagement,
            this.báoCáoToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1212, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnLogin,
            this.mnLogout,
            this.mnExit});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.menuToolStripMenuItem.Text = "Danh mục";
            // 
            // mnLogin
            // 
            this.mnLogin.Name = "mnLogin";
            this.mnLogin.Size = new System.Drawing.Size(132, 22);
            this.mnLogin.Text = "Đăng nhập";
            this.mnLogin.Click += new System.EventHandler(this.mnLogin_Click);
            // 
            // mnLogout
            // 
            this.mnLogout.Name = "mnLogout";
            this.mnLogout.Size = new System.Drawing.Size(132, 22);
            this.mnLogout.Text = "Đăng xuất";
            this.mnLogout.Click += new System.EventHandler(this.mnLogout_Click);
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.Size = new System.Drawing.Size(132, 22);
            this.mnExit.Text = "Thoát";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // mnManagement
            // 
            this.mnManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNhapMonHoc,
            this.btnNhapKhoaLop,
            this.btnNhapSinhVien,
            this.btnNhapGiaoVien,
            this.btnNhapDe,
            this.btnChuanBiThi,
            this.btnThi});
            this.mnManagement.Name = "mnManagement";
            this.mnManagement.Size = new System.Drawing.Size(79, 20);
            this.mnManagement.Text = "Chức Năng";
            // 
            // btnNhapMonHoc
            // 
            this.btnNhapMonHoc.Name = "btnNhapMonHoc";
            this.btnNhapMonHoc.Size = new System.Drawing.Size(180, 22);
            this.btnNhapMonHoc.Text = "Nhập môn học";
            // 
            // btnNhapKhoaLop
            // 
            this.btnNhapKhoaLop.Name = "btnNhapKhoaLop";
            this.btnNhapKhoaLop.Size = new System.Drawing.Size(180, 22);
            this.btnNhapKhoaLop.Text = "Nhập khoa-lớp";
            // 
            // btnNhapSinhVien
            // 
            this.btnNhapSinhVien.Name = "btnNhapSinhVien";
            this.btnNhapSinhVien.Size = new System.Drawing.Size(180, 22);
            this.btnNhapSinhVien.Text = "Nhập sinh viên";
            // 
            // btnNhapGiaoVien
            // 
            this.btnNhapGiaoVien.Name = "btnNhapGiaoVien";
            this.btnNhapGiaoVien.Size = new System.Drawing.Size(180, 22);
            this.btnNhapGiaoVien.Text = "Nhập giáo viên";
            // 
            // btnNhapDe
            // 
            this.btnNhapDe.Name = "btnNhapDe";
            this.btnNhapDe.Size = new System.Drawing.Size(180, 22);
            this.btnNhapDe.Text = "Nhập đề";
            // 
            // btnChuanBiThi
            // 
            this.btnChuanBiThi.Name = "btnChuanBiThi";
            this.btnChuanBiThi.Size = new System.Drawing.Size(180, 22);
            this.btnChuanBiThi.Text = "Chuẩn bị thi";
            // 
            // btnThi
            // 
            this.btnThi.Name = "btnThi";
            this.btnThi.Size = new System.Drawing.Size(180, 22);
            this.btnThi.Text = "Thi";
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnKetQua,
            this.btnBangDiem,
            this.btnDanhSachDangKy});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.báoCáoToolStripMenuItem.Text = "Báo Cáo";
            // 
            // btnKetQua
            // 
            this.btnKetQua.Name = "btnKetQua";
            this.btnKetQua.Size = new System.Drawing.Size(182, 22);
            this.btnKetQua.Text = "Kết quả thi";
            // 
            // btnBangDiem
            // 
            this.btnBangDiem.Name = "btnBangDiem";
            this.btnBangDiem.Size = new System.Drawing.Size(182, 22);
            this.btnBangDiem.Text = "Bảng điểm môn học";
            // 
            // btnDanhSachDangKy
            // 
            this.btnDanhSachDangKy.Name = "btnDanhSachDangKy";
            this.btnDanhSachDangKy.Size = new System.Drawing.Size(182, 22);
            this.btnDanhSachDangKy.Text = "Danh sách đăng ký";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.infoToolStripMenuItem.Text = "Thông Tin";
            // 
            // helpsToolStripMenuItem
            // 
            this.helpsToolStripMenuItem.Name = "helpsToolStripMenuItem";
            this.helpsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.helpsToolStripMenuItem.Text = "Trợ giúp";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.aboutToolStripMenuItem.Text = "Thông tin ứng dụng";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFooter});
            this.statusStrip1.Location = new System.Drawing.Point(0, 592);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1212, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblFooter
            // 
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(118, 17);
            this.lblFooter.Text = "toolStripStatusLabel1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 614);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Hệ thống Thi Trắc nghiệm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnLogout;
        private System.Windows.Forms.ToolStripMenuItem mnExit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblFooter;
        private System.Windows.Forms.ToolStripMenuItem mnLogin;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnManagement;
        private System.Windows.Forms.ToolStripMenuItem btnThi;
        private System.Windows.Forms.ToolStripMenuItem btnChuanBiThi;
        private System.Windows.Forms.ToolStripMenuItem btnNhapDe;
        private System.Windows.Forms.ToolStripMenuItem btnNhapSinhVien;
        private System.Windows.Forms.ToolStripMenuItem btnNhapKhoaLop;
        private System.Windows.Forms.ToolStripMenuItem btnNhapMonHoc;
        private System.Windows.Forms.ToolStripMenuItem btnNhapGiaoVien;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnKetQua;
        private System.Windows.Forms.ToolStripMenuItem btnBangDiem;
        private System.Windows.Forms.ToolStripMenuItem btnDanhSachDangKy;
    }
}