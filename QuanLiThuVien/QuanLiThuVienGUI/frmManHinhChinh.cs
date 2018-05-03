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
        QuanLiBanDocBUS quanLiBanDocBUS = new QuanLiBanDocBUS();
        int index = -1;

        public frmManHinhChinh()
        {
            InitializeComponent();
            listDocGia = quanLiBanDocBUS.DanhSachDocGia();
            initDataGridView();
        }

        private void initDataGridView()
        {
            dgvThongTinBanDoc.DataSource = listDocGia.Select(o => new { Column1 = o.MaThe, Column2 = o.HoTen, Column3 = o.Email, Column4 = o.NgaySinh }).ToList();
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

        /// <summary>
        /// Event menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void thêmBạnĐọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemBanDoc f = new frmThemBanDoc();
            f.ShowDialog();
        }

        private void thêmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemSach f = new frmThemSach();
            f.ShowDialog();
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

        }

        private void tạoPhiếuTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
            listDocGia = quanLiBanDocBUS.TimDocGia(txbTimKiemBanDocTheoMa.Text, txbTimKiemTheoTenBanDoc.Text);
            dgvThongTinBanDoc.DataSource = listDocGia.Select(o => new { Column1 = o.MaThe, Column2 = o.HoTen, Column3 = o.Email, Column4 = o.NgaySinh }).ToList();
            dgvThongTinBanDoc.Columns[0].HeaderText = "Mã thẻ";
            dgvThongTinBanDoc.Columns[1].HeaderText = "Họ tên";
            dgvThongTinBanDoc.Columns[2].HeaderText = "Email";
            dgvThongTinBanDoc.Columns[3].HeaderText = "Ngày sinh";
            //dgvThongTinBanDoc.Show();
        }

        private void btnHienThongTinChiTietBanDoc_Click(object sender, EventArgs e)
        {
            if (index >= 0)
            {
                frmThongTinBanDoc f = new frmThongTinBanDoc(listDocGia[index]);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin bạn đọc để hiển thị", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThemBanDoc_Click(object sender, EventArgs e)
        {
            frmThemBanDoc f = new frmThemBanDoc();
            f.ShowDialog();
        }

        private void btnSuaThongTinBanDoc_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaBanDoc_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event Tab Sach
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnTimSach_Click(object sender, EventArgs e)
        {

        }

        private void btnHienThongTinChiTietSach_Click(object sender, EventArgs e)
        {
            frmThongTinSach f = new frmThongTinSach();
            f.ShowDialog();
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            frmThemSach f = new frmThemSach();
            f.ShowDialog();
        }

        private void btnSuaThongTinSach_Click(object sender, EventArgs e)
        {

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

        }

        /// <summary>
        /// Event Tab Phieu Tra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnPhieuTra_Click(object sender, EventArgs e)
        {

        }

        private void lvDanhSachBanDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            index = data.SelectedRows[0].Index;
            anhXaThongTinBanDoc(index);
        }

        private void anhXaThongTinBanDoc(int index)
        {
            txbTenBanDoc.Text = listDocGia[index].HoTen;
            txbCMNDBanDoc.Text = listDocGia[index].MaThe.ToString();
            dtpNgaySinhBanDoc.Value = listDocGia[index].NgaySinh;
            txbEmailBanDoc.Text = listDocGia[index].Email;
            txbDiaChiBanDoc.Text = listDocGia[index].DiaChi;
            cbLoaiDocGia.Text = listDocGia[index].Loaidocgia.ToString();
            txbTongTienNoBanDoc.Text = listDocGia[index].Tongtienno.ToString();
            dtpNgayTaoTheBanDoc.Value = listDocGia[index].Ngaydk;
        }
    }
}
