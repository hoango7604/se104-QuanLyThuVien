﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiThuVienBUS;
using QuanLiThuVienDTO;

namespace QuanLiThuVienGUI
{
    public partial class frmPhieuTra : Form
    {

        docgiaDTO docgia;
        List<sachDTO> listSach = new List<sachDTO>();
        QuanLiSachBUS quanLiSach = new QuanLiSachBUS();
        QuanLiMuonTraMatBUS quanLiMuonTraMat = new QuanLiMuonTraMatBUS();
        List<dongThongTinSach> listDongThongTinSach = new List<dongThongTinSach>();

        public frmPhieuTra(docgiaDTO docgia, List<sachDTO> listSach)
        {
            InitializeComponent();
            initFormPhieuTra(docgia);
            this.docgia = docgia;
            this.listSach = listSach;
            foreach (sachDTO sach in listSach)
            {
                initDongThongTinSach(sach);
            }
        }

        private void initFormPhieuTra(docgiaDTO docgia)
        {
            txbTenBanDoc.Text = docgia.HoTen;
            txbMaTheBanDoc.Text = docgia.MaThe.ToString();
        }

        private void initDongThongTinSach(sachDTO sach)
        {
            dongThongTinSach dongThongTin = new dongThongTinSach(sach);
            dongThongTin.changeEnable_CbTinhTrangSach(false);
            dongThongTin.chkChonSach.Enabled = false;
            listDongThongTinSach.Add(dongThongTin);
            dongThongTin.Location = new Point(3, 3 + dongThongTin.Height * (listDongThongTinSach.Count() - 1));
            pnDanhSachSachTra.Controls.Add(dongThongTin);
        }

        private void btnTaoPhieuTra_Click(object sender, EventArgs e)
        { // 21 13 14
            QuanLiMuonTraMatBUS mBus = new QuanLiMuonTraMatBUS();
            mBus.TraSach(docgia, listSach);
        }

        private void chkChonSach_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            foreach (dongThongTinSach dongThongTin in listDongThongTinSach)
            {
                dongThongTin.chkChonSach.CheckState = cb.CheckState;
            }
        }
    }
}
