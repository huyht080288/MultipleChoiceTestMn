namespace THITN.View
{
    partial class frmThi
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
            this.components = new System.ComponentModel.Container();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblMonThi = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblThongTinSV = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.flowDanhSachCauHoi = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDanhSachCauHoi = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnNopBai = new System.Windows.Forms.Button();
            this.btnSau = new System.Windows.Forms.Button();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gbDapAn = new System.Windows.Forms.GroupBox();
            this.rdoD = new System.Windows.Forms.RadioButton();
            this.rdoC = new System.Windows.Forms.RadioButton();
            this.rdoB = new System.Windows.Forms.RadioButton();
            this.rdoA = new System.Windows.Forms.RadioButton();
            this.lblNoiDungCauHoi = new System.Windows.Forms.Label();
            this.lblCauHoiSo = new System.Windows.Forms.Label();
            this.timerThi = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.gbDapAn.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblMonThi);
            this.pnlHeader.Controls.Add(this.lblLop);
            this.pnlHeader.Controls.Add(this.lblThongTinSV);
            this.pnlHeader.Controls.Add(this.lblTime);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(964, 115);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblMonThi
            // 
            this.lblMonThi.AutoSize = true;
            this.lblMonThi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonThi.ForeColor = System.Drawing.Color.Navy;
            this.lblMonThi.Location = new System.Drawing.Point(13, 49);
            this.lblMonThi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonThi.Name = "lblMonThi";
            this.lblMonThi.Size = new System.Drawing.Size(189, 21);
            this.lblMonThi.TabIndex = 3;
            this.lblMonThi.Text = "Môn thi: Cơ sở dữ liệu...";
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLop.Location = new System.Drawing.Point(13, 5);
            this.lblLop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(178, 19);
            this.lblLop.TabIndex = 2;
            this.lblLop.Text = "Lớp: CNTT1 - K23DTCNN02";
            // 
            // lblThongTinSV
            // 
            this.lblThongTinSV.AutoSize = true;
            this.lblThongTinSV.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinSV.Location = new System.Drawing.Point(13, 28);
            this.lblThongTinSV.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblThongTinSV.Name = "lblThongTinSV";
            this.lblThongTinSV.Size = new System.Drawing.Size(208, 19);
            this.lblThongTinSV.TabIndex = 2;
            this.lblThongTinSV.Text = "Sinh viên: Nguyễn Văn A - Lớp X";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Red;
            this.lblTime.Location = new System.Drawing.Point(857, 28);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(88, 37);
            this.lblTime.TabIndex = 1;
            this.lblTime.Text = "00:00";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(846, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thời gian còn lại";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRight.Controls.Add(this.flowDanhSachCauHoi);
            this.pnlRight.Controls.Add(this.lblDanhSachCauHoi);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(776, 115);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(188, 553);
            this.pnlRight.TabIndex = 1;
            // 
            // flowDanhSachCauHoi
            // 
            this.flowDanhSachCauHoi.AutoScroll = true;
            this.flowDanhSachCauHoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowDanhSachCauHoi.Location = new System.Drawing.Point(0, 28);
            this.flowDanhSachCauHoi.Margin = new System.Windows.Forms.Padding(2);
            this.flowDanhSachCauHoi.Name = "flowDanhSachCauHoi";
            this.flowDanhSachCauHoi.Padding = new System.Windows.Forms.Padding(4);
            this.flowDanhSachCauHoi.Size = new System.Drawing.Size(186, 523);
            this.flowDanhSachCauHoi.TabIndex = 1;
            // 
            // lblDanhSachCauHoi
            // 
            this.lblDanhSachCauHoi.BackColor = System.Drawing.Color.Gainsboro;
            this.lblDanhSachCauHoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDanhSachCauHoi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDanhSachCauHoi.Location = new System.Drawing.Point(0, 0);
            this.lblDanhSachCauHoi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDanhSachCauHoi.Name = "lblDanhSachCauHoi";
            this.lblDanhSachCauHoi.Size = new System.Drawing.Size(186, 28);
            this.lblDanhSachCauHoi.TabIndex = 0;
            this.lblDanhSachCauHoi.Text = "Danh sách câu hỏi";
            this.lblDanhSachCauHoi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.btnNopBai);
            this.pnlBottom.Controls.Add(this.btnSau);
            this.pnlBottom.Controls.Add(this.btnTruoc);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 606);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(776, 62);
            this.pnlBottom.TabIndex = 2;
            // 
            // btnNopBai
            // 
            this.btnNopBai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNopBai.BackColor = System.Drawing.Color.Tomato;
            this.btnNopBai.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNopBai.ForeColor = System.Drawing.Color.White;
            this.btnNopBai.Location = new System.Drawing.Point(661, 11);
            this.btnNopBai.Margin = new System.Windows.Forms.Padding(2);
            this.btnNopBai.Name = "btnNopBai";
            this.btnNopBai.Size = new System.Drawing.Size(95, 39);
            this.btnNopBai.TabIndex = 2;
            this.btnNopBai.Text = "NỘP BÀI";
            this.btnNopBai.UseVisualStyleBackColor = false;
            // 
            // btnSau
            // 
            this.btnSau.BackColor = System.Drawing.Color.White;
            this.btnSau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSau.Location = new System.Drawing.Point(275, 15);
            this.btnSau.Margin = new System.Windows.Forms.Padding(2);
            this.btnSau.Name = "btnSau";
            this.btnSau.Size = new System.Drawing.Size(82, 32);
            this.btnSau.TabIndex = 1;
            this.btnSau.Text = "Câu sau >";
            this.btnSau.UseVisualStyleBackColor = false;
            // 
            // btnTruoc
            // 
            this.btnTruoc.BackColor = System.Drawing.Color.White;
            this.btnTruoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTruoc.Location = new System.Drawing.Point(177, 15);
            this.btnTruoc.Margin = new System.Windows.Forms.Padding(2);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(82, 32);
            this.btnTruoc.TabIndex = 0;
            this.btnTruoc.Text = "< Câu trước";
            this.btnTruoc.UseVisualStyleBackColor = false;
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.gbDapAn);
            this.pnlMain.Controls.Add(this.lblNoiDungCauHoi);
            this.pnlMain.Controls.Add(this.lblCauHoiSo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 115);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.pnlMain.Size = new System.Drawing.Size(776, 491);
            this.pnlMain.TabIndex = 3;
            // 
            // gbDapAn
            // 
            this.gbDapAn.Controls.Add(this.rdoD);
            this.gbDapAn.Controls.Add(this.rdoC);
            this.gbDapAn.Controls.Add(this.rdoB);
            this.gbDapAn.Controls.Add(this.rdoA);
            this.gbDapAn.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDapAn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDapAn.Location = new System.Drawing.Point(15, 134);
            this.gbDapAn.Margin = new System.Windows.Forms.Padding(2);
            this.gbDapAn.Name = "gbDapAn";
            this.gbDapAn.Padding = new System.Windows.Forms.Padding(2);
            this.gbDapAn.Size = new System.Drawing.Size(746, 205);
            this.gbDapAn.TabIndex = 2;
            this.gbDapAn.TabStop = false;
            this.gbDapAn.Text = "Chọn đáp án";
            // 
            // rdoD
            // 
            this.rdoD.AutoSize = true;
            this.rdoD.Location = new System.Drawing.Point(26, 148);
            this.rdoD.Margin = new System.Windows.Forms.Padding(2);
            this.rdoD.Name = "rdoD";
            this.rdoD.Size = new System.Drawing.Size(37, 23);
            this.rdoD.TabIndex = 3;
            this.rdoD.TabStop = true;
            this.rdoD.Text = "D";
            this.rdoD.UseVisualStyleBackColor = true;
            // 
            // rdoC
            // 
            this.rdoC.AutoSize = true;
            this.rdoC.Location = new System.Drawing.Point(26, 112);
            this.rdoC.Margin = new System.Windows.Forms.Padding(2);
            this.rdoC.Name = "rdoC";
            this.rdoC.Size = new System.Drawing.Size(36, 23);
            this.rdoC.TabIndex = 2;
            this.rdoC.TabStop = true;
            this.rdoC.Text = "C";
            this.rdoC.UseVisualStyleBackColor = true;
            // 
            // rdoB
            // 
            this.rdoB.AutoSize = true;
            this.rdoB.Location = new System.Drawing.Point(26, 74);
            this.rdoB.Margin = new System.Windows.Forms.Padding(2);
            this.rdoB.Name = "rdoB";
            this.rdoB.Size = new System.Drawing.Size(35, 23);
            this.rdoB.TabIndex = 1;
            this.rdoB.TabStop = true;
            this.rdoB.Text = "B";
            this.rdoB.UseVisualStyleBackColor = true;
            // 
            // rdoA
            // 
            this.rdoA.AutoSize = true;
            this.rdoA.Location = new System.Drawing.Point(26, 37);
            this.rdoA.Margin = new System.Windows.Forms.Padding(2);
            this.rdoA.Name = "rdoA";
            this.rdoA.Size = new System.Drawing.Size(36, 23);
            this.rdoA.TabIndex = 0;
            this.rdoA.TabStop = true;
            this.rdoA.Text = "A";
            this.rdoA.UseVisualStyleBackColor = true;
            // 
            // lblNoiDungCauHoi
            // 
            this.lblNoiDungCauHoi.AutoSize = true;
            this.lblNoiDungCauHoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNoiDungCauHoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoiDungCauHoi.Location = new System.Drawing.Point(15, 46);
            this.lblNoiDungCauHoi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNoiDungCauHoi.MaximumSize = new System.Drawing.Size(562, 0);
            this.lblNoiDungCauHoi.Name = "lblNoiDungCauHoi";
            this.lblNoiDungCauHoi.Padding = new System.Windows.Forms.Padding(0, 9, 0, 16);
            this.lblNoiDungCauHoi.Size = new System.Drawing.Size(256, 88);
            this.lblNoiDungCauHoi.TabIndex = 1;
            this.lblNoiDungCauHoi.Text = "Nội dung câu hỏi sẽ hiển thị ở đây...\r\n\r\n(Dài quá sẽ tự xuống dòng)";
            // 
            // lblCauHoiSo
            // 
            this.lblCauHoiSo.AutoSize = true;
            this.lblCauHoiSo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCauHoiSo.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauHoiSo.ForeColor = System.Drawing.Color.Teal;
            this.lblCauHoiSo.Location = new System.Drawing.Point(15, 16);
            this.lblCauHoiSo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCauHoiSo.Name = "lblCauHoiSo";
            this.lblCauHoiSo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 9);
            this.lblCauHoiSo.Size = new System.Drawing.Size(86, 30);
            this.lblCauHoiSo.TabIndex = 0;
            this.lblCauHoiSo.Text = "Câu số 01:";
            // 
            // timerThi
            // 
            this.timerThi.Interval = 1000;
            // 
            // frmThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 668);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmThi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thi Trắc Nghiệm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThi_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.gbDapAn.ResumeLayout(false);
            this.gbDapAn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblThongTinSV;
        private System.Windows.Forms.Label lblMonThi;
        private System.Windows.Forms.Label lblDanhSachCauHoi;
        private System.Windows.Forms.FlowLayoutPanel flowDanhSachCauHoi;
        private System.Windows.Forms.Button btnNopBai;
        private System.Windows.Forms.Button btnSau;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.GroupBox gbDapAn;
        private System.Windows.Forms.RadioButton rdoD;
        private System.Windows.Forms.RadioButton rdoC;
        private System.Windows.Forms.RadioButton rdoB;
        private System.Windows.Forms.RadioButton rdoA;
        private System.Windows.Forms.Label lblNoiDungCauHoi;
        private System.Windows.Forms.Label lblCauHoiSo;
        private System.Windows.Forms.Timer timerThi;
        private System.Windows.Forms.Label lblLop;
    }
}

