namespace THITN.View
{
    partial class frmNhapDe
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnPhucHoi = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.grpNhapLieu = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbDAPAN = new System.Windows.Forms.ComboBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNOIDUNG = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbTRINHDO = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbMAMH = new System.Windows.Forms.ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.dgvBoDe = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpNhapLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoDe)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTop.Controls.Add(this.btnThoat);
            this.pnlTop.Controls.Add(this.btnReload);
            this.pnlTop.Controls.Add(this.btnPhucHoi);
            this.pnlTop.Controls.Add(this.btnGhi);
            this.pnlTop.Controls.Add(this.btnXoa);
            this.pnlTop.Controls.Add(this.btnThem);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1084, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThoat.Location = new System.Drawing.Point(520, 12);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 35);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReload.Location = new System.Drawing.Point(420, 12);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(90, 35);
            this.btnReload.TabIndex = 4;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPhucHoi.Location = new System.Drawing.Point(320, 12);
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.Size = new System.Drawing.Size(90, 35);
            this.btnPhucHoi.TabIndex = 3;
            this.btnPhucHoi.Text = "Phục hồi";
            this.btnPhucHoi.UseVisualStyleBackColor = true;
            // 
            // btnGhi
            // 
            this.btnGhi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGhi.ForeColor = System.Drawing.Color.Blue;
            this.btnGhi.Location = new System.Drawing.Point(220, 12);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(90, 35);
            this.btnGhi.TabIndex = 2;
            this.btnGhi.Text = "Ghi (Lưu)";
            this.btnGhi.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.Red;
            this.btnXoa.Location = new System.Drawing.Point(120, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 35);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.Green;
            this.btnThem.Location = new System.Drawing.Point(20, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 35);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // grpNhapLieu
            // 
            this.grpNhapLieu.Controls.Add(this.label7);
            this.grpNhapLieu.Controls.Add(this.cbbDAPAN);
            this.grpNhapLieu.Controls.Add(this.txtD);
            this.grpNhapLieu.Controls.Add(this.label6);
            this.grpNhapLieu.Controls.Add(this.txtC);
            this.grpNhapLieu.Controls.Add(this.label5);
            this.grpNhapLieu.Controls.Add(this.txtB);
            this.grpNhapLieu.Controls.Add(this.label4);
            this.grpNhapLieu.Controls.Add(this.txtA);
            this.grpNhapLieu.Controls.Add(this.label3);
            this.grpNhapLieu.Controls.Add(this.txtNOIDUNG);
            this.grpNhapLieu.Controls.Add(this.label2);
            this.grpNhapLieu.Controls.Add(this.cbbTRINHDO);
            this.grpNhapLieu.Controls.Add(this.label1);
            this.grpNhapLieu.Controls.Add(this.cbbMAMH);
            this.grpNhapLieu.Controls.Add(this.lblMonHoc);
            this.grpNhapLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNhapLieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNhapLieu.Location = new System.Drawing.Point(0, 60);
            this.grpNhapLieu.Name = "grpNhapLieu";
            this.grpNhapLieu.Size = new System.Drawing.Size(1084, 250);
            this.grpNhapLieu.TabIndex = 1;
            this.grpNhapLieu.TabStop = false;
            this.grpNhapLieu.Text = "Thông tin chi tiết câu hỏi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(820, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Đáp án:";
            // 
            // cbbDAPAN
            // 
            this.cbbDAPAN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDAPAN.FormattingEnabled = true;
            this.cbbDAPAN.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.cbbDAPAN.Location = new System.Drawing.Point(890, 32);
            this.cbbDAPAN.Name = "cbbDAPAN";
            this.cbbDAPAN.Size = new System.Drawing.Size(90, 28);
            this.cbbDAPAN.TabIndex = 14;
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(580, 195);
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(400, 27);
            this.txtD.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(540, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "D:";
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(100, 195);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(400, 27);
            this.txtC.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "C:";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(580, 155);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(400, 27);
            this.txtB.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(540, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "B:";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(100, 155);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(400, 27);
            this.txtA.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "A:";
            // 
            // txtNOIDUNG
            // 
            this.txtNOIDUNG.Location = new System.Drawing.Point(100, 70);
            this.txtNOIDUNG.Name = "txtNOIDUNG";
            this.txtNOIDUNG.Size = new System.Drawing.Size(880, 70);
            this.txtNOIDUNG.TabIndex = 5;
            this.txtNOIDUNG.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nội dung:";
            // 
            // cbbTRINHDO
            // 
            this.cbbTRINHDO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTRINHDO.FormattingEnabled = true;
            this.cbbTRINHDO.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.cbbTRINHDO.Location = new System.Drawing.Point(430, 32);
            this.cbbTRINHDO.Name = "cbbTRINHDO";
            this.cbbTRINHDO.Size = new System.Drawing.Size(120, 28);
            this.cbbTRINHDO.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Trình độ:";
            // 
            // cbbMAMH
            // 
            this.cbbMAMH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMAMH.FormattingEnabled = true;
            this.cbbMAMH.Location = new System.Drawing.Point(100, 32);
            this.cbbMAMH.Name = "cbbMAMH";
            this.cbbMAMH.Size = new System.Drawing.Size(220, 28);
            this.cbbMAMH.TabIndex = 1;
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(20, 35);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(70, 20);
            this.lblMonHoc.TabIndex = 0;
            this.lblMonHoc.Text = "Môn học:";
            // 
            // dgvBoDe
            // 
            this.dgvBoDe.AllowUserToAddRows = false;
            this.dgvBoDe.AllowUserToDeleteRows = false;
            this.dgvBoDe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBoDe.BackgroundColor = System.Drawing.Color.White;
            this.dgvBoDe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoDe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBoDe.Location = new System.Drawing.Point(0, 310);
            this.dgvBoDe.Name = "dgvBoDe";
            this.dgvBoDe.ReadOnly = true;
            this.dgvBoDe.RowHeadersVisible = false;
            this.dgvBoDe.RowHeadersWidth = 51;
            this.dgvBoDe.RowTemplate.Height = 24;
            this.dgvBoDe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBoDe.Size = new System.Drawing.Size(1084, 351);
            this.dgvBoDe.TabIndex = 2;
            // 
            // frmNhapDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.dgvBoDe);
            this.Controls.Add(this.grpNhapLieu);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmNhapDe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Bộ Đề Thi (Giảng Viên)";
            this.pnlTop.ResumeLayout(false);
            this.grpNhapLieu.ResumeLayout(false);
            this.grpNhapLieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoDe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnPhucHoi;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox grpNhapLieu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbDAPAN;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtNOIDUNG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbTRINHDO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbMAMH;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.DataGridView dgvBoDe;
    }
}