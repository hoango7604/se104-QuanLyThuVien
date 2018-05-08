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
using QuanLiThuVienDAL;

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
                if (txbMaTheBanDoc.Text != "" && new docgiaDAL().isDocGia(int.Parse(txbMaTheBanDoc.Text)))
                {
                    QuanLiBanDocBUS quanLiBanDoc = new QuanLiBanDocBUS();
                    QuanLiSachBUS quanLiSach = new QuanLiSachBUS();
                    if (codeMuonTra == 0)
                    {
                        frmPhieuMuon f = new frmPhieuMuon(quanLiBanDoc.TimDocGia(txbMaTheBanDoc.Text, "")[0]);
                        f.ShowDialog();
                    }
                    else
                    {
                        frmThongTinBanDoc f = new frmThongTinBanDoc(quanLiBanDoc.TimDocGia(txbMaTheBanDoc.Text, "")[0]);
                        f.ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    if (txbMaTheBanDoc.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập mã bạn đọc", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Bạn đọc không tồn tại", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }    
        }
    }
}
