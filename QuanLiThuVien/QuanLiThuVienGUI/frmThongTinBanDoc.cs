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
        QuanLiBanDocBUS quanLiBanDocBUS = new QuanLiBanDocBUS();
        QuanLiSachBUS quanLiSachBUS = new QuanLiSachBUS();

        docgiaDTO docgia;
        List<sachDTO> listSachDocGiaDangMuon = new List<sachDTO>();
        List<dongThongTinSach> listDongThongTinSach = new List<dongThongTinSach>();
        List<DateTime> listngaymuon = new List<DateTime>();
        List<sachDTO> listSachDocGiaMuonTra = new List<sachDTO>();

        public frmThongTinBanDoc(docgiaDTO docgia)
        {
            InitializeComponent();
            this.docgia = docgia;
            initThongTinBanDoc(docgia);
            initDanhSachSachDangMuon(docgia);
        }

        private void initDanhSachSachDangMuon(docgiaDTO docgia)
        {
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
            pnDanhSachSachDangMuon.Controls.Add(dongThongTin);
        }

        private void initThongTinBanDoc(docgiaDTO docgia)
        {
            txbTenBanDoc.Text = docgia.HoTen;
            txbCMNDBanDoc.Text = docgia.MaThe.ToString();
            dtpNgaySinhBanDoc.Value = docgia.NgaySinh;
            txbEmailBanDoc.Text = docgia.Email;
            txbDiaChiBanDoc.Text = docgia.DiaChi;
            cbLoaiDocGia.Text = docgia.Loaidocgia.ToString();
            txbTongTienNoBanDoc.Text = docgia.Tongtienno.ToString();
            dtpNgayTaoTheBanDoc.Value = docgia.Ngaydk;
        }

        private void btnCapNhatBanDoc_Click(object sender, EventArgs e)
        {
            if (txbTenBanDoc.Text != "" && txbEmailBanDoc.Text != "" && txbDiaChiBanDoc.Text != "" && txbCMNDBanDoc.Text != "" && cbLoaiDocGia.Text != "" && dtpNgaySinhBanDoc.Text != "")
            {
                if (quanLiBanDocBUS.SuaDocGia(new docgiaDTO(int.Parse(txbCMNDBanDoc.Text), txbTenBanDoc.Text, txbDiaChiBanDoc.Text, txbEmailBanDoc.Text, dtpNgaySinhBanDoc.Value, DateTime.Now, 0, int.Parse(cbLoaiDocGia.Text))))
                {
                    MessageBox.Show("Cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK);

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

        private void btnLapPhieuMuon_Click(object sender, EventArgs e)
        {
            frmPhieuMuon f = new frmPhieuMuon(docgia);
            if (f.ShowDialog() == DialogResult.OK)
            {
                pnDanhSachSachDangMuon.Controls.Clear();
                initDanhSachSachDangMuon(docgia);
            }
        }

        private void btnLapPhieuTra_Click(object sender, EventArgs e)
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

            frmPhieuTra f = new frmPhieuTra(docgia, listSachDocGiaMuonTra);
            f.ShowDialog();
        }

        private void btnGiaHanSach_Click(object sender, EventArgs e)
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

            GiaHanSachBUS gh = new GiaHanSachBUS();
            foreach (sachDTO sach in listSachDocGiaMuonTra)
            {
               if(gh.GiaHan(sach.Masach))
                {
                    MessageBox.Show("gia hạn thành cmn công cuốn " + sach.Tensach);
                }
               else
                    MessageBox.Show("gia hạn thất cmn bại liệt " + sach.Tensach + BUS_notification.mess);

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
    }
}
