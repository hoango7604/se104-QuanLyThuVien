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

        public dongPhieuTra(ctptDTO ctpt)
        {
            InitializeComponent();
            lbMaSach.Text = ctpt.Masach.ToString();
            lbTenSach.Text = new QuanLiSachBUS().Timsachtheoma(ctpt.Masach).Tensach;
            lbSoNgayDaMuon.Text = ctpt.Songaydamuon.ToString();
            lbTienPhatChoSach.Text = ctpt.Tienphatsach.ToString();
        }
    }
}
