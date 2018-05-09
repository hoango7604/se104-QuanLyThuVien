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
    public partial class frmThemBanDoc : Form
    {
        public frmThemBanDoc()
        {
            InitializeComponent();
        }

        private void btnHuyBanDoc_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnThemBanDoc_Click(object sender, EventArgs e)
        {

        }

        private void frmThemBanDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy lệnh thêm bạn đọc?", "Hủy thêm bạn đọc", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
