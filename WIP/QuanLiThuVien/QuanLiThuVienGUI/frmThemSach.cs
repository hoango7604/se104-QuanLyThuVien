using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLiThuVienDTO;
using QuanLiThuVienBUS;

namespace QuanLiThuVienGUI
{
    public partial class frmThemSach : Form
    {
        frmManHinhChinh frmChinh;
        List<loaisachDTO> listLoaiSach = new QuanLiTheLoaiSachBUS().LayDanhSachCacTheLoai();
        public frmThemSach(frmManHinhChinh main)
        {
            this.frmChinh = main;
            InitializeComponent();

            foreach (loaisachDTO loaisach in listLoaiSach)
            {
                cbTheLoaiSach.Items.Add(loaisach.Theloaisach);
            }
        }

        private void btnHuySach_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            if (txbTenSach.Text != "" && txbMaSach.Text != "" && cbTheLoaiSach.Text != "" && txbTacGiaSach.Text != "" && txbNhaXuatBanSach.Text != "" && txbNamXuatBanSach.Text != "" && txbGiaTriSach.Text != "" )
            {
                QuanLiSachBUS qlsBUSS = new QuanLiSachBUS();
                DateTime dtXuatban = new DateTime(int.Parse(txbNamXuatBanSach.Text),1,1);

                sachDTO sach = new sachDTO(int.Parse(txbMaSach.Text), txbTenSach.Text, cbTheLoaiSach.Text, txbTacGiaSach.Text, txbNhaXuatBanSach.Text, DateTime.Now, dtXuatban, int.Parse(txbGiaTriSach.Text), 1);
                if (qlsBUSS.ThemSach(sach)) 
                {
                    MessageBox.Show("Thêm sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();

                    if (!listLoaiSach.Contains(new loaisachDTO(cbTheLoaiSach.Text)))
                    {
                        new QuanLiTheLoaiSachBUS().ThemTheLoaisach(new loaisachDTO(cbTheLoaiSach.Text));
                    }
                }
                else
                {
                    MessageBox.Show("Thêm sách thất bại. " + BUS_notification.mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            frmChinh.loadDanhSachSach();
        }

        private void txbNamXuatBanSach_TextChanged(object sender, EventArgs e)
        {
            string namxb = txbNamXuatBanSach.Text;
            int check;
            Int32.TryParse(namxb, out check);
            if (check == 0 && namxb != "")
            {
                lbNamxbEX.Text = "Vui lòng chỉ nhập số!";
                btnThemSach.Enabled = false;
            }
            else
            {
                lbNamxbEX.Text = "";
                btnThemSach.Enabled = true;
            }
        }

        private void txbGiaTriSach_TextChanged(object sender, EventArgs e)
        {
            string giatri = txbGiaTriSach.Text;
            int check;
            Int32.TryParse(giatri, out check);
            if (check == 0 && giatri != "")
            {
                lbGiaTriEX.Text = "Vui lòng chỉ nhập số!";
                btnThemSach.Enabled = false;
            }
            else
            {
                lbGiaTriEX.Text = "";
                btnThemSach.Enabled = true;
            }
        }

        private void txbMaSach_TextChanged(object sender, EventArgs e)
        {
            string masach = txbMaSach.Text;
            int check;
            Int32.TryParse(masach, out check);
            if (check == 0 && masach != "")
            {
                lbMasSachEX.Text = "Vui lòng chỉ nhập số !";
                btnThemSach.Enabled = false;
            }
            else
            {
                lbMasSachEX.Text = "";
                btnThemSach.Enabled = true;
            }
        }

        private void refresh()
        {
            txbGiaTriSach.Text = "";
            txbMaSach.Text = "";
            txbNamXuatBanSach.Text = "";
            txbNhaXuatBanSach.Text = "";
            txbTacGiaSach.Text = "";
            txbTenSach.Text = "";
            dtpNgayNhapSach.Text = "";
            cbTheLoaiSach.Text = "";
            txbTenSach.Focus();
        }

        private void cbTheLoaiSach_Enter(object sender, EventArgs e)
        {
            cbTheLoaiSach.DroppedDown = true;
        }
    }
}
