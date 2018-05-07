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
    public partial class frmNhapMaThe : Form
    {
        int codeMuonTra;

        public frmNhapMaThe(int codeMuonTra)
        {
            InitializeComponent();
            this.codeMuonTra = codeMuonTra;
        }


        private void txbMaTheBanDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                QuanLiBanDocBUS quanLiBanDoc = new QuanLiBanDocBUS();
                QuanLiSachBUS quanLiSach = new QuanLiSachBUS();
                if (codeMuonTra == 0)
                {
                    frmPhieuMuon f = new frmPhieuMuon(quanLiBanDoc.TimDocGia(txbMaTheBanDoc.Text, "")[0]);
                }
                else
                {
                    frmPhieuTra f = new frmPhieuTra(quanLiBanDoc.TimDocGia(txbMaTheBanDoc.Text, "")[0], quan)
                }
                f.ShowDialog();
                this.Close();
            }
        }
    }
}
