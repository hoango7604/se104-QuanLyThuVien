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
    public partial class frmThemBanDoc : Form
    {
        private Form mainForm;
        public frmThemBanDoc(Form parent)
        {
            InitializeComponent();
            this.mainForm = parent;
        }

        private void btnHuyBanDoc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnThemBanDoc_Click(object sender, EventArgs e)
        {
            int loaiDocGia = 0;
            int tuoi = 0;

            if (txbTenBanDoc.Text != "" && txbEmailBanDoc.Text != "" && txbDiaChiBanDoc.Text != "" && txbCMNDBanDoc.Text != "" && dtpNgaySinhBanDoc.Text != "")
            {
                QuanLiBanDocBUS quanLiBanDocBUS = new QuanLiBanDocBUS();
                tuoi = DateTime.Now.Year - dtpNgaySinhBanDoc.Value.Year;
                if (tuoi < 18)
                {
                    loaiDocGia = 0;
                }
                else if (tuoi >= 18 && tuoi <= 22)
                {
                    loaiDocGia = 1;
                }
                else if (tuoi > 22)
                {
                    loaiDocGia = 3;
                }

                docgiaDTO dgDTO = new docgiaDTO(int.Parse(txbCMNDBanDoc.Text), txbTenBanDoc.Text, txbDiaChiBanDoc.Text, txbEmailBanDoc.Text, dtpNgaySinhBanDoc.Value, DateTime.Now, 0, loaiDocGia);
                if (quanLiBanDocBUS.ThemDocGia(dgDTO))
                {
                    MessageBox.Show("Đã thêm bạn đọc thành công", "Thông báo", MessageBoxButtons.OK);
                    refresh();
                    (mainForm as frmManHinhChinh).loadDanhSachBanDoc();
                }
                else
                {
                    MessageBox.Show("Thêm bạn đọc thất bại. Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void refresh()
        {
            txbCMNDBanDoc.Text = "";
            txbDiaChiBanDoc.Text = "";
            txbEmailBanDoc.Text = "";
            txbTenBanDoc.Text = "";
            dtpNgaySinhBanDoc.Text = "";
            txbTenBanDoc.Focus();
        }
    }
}
