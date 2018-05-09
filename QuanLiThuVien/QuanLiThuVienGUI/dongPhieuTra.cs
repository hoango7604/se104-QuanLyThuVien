using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiThuVienDTO;
using QuanLiThuVienBUS;

namespace QuanLiThuVienGUI
{
    public partial class dongPhieuTra : UserControl
    {
        public dongPhieuTra()
        {
            InitializeComponent();
        }

        public dongPhieuTra(sachDTO sach, DateTime ngaymuon)
        {
            InitializeComponent();
            lbMaSach.Text = sach.Masach.ToString();
            lbTenSach.Text = sach.Tensach;
            lbSoNgayTraTre.Text = (DateTime.Now - ngaymuon).TotalDays.ToString();

        }
    }
}
