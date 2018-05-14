namespace QuanLiThuVienGUI
{
    partial class dongThongTinSach
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkChonSach = new System.Windows.Forms.CheckBox();
            this.lbMaSach = new System.Windows.Forms.Label();
            this.lbTenSach = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpNgayMuonSach = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbTinhTrangSach = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkChonSach
            // 
            this.chkChonSach.AutoSize = true;
            this.chkChonSach.Location = new System.Drawing.Point(12, 30);
            this.chkChonSach.Name = "chkChonSach";
            this.chkChonSach.Size = new System.Drawing.Size(15, 14);
            this.chkChonSach.TabIndex = 0;
            this.chkChonSach.UseVisualStyleBackColor = true;
            this.chkChonSach.CheckStateChanged += new System.EventHandler(this.chkChonSach_CheckStateChanged);
            // 
            // lbMaSach
            // 
            this.lbMaSach.AutoEllipsis = true;
            this.lbMaSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSach.Location = new System.Drawing.Point(36, 0);
            this.lbMaSach.Name = "lbMaSach";
            this.lbMaSach.Size = new System.Drawing.Size(144, 70);
            this.lbMaSach.TabIndex = 1;
            this.lbMaSach.Text = "Mã sách";
            this.lbMaSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbMaSach.Click += new System.EventHandler(this.myClick);
            // 
            // lbTenSach
            // 
            this.lbTenSach.AutoEllipsis = true;
            this.lbTenSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSach.Location = new System.Drawing.Point(176, 0);
            this.lbTenSach.Name = "lbTenSach";
            this.lbTenSach.Size = new System.Drawing.Size(241, 70);
            this.lbTenSach.TabIndex = 2;
            this.lbTenSach.Text = "Tên sách";
            this.lbTenSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbTenSach.Click += new System.EventHandler(this.myClick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtpNgayMuonSach);
            this.panel1.Location = new System.Drawing.Point(416, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 70);
            this.panel1.TabIndex = 3;
            this.panel1.Click += new System.EventHandler(this.myClick);
            // 
            // dtpNgayMuonSach
            // 
            this.dtpNgayMuonSach.Enabled = false;
            this.dtpNgayMuonSach.Location = new System.Drawing.Point(4, 27);
            this.dtpNgayMuonSach.Name = "dtpNgayMuonSach";
            this.dtpNgayMuonSach.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayMuonSach.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbTinhTrangSach);
            this.panel2.Location = new System.Drawing.Point(624, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 70);
            this.panel2.TabIndex = 5;
            this.panel2.Click += new System.EventHandler(this.myClick);
            // 
            // cbTinhTrangSach
            // 
            this.cbTinhTrangSach.FormattingEnabled = true;
            this.cbTinhTrangSach.Location = new System.Drawing.Point(4, 27);
            this.cbTinhTrangSach.Name = "cbTinhTrangSach";
            this.cbTinhTrangSach.Size = new System.Drawing.Size(183, 21);
            this.cbTinhTrangSach.TabIndex = 0;
            this.cbTinhTrangSach.TextChanged += new System.EventHandler(this.cbTinhTrangSach_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chkChonSach);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(37, 70);
            this.panel3.TabIndex = 6;
            // 
            // dongThongTinSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbTenSach);
            this.Controls.Add(this.lbMaSach);
            this.Controls.Add(this.panel3);
            this.Name = "dongThongTinSach";
            this.Size = new System.Drawing.Size(816, 70);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckBox chkChonSach;
        private System.Windows.Forms.Label lbMaSach;
        private System.Windows.Forms.Label lbTenSach;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpNgayMuonSach;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.ComboBox cbTinhTrangSach;
        private System.Windows.Forms.Panel panel3;
    }
}
