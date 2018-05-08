﻿using System;
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
    public partial class dongThongTinSach : UserControl
    {
        public dongThongTinSach()
        {
            InitializeComponent();
        }

        public dongThongTinSach(sachDTO sach)
        {
            InitializeComponent();
            lbMaSach.Text = sach.Masach.ToString();
            lbTenSach.Text = sach.Tensach;
            dtpNgayMuonSach.Value = DateTime.Now;
            cbTinhTrangSach.Text = QuanLiSachBUS.DanhSachTrangThaiSach[sach.Trangthai];
        }

        public dongThongTinSach(sachDTO sach, DateTime date)
        {
            InitializeComponent();
            lbMaSach.Text = sach.Masach.ToString();
            lbTenSach.Text = sach.Tensach;
            dtpNgayMuonSach.Value = date;
            cbTinhTrangSach.Text = QuanLiSachBUS.DanhSachTrangThaiSach[sach.Trangthai];
        }

        public void changeEnable_CbTinhTrangSach(bool var)
        {
            this.cbTinhTrangSach.Enabled = var;
        }
    }
}
