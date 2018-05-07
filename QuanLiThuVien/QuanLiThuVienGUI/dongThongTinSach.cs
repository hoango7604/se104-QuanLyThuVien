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
            chkChonSach.CheckState = CheckState.Checked;
            lbMaSach.Text = sach.Masach.ToString();
            lbTenSach.Text = sach.Tensach;
            dtpNgayMuonSach.Value = DateTime.Now;
            cbTinhTrangSach.Text = "Có sẵn";
            changeEnable_CbTinhTrangSach(false);
        }

        public void changeEnable_CbTinhTrangSach(bool var)
        {
            this.cbTinhTrangSach.Enabled = var;
        }
    }
}
