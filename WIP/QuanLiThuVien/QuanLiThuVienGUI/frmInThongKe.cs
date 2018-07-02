using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiThuVienGUI
{
    public partial class frmInThongKe : Form
    {
        public frmInThongKe()
        {
            InitializeComponent();
        }

        private void frmInThongKe_Load(object sender, EventArgs e)
        {
            this.TKRportViewer.RefreshReport();
            
        }
    }
}
