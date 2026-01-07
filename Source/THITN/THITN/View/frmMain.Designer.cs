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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblFooter = new System.Windows.Forms.ToolStripStatusLabel();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.examToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tạoĐềToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpĐềToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpSinhViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpKhoalớpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpMônHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpGiáoViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bảngĐiểmMônHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchĐăngKýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kếtQuảThiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnLogin.Size = new System.Drawing.Size(180, 22);
            this.mnLogin.Text = "Đăng nhập";
            this.mnLogin.Click += new System.EventHandler(this.mnLogin_Click);
            // 
            // mnLogout
            // 
            this.mnLogout.Name = "mnLogout";
            this.mnLogout.Size = new System.Drawing.Size(180, 22);
            this.mnLogout.Text = "Đăng xuất";
            this.mnLogout.Click += new System.EventHandler(this.mnLogout_Click);
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.Size = new System.Drawing.Size(180, 22);
            this.mnExit.Text = "Thoát";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
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
            // mnManagement
            // 
            this.mnManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpMônHọcToolStripMenuItem,
            this.nhậpKhoalớpToolStripMenuItem,
            this.nhậpSinhViênToolStripMenuItem,
            this.nhậpGiáoViênToolStripMenuItem,
            this.nhậpĐềToolStripMenuItem,
            this.tạoĐềToolStripMenuItem,
            this.examToolStripMenuItem});
            this.mnManagement.Name = "mnManagement";
            this.mnManagement.Size = new System.Drawing.Size(79, 20);
            this.mnManagement.Text = "Chức Năng";
            // 
            // examToolStripMenuItem
            // 
            this.examToolStripMenuItem.Name = "examToolStripMenuItem";
            this.examToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.examToolStripMenuItem.Text = "Thi";
            // 
            // tạoĐềToolStripMenuItem
            // 
            this.tạoĐềToolStripMenuItem.Name = "tạoĐềToolStripMenuItem";
            this.tạoĐềToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tạoĐềToolStripMenuItem.Text = "Chuẩn bị thi";
            // 
            // nhậpĐềToolStripMenuItem
            // 
            this.nhậpĐềToolStripMenuItem.Name = "nhậpĐềToolStripMenuItem";
            this.nhậpĐềToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nhậpĐềToolStripMenuItem.Text = "Nhập đề";
            // 
            // nhậpSinhViênToolStripMenuItem
            // 
            this.nhậpSinhViênToolStripMenuItem.Name = "nhậpSinhViênToolStripMenuItem";
            this.nhậpSinhViênToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nhậpSinhViênToolStripMenuItem.Text = "Nhập sinh viên";
            // 
            // nhậpKhoalớpToolStripMenuItem
            // 
            this.nhậpKhoalớpToolStripMenuItem.Name = "nhậpKhoalớpToolStripMenuItem";
            this.nhậpKhoalớpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nhậpKhoalớpToolStripMenuItem.Text = "Nhập khoa-lớp";
            // 
            // nhậpMônHọcToolStripMenuItem
            // 
            this.nhậpMônHọcToolStripMenuItem.Name = "nhậpMônHọcToolStripMenuItem";
            this.nhậpMônHọcToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nhậpMônHọcToolStripMenuItem.Text = "Nhập môn học";
            // 
            // nhậpGiáoViênToolStripMenuItem
            // 
            this.nhậpGiáoViênToolStripMenuItem.Name = "nhậpGiáoViênToolStripMenuItem";
            this.nhậpGiáoViênToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nhậpGiáoViênToolStripMenuItem.Text = "Nhập giáo viên";
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kếtQuảThiToolStripMenuItem,
            this.bảngĐiểmMônHọcToolStripMenuItem,
            this.danhSáchĐăngKýToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.báoCáoToolStripMenuItem.Text = "Báo Cáo";
            // 
            // bảngĐiểmMônHọcToolStripMenuItem
            // 
            this.bảngĐiểmMônHọcToolStripMenuItem.Name = "bảngĐiểmMônHọcToolStripMenuItem";
            this.bảngĐiểmMônHọcToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.bảngĐiểmMônHọcToolStripMenuItem.Text = "Bảng điểm môn học";
            // 
            // danhSáchĐăngKýToolStripMenuItem
            // 
            this.danhSáchĐăngKýToolStripMenuItem.Name = "danhSáchĐăngKýToolStripMenuItem";
            this.danhSáchĐăngKýToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.danhSáchĐăngKýToolStripMenuItem.Text = "Danh sách đăng ký";
            // 
            // kếtQuảThiToolStripMenuItem
            // 
            this.kếtQuảThiToolStripMenuItem.Name = "kếtQuảThiToolStripMenuItem";
            this.kếtQuảThiToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.kếtQuảThiToolStripMenuItem.Text = "Kết quả thi";
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
        private System.Windows.Forms.ToolStripMenuItem examToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tạoĐềToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpĐềToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpSinhViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpKhoalớpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpMônHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpGiáoViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kếtQuảThiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bảngĐiểmMônHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhSáchĐăngKýToolStripMenuItem;
    }
}