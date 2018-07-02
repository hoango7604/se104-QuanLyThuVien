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
        Form mainForm;
        List<docgiaDTO> listDocGia = new List<docgiaDTO>();
        int codeMuonTra;

        public frmNhapMaThe(string title, List<docgiaDTO> listDocGia, int codeMuonTra, Form parent)
        {
            InitializeComponent();
            this.Text = title;
            this.listDocGia = listDocGia;
            this.codeMuonTra = codeMuonTra;
            this.mainForm = parent;
            foreach (docgiaDTO docgia in listDocGia)
            {
                cbNhapMaTheBanDoc.Items.Add(docgia.MaThe + " - " + docgia.HoTen);
            }
        }

        private void cbNhapMaTheBanDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (cbNhapMaTheBanDoc.Text != "" && new docgiaDAL().isDocGia(listDocGia[cbNhapMaTheBanDoc.SelectedIndex].MaThe))
                    {
                        QuanLiBanDocBUS quanLiBanDoc = new QuanLiBanDocBUS();
                        QuanLiSachBUS quanLiSach = new QuanLiSachBUS();
                        docgiaDTO docgia = listDocGia[cbNhapMaTheBanDoc.SelectedIndex];

                        int index = 0;
                        for (int i = 0; i < quanLiBanDoc.DanhSachDocGia().Count; i++)
                        {
                            if (docgia.MaThe == quanLiBanDoc.DanhSachDocGia()[i].MaThe)
                            {
                                index = i;
                            }
                        }

                        if (codeMuonTra == 0)
                        {
                            frmPhieuMuon f = new frmPhieuMuon(docgia);
                            f.ShowDialog();
                            (mainForm as frmManHinhChinh).ShowThongTinBanDoc(index);
                        }
                        else if (codeMuonTra == 1)
                        {
                            frmThongTinBanDoc f = new frmThongTinBanDoc(docgia, mainForm);
                            f.ShowDialog();
                        }
                        else if (codeMuonTra == 2)
                        {
                            frmPhieuThuTienPhat f = new frmPhieuThuTienPhat(docgia, mainForm);
                            f.ShowDialog();
                        }
                        this.Close();
                    }
                    else
                    {
                        if (cbNhapMaTheBanDoc.Text == "")
                        {
                            MessageBox.Show("Vui lòng nhập mã bạn đọc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Bạn đọc không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Lỗi định dạng hoặc mã không tồn tại. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
