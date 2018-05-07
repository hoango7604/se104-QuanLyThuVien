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
    public partial class frmThongTinBanDoc : Form
    {
        QuanLiBanDocBUS quanLiBanDocBUS = new QuanLiBanDocBUS();
        docgiaDTO docgia;

        public frmThongTinBanDoc(docgiaDTO docgia)
        {
            InitializeComponent();
            this.docgia = docgia;
            initThongTinBanDoc(docgia);
        }

        private void initThongTinBanDoc(docgiaDTO docgia)
        {
            txbTenBanDoc.Text = docgia.HoTen;
            txbCMNDBanDoc.Text = docgia.MaThe.ToString();
            dtpNgaySinhBanDoc.Value = docgia.NgaySinh;
            txbEmailBanDoc.Text = docgia.Email;
            txbDiaChiBanDoc.Text = docgia.DiaChi;
            cbLoaiDocGia.Text = docgia.Loaidocgia.ToString();
            txbTongTienNoBanDoc.Text = docgia.Tongtienno.ToString();
            dtpNgayTaoTheBanDoc.Value = docgia.Ngaydk;
        }

        private void btnCapNhatBanDoc_Click(object sender, EventArgs e)
        {
            if (txbTenBanDoc.Text != "" && txbEmailBanDoc.Text != "" && txbDiaChiBanDoc.Text != "" && txbCMNDBanDoc.Text != "" && cbLoaiDocGia.Text != "" && dtpNgaySinhBanDoc.Text != "")
            {
                if (quanLiBanDocBUS.SuaDocGia(new docgiaDTO(int.Parse(txbCMNDBanDoc.Text), txbTenBanDoc.Text, txbDiaChiBanDoc.Text, txbEmailBanDoc.Text, dtpNgaySinhBanDoc.Value, DateTime.Now, 0, int.Parse(cbLoaiDocGia.Text))))
                {
                    MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại. Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);

            }
        }

        private void btnLapPhieuTra_Click(object sender, EventArgs e)
        {
        }

        private void btnLapPhieuMuon_Click(object sender, EventArgs e)
        {
            frmPhieuMuon f = new frmPhieuMuon(docgia);
            f.ShowDialog();
        }
    }
}
