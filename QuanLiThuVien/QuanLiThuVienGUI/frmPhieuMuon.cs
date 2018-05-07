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
    public partial class frmPhieuMuon : Form
    {

        docgiaDTO docgia;
        List<sachDTO> listSach = new List<sachDTO>();
        QuanLiSachBUS quanLiSach = new QuanLiSachBUS();
        QuanLiMuonTraMatBUS quanLiMuonTraMat = new QuanLiMuonTraMatBUS();
        List<dongThongTinSach> listDongThongTinSach = new List<dongThongTinSach>();

        public frmPhieuMuon(docgiaDTO docgia)
        {
            InitializeComponent();
            this.docgia = docgia;
            initFormPhieuMuon(docgia);
        }

        private void initFormPhieuMuon(docgiaDTO docgia)
        {
            txbTenBanDoc.Text = docgia.HoTen;
            txbMaTheBanDoc.Text = docgia.MaThe.ToString();
        }

        private void txbTimSachTheoMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sachDTO sach = quanLiSach.TimSach(new sachDTO(int.Parse(txbTimSachTheoMa.Text), "", "", "", "", DateTime.Now, DateTime.Now, 0, 0))[0];
                listSach.Add(sach);
                initDongThongTinSach(sach);
                txbTimSachTheoMa.Clear();
            }
        }

        private void initDongThongTinSach(sachDTO sach)
        {
            dongThongTinSach dongThongTin = new dongThongTinSach(sach);
            dongThongTin.changeEnable_CbTinhTrangSach(false);
            listDongThongTinSach.Add(dongThongTin);
            dongThongTin.Location = new Point(3, 3 + dongThongTin.Height * (listDongThongTinSach.Count() - 1));
            pnDanhSachSachMuon.Controls.Add(dongThongTin);
        }

        private void btnTaoPhieuMuon_Click(object sender, EventArgs e)
        {
            List<sachDTO> listSachMuon = new List<sachDTO>();
            for (int i = 0; i < listDongThongTinSach.Count; i++)
            {
                if (listDongThongTinSach[i].chkChonSach.Checked)
                {
                    listSachMuon.Add(listSach[i]);
                }
            }

            if (quanLiMuonTraMat.MuonSach(docgia, listSachMuon))
            {
                MessageBox.Show("Tạo phiếu mượn thành công", "Thông báo", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                MessageBox.Show(BUS_notification.mess, "Thông báo", MessageBoxButtons.OK);
            }
            
        }
    }
}
