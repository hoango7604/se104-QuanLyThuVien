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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhieuMuon));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lbThongTinBanDoc = new System.Windows.Forms.Label();
            this.txbMaTheBanDoc = new System.Windows.Forms.TextBox();
            this.lbTenBanDoc = new System.Windows.Forms.Label();
            this.lbMaTheBanDoc = new System.Windows.Forms.Label();
            this.txbTenBanDoc = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbError = new System.Windows.Forms.Label();
            this.cbTimSachTheoMa = new System.Windows.Forms.ComboBox();
            this.lbTimSachTheoMa = new System.Windows.Forms.Label();
            this.btnTaoPhieuMuon = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbTinhTrangSach = new System.Windows.Forms.Label();
            this.lbNgayMuonSach = new System.Windows.Forms.Label();
            this.lbTenSach = new System.Windows.Forms.Label();
            this.lbMaSach = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chkChonSach = new System.Windows.Forms.CheckBox();
            this.lbDanhSachSachMuon = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnDanhSachSachMuon = new System.Windows.Forms.Panel();
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
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.lbThongTinBanDoc);
            this.panel1.Controls.Add(this.txbMaTheBanDoc);
            this.panel1.Controls.Add(this.lbTenBanDoc);
            this.panel1.Controls.Add(this.lbMaTheBanDoc);
            this.panel1.Controls.Add(this.txbTenBanDoc);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 98);
            this.panel1.TabIndex = 0;
            // 
            // btnHuy
            // 
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.Location = new System.Drawing.Point(1000, 1000);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "button1";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
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
            // txbMaTheBanDoc
            // 
            this.txbMaTheBanDoc.Enabled = false;
            this.txbMaTheBanDoc.Location = new System.Drawing.Point(90, 59);
            this.txbMaTheBanDoc.Name = "txbMaTheBanDoc";
            this.txbMaTheBanDoc.Size = new System.Drawing.Size(264, 20);
            this.txbMaTheBanDoc.TabIndex = 5;
            this.txbMaTheBanDoc.TabStop = false;
            // 
            // lbTenBanDoc
            // 
            this.lbTenBanDoc.AutoSize = true;
            this.lbTenBanDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbTenBanDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbTenBanDoc.Location = new System.Drawing.Point(466, 57);
            this.lbTenBanDoc.Name = "lbTenBanDoc";
            this.lbTenBanDoc.Size = new System.Drawing.Size(101, 20);
            this.lbTenBanDoc.TabIndex = 6;
            this.lbTenBanDoc.Text = "Tên bạn đọc:";
            // 
            // lbMaTheBanDoc
            // 
            this.lbMaTheBanDoc.AutoSize = true;
            this.lbMaTheBanDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbMaTheBanDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbMaTheBanDoc.Location = new System.Drawing.Point(8, 57);
            this.lbMaTheBanDoc.Name = "lbMaTheBanDoc";
            this.lbMaTheBanDoc.Size = new System.Drawing.Size(62, 20);
            this.lbMaTheBanDoc.TabIndex = 7;
            this.lbMaTheBanDoc.Text = "Mã thẻ:";
            // 
            // txbTenBanDoc
            // 
            this.txbTenBanDoc.Enabled = false;
            this.txbTenBanDoc.Location = new System.Drawing.Point(571, 57);
            this.txbTenBanDoc.Name = "txbTenBanDoc";
            this.txbTenBanDoc.Size = new System.Drawing.Size(262, 20);
            this.txbTenBanDoc.TabIndex = 4;
            this.txbTenBanDoc.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lbError);
            this.panel2.Controls.Add(this.cbTimSachTheoMa);
            this.panel2.Controls.Add(this.lbTimSachTheoMa);
            this.panel2.Controls.Add(this.btnTaoPhieuMuon);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.lbDanhSachSachMuon);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(13, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(854, 372);
            this.panel2.TabIndex = 19;
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(11, 74);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 13);
            this.lbError.TabIndex = 23;
            // 
            // cbTimSachTheoMa
            // 
            this.cbTimSachTheoMa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTimSachTheoMa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTimSachTheoMa.FormattingEnabled = true;
            this.cbTimSachTheoMa.Location = new System.Drawing.Point(90, 49);
            this.cbTimSachTheoMa.Name = "cbTimSachTheoMa";
            this.cbTimSachTheoMa.Size = new System.Drawing.Size(264, 21);
            this.cbTimSachTheoMa.TabIndex = 0;
            // 
            // lbTimSachTheoMa
            // 
            this.lbTimSachTheoMa.AutoSize = true;
            this.lbTimSachTheoMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimSachTheoMa.Location = new System.Drawing.Point(7, 50);
            this.lbTimSachTheoMa.Name = "lbTimSachTheoMa";
            this.lbTimSachTheoMa.Size = new System.Drawing.Size(73, 20);
            this.lbTimSachTheoMa.TabIndex = 22;
            this.lbTimSachTheoMa.Text = "Mã sách:";
            // 
            // btnTaoPhieuMuon
            // 
            this.btnTaoPhieuMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoPhieuMuon.Location = new System.Drawing.Point(697, 18);
            this.btnTaoPhieuMuon.Name = "btnTaoPhieuMuon";
            this.btnTaoPhieuMuon.Size = new System.Drawing.Size(136, 63);
            this.btnTaoPhieuMuon.TabIndex = 1;
            this.btnTaoPhieuMuon.Text = "Tạo phiếu mượn";
            this.btnTaoPhieuMuon.UseVisualStyleBackColor = true;
            this.btnTaoPhieuMuon.Click += new System.EventHandler(this.btnTaoPhieuMuon_Click);
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
            this.chkChonSach.TabStop = false;
            this.chkChonSach.UseVisualStyleBackColor = true;
            this.chkChonSach.CheckStateChanged += new System.EventHandler(this.chkChonSach_CheckStateChanged);
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
            this.panel3.Controls.Add(this.pnDanhSachSachMuon);
            this.panel3.Location = new System.Drawing.Point(4, 140);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(838, 225);
            this.panel3.TabIndex = 18;
            // 
            // pnDanhSachSachMuon
            // 
            this.pnDanhSachSachMuon.AutoSize = true;
            this.pnDanhSachSachMuon.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnDanhSachSachMuon.Location = new System.Drawing.Point(3, 3);
            this.pnDanhSachSachMuon.Name = "pnDanhSachSachMuon";
            this.pnDanhSachSachMuon.Size = new System.Drawing.Size(817, 218);
            this.pnDanhSachSachMuon.TabIndex = 19;
            // 
            // frmPhieuMuon
            // 
            this.AcceptButton = this.btnTaoPhieuMuon;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuy;
            this.ClientSize = new System.Drawing.Size(877, 500);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhieuMuon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.TextBox txbMaTheBanDoc;
        private System.Windows.Forms.Label lbTenBanDoc;
        private System.Windows.Forms.TextBox txbTenBanDoc;
        private System.Windows.Forms.Label lbMaTheBanDoc;
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
        private System.Windows.Forms.Panel pnDanhSachSachMuon;
        private System.Windows.Forms.Label lbTimSachTheoMa;
        private System.Windows.Forms.ComboBox cbTimSachTheoMa;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label lbError;
    }
}