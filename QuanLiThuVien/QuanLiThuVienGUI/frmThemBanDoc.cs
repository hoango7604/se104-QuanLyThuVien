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
        public frmThemBanDoc()
        {
            InitializeComponent();
        }

        private void btnHuyBanDoc_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnThemBanDoc_Click(object sender, EventArgs e)
        {
            if (txbTenBanDoc.Text != "" && txbEmailBanDoc.Text != "" && txbDiaChiBanDoc.Text != "" && txbCMNDBanDoc.Text != "" && cbLoaiDocGia.Text != "" && dtpNgaySinhBanDoc.Text != "")
            {
                QuanLiBanDocBUS quanLiBanDocBUS = new QuanLiBanDocBUS();
                docgiaDTO dgDTO = new docgiaDTO(int.Parse(txbCMNDBanDoc.Text), txbTenBanDoc.Text, txbDiaChiBanDoc.Text, txbEmailBanDoc.Text, dtpNgaySinhBanDoc.Value, DateTime.Now, 0, int.Parse(cbLoaiDocGia.Text));
                if (quanLiBanDocBUS.ThemDocGia(dgDTO))
                {
                    MessageBox.Show("Đã thêm bạn đọc thành công", "Thông báo", MessageBoxButtons.OK);
                    
                }
                else
                {
                    MessageBox.Show("Thêm bạn đọc thất bại. Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void frmThemBanDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy lệnh thêm bạn đọc?", "Hủy thêm bạn đọc", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
