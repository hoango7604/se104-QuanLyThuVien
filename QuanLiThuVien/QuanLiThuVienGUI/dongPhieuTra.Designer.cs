namespace QuanLiThuVienGUI
{
    partial class dongPhieuTra
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
            this.lbTenSach = new System.Windows.Forms.Label();
            this.lbMaSach = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkChonSach = new System.Windows.Forms.CheckBox();
            this.lbSoNgayDaMuon = new System.Windows.Forms.Label();
            this.lbTienPhatChoSach = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTenSach
            // 
            this.lbTenSach.AutoEllipsis = true;
            this.lbTenSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenSach.Location = new System.Drawing.Point(176, 0);
            this.lbTenSach.Name = "lbTenSach";
            this.lbTenSach.Size = new System.Drawing.Size(241, 70);
            this.lbTenSach.TabIndex = 8;
            this.lbTenSach.Text = "Tên sách";
            this.lbTenSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMaSach
            // 
            this.lbMaSach.AutoEllipsis = true;
            this.lbMaSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSach.Location = new System.Drawing.Point(36, 0);
            this.lbMaSach.Name = "lbMaSach";
            this.lbMaSach.Size = new System.Drawing.Size(144, 70);
            this.lbMaSach.TabIndex = 7;
            this.lbMaSach.Text = "Mã sách";
            this.lbMaSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chkChonSach);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(37, 70);
            this.panel3.TabIndex = 9;
            // 
            // chkChonSach
            // 
            this.chkChonSach.AutoSize = true;
            this.chkChonSach.Location = new System.Drawing.Point(12, 30);
            this.chkChonSach.Name = "chkChonSach";
            this.chkChonSach.Size = new System.Drawing.Size(15, 14);
            this.chkChonSach.TabIndex = 0;
            this.chkChonSach.UseVisualStyleBackColor = true;
            // 
            // lbSoNgayDaMuon
            // 
            this.lbSoNgayDaMuon.AutoEllipsis = true;
            this.lbSoNgayDaMuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSoNgayDaMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoNgayDaMuon.Location = new System.Drawing.Point(416, 0);
            this.lbSoNgayDaMuon.Name = "lbSoNgayDaMuon";
            this.lbSoNgayDaMuon.Size = new System.Drawing.Size(209, 70);
            this.lbSoNgayDaMuon.TabIndex = 10;
            this.lbSoNgayDaMuon.Text = "Số ngày đã mượn";
            this.lbSoNgayDaMuon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTienPhatChoSach
            // 
            this.lbTienPhatChoSach.AutoEllipsis = true;
            this.lbTienPhatChoSach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTienPhatChoSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTienPhatChoSach.Location = new System.Drawing.Point(624, 0);
            this.lbTienPhatChoSach.Name = "lbTienPhatChoSach";
            this.lbTienPhatChoSach.Size = new System.Drawing.Size(192, 70);
            this.lbTienPhatChoSach.TabIndex = 11;
            this.lbTienPhatChoSach.Text = "Tiền phạt cho sách";
            this.lbTienPhatChoSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dongPhieuTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.lbTienPhatChoSach);
            this.Controls.Add(this.lbSoNgayDaMuon);
            this.Controls.Add(this.lbTenSach);
            this.Controls.Add(this.lbMaSach);
            this.Controls.Add(this.panel3);
            this.Name = "dongPhieuTra";
            this.Size = new System.Drawing.Size(816, 70);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTenSach;
        private System.Windows.Forms.Label lbMaSach;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.CheckBox chkChonSach;
        private System.Windows.Forms.Label lbSoNgayDaMuon;
        private System.Windows.Forms.Label lbTienPhatChoSach;
    }
}
