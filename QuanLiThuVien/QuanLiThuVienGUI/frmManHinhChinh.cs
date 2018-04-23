using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiThuVienGUI
{
    public partial class frmManHinhChinh : Form
    {
        public frmManHinhChinh()
        {
            InitializeComponent();
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

        }

        private void tìmKiếmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void thôngTinPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event Tab Ban Doc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnTimKiemBanDoc_Click(object sender, EventArgs e)
        {

        }

        private void btnHienThongTinChiTietBanDoc_Click(object sender, EventArgs e)
        {

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

        /// <summary>
        /// Event Tab Phieu Tra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnTaoPhieuThuTienPhat_Click(object sender, EventArgs e)
        {

        }
    }
}
