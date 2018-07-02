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
    public partial class frmThongTinBanDoc : Form
    {
        Form mainForm;

        QuanLiBanDocBUS quanLiBanDocBUS = new QuanLiBanDocBUS();
        QuanLiSachBUS quanLiSachBUS = new QuanLiSachBUS();
        QuanLiMuonTraMatBUS quanLiMuonTraMatBUS = new QuanLiMuonTraMatBUS();

        docgiaDTO docgia;
        List<sachDTO> listSachDocGiaDangMuon = new List<sachDTO>();
        List<dongThongTinSach> listDongThongTinSach = new List<dongThongTinSach>();
        List<DateTime> listngaymuon = new List<DateTime>();
        List<sachDTO> listSachDocGiaMuonTra = new List<sachDTO>();

        public frmThongTinBanDoc(docgiaDTO docgia, Form parent)
        {
            InitializeComponent();
            this.docgia = docgia;
            this.mainForm = parent;
            initThongTinBanDoc(docgia);
            initDanhSachSachDangMuon(docgia);
        }

        private void resizeSttErrorLabel()
        {
            this.sttError.Size = new Size(48, 22);
            this.Size = new Size(885, 604);
        }

        private void initDanhSachSachDangMuon(docgiaDTO docgia)
        {
            pnDanhSachSachDangMuon.Controls.Clear();
            listDongThongTinSach.Clear();
            listngaymuon.Clear();
            listSachDocGiaDangMuon = quanLiSachBUS.DanhSachDocGiaDangMuon(docgia, listngaymuon);
            for (int i = 0; i < listSachDocGiaDangMuon.Count; i++)
            {
                initDongThongTinSach(listSachDocGiaDangMuon[i], listngaymuon[i]);
            }
        }

        private void initDongThongTinSach(sachDTO sach, DateTime ngaymuon)
        {
            dongThongTinSach dongThongTin = new dongThongTinSach(sach, ngaymuon);
            listDongThongTinSach.Add(dongThongTin);
            dongThongTin.cbTinhTrangSach.DataSource = new List<String> { QuanLiSachBUS.DanhSachTrangThaiSach[0], QuanLiSachBUS.DanhSachTrangThaiSach[2] };
            dongThongTin.Location = new Point(3, 3 + dongThongTin.Height * (listDongThongTinSach.Count() - 1));
            dongThongTin.chkChonSach.CheckState = CheckState.Unchecked;
            dongThongTin.Click += DongThongTin_Click;
            pnDanhSachSachDangMuon.Controls.Add(dongThongTin);
        }

        private void DongThongTin_Click(object sender, EventArgs e)
        {
            dongThongTinSach dongthongtin = (dongThongTinSach)sender;

            if (dongthongtin.chkChonSach.CheckState == CheckState.Checked)
            {
                dongthongtin.chkChonSach.CheckState = CheckState.Unchecked;
            }
            else
            {
                dongthongtin.chkChonSach.CheckState = CheckState.Checked;
            }
        }

        private void initThongTinBanDoc(docgiaDTO docgia)
        {
            txbTenBanDoc.Text = docgia.HoTen;
            txbCMNDBanDoc.Text = docgia.MaThe.ToString();
            dtpNgaySinhBanDoc.Value = docgia.NgaySinh;
            txbEmailBanDoc.Text = docgia.Email;
            txbDiaChiBanDoc.Text = docgia.DiaChi;
            cbLoaiDocGia.Text = QuanLiBanDocBUS.LoaiDocGia[docgia.Loaidocgia];
            txbTongTienNoBanDoc.Text = docgia.Tongtienno.ToString();
            dtpNgayTaoTheBanDoc.Value = docgia.Ngaydk;
        }

        private void refreshError()
        {
            lbError.Text = "";
            sttErrorLabel.Text = "";
            resizeSttErrorLabel();
        }

        private void btnLapPhieuMuon_Click(object sender, EventArgs e)
        {
            refreshError();

            frmPhieuMuon f = new frmPhieuMuon(docgia);
            f.ShowDialog();
            initDanhSachSachDangMuon(docgia);
            chkChonSach.CheckState = CheckState.Unchecked;
        }

        private void btnLapPhieuTra_Click(object sender, EventArgs e)
        {
            refreshError();

            for (int i = 0; i < listDongThongTinSach.Count; i++)
            {
                if (listDongThongTinSach[i].chkChonSach.CheckState == CheckState.Checked)
                {
                    listSachDocGiaMuonTra.Add(listSachDocGiaDangMuon[i]);
                    if (listDongThongTinSach[i].cbTinhTrangSach.SelectedItem.ToString() == QuanLiSachBUS.DanhSachTrangThaiSach[0])
                    {
                        listSachDocGiaDangMuon[i].Trangthai = 0;
                    }
                    else
                    {
                        listSachDocGiaDangMuon[i].Trangthai = 2;
                    }
                }
            }

            if (listSachDocGiaMuonTra.Count == 0)
            {
                lbError.Text = "Vui lòng chọn sách để tạo phiếu trả";
            }
            else
            {
                try
                {
                    frmPhieuTra f = new frmPhieuTra(docgia, quanLiMuonTraMatBUS.TraSach(docgia, listSachDocGiaMuonTra));
                    f.ShowDialog();
                    listSachDocGiaMuonTra.Clear();
                    docgia = quanLiBanDocBUS.TimDocGia(docgia.MaThe.ToString(), docgia.HoTen)[0];
                    initThongTinBanDoc(docgia);
                    initDanhSachSachDangMuon(docgia);
                    chkChonSach.CheckState = CheckState.Unchecked;
                    sttErrorLabel.Text = "Tạo phiếu trả thành công";
                }
                catch (Exception error)
                {
                    sttErrorLabel.Text = "Tạo phiếu trả thất bại. Vui lòng thử lại";
                    Console.WriteLine(error.ToString());
                }
            }
            
        }

        private void btnGiaHanSach_Click(object sender, EventArgs e)
        {
            refreshError();

            if (listSachDocGiaDangMuon.Count > 0)
            {
                for (int i = 0; i < listDongThongTinSach.Count; i++)
                {
                    if (listDongThongTinSach[i].chkChonSach.CheckState == CheckState.Checked)
                    {
                        listSachDocGiaMuonTra.Add(listSachDocGiaDangMuon[i]);
                        if (listDongThongTinSach[i].cbTinhTrangSach.SelectedItem.ToString() == QuanLiSachBUS.DanhSachTrangThaiSach[0])
                        {
                            listSachDocGiaDangMuon[i].Trangthai = 0;
                        }
                        else
                        {
                            listSachDocGiaDangMuon[i].Trangthai = 2;
                        }
                    }
                }

                if (listSachDocGiaMuonTra.Count > 0)
                {
                    sttErrorLabel.Text = "";
                    resizeSttErrorLabel();
                    GiaHanSachBUS gh = new GiaHanSachBUS();
                    foreach (sachDTO sach in listSachDocGiaMuonTra)
                    {
                        if (gh.GiaHan(sach.Masach))
                        {
                            sttErrorLabel.Text += "Gia hạn thành công cuốn " + sach.Tensach + "\n";
                        }
                        else
                            sttErrorLabel.Text += "Gia hạn thất bại " + sach.Tensach + ". " + BUS_notification.mess + "\n";

                    }
                }
                else
                {
                    lbError.Text = "Vui lòng chọn sách để gia hạn";
                }

                listSachDocGiaMuonTra.Clear();
                chkChonSach.CheckState = CheckState.Unchecked;
            }
            else
            {
                lbError.Text = "Không có sách để gia hạn";
            }
        }

        private void chkChonSach_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            foreach (dongThongTinSach dongThongTin in listDongThongTinSach)
            {
                dongThongTin.chkChonSach.CheckState = cb.CheckState;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            int index = 0;
            for (int i = 0; i < quanLiBanDocBUS.DanhSachDocGia().Count; i++)
            {
                if (docgia.MaThe == quanLiBanDocBUS.DanhSachDocGia()[i].MaThe)
                {
                    index = i;
                }
            }
            (mainForm as frmManHinhChinh).loadDanhSachBanDoc(index);
        }
    }
}
