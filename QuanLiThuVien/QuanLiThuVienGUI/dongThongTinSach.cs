using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiThuVienGUI
{
    public partial class dongThongTinSach : UserControl
    {
        public dongThongTinSach()
        {
            InitializeComponent();
        }

        public void changeEnable(bool var)
        {
            this.cbTinhTrangSach.Enabled = var;
        }
    }
}
