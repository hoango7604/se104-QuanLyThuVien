namespace QuanLiThuVienGUI
{
    partial class frmInThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInThongKe));
            this.SachTraTreDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SachTraTreDataSet = new QuanLiThuVienGUI.SachTraTreDataSet();
            this.TKRportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.SachTraTreDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SachTraTreDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // SachTraTreDataSetBindingSource
            // 
            this.SachTraTreDataSetBindingSource.DataMember = "SachTraTreDataSet";
            this.SachTraTreDataSetBindingSource.DataSource = this.SachTraTreDataSet;
            // 
            // SachTraTreDataSet
            // 
            this.SachTraTreDataSet.DataSetName = "SachTraTreDataSet";
            this.SachTraTreDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TKRportViewer
            // 
            this.TKRportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TKRportViewer.LocalReport.ReportEmbeddedResource = "QuanLiThuVienGUI.TheLoaiSach.rdlc";
            this.TKRportViewer.Location = new System.Drawing.Point(0, 0);
            this.TKRportViewer.Name = "TKRportViewer";
            this.TKRportViewer.ServerReport.BearerToken = null;
            this.TKRportViewer.Size = new System.Drawing.Size(736, 525);
            this.TKRportViewer.TabIndex = 0;
            // 
            // frmInThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 525);
            this.Controls.Add(this.TKRportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInThongKe";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống Kê";
            this.Load += new System.EventHandler(this.frmInThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SachTraTreDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SachTraTreDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer TKRportViewer;
        private System.Windows.Forms.BindingSource SachTraTreDataSetBindingSource;
        private SachTraTreDataSet SachTraTreDataSet;
    }
}