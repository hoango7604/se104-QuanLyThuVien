using System;
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
        int tongTienPhat = 0;
        docgiaDTO docgia;
        List<ctptDTO> listCTPT = new List<ctptDTO>();
        QuanLiSachBUS quanLiSach = new QuanLiSachBUS();
        QuanLiMuonTraMatBUS quanLiMuonTraMat = new QuanLiMuonTraMatBUS();
        List<dongPhieuTra> listDongPhieuTra = new List<dongPhieuTra>();

        public frmPhieuTra(docgiaDTO docgia, List<ctptDTO> listCTPT)
        {
            InitializeComponent();
            this.docgia = docgia;
            this.listCTPT = listCTPT;
            foreach (ctptDTO ctpt in listCTPT)
            {
                tongTienPhat += ctpt.Tienphatsach;
                initDongPhieuTra(ctpt);
            }
            initFormPhieuTra(docgia);
        }

        private void initFormPhieuTra(docgiaDTO docgia)
        {
            txbTenBanDoc.Text = docgia.HoTen;
            txbMaTheBanDoc.Text = docgia.MaThe.ToString();
            txbTongTienPhat.Text = tongTienPhat.ToString();
        }

        private void initDongPhieuTra(ctptDTO ctpt)
        {
            dongPhieuTra dongPhieuTra = new dongPhieuTra(ctpt);
            dongPhieuTra.chkChonSach.Enabled = false;
            listDongPhieuTra.Add(dongPhieuTra);
            dongPhieuTra.Location = new Point(3, 3 + dongPhieuTra.Height * (listDongPhieuTra.Count() - 1));
            pnDanhSachSachTra.Controls.Add(dongPhieuTra);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
