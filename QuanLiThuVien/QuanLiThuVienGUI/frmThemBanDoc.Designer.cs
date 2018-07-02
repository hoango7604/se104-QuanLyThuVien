namespace QuanLiThuVienGUI
{
    partial class frmThemBanDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemBanDoc));
            this.lbThemBanDoc = new System.Windows.Forms.Label();
            this.lbTenBanDoc = new System.Windows.Forms.Label();
            this.txbTenBanDoc = new System.Windows.Forms.TextBox();
            this.txbCMNDBanDoc = new System.Windows.Forms.TextBox();
            this.lbCMNDBanDoc = new System.Windows.Forms.Label();
            this.lbNgaySinhBanDoc = new System.Windows.Forms.Label();
            this.txbEmailBanDoc = new System.Windows.Forms.TextBox();
            this.lbEmailBanDoc = new System.Windows.Forms.Label();
            this.txbDiaChiBanDoc = new System.Windows.Forms.TextBox();
            this.lbDiaChiBanDoc = new System.Windows.Forms.Label();
            this.dtpNgaySinhBanDoc = new System.Windows.Forms.DateTimePicker();
            this.btnThemBanDoc = new System.Windows.Forms.Button();
            this.btnHuyBanDoc = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbNgaySinhEX = new System.Windows.Forms.Label();
            this.lbEmailEX = new System.Windows.Forms.Label();
            this.lbCmndEX = new System.Windows.Forms.Label();
            this.lbTenbandocEX = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbThemBanDoc
            // 
            resources.ApplyResources(this.lbThemBanDoc, "lbThemBanDoc");
            this.lbThemBanDoc.Name = "lbThemBanDoc";
            // 
            // lbTenBanDoc
            // 
            resources.ApplyResources(this.lbTenBanDoc, "lbTenBanDoc");
            this.lbTenBanDoc.Name = "lbTenBanDoc";
            // 
            // txbTenBanDoc
            // 
            resources.ApplyResources(this.txbTenBanDoc, "txbTenBanDoc");
            this.txbTenBanDoc.Name = "txbTenBanDoc";
            this.txbTenBanDoc.TextChanged += new System.EventHandler(this.txbTenBanDoc_TextChanged);
            // 
            // txbCMNDBanDoc
            // 
            resources.ApplyResources(this.txbCMNDBanDoc, "txbCMNDBanDoc");
            this.txbCMNDBanDoc.Name = "txbCMNDBanDoc";
            this.txbCMNDBanDoc.TextChanged += new System.EventHandler(this.txbCMNDBanDoc_TextChanged);
            // 
            // lbCMNDBanDoc
            // 
            resources.ApplyResources(this.lbCMNDBanDoc, "lbCMNDBanDoc");
            this.lbCMNDBanDoc.Name = "lbCMNDBanDoc";
            // 
            // lbNgaySinhBanDoc
            // 
            resources.ApplyResources(this.lbNgaySinhBanDoc, "lbNgaySinhBanDoc");
            this.lbNgaySinhBanDoc.Name = "lbNgaySinhBanDoc";
            // 
            // txbEmailBanDoc
            // 
            resources.ApplyResources(this.txbEmailBanDoc, "txbEmailBanDoc");
            this.txbEmailBanDoc.Name = "txbEmailBanDoc";
            this.txbEmailBanDoc.TextChanged += new System.EventHandler(this.txbEmailBanDoc_TextChanged);
            // 
            // lbEmailBanDoc
            // 
            resources.ApplyResources(this.lbEmailBanDoc, "lbEmailBanDoc");
            this.lbEmailBanDoc.Name = "lbEmailBanDoc";
            // 
            // txbDiaChiBanDoc
            // 
            resources.ApplyResources(this.txbDiaChiBanDoc, "txbDiaChiBanDoc");
            this.txbDiaChiBanDoc.Name = "txbDiaChiBanDoc";
            // 
            // lbDiaChiBanDoc
            // 
            resources.ApplyResources(this.lbDiaChiBanDoc, "lbDiaChiBanDoc");
            this.lbDiaChiBanDoc.Name = "lbDiaChiBanDoc";
            // 
            // dtpNgaySinhBanDoc
            // 
            resources.ApplyResources(this.dtpNgaySinhBanDoc, "dtpNgaySinhBanDoc");
            this.dtpNgaySinhBanDoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinhBanDoc.Name = "dtpNgaySinhBanDoc";
            this.dtpNgaySinhBanDoc.ValueChanged += new System.EventHandler(this.dtpNgaySinhBanDoc_ValueChanged);
            // 
            // btnThemBanDoc
            // 
            resources.ApplyResources(this.btnThemBanDoc, "btnThemBanDoc");
            this.btnThemBanDoc.Name = "btnThemBanDoc";
            this.btnThemBanDoc.UseVisualStyleBackColor = true;
            this.btnThemBanDoc.Click += new System.EventHandler(this.btnThemBanDoc_Click);
            // 
            // btnHuyBanDoc
            // 
            this.btnHuyBanDoc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnHuyBanDoc, "btnHuyBanDoc");
            this.btnHuyBanDoc.Name = "btnHuyBanDoc";
            this.btnHuyBanDoc.UseVisualStyleBackColor = true;
            this.btnHuyBanDoc.Click += new System.EventHandler(this.btnHuyBanDoc_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbNgaySinhEX);
            this.panel1.Controls.Add(this.lbEmailEX);
            this.panel1.Controls.Add(this.lbCmndEX);
            this.panel1.Controls.Add(this.lbTenbandocEX);
            this.panel1.Controls.Add(this.txbDiaChiBanDoc);
            this.panel1.Controls.Add(this.dtpNgaySinhBanDoc);
            this.panel1.Controls.Add(this.txbEmailBanDoc);
            this.panel1.Controls.Add(this.btnHuyBanDoc);
            this.panel1.Controls.Add(this.btnThemBanDoc);
            this.panel1.Controls.Add(this.txbCMNDBanDoc);
            this.panel1.Controls.Add(this.lbThemBanDoc);
            this.panel1.Controls.Add(this.lbTenBanDoc);
            this.panel1.Controls.Add(this.txbTenBanDoc);
            this.panel1.Controls.Add(this.lbCMNDBanDoc);
            this.panel1.Controls.Add(this.lbNgaySinhBanDoc);
            this.panel1.Controls.Add(this.lbEmailBanDoc);
            this.panel1.Controls.Add(this.lbDiaChiBanDoc);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // lbNgaySinhEX
            // 
            resources.ApplyResources(this.lbNgaySinhEX, "lbNgaySinhEX");
            this.lbNgaySinhEX.ForeColor = System.Drawing.Color.Red;
            this.lbNgaySinhEX.Name = "lbNgaySinhEX";
            // 
            // lbEmailEX
            // 
            resources.ApplyResources(this.lbEmailEX, "lbEmailEX");
            this.lbEmailEX.ForeColor = System.Drawing.Color.Red;
            this.lbEmailEX.Name = "lbEmailEX";
            // 
            // lbCmndEX
            // 
            resources.ApplyResources(this.lbCmndEX, "lbCmndEX");
            this.lbCmndEX.ForeColor = System.Drawing.Color.Red;
            this.lbCmndEX.Name = "lbCmndEX";
            // 
            // lbTenbandocEX
            // 
            resources.ApplyResources(this.lbTenbandocEX, "lbTenbandocEX");
            this.lbTenbandocEX.ForeColor = System.Drawing.Color.Red;
            this.lbTenbandocEX.Name = "lbTenbandocEX";
            // 
            // frmThemBanDoc
            // 
            this.AcceptButton = this.btnThemBanDoc;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnHuyBanDoc;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemBanDoc";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbThemBanDoc;
        private System.Windows.Forms.Label lbTenBanDoc;
        private System.Windows.Forms.TextBox txbTenBanDoc;
        private System.Windows.Forms.TextBox txbCMNDBanDoc;
        private System.Windows.Forms.Label lbCMNDBanDoc;
        private System.Windows.Forms.Label lbNgaySinhBanDoc;
        private System.Windows.Forms.TextBox txbEmailBanDoc;
        private System.Windows.Forms.Label lbEmailBanDoc;
        private System.Windows.Forms.TextBox txbDiaChiBanDoc;
        private System.Windows.Forms.Label lbDiaChiBanDoc;
        private System.Windows.Forms.DateTimePicker dtpNgaySinhBanDoc;
        private System.Windows.Forms.Button btnThemBanDoc;
        private System.Windows.Forms.Button btnHuyBanDoc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTenbandocEX;
        private System.Windows.Forms.Label lbCmndEX;
        private System.Windows.Forms.Label lbEmailEX;
        private System.Windows.Forms.Label lbNgaySinhEX;
    }
}

