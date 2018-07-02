using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLiThuVienBUS;
using QuanLiThuVienDTO;

namespace QuanLiThuVienGUI
{
    public partial class frmManHinhChinh : Form
    {
        List<docgiaDTO> listDocGia;
        List<sachDTO> listSach;
        List<loaidocgiaDTO> listLoaiDocGia;
        List<loaisachDTO> listLoaiSach;

        QuanLiBanDocBUS quanLiBanDocBUS = new QuanLiBanDocBUS();
        QuanLiSachBUS quanLiSachBUS = new QuanLiSachBUS();
        QuanLiTheLoaiSachBUS quanLiTheLoaiSachBUS = new QuanLiTheLoaiSachBUS();

        docgiaDTO docgia;
        sachDTO sach;

        int indexBanDoc = 0;
        int indexSach = 0;

        public frmManHinhChinh()
        {
            InitializeComponent();

            resizeSttErrorLabel();

            try
            {
                initComboBox();

                loadDanhSachBanDoc();
                initDataGridViewBanDoc();

                loadDanhSachSach();
                initDataGridViewSach();

                anhXaQuyDinh();
            }
            catch (Exception e)
            {
                ConnectionError();
                MessageBox.Show(e.ToString());
            }
        }

        private void ConnectionError()
        {
            cậpNhậtToolStripMenuItem.Enabled = false;
            quảnLýMượntrảToolStripMenuItem.Enabled = false;
            sttErrorLabel.Text = "Không kết nối được với dữ liệu. Vui lòng thử lại!";
        }

        private void initComboBox()
        {
            listLoaiDocGia = quanLiBanDocBUS.CacLoaiDocGia();
            foreach (loaidocgiaDTO loaidocgia in listLoaiDocGia)
            {
                cbLoaiDocGia.Items.Add(QuanLiBanDocBUS.LoaiDocGia[loaidocgia.Cacloai]);
            }

            listLoaiSach = quanLiTheLoaiSachBUS.LayDanhSachCacTheLoai();
            foreach (loaisachDTO loaisach in listLoaiSach)
            {
                cbTheLoaiSach.Items.Add(loaisach.Theloaisach);
                cbTimSachTheoTheLoai.Items.Add(loaisach.Theloaisach);
            }
        }

        private void initDataGridViewBanDoc()
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

        public void loadDanhSachBanDoc()
        {
            listDocGia = quanLiBanDocBUS.DanhSachDocGia();
            if (listDocGia.Count > 0)
            {
                docgia = listDocGia[0];
                anhXaThongTinBanDoc(0);
            }
        }

        public void loadDanhSachBanDoc(int index)
        {
            listDocGia = quanLiBanDocBUS.DanhSachDocGia();
            dgvThongTinBanDoc.DataSource = listDocGia.Select(o => new { Column1 = o.MaThe, Column2 = o.HoTen, Column3 = o.Email, Column4 = o.NgaySinh }).ToList();
            if (listDocGia.Count > 0)
            {
                dgvThongTinBanDoc.Rows[0].Selected = false;
                dgvThongTinBanDoc.Rows[index].Selected = true;
                dgvThongTinBanDoc.CurrentCell = dgvThongTinBanDoc.Rows[index].Cells[0];
                anhXaThongTinBanDoc(index);
                indexBanDoc = index;
                docgia = listDocGia[indexBanDoc];
            }
        }

        private void initDataGridViewSach()
        {
            dgvThongTinSach.DataSource = listSach.Select(o => new { Column1 = o.Masach, Column2 = o.Tensach, Column3 = o.Tacgia, Column4 = o.Nxb }).ToList();
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
            if (listSach.Count > 0)
            {
                sach = listSach[0];
                anhXaThongTinSach(0);
            }
        }

        public void loadDanhSachSach(int index)
        {
            listSach = quanLiSachBUS.DanhSachSach();
            dgvThongTinSach.DataSource = listSach.Select(o => new { Column1 = o.Masach, Column2 = o.Tensach, Column3 = o.Tacgia, Column4 = o.Nxb }).ToList();
            dgvThongTinSach.Rows[0].Selected = false;
            dgvThongTinSach.Rows[index].Selected = true;
            dgvThongTinSach.CurrentCell = dgvThongTinSach.Rows[index].Cells[0];
            anhXaThongTinSach(index);
            indexSach = index;
            sach = listSach[indexSach];
        }

        /// <summary>
        /// Event menu strip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void thêmBạnĐọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemBanDoc f = new frmThemBanDoc(this);
            f.ShowDialog();
        }

        private void thêmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemSach f = new frmThemSach(this);
            f.ShowDialog();
        }

        private void tạoPhiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapMaThe f = new frmNhapMaThe("Tạo phiếu mượn", listDocGia ,0, this);
            f.ShowDialog();
        }

        private void tạoPhiếuTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapMaThe f = new frmNhapMaThe("Tạo phiếu trả", listDocGia, 1, this);
            f.ShowDialog();
        }

        private void thuTiềnPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapMaThe f = new frmNhapMaThe("Tạo phiếu thu tiền phạt", listDocGia, 2, this);
            f.ShowDialog();
        }

        private void thôngTinPhầnMềmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/hoango7604/se104-QuanLyThuVien");
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
            refreshError();

            if (txbTimKiemBanDocTheoMa.Text == "" && txbTimKiemTheoTenBanDoc.Text == "")
            {
                listDocGia = quanLiBanDocBUS.DanhSachDocGia();
            }
            else
            {
                try
                {
                    listDocGia = quanLiBanDocBUS.TimDocGia(txbTimKiemBanDocTheoMa.Text, txbTimKiemTheoTenBanDoc.Text);
                }
                catch (FormatException error)
                {
                    sttErrorLabel.Text = "Lỗi định dạng. Vui lòng nhập lại";
                    Console.WriteLine(error.ToString());
                }
            }
            initDataGridViewBanDoc();
        }

        public void ShowThongTinBanDoc(int index)
        {
            refreshError();

            if (index >= 0)
            {
                frmThongTinBanDoc f = new frmThongTinBanDoc(docgia, this);
                f.ShowDialog();
            }
            else
            {
                sttErrorLabel.Text = "Vui lòng chọn thông tin bạn đọc để hiển thị";
            }
        }

        private void btnHienThongTinChiTietBanDoc_Click(object sender, EventArgs e)
        {
            if (listDocGia.Count > 0)
            {
                ShowThongTinBanDoc(indexBanDoc);
            }
        }

        private void btnThemBanDoc_Click(object sender, EventArgs e)
        {
            frmThemBanDoc f = new frmThemBanDoc(this);
            f.ShowDialog();
        }

        private void btnSuaThongTinBanDoc_Click(object sender, EventArgs e)
        {
            int loaiDocGia = 0;
            int tuoi = 0;

            refreshError();

            if (listDocGia.Count > 0)
            {
                if (txbTenBanDoc.Text != "" && txbEmailBanDoc.Text != "" && txbDiaChiBanDoc.Text != "" && txbCMNDBanDoc.Text != "" && cbLoaiDocGia.Text != "" && dtpNgaySinhBanDoc.Text != "")
                {
                    tuoi = DateTime.Now.Year - dtpNgaySinhBanDoc.Value.Year;
                    if (tuoi < 18)
                    {
                        loaiDocGia = 0;
                    }
                    else if (tuoi >= 18 && tuoi <= 22)
                    {
                        loaiDocGia = 1;
                    }
                    else if (tuoi > 22)
                    {
                        loaiDocGia = 2;
                    }

                    if (quanLiBanDocBUS.SuaDocGia(new docgiaDTO(int.Parse(txbCMNDBanDoc.Text), txbTenBanDoc.Text, txbDiaChiBanDoc.Text, txbEmailBanDoc.Text, dtpNgaySinhBanDoc.Value, dtpNgayTaoTheBanDoc.Value, int.Parse(txbTongTienNoBanDoc.Text), loaiDocGia)))
                    {
                        sttErrorLabel.Text = "Cập nhật thông tin thành công";
                        loadDanhSachBanDoc(indexBanDoc);
                    }
                    else
                    {
                        sttErrorLabel.Text = "Cập nhật thông tin thất bại. Vui lòng kiểm tra lại";
                    }
                }
                else
                {
                    sttErrorLabel.Text = "Vui lòng điền đầy đủ thông tin";

                }
            }
        }

        private void btnXoaBanDoc_Click(object sender, EventArgs e)
        {
            refreshError();

            if (indexBanDoc >= 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa bạn đọc " + listDocGia[indexBanDoc].HoTen + "?", "Xóa bạn đọc", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    if (quanLiBanDocBUS.XoaDocGia(docgia))
                    {
                        sttErrorLabel.Text = "Xóa bạn đọc thành công";
                        loadDanhSachBanDoc(indexBanDoc >= listDocGia.Count - 1 ? indexBanDoc - 1 : indexBanDoc);
                    }
                    else
                    {
                        sttErrorLabel.Text = "Xóa bạn đọc thất bại. Vui lòng kiểm tra lại";
                    }
                }
            }
            else
            {
                sttErrorLabel.Text = "Vui lòng chọn một bạn đọc";
            }
        }

        /// <summary>
        /// Event Tab Sach
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnTimSach_Click(object sender, EventArgs e)
        {
            refreshError();

            if (txbTimSachTheoMa.Text == "" && txbTimSachTheoTacGia.Text == "" && txbTimSachTheoTen.Text == "" && cbTimSachTheoTheLoai.Text == "")
            {
                listSach = quanLiSachBUS.DanhSachSach();
            }
            else
            {
                try
                {
                    sachDTO sDTO = new sachDTO(txbTimSachTheoMa.Text == "" ? -1 : int.Parse(txbTimSachTheoMa.Text), txbTimSachTheoTen.Text, cbTimSachTheoTheLoai.Text, txbTimSachTheoTacGia.Text, "", DateTime.Now, DateTime.Now, 0, 0);
                    listSach = quanLiSachBUS.TimSach(sDTO);
                }
                catch (FormatException error)
                {
                    sttErrorLabel.Text = "Lỗi định dạng. Vui lòng nhập lại";
                    Console.WriteLine(error.ToString());
                }
            }

            initDataGridViewSach();
     
        }

        private void btnHienThongTinChiTietSach_Click(object sender, EventArgs e)
        {
            refreshError();

            if (listSach.Count > 0)
            {
                if (indexSach >= 0)
                {
                    frmThongTinSach f = new frmThongTinSach(sach);
                    f.ShowDialog();
                }
                else
                {
                    sttErrorLabel.Text = "Vui lòng chọn thông tin sách để hiển thị";
                }
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            frmThemSach f = new frmThemSach(this);
            f.ShowDialog();
        }

        private void btnSuaThongTinSach_Click(object sender, EventArgs e)
        {
            refreshError();

            if (listSach.Count > 0)
            {
                if (txbTenSach.Text != "" && cbTheLoaiSach.Text != "" && txbTacGiaSach.Text != "" && txbNhaXuatBanSach.Text != "" && txbNamXuatBanSach.Text != "" && txbGiaTriSach.Text != "")
                {
                    DateTime datebyYear = new DateTime(int.Parse(txbNamXuatBanSach.Text), 1, 1);
                    int trangThaiSach = 0;
                    for (int i = 0; i < QuanLiSachBUS.DanhSachTrangThaiSach.Length; i++)
                    {
                        if (cbTinhTrangSach.Text == QuanLiSachBUS.DanhSachTrangThaiSach[i])
                        {
                            trangThaiSach = i;
                        }
                    }
                    sachDTO sach = new sachDTO(int.Parse(txbMaSach.Text), txbTenSach.Text, cbTheLoaiSach.Text, txbTacGiaSach.Text, txbNhaXuatBanSach.Text, dtpNgayNhapSach.Value, datebyYear, int.Parse(txbGiaTriSach.Text), trangThaiSach);

                    bool isExistTheLoaiSach = false;
                    foreach (loaisachDTO loaisach in listLoaiSach)
                    {
                        if (cbTheLoaiSach.Text == loaisach.Theloaisach)
                        {
                            isExistTheLoaiSach = true;
                        }
                    }
                    if (isExistTheLoaiSach == false)
                    {
                        quanLiTheLoaiSachBUS.ThemTheLoaisach(new loaisachDTO(cbTheLoaiSach.Text));

                        listLoaiSach.Clear();
                        listLoaiSach = quanLiTheLoaiSachBUS.LayDanhSachCacTheLoai();

                        cbTheLoaiSach.Items.Clear();
                        cbTimSachTheoTheLoai.Items.Clear();
                        foreach (loaisachDTO loaisach in listLoaiSach)
                        {
                            cbTheLoaiSach.Items.Add(loaisach.Theloaisach);
                            cbTimSachTheoTheLoai.Items.Add(loaisach.Theloaisach);
                        }
                    }

                    if (quanLiSachBUS.SuaSach(sach))
                    {
                        sttErrorLabel.Text = "Cập nhật thông tin thành công";
                        loadDanhSachSach(indexSach);
                    }
                    else
                    {
                        sttErrorLabel.Text = "Cập nhật thông tin thất bại. " + BUS_notification.mess;
                    }
                }
                else
                {
                    sttErrorLabel.Text = "Vui lòng điền đầy đủ thông tin";

                }
            }
        }

        /// <summary>
        /// Event Form Man Hinh Chinh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmManHinhChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát chương trình", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
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
                docgia = listDocGia[indexBanDoc];
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
            cbLoaiDocGia.Text = QuanLiBanDocBUS.LoaiDocGia[listDocGia[indexBanDoc].Loaidocgia];
            txbTongTienNoBanDoc.Text = listDocGia[indexBanDoc].Tongtienno.ToString();
            dtpNgayTaoTheBanDoc.Value = listDocGia[indexBanDoc].Ngaydk;
        }

        private void dgvThongTinSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView data = (DataGridView)sender;
            if (data.RowCount > 0)
            {
                indexSach = data.SelectedRows[0].Index;
                sach = listSach[indexSach];
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
            cbTinhTrangSach.Text = QuanLiSachBUS.DanhSachTrangThaiSach[listSach[indexSach].Trangthai];
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
                dgvThongKe.Columns[0].Width = dgvThongKe.Size.Width / 3;
                dgvThongKe.Columns[1].Width = dgvThongKe.Size.Width / 3;
                dgvThongKe.Columns[2].Width = dgvThongKe.Size.Width / 3;
            }
            else if (rdoTheLoai.Checked)
            {
                DateTime thangThongKe = dtmThongKe.Value;
                dgvThongKe.DataSource = theloaiBUS.layDSLoaiSachDuocQuanTam(thangThongKe);
                dgvThongKe.Columns[0].Width = dgvThongKe.Size.Width / 2;
                dgvThongKe.Columns[1].Width = dgvThongKe.Size.Width / 2;
            }
        }
        private void btnInDS_Click(object sender, EventArgs e)
        {           
            frmInThongKe frmInThongKe = new frmInThongKe();
            
            if(rdoSachTraTre.Checked)
            {
                frmInThongKe.TKRportViewer.Reset();
                frmInThongKe.TKRportViewer.LocalReport.ReportEmbeddedResource = "QuanLiThuVienGUI.SachTraTre.rdlc";

                SachTraTreDataSet sachTraTreDataSet = new SachTraTreDataSet();

                SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=THUVIEN;Integrated Security=True");
                string SQL = string.Format("select s.tensach, pm.ngaymuon, DATEDIFF(day, pm.ngaymuon,GETDATE()) as songaytre from((sach s inner join ct_phieumuon ctpm on s.masach = ctpm.masach) inner join phieumuon pm on ctpm.mapm = pm.mapm) where (MONTH(pm.ngaymuon) = {0} and YEAR(pm.ngaymuon) = {1}) and s.masach not in  (select s1.masach from(sach s1 inner join ct_phieutra ctpt on s1.masach = ctpt.masach) inner join phieutra pt on ctpt.mapt = pt.mapt)", dtmThongKe.Value.Month, dtmThongKe.Value.Year);
                SqlDataAdapter da = new SqlDataAdapter(SQL, cn);
                da.Fill(sachTraTreDataSet, sachTraTreDataSet.Tables[0].TableName);

                

                ReportParameterCollection reportParameterCollection = new ReportParameterCollection();
                reportParameterCollection.Add(new ReportParameter("MonthReportParameter", dtmThongKe.Value.Month.ToString()));
                frmInThongKe.TKRportViewer.LocalReport.SetParameters(reportParameterCollection);

                ReportDataSource rds = new ReportDataSource("SachTraTre", sachTraTreDataSet.Tables[0]);
                frmInThongKe.TKRportViewer.LocalReport.DataSources.Clear();
                frmInThongKe.TKRportViewer.LocalReport.DataSources.Add(rds);
                frmInThongKe.TKRportViewer.LocalReport.Refresh();
                frmInThongKe.TKRportViewer.RefreshReport();

                frmInThongKe.Show();
            }    
            else if(rdoTheLoai.Checked)
            {
                frmInThongKe.TKRportViewer.Reset();
                frmInThongKe.TKRportViewer.LocalReport.ReportEmbeddedResource = "QuanLiThuVienGUI.TheLoaiSach.rdlc";

                TheLoaiSachDataSet theLoaiSachDataSet = new TheLoaiSachDataSet();
                SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=THUVIEN;Integrated Security=True");
                string SQL = string.Format("select s.theloai, COUNT(*) as SoLuong from(phieumuon pm inner join ct_phieumuon ctpm on pm.mapm = ctpm.mapm) inner join sach s on s.masach = ctpm.masach where MONTH(pm.ngaymuon) = {0} and YEAR(pm.ngaymuon) = {1} group by(s.theloai) order by SoLuong desc ", dtmThongKe.Value.Month, dtmThongKe.Value.Year);
                SqlDataAdapter da = new SqlDataAdapter(SQL, cn);
                da.Fill(theLoaiSachDataSet, theLoaiSachDataSet.Tables[0].TableName);

                

                ReportParameterCollection reportParameterCollection = new ReportParameterCollection();
                reportParameterCollection.Add(new ReportParameter("TheLoai_MonthReportParameter", dtmThongKe.Value.Month.ToString()));
                frmInThongKe.TKRportViewer.LocalReport.SetParameters(reportParameterCollection);

                ReportDataSource rds = new ReportDataSource("TheLoaiSach", theLoaiSachDataSet.Tables[0]);
                frmInThongKe.TKRportViewer.LocalReport.DataSources.Clear();
                frmInThongKe.TKRportViewer.LocalReport.DataSources.Add(rds);
                frmInThongKe.TKRportViewer.LocalReport.Refresh();

                frmInThongKe.TKRportViewer.RefreshReport();

                frmInThongKe.Show();
            }
            
        }

        
        //end tab THONG KE
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

        

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchBanDocTheoMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiemBanDoc_Click(sender, e);
            }
        }
        
        private void searchSachTheoMa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimSach_Click(sender, e);
            }
        }

        private void editThongTinBanDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSuaThongTinBanDoc_Click(sender, e);
            }
        }

        //
        //TAB QUY DINH
        //

        private void anhXaQuyDinh()
        {
            quydinhBUS quydinhBUS = new quydinhBUS();
            quydinhDTO quydinhDTO = new quydinhDTO();

            if(quydinhBUS.ListQuyDinh(quydinhDTO))
            {
                txbQuyDinhTienPhat.Text = quydinhDTO.Tienphattrasachtremoingay.ToString();
                txbQuyDinhTuoiToiThieu.Text = quydinhDTO.Tuoimin.ToString();
                txbQuyDinhTuoiToiDa.Text = quydinhDTO.Tuoimax.ToString();
                txbQuyDinhSoSachDuocMuon.Text = quydinhDTO.Sosachduocmuon.ToString();
                txbQuyDinhSoNgayDuocMuon.Text = quydinhDTO.Songayduocmuon.ToString();
                txbQuyDinhKhoangCachNamXB.Text = quydinhDTO.Kcnamxuatban.ToString();
            }
        }

        private void btnCapNhatQuyDinh_Click(object sender, EventArgs e)
        {
            refreshError();
            if(btnCapNhatQuyDinh.Text == "Cập Nhật Quy Định")
            {
                txbQuyDinhKhoangCachNamXB.Enabled = true;
                txbQuyDinhSoNgayDuocMuon.Enabled = true;
                txbQuyDinhSoSachDuocMuon.Enabled = true;
                txbQuyDinhTienPhat.Enabled = true;
                txbQuyDinhTuoiToiDa.Enabled = true;
                txbQuyDinhTuoiToiThieu.Enabled = true;

                btnCapNhatQuyDinh.Text = "Lưu";
            }
            else if(btnCapNhatQuyDinh.Text == "Lưu")
            {
                if (txbQuyDinhKhoangCachNamXB.Text != "" && txbQuyDinhSoNgayDuocMuon.Text != "" && txbQuyDinhSoSachDuocMuon.Text != "" && txbQuyDinhTienPhat.Text != "" && txbQuyDinhTuoiToiDa.Text != "" && txbQuyDinhTuoiToiThieu.Text != "")
                {
                    quydinhBUS quydinhBUS = new quydinhBUS();
                    quydinhDTO quydinhDTO = new quydinhDTO(int.Parse(txbQuyDinhTienPhat.Text), int.Parse(txbQuyDinhTuoiToiDa.Text), int.Parse(txbQuyDinhTuoiToiThieu.Text), int.Parse(txbQuyDinhSoNgayDuocMuon.Text), int.Parse(txbQuyDinhSoSachDuocMuon.Text), int.Parse(txbQuyDinhKhoangCachNamXB.Text));

                    if (quydinhBUS.SuaQuyDinh(quydinhDTO))
                    {
                        txbQuyDinhKhoangCachNamXB.Enabled = false;
                        txbQuyDinhSoNgayDuocMuon.Enabled = false;
                        txbQuyDinhSoSachDuocMuon.Enabled = false;
                        txbQuyDinhTienPhat.Enabled = false;
                        txbQuyDinhTuoiToiDa.Enabled = false;
                        txbQuyDinhTuoiToiThieu.Enabled = false;

                        sttErrorLabel.Text = "Cập nhật quy định thành công!";

                        btnCapNhatQuyDinh.Text = "Cập Nhật Quy Định";
                    }

                    anhXaQuyDinh();
                    
                }
                else
                {
                    sttErrorLabel.Text = "Vui lòng điền đầy đủ các ô quy định";
                }
            }
        }

        private void txbTenBanDoc_TextChanged(object sender, EventArgs e)
        {
            string Name = txbTenBanDoc.Text;

            if (Name.Length <= 3 && Name != "")
            {
                lbTenbandocEX.Text = "Vui lòng nhập tên nhiều hơn 3 kí tự!";
                btnThemBanDoc.Enabled = false;
            }
            else
            {
                lbTenbandocEX.Text = "";
                btnThemBanDoc.Enabled = true;
            }
        }

        private void txbCMNDBanDoc_TextChanged(object sender, EventArgs e)
        {
            string cmnd = txbCMNDBanDoc.Text;

            int check;
            Int32.TryParse(cmnd, out check);
            if (check == 0 && cmnd != "")
            {
                lbCmndEX.Text = "Vui lòng chỉ nhập số!";
                btnThemBanDoc.Enabled = false;
            }
            else
            {
                lbCmndEX.Text = "";
                btnThemBanDoc.Enabled = true;

            }
        }

        private void txbEmailBanDoc_TextChanged(object sender, EventArgs e)
        {
            string email = txbEmailBanDoc.Text;
            if ((email.Contains(".com") || email.Contains(".vn")) && email.Contains("@"))
            {
                lbEmailEX.Text = "";
                btnThemBanDoc.Enabled = true;

            }
            else
            {
                if (email != "")
                {
                    lbEmailEX.Text = "Vui lòng nhập đúng địa chỉ Email!";
                }
                else
                {
                    lbEmailEX.Text = "";
                }

                btnThemBanDoc.Enabled = false;
            }
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

        private void cbTheLoaiSach_Enter(object sender, EventArgs e)
        {
            cbTheLoaiSach.DroppedDown = true;
        }

        private void cbTimSachTheoTheLoai_Enter(object sender, EventArgs e)
        {
            cbTimSachTheoTheLoai.DroppedDown = true;
        }

        private void refreshError()
        {
            sttErrorLabel.Text = "";
            resizeSttErrorLabel();
        }

        private void resizeSttErrorLabel()
        {
            this.sttError.Size = new Size(48, 22);
            this.Size = new Size(990, 640);
        }

        //End tab QuyDinh

        private void editThongTinSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSuaThongTinSach_Click(sender, e);
            }
        }
    }
}