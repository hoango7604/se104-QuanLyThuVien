namespace QuanLiThuVienGUI
{
    partial class frmPhieuMuon
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbCMNDBanDoc = new System.Windows.Forms.TextBox();
            this.lbTenBanDoc = new System.Windows.Forms.Label();
            this.txbTenBanDoc = new System.Windows.Forms.TextBox();
            this.lbCMNDBanDoc = new System.Windows.Forms.Label();
            this.lbThongTinBanDoc = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbTinhTrangSach = new System.Windows.Forms.Label();
            this.lbNgayMuonSach = new System.Windows.Forms.Label();
            this.lbTenSach = new System.Windows.Forms.Label();
            this.lbMaSach = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chkChonSach = new System.Windows.Forms.CheckBox();
            this.lbDanhSachSachMuon = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnDanhSachSachDangMuon = new System.Windows.Forms.Panel();
            this.btnTaoPhieuMuon = new System.Windows.Forms.Button();
            this.lbTimSachTheoMa = new System.Windows.Forms.Label();
            this.txbTimSachTheoMa = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbThongTinBanDoc);
            this.panel1.Controls.Add(this.txbCMNDBanDoc);
            this.panel1.Controls.Add(this.lbTenBanDoc);
            this.panel1.Controls.Add(this.txbTenBanDoc);
            this.panel1.Controls.Add(this.lbCMNDBanDoc);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 98);
            this.panel1.TabIndex = 0;
            // 
            // txbCMNDBanDoc
            // 
            this.txbCMNDBanDoc.Enabled = false;
            this.txbCMNDBanDoc.Location = new System.Drawing.Point(569, 59);
            this.txbCMNDBanDoc.Name = "txbCMNDBanDoc";
            this.txbCMNDBanDoc.Size = new System.Drawing.Size(264, 20);
            this.txbCMNDBanDoc.TabIndex = 5;
            // 
            // lbTenBanDoc
            // 
            this.lbTenBanDoc.AutoSize = true;
            this.lbTenBanDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTenBanDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTenBanDoc.Location = new System.Drawing.Point(6, 59);
            this.lbTenBanDoc.Name = "lbTenBanDoc";
            this.lbTenBanDoc.Size = new System.Drawing.Size(101, 20);
            this.lbTenBanDoc.TabIndex = 6;
            this.lbTenBanDoc.Text = "Tên bạn đọc:";
            // 
            // txbTenBanDoc
            // 
            this.txbTenBanDoc.Enabled = false;
            this.txbTenBanDoc.Location = new System.Drawing.Point(111, 59);
            this.txbTenBanDoc.Name = "txbTenBanDoc";
            this.txbTenBanDoc.Size = new System.Drawing.Size(262, 20);
            this.txbTenBanDoc.TabIndex = 4;
            // 
            // lbCMNDBanDoc
            // 
            this.lbCMNDBanDoc.AutoSize = true;
            this.lbCMNDBanDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbCMNDBanDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbCMNDBanDoc.Location = new System.Drawing.Point(466, 57);
            this.lbCMNDBanDoc.Name = "lbCMNDBanDoc";
            this.lbCMNDBanDoc.Size = new System.Drawing.Size(60, 20);
            this.lbCMNDBanDoc.TabIndex = 7;
            this.lbCMNDBanDoc.Text = "CMND:";
            // 
            // lbThongTinBanDoc
            // 
            this.lbThongTinBanDoc.AutoSize = true;
            this.lbThongTinBanDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongTinBanDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbThongTinBanDoc.Location = new System.Drawing.Point(299, 3);
            this.lbThongTinBanDoc.Name = "lbThongTinBanDoc";
            this.lbThongTinBanDoc.Size = new System.Drawing.Size(291, 39);
            this.lbThongTinBanDoc.TabIndex = 8;
            this.lbThongTinBanDoc.Text = "Thông tin bạn đọc";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbTimSachTheoMa);
            this.panel2.Controls.Add(this.txbTimSachTheoMa);
            this.panel2.Controls.Add(this.btnTaoPhieuMuon);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.lbDanhSachSachMuon);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(13, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(854, 372);
            this.panel2.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbTinhTrangSach);
            this.panel4.Controls.Add(this.lbNgayMuonSach);
            this.panel4.Controls.Add(this.lbTenSach);
            this.panel4.Controls.Add(this.lbMaSach);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(4, 97);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(820, 41);
            this.panel4.TabIndex = 19;
            // 
            // lbTinhTrangSach
            // 
            this.lbTinhTrangSach.AutoEllipsis = true;
            this.lbTinhTrangSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTinhTrangSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTinhTrangSach.Location = new System.Drawing.Point(628, 3);
            this.lbTinhTrangSach.Name = "lbTinhTrangSach";
            this.lbTinhTrangSach.Size = new System.Drawing.Size(189, 35);
            this.lbTinhTrangSach.TabIndex = 30;
            this.lbTinhTrangSach.Text = "Tình trạng sách";
            this.lbTinhTrangSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNgayMuonSach
            // 
            this.lbNgayMuonSach.AutoEllipsis = true;
            this.lbNgayMuonSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNgayMuonSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgayMuonSach.Location = new System.Drawing.Point(419, 3);
            this.lbNgayMuonSach.Name = "lbNgayMuonSach";
            this.lbNgayMuonSach.Size = new System.Drawing.Size(210, 35);
            this.lbNgayMuonSach.TabIndex = 29;
            this.lbNgayMuonSach.Text = "Ngày mượn";
            this.lbNgayMuonSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTenSach
            // 
            this.lbTenSach.AutoEllipsis = true;
            this.lbTenSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSach.Location = new System.Drawing.Point(180, 3);
            this.lbTenSach.Name = "lbTenSach";
            this.lbTenSach.Size = new System.Drawing.Size(241, 35);
            this.lbTenSach.TabIndex = 27;
            this.lbTenSach.Text = "Tên sách";
            this.lbTenSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMaSach
            // 
            this.lbMaSach.AutoEllipsis = true;
            this.lbMaSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSach.Location = new System.Drawing.Point(40, 3);
            this.lbMaSach.Name = "lbMaSach";
            this.lbMaSach.Size = new System.Drawing.Size(144, 35);
            this.lbMaSach.TabIndex = 26;
            this.lbMaSach.Text = "Mã sách";
            this.lbMaSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.chkChonSach);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(38, 35);
            this.panel6.TabIndex = 28;
            // 
            // chkChonSach
            // 
            this.chkChonSach.AutoSize = true;
            this.chkChonSach.Location = new System.Drawing.Point(11, 9);
            this.chkChonSach.Name = "chkChonSach";
            this.chkChonSach.Size = new System.Drawing.Size(15, 14);
            this.chkChonSach.TabIndex = 0;
            this.chkChonSach.UseVisualStyleBackColor = true;
            // 
            // lbDanhSachSachMuon
            // 
            this.lbDanhSachSachMuon.AutoSize = true;
            this.lbDanhSachSachMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDanhSachSachMuon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbDanhSachSachMuon.Location = new System.Drawing.Point(351, 9);
            this.lbDanhSachSachMuon.Name = "lbDanhSachSachMuon";
            this.lbDanhSachSachMuon.Size = new System.Drawing.Size(192, 39);
            this.lbDanhSachSachMuon.TabIndex = 15;
            this.lbDanhSachSachMuon.Text = "Sách mượn";
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.pnDanhSachSachDangMuon);
            this.panel3.Location = new System.Drawing.Point(4, 140);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(838, 225);
            this.panel3.TabIndex = 18;
            // 
            // pnDanhSachSachDangMuon
            // 
            this.pnDanhSachSachDangMuon.AutoSize = true;
            this.pnDanhSachSachDangMuon.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnDanhSachSachDangMuon.Location = new System.Drawing.Point(3, 3);
            this.pnDanhSachSachDangMuon.Name = "pnDanhSachSachDangMuon";
            this.pnDanhSachSachDangMuon.Size = new System.Drawing.Size(823, 273);
            this.pnDanhSachSachDangMuon.TabIndex = 19;
            // 
            // btnTaoPhieuMuon
            // 
            this.btnTaoPhieuMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoPhieuMuon.Location = new System.Drawing.Point(697, 18);
            this.btnTaoPhieuMuon.Name = "btnTaoPhieuMuon";
            this.btnTaoPhieuMuon.Size = new System.Drawing.Size(136, 63);
            this.btnTaoPhieuMuon.TabIndex = 20;
            this.btnTaoPhieuMuon.Text = "Tạo phiếu mượn";
            this.btnTaoPhieuMuon.UseVisualStyleBackColor = true;
            // 
            // lbTimSachTheoMa
            // 
            this.lbTimSachTheoMa.AutoSize = true;
            this.lbTimSachTheoMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimSachTheoMa.Location = new System.Drawing.Point(7, 61);
            this.lbTimSachTheoMa.Name = "lbTimSachTheoMa";
            this.lbTimSachTheoMa.Size = new System.Drawing.Size(73, 20);
            this.lbTimSachTheoMa.TabIndex = 22;
            this.lbTimSachTheoMa.Text = "Mã sách:";
            // 
            // txbTimSachTheoMa
            // 
            this.txbTimSachTheoMa.Location = new System.Drawing.Point(111, 61);
            this.txbTimSachTheoMa.Name = "txbTimSachTheoMa";
            this.txbTimSachTheoMa.Size = new System.Drawing.Size(262, 20);
            this.txbTimSachTheoMa.TabIndex = 21;
            // 
            // frmPhieuMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 500);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPhieuMuon";
            this.Text = "Phiếu mượn";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txbCMNDBanDoc;
        private System.Windows.Forms.Label lbTenBanDoc;
        private System.Windows.Forms.TextBox txbTenBanDoc;
        private System.Windows.Forms.Label lbCMNDBanDoc;
        private System.Windows.Forms.Label lbThongTinBanDoc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTaoPhieuMuon;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbTinhTrangSach;
        private System.Windows.Forms.Label lbNgayMuonSach;
        private System.Windows.Forms.Label lbTenSach;
        private System.Windows.Forms.Label lbMaSach;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox chkChonSach;
        private System.Windows.Forms.Label lbDanhSachSachMuon;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnDanhSachSachDangMuon;
        private System.Windows.Forms.Label lbTimSachTheoMa;
        private System.Windows.Forms.TextBox txbTimSachTheoMa;
    }
}