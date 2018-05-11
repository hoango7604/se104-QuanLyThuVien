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
    public partial class frmManHinhChinh : Form
    {
        List<docgiaDTO> listDocGia;
        List<sachDTO> listSach;
        QuanLiBanDocBUS quanLiBanDocBUS = new QuanLiBanDocBUS();
        QuanLiSachBUS quanLiSachBUS = new QuanLiSachBUS();
        int indexBanDoc = 0;
        int indexSach = 0;

        public frmManHinhChinh()
        {
            InitializeComponent();
            initDataGridViewBanDoc();
            initDataGridViewSach();
            anhXaThongTinBanDoc(indexBanDoc);
            anhXaThongTinSach(indexSach);
        }

        private void initDataGridViewBanDoc()
        {
            loadDanhSachBanDoc();
            dgvThongTinBanDoc.Columns[0].HeaderText = "Mã thẻ";
            dgvThongTinBanDoc.Columns[0].Width = 80;
            dgvThongTinBanDoc.Columns[1].HeaderText = "Họ tên";
            dgvThongTinBanDoc.Columns[1].Width = 170;
            dgvThongTinBanDoc.Columns[2].HeaderText = "Email";
            dgvThongTinBanDoc.Columns[2].Width = 120;
            dgvThongTinBanDoc.Columns[3].HeaderText = "Ngày sinh";
            dgvThongTinBanDoc.Columns[3].Width = 100;
            dgvThongTinBanDoc.Show();
        }

        public void loadDanhSachBanDoc()
        {
            listDocGia = quanLiBanDocBUS.DanhSachDocGia();
            dgvThongTinBanDoc.DataSource = listDocGia.Select(o => new { Column1 = o.MaThe, Column2 = o.HoTen, Column3 = o.Email, Column4 = o.NgaySinh }).ToList();
        }

        private void initDataGridViewSach()
        {
            loadDanhSachSach();
            dgvThongTinSach.Columns[0].HeaderText = "Mã sách";
            dgvThongTinSach.Columns[0].Width = 80;
            dgvThongTinSach.Columns[1].HeaderText = "Tên sách";
            dgvThongTinSach.Columns[1].Width = 170;
            dgvThongTinSach.Columns[2].HeaderText = "Tác giả";
            dgvThongTinSach.Columns[2].Width = 120;
            dgvThongTinSach.Columns[3].HeaderText = "NXB";
            dgvThongTinSach.Columns[3].Width = 100;
            dgvThongTinSach.Show();
        }

        public void loadDanhSachSach()
        {
            listSach = quanLiSachBUS.DanhSachSach();
            dgvThongTinSach.DataSource = listSach.Select(o => new { Column1 = o.Masach, Column2 = o.Tensach, Column3 = o.Tacgia, Column4 = o.Nxb }).ToList();
        }

        /// <summary>
        /// Event menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void thêmBạnĐọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemBanDoc f = new frmThemBanDoc(this);
            f.Show();
        }

        private void thêmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemSach f = new frmThemSach(this);
            f.Show();
        }

        private void tìmKiếmBạnĐọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tcManHinhChinh.SelectTab(tpBanDoc);
        }

        private void tìmKiếmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tcManHinhChinh.SelectTab(tpSach);
        }

        private void tạoPhiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapMaThe f = new frmNhapMaThe(listDocGia ,0);
            f.Show();
        }

        private void tạoPhiếuTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapMaThe f = new frmNhapMaThe(listDocGia, 1);
            f.Show();
        }

        private void giaHạnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xuấtPhiếuThuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thốngKêSáchTrảTrễToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thốngKêTìnhHìnhMượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinPhầnMềmToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Event Tab Ban Doc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnTimKiemBanDoc_Click(object sender, EventArgs e)
        {
            if (txbTimKiemBanDocTheoMa.Text == "" && txbTimKiemTheoTenBanDoc.Text == "")
            {
                listDocGia = quanLiBanDocBUS.DanhSachDocGia();
            }
            else
            {
                listDocGia = quanLiBanDocBUS.TimDocGia(txbTimKiemBanDocTheoMa.Text, txbTimKiemTheoTenBanDoc.Text);
            }
            dgvThongTinBanDoc.DataSource = listDocGia.Select(o => new { Column1 = o.MaThe, Column2 = o.HoTen, Column3 = o.Email, Column4 = o.NgaySinh }).ToList();
        }

        private void btnHienThongTinChiTietBanDoc_Click(object sender, EventArgs e)
        {
            if (indexBanDoc >= 0)
            {
                frmThongTinBanDoc f = new frmThongTinBanDoc(listDocGia[indexBanDoc]);
                f.Show();
                loadDanhSachBanDoc();
                loadDanhSachSach();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin bạn đọc để hiển thị", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThemBanDoc_Click(object sender, EventArgs e)
        {
            frmThemBanDoc f = new frmThemBanDoc(this);
            f.Show();
        }

        private void btnSuaThongTinBanDoc_Click(object sender, EventArgs e)
        {
            if (txbTenBanDoc.Text != "" && txbEmailBanDoc.Text != "" && txbDiaChiBanDoc.Text != "" && txbCMNDBanDoc.Text != "" && cbLoaiDocGia.Text != "" && dtpNgaySinhBanDoc.Text != "")
            {
                if (quanLiBanDocBUS.SuaDocGia(new docgiaDTO(int.Parse(txbCMNDBanDoc.Text), txbTenBanDoc.Text, txbDiaChiBanDoc.Text, txbEmailBanDoc.Text, dtpNgaySinhBanDoc.Value, dtpNgayTaoTheBanDoc.Value, 8,8)))
                {
                    MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK);
                    loadDanhSachBanDoc();
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

        private void btnXoaBanDoc_Click(object sender, EventArgs e)
        {
            if (indexBanDoc >= 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa bạn đọc " + listDocGia[indexBanDoc].HoTen + "?", "Xóa bạn đọc", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (quanLiBanDocBUS.XoaDocGia(listDocGia[indexBanDoc]))
                    {
                        MessageBox.Show("Xóa bạn đọc thành công", "Thông báo", MessageBoxButtons.OK);
                        loadDanhSachBanDoc();
                    }
                    else
                    {
                        MessageBox.Show("Xóa bạn đọc thất bại. Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bạn đọc", "Thông báo", MessageBoxButtons.OK);
            }
        }

     
        private void btnTimSach_Click(object sender, EventArgs e)
        {
            if (txbTimSachTheoMa.Text == "" && txbTimSachTheoTacGia.Text == "" && txbTimSachTheoTen.Text == "" && txbTimSachTheoTheLoai.Text == "")
            {
                listSach = quanLiSachBUS.DanhSachSach();
            }
            else
            {
                string masach = txbTimSachTheoMa.Text;
                int resultCMND;
                if (!int.TryParse(masach, out resultCMND))
                {
                    resultCMND = -1;
                }

                sachDTO sDTO = new sachDTO(resultCMND, txbTimSachTheoTen.Text, txbTimSachTheoTheLoai.Text, txbTimSachTheoTacGia.Text, "", DateTime.Now, DateTime.Now, 0, 0);
                listSach = quanLiSachBUS.TimSach(sDTO);
            }
            
            dgvThongTinSach.DataSource = listSach.Select(o => new { Column1 = o.Masach, Column2 = o.Tensach, Column3 = o.Tacgia, colum4 = o.Nxb}).ToList();
     
        }

        private void btnHienThongTinChiTietSach_Click(object sender, EventArgs e)
        {
            if (indexSach >= 0)
            {
                frmThongTinSach f = new frmThongTinSach(listSach[indexSach]);
                f.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin sách để hiển thị", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            frmThemSach f = new frmThemSach(this);
            f.Show();
        }

        private void btnSuaThongTinSach_Click(object sender, EventArgs e)
        {
            if (txbTenSach.Text != "" && cbTheLoaiSach.Text != "" && txbTacGiaSach.Text != "" && txbNhaXuatBanSach.Text != "" && txbNamXuatBanSach.Text != "" && txbGiaTriSach.Text != "")
            {
                DateTime datebyYear = new DateTime(int.Parse(txbNamXuatBanSach.Text),1,1);
                sachDTO sach = new sachDTO(int.Parse( txbMaSach.Text), txbTenSach.Text, cbTheLoaiSach.Text, txbTacGiaSach.Text, txbNhaXuatBanSach.Text, dtpNgayNhapSach.Value, datebyYear, int.Parse(txbGiaTriSach.Text), int.Parse( cbTinhTrangSach.Text));
                QuanLiSachBUS qlSach = new QuanLiSachBUS();
                if (qlSach.SuaSach(sach))
                {
                    MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK);
                    loadDanhSachSach();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại. "+BUS_notification.mess, "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);

            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event Tab Phieu Muon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoPhieuMuon_Click(object sender, EventArgs e)
        {
            frmNhapMaThe f = new frmNhapMaThe(listDocGia, 0);
            f.Show();
        }

        /// <summary>
        /// Event Tab Phieu Tra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPhieuTra_Click(object sender, EventArgs e)
        {
            frmNhapMaThe f = new frmNhapMaThe(listDocGia, 1);
            f.Show();
        }

        /// <summary>
        /// Event Tab Phieu Tra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaoPhieuThuTienPhat_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event Form Man Hinh Chinh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmManHinhChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát chương trình", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Ánh xạ thông tin bạn đọc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvThongTinBanDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView data = (DataGridView)sender;
            if (data.RowCount > 0)
            {
                indexBanDoc = data.SelectedRows[0].Index;
                anhXaThongTinBanDoc(indexBanDoc);
            }
            
        }

        private void anhXaThongTinBanDoc(int indexBanDoc)
        {
            txbTenBanDoc.Text = listDocGia[indexBanDoc].HoTen;
            txbCMNDBanDoc.Text = listDocGia[indexBanDoc].MaThe.ToString();
            dtpNgaySinhBanDoc.Value = listDocGia[indexBanDoc].NgaySinh;
            txbEmailBanDoc.Text = listDocGia[indexBanDoc].Email;
            txbDiaChiBanDoc.Text = listDocGia[indexBanDoc].DiaChi;
            cbLoaiDocGia.Text = listDocGia[indexBanDoc].Loaidocgia.ToString();
            txbTongTienNoBanDoc.Text = listDocGia[indexBanDoc].Tongtienno.ToString();
            dtpNgayTaoTheBanDoc.Value = listDocGia[indexBanDoc].Ngaydk;
        }

        private void dgvThongTinSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView data = (DataGridView)sender;
            if (data.RowCount > 0)
            {
                indexSach = data.SelectedRows[0].Index;
                anhXaThongTinSach(indexSach);
            }
        }

        private void anhXaThongTinSach(int indexSach)
        {
            txbMaSach.Text = listSach[indexSach].Masach.ToString();
            txbTenSach.Text = listSach[indexSach].Tensach;
            cbTheLoaiSach.Text = listSach[indexSach].Theloai;
            txbTacGiaSach.Text = listSach[indexSach].Tacgia;
            txbNhaXuatBanSach.Text = listSach[indexSach].Nxb;
            dtpNgayNhapSach.Value = listSach[indexSach].Ngaynhap;
            txbNamXuatBanSach.Text = listSach[indexSach].Ngayxb.Year.ToString();
            txbGiaTriSach.Text = listSach[indexSach].Giatri.ToString();
            cbTinhTrangSach.Text = listSach[indexSach].Trangthai.ToString();
        }
        //
        //TAB THONG KE
        //
        private void btnXemDS_Click(object sender, EventArgs e)
        {
            sachtratreBUS sachtratreBUS = new sachtratreBUS();
            thongketheloaiBUS theloaiBUS = new thongketheloaiBUS();

            if (rdoSachTraTre.Checked)
            {
                DateTime thangThongKe = dtmThongKe.Value;
                


                dgvThongKe.DataSource = sachtratreBUS.LayDSSachChuaTra(thangThongKe);
            }
            else if (rdoTheLoai.Checked)
            {
                DateTime thangThongKe = dtmThongKe.Value;
               
                
                dgvThongKe.DataSource = theloaiBUS.layDSLoaiSachDuocQuanTam(thangThongKe);
            }
        }

        private void tcManHinhChinh_Selected(object sender, TabControlEventArgs e)
        {
            switch (tcManHinhChinh.SelectedIndex)
            {
                case 0:
                    txbTimKiemBanDocTheoMa.Focus();
                    break;
                case 1:
                    txbTimSachTheoMa.Focus();
                    break;
            }
        }
    }
}
