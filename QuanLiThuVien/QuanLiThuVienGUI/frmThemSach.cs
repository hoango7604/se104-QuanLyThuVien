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
    public partial class frmThemSach : Form
    {
        frmManHinhChinh frmChinh;
        List<loaisachDTO> listLoaiSach = new List<loaisachDTO>();
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
                    MessageBox.Show("Thêm sách thành công");

                    if (!listLoaiSach.Contains(new loaisachDTO(cbTheLoaiSach.Text)))
                    {
                        new QuanLiTheLoaiSachBUS().ThemTheLoaisach(new loaisachDTO(cbTheLoaiSach.Text));
                    }
                }
                else
                {
                    MessageBox.Show("Thêm sách thất bại ."+BUS_notification.mess );
                }
            }
            else
            {
                MessageBox.Show("Xin hãy nhập đầy đủ thông tin sách");
            }

            frmChinh.loadDanhSachSach();
        }

        private void cbTheLoaiSach_Enter(object sender, EventArgs e)
        {
            cbTheLoaiSach.DroppedDown = true;
        }
    }
}
