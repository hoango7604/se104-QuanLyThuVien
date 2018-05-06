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
    public partial class frmThemSach : Form
    {
        public frmThemSach()
        {
            InitializeComponent();
        }

        private void btnHuySach_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (txbTenSach.Text != "" && txbMaSach.Text != "" && cbTheLoaiSach.Text != "" && txbTacGiaSach.Text != "" && txbNhaXuatBanSach != "" )
            {

            }
        }

        private void frmThemSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy lệnh thêm sách?", "Hủy thêm sách", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
