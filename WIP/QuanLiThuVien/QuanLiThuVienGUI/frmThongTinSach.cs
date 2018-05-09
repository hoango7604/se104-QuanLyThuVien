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
    public partial class frmThongTinSach : Form
    {
        public frmThongTinSach()
        {
            InitializeComponent();
        }

        private void btnCapNhatBanDoc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK);
        }
    }
}
