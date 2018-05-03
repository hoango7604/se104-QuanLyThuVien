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
        List<docgiaDTO> list;
        QuanLiBanDocBUS quanLiBanDocBUS = new QuanLiBanDocBUS();

        public frmManHinhChinh()
        {
            InitializeComponent();
            initDataGridView();
        }

        private void initDataGridView()
        {
            list = quanLiBanDocBUS.DanhSachDocGia();
            dgvThongTinBanDoc.DataSource = list.Select(o => new { Column1 = o.MaThe, Column2 = o.HoTen, Column3 = o.Email, Column4 = o.NgaySinh }).ToList();
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
            list = quanLiBanDocBUS.TimDocGia(txbTimKiemBanDocTheoMa.Text, txbTimKiemTheoTenBanDoc.Text);
            // dgvThongTinBanDoc.Refresh();
            dgvThongTinBanDoc.DataSource = list.Select(o => new { Column1 = o.MaThe, Column2 = o.HoTen, Column3 = o.Email, Column4 = o.NgaySinh }).ToList();
            dgvThongTinBanDoc.Columns[0].HeaderText = "Mã thẻ";
            dgvThongTinBanDoc.Columns[1].HeaderText = "Họ tên";
            dgvThongTinBanDoc.Columns[2].HeaderText = "Email";
            dgvThongTinBanDoc.Columns[3].HeaderText = "Ngày sinh";
            dgvThongTinBanDoc.Show();
        }

        private void btnHienThongTinChiTietBanDoc_Click(object sender, EventArgs e)
        {
            frmThongTinBanDoc f = new frmThongTinBanDoc();
            f.ShowDialog();
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

        private void dgvThongTinBanDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView data = (DataGridView)sender;
            int index = data.SelectedRows[0].Index;
            txbTenBanDoc.Text = list[index].HoTen;
            txbCMNDBanDoc.Text = list[index].MaThe.ToString();
            dtpNgaySinhBanDoc.Value = list[index].NgaySinh;
            txbEmailBanDoc.Text = list[index].Email;
            txbDiaChiBanDoc.Text = list[index].DiaChi;
            cbLoaiDocGia.Text = list[index].Loaidocgia.ToString();
            txbTongTienNoBanDoc.Text = list[index].Tongtienno.ToString();
            dtpNgayTaoTheBanDoc.Value = list[index].Ngaydk;
        }
    }
}
