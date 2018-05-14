using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiThuVienDTO;
using QuanLiThuVienBUS;

namespace QuanLiThuVienGUI
{
    public partial class frmPhieuThuTienPhat : Form
    {
        docgiaDTO docgia;
        public frmPhieuThuTienPhat(docgiaDTO docgia)
        {
            InitializeComponent();
            this.docgia = docgia;
            initPhieuThuTienPhat();
        }

        private void initPhieuThuTienPhat()
        {
            txbTenBanDoc.Text = docgia.HoTen;
            txbTongTienNoBanDoc.Text = docgia.Tongtienno.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                txbSoTienConLai.Text = (int.Parse(txbTongTienNoBanDoc.Text) - int.Parse(txbSoTienThu.Text)).ToString();
                if (new QuanLiBanDocBUS().SuaDocGia(new docgiaDTO(docgia.MaThe, docgia.HoTen, docgia.DiaChi, docgia.Email, docgia.NgaySinh, docgia.Ngaydk, int.Parse(txbSoTienConLai.Text), docgia.Loaidocgia)))
                {
                    MessageBox.Show("Thu tiền thành công", "Thông báo", MessageBoxButtons.OK);
                    Close();
                }
            }
            catch (FormatException error)
            {
                MessageBox.Show("Lỗi định dạng. Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK);
                Console.WriteLine(error.ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show("Thu tiền thất bại. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK);
                Console.WriteLine(error.ToString());
            }
        }
    }
}
