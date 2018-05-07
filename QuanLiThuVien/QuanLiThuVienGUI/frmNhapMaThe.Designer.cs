namespace QuanLiThuVienGUI
{
    partial class frmNhapMaThe
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
            this.lbMaTheBanDoc = new System.Windows.Forms.Label();
            this.txbMaTheBanDoc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbMaTheBanDoc
            // 
            this.lbMaTheBanDoc.AutoSize = true;
            this.lbMaTheBanDoc.Location = new System.Drawing.Point(13, 29);
            this.lbMaTheBanDoc.Name = "lbMaTheBanDoc";
            this.lbMaTheBanDoc.Size = new System.Drawing.Size(114, 13);
            this.lbMaTheBanDoc.TabIndex = 0;
            this.lbMaTheBanDoc.Text = "Nhập mã thẻ bạn đọc:";
            // 
            // txbMaTheBanDoc
            // 
            this.txbMaTheBanDoc.Location = new System.Drawing.Point(134, 29);
            this.txbMaTheBanDoc.Name = "txbMaTheBanDoc";
            this.txbMaTheBanDoc.Size = new System.Drawing.Size(267, 20);
            this.txbMaTheBanDoc.TabIndex = 1;
            this.txbMaTheBanDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbMaTheBanDoc_KeyDown);
            // 
            // frmNhapMaThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 76);
            this.Controls.Add(this.txbMaTheBanDoc);
            this.Controls.Add(this.lbMaTheBanDoc);
            this.Name = "frmNhapMaThe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập mã thẻ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMaTheBanDoc;
        private System.Windows.Forms.TextBox txbMaTheBanDoc;
    }
}