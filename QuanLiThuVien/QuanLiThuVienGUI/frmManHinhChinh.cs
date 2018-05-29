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
        List<loaidocgiaDTO> listLoaiDocGia;
        List<loaisachDTO> listLoaiSach;
        QuanLiBanDocBUS quanLiBanDocBUS = new QuanLiBanDocBUS();
        QuanLiSachBUS quanLiSachBUS = new QuanLiSachBUS();
        QuanLiTheLoaiSachBUS quanLiTheLoaiSachBUS = new QuanLiTheLoaiSachBUS();
        int indexBanDoc = 0;
        int indexSach = 0;

        public frmManHinhChinh()
        {
            InitializeComponent();
            initComboBox();
            initDataGridViewBanDoc();
            initDataGridViewSach();
            anhXaThongTinBanDoc(indexBanDoc);
            anhXaThongTinSach(indexSach);
            anhXaQuyDinh();
            LoadQuyDinh();
        }

        private void anhXaQuyDinh()
        {

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
            }
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
            f.ShowDialog();
        }

        private void thêmSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemSach f = new frmThemSach(this);
            f.ShowDialog();
        }

        private void tạoPhiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapMaThe f = new frmNhapMaThe("Tạo phiếu mượn", listDocGia ,0);
            f.ShowDialog();
        }

        private void tạoPhiếuTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapMaThe f = new frmNhapMaThe("Tạo phiếu trả", listDocGia, 1);
            f.ShowDialog();
        }

        private void thuTiềnPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapMaThe f = new frmNhapMaThe("Tạo phiếu thu tiền phạt", listDocGia, 2);
            f.ShowDialog();
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
                try
                {
                    listDocGia = quanLiBanDocBUS.TimDocGia(txbTimKiemBanDocTheoMa.Text, txbTimKiemTheoTenBanDoc.Text);
                }
                catch (FormatException error)
                {
                    MessageBox.Show("Lỗi định dạng. Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK);
                    Console.WriteLine(error.ToString());
                }
            }
            dgvThongTinBanDoc.DataSource = listDocGia.Select(o => new { Column1 = o.MaThe, Column2 = o.HoTen, Column3 = o.Email, Column4 = o.NgaySinh }).ToList();
        }

        private void btnHienThongTinChiTietBanDoc_Click(object sender, EventArgs e)
        {
            if (indexBanDoc >= 0)
            {
                frmThongTinBanDoc f = new frmThongTinBanDoc(listDocGia[indexBanDoc]);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin bạn đọc để hiển thị", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThemBanDoc_Click(object sender, EventArgs e)
        {
            frmThemBanDoc f = new frmThemBanDoc(this);
            f.ShowDialog();
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
                try
                {
                    sachDTO sDTO = new sachDTO(txbTimSachTheoMa.Text == "" ? -1 : int.Parse(txbTimSachTheoMa.Text), txbTimSachTheoTen.Text, txbTimSachTheoTheLoai.Text, txbTimSachTheoTacGia.Text, "", DateTime.Now, DateTime.Now, 0, 0);
                    listSach = quanLiSachBUS.TimSach(sDTO);
                }
                catch (FormatException error)
                {
                    MessageBox.Show("Lỗi định dạng. Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK);
                    Console.WriteLine(error.ToString());
                }
            }
            
            dgvThongTinSach.DataSource = listSach.Select(o => new { Column1 = o.Masach, Column2 = o.Tensach, Column3 = o.Tacgia, colum4 = o.Nxb}).ToList();
     
        }

        private void btnHienThongTinChiTietSach_Click(object sender, EventArgs e)
        {
            if (indexSach >= 0)
            {
                frmThongTinSach f = new frmThongTinSach(listSach[indexSach]);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin sách để hiển thị", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            frmThemSach f = new frmThemSach(this);
            f.ShowDialog();
        }

        private void btnSuaThongTinSach_Click(object sender, EventArgs e)
        {
            if (txbTenSach.Text != "" && cbTheLoaiSach.Text != "" && txbTacGiaSach.Text != "" && txbNhaXuatBanSach.Text != "" && txbNamXuatBanSach.Text != "" && txbGiaTriSach.Text != "")
            {
                DateTime datebyYear = new DateTime(int.Parse(txbNamXuatBanSach.Text),1,1);
                int trangThaiSach = 0;
                for (int i = 0; i < QuanLiSachBUS.DanhSachTrangThaiSach.Length; i++)
                {
                    if (cbTinhTrangSach.Text == QuanLiSachBUS.DanhSachTrangThaiSach[i])
                    {
                        trangThaiSach = i;
                    }
                }
                sachDTO sach = new sachDTO(int.Parse( txbMaSach.Text), txbTenSach.Text, cbTheLoaiSach.Text, txbTacGiaSach.Text, txbNhaXuatBanSach.Text, dtpNgayNhapSach.Value, datebyYear, int.Parse(txbGiaTriSach.Text), trangThaiSach);

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
                    foreach (loaisachDTO loaisach in listLoaiSach)
                    {
                        cbTheLoaiSach.Items.Add(loaisach.Theloaisach);
                    }
                }

                if (quanLiSachBUS.SuaSach(sach))
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
            frmNhapMaThe f = new frmNhapMaThe("Tạo phiếu mượn", listDocGia, 0);
            f.ShowDialog();
        }

        /// <summary>
        /// Event Tab Phieu Tra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPhieuTra_Click(object sender, EventArgs e)
        {
            frmNhapMaThe f = new frmNhapMaThe("Tạo phiếu trả", listDocGia, 1);
            f.ShowDialog();
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

        private void btnInDS_Click(object sender, EventArgs e)
        {
            pvdInDanhSach.Document = pdInDanhSach;
            pvdInDanhSach.ShowDialog();
        }

        private void pdInDanhSach_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if(rdoSachTraTre.Checked)
            {
                sachtratreBUS busSachTraTre = new sachtratreBUS();
                DataTable dt = busSachTraTre.LayDSSachChuaTra(dtmThongKe.Value);

                e.Graphics.DrawString("THỐNG KÊ SÁCH TRẢ TRỄ", new Font("Arial", 26, FontStyle.Bold), Brushes.Black, new Point(25, 100));

                e.Graphics.DrawString(dtmThongKe.Value.Month.ToString() + "/" + dtmThongKe.Value.Year.ToString(), new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(25, 150));


                e.Graphics.DrawString("STT", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 250));
                e.Graphics.DrawString("Tên Sách", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(90, 250));
                e.Graphics.DrawString("Ngày Mượn", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(500, 250));
                e.Graphics.DrawString("Số Ngày Trễ", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(700, 250));

                int y = 300;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string TheLoai = dt.Rows[i]["Tên Sách"].ToString() + " ";

                    List<String> listTuKhoa = new List<string>();
                    for (int j = 0; j < TheLoai.Length; j++)
                    {
                        if (TheLoai[j] == ' ')
                        {
                            listTuKhoa.Add(TheLoai.Substring(0, j));
                            TheLoai = TheLoai.Substring(j + 1);
                            j = 0;
                        }
                    }

                    string ngayMuon = dt.Rows[i]["Ngày Mượn"].ToString();

                    e.Graphics.DrawString((i + 1).ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(25, y));
                    e.Graphics.DrawString(ngayMuon.Substring(0, 10), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(500, y));
                    e.Graphics.DrawString(dt.Rows[i]["Số Ngày Trễ"].ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(700, y));



                    while (listTuKhoa.Count >= 6)
                    {
                        string showTheLoai = "";
                        for (int count = 0; count < 6; count++)
                        {
                            showTheLoai += listTuKhoa[count] + " ";
                        }
                        e.Graphics.DrawString(showTheLoai, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(90, y));

                        listTuKhoa.RemoveRange(0, 6);
                        y += 30;
                    }
                    if (listTuKhoa.Count < 6)
                    {
                        string showTheLoai = "";
                        for (int count = 0; count < listTuKhoa.Count; count++)
                        {
                            showTheLoai += listTuKhoa[count] + " ";
                        }
                        e.Graphics.DrawString(showTheLoai, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(90, y));
                    }
                    y += 50;
                }
            }

            if (rdoTheLoai.Checked)
            {
                thongketheloaiBUS busTheLoai = new thongketheloaiBUS();
                DataTable dt = busTheLoai.layDSLoaiSachDuocQuanTam(dtmThongKe.Value);

                e.Graphics.DrawString("THỐNG KÊ THỂ LOẠI ĐANG ĐƯỢC MƯỢN NHIỀU", new Font("Arial", 20, FontStyle.Bold), Brushes.Black, new Point(25, 100));

                e.Graphics.DrawString(dtmThongKe.Value.Month.ToString() + "/" + dtmThongKe.Value.Year.ToString(), new Font("Arial", 16, FontStyle.Bold), Brushes.Black, new Point(25, 150));

                
                e.Graphics.DrawString("STT", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(25, 250));
                e.Graphics.DrawString("Thể Loại", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(90, 250));
                e.Graphics.DrawString("Số Lượt Mượn", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(400, 250));
               
                int y = 300;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string TheLoai = dt.Rows[i]["Thể Loại"].ToString() + " ";
                    
                    List<String> listTuKhoa = new List<string>();
                    for(int j = 0; j < TheLoai.Length; j++)
                    {
                        if(TheLoai[j] == ' ')
                        {
                            listTuKhoa.Add(TheLoai.Substring(0, j));
                            TheLoai = TheLoai.Substring(j + 1);
                            j = 0;
                        }
                    }


                    e.Graphics.DrawString((i + 1).ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(25, y));
                    e.Graphics.DrawString(dt.Rows[i]["Số Lượt Mượn"].ToString(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(400, y));

                    
                    while (listTuKhoa.Count >= 5)
                    {
                        string showTheLoai = "";
                        for (int count = 0; count < 5; count++)
                        {
                            showTheLoai += listTuKhoa[count] + " ";
                        }
                        e.Graphics.DrawString(showTheLoai, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(90, y));

                        listTuKhoa.RemoveRange(0, 5);
                        y += 30;
                    }
                    if (listTuKhoa.Count < 5)
                    {
                        string showTheLoai = "";
                        for (int count = 0; count < listTuKhoa.Count; count++)
                        {
                            showTheLoai += listTuKhoa[count] + " ";
                        }
                        e.Graphics.DrawString(showTheLoai, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(90, y));
                    }
                    y += 50;
                }
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

        void LoadQuyDinh()
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
            if (txbQuyDinhKhoangCachNamXB.Text != "" && txbQuyDinhSoNgayDuocMuon.Text != "" && txbQuyDinhSoSachDuocMuon.Text != "" && txbQuyDinhTienPhat.Text != "" && txbQuyDinhTuoiToiDa.Text != "" && txbQuyDinhTuoiToiThieu.Text != "")
            {
                quydinhBUS quydinhBUS = new quydinhBUS();
                quydinhDTO quydinhDTO = new quydinhDTO(int.Parse(txbQuyDinhTienPhat.Text), int.Parse(txbQuyDinhTuoiToiDa.Text), int.Parse(txbQuyDinhTuoiToiThieu.Text), int.Parse(txbQuyDinhSoNgayDuocMuon.Text), int.Parse(txbQuyDinhSoSachDuocMuon.Text), int.Parse(txbQuyDinhKhoangCachNamXB.Text));

                if (quydinhBUS.SuaQuyDinh(quydinhDTO))
                {

                }

                LoadQuyDinh();
            }
        }
    }
}
