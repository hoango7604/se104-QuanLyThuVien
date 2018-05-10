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
using QuanLiThuVienDAL;

namespace QuanLiThuVienGUI
{
    public partial class frmNhapMaThe : Form
    {
        List<docgiaDTO> listDocGia = new List<docgiaDTO>();
        int codeMuonTra;

        public frmNhapMaThe(List<docgiaDTO> listDocGia, int codeMuonTra)
        {
            InitializeComponent();
            this.listDocGia = listDocGia;
            this.codeMuonTra = codeMuonTra;
            foreach (docgiaDTO docgia in listDocGia)
            {
                cbNhapMaTheBanDoc.Items.Add(docgia.MaThe + " - " + docgia.HoTen);
            }
        }

        private void cbNhapMaTheBanDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbNhapMaTheBanDoc.Text != "" && new docgiaDAL().isDocGia(listDocGia[cbNhapMaTheBanDoc.SelectedIndex].MaThe))
                {
                    QuanLiBanDocBUS quanLiBanDoc = new QuanLiBanDocBUS();
                    QuanLiSachBUS quanLiSach = new QuanLiSachBUS();
                    if (codeMuonTra == 0)
                    {
                        frmPhieuMuon f = new frmPhieuMuon(listDocGia[cbNhapMaTheBanDoc.SelectedIndex]);
                        f.ShowDialog();
                    }
                    else
                    {
                        frmThongTinBanDoc f = new frmThongTinBanDoc(listDocGia[cbNhapMaTheBanDoc.SelectedIndex]);
                        f.ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    if (cbNhapMaTheBanDoc.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập mã bạn đọc", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Bạn đọc không tồn tại", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}