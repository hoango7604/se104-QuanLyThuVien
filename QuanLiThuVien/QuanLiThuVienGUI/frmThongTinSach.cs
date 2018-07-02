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
    public partial class frmThongTinSach : Form
    {
        public frmThongTinSach(sachDTO sach)
        {
            InitializeComponent();
            initThongTinSach(sach);
        }

        private void initThongTinSach(sachDTO sach)
        {
            txbMaSach.Text = sach.Masach.ToString();
            txbTenSach.Text = sach.Tensach;
            cbTheLoaiSach.Text = sach.Theloai;
            txbTacGiaSach.Text = sach.Tacgia;
            txbNhaXuatBanSach.Text = sach.Nxb;
            dtpNgayNhapSach.Value = sach.Ngaynhap;
            txbNamXuatBanSach.Text = sach.Ngayxb.Year.ToString();
            txbGiaTriSach.Text = sach.Giatri.ToString();
            cbTinhTrangSach.Text = QuanLiSachBUS.DanhSachTrangThaiSach[sach.Trangthai];
        }

        private void btnCapNhatBanDoc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
