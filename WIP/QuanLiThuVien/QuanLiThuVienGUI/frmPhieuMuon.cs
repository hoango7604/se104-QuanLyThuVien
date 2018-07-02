using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiThuVienGUI;
using QuanLiThuVienBUS;
using QuanLiThuVienDTO;

namespace QuanLiThuVienGUI
{
    public partial class frmPhieuMuon : Form
    {
        docgiaDTO docgia;
        List<sachDTO> listSach = new List<sachDTO>();
        List<sachDTO> listSachCoSan = new List<sachDTO>();
        QuanLiSachBUS quanLiSach = new QuanLiSachBUS();
        QuanLiMuonTraMatBUS quanLiMuonTraMat = new QuanLiMuonTraMatBUS();
        List<dongThongTinSach> listDongThongTinSach = new List<dongThongTinSach>();

        public frmPhieuMuon(docgiaDTO docgia)
        {
            InitializeComponent();
            this.docgia = docgia;
            initFormPhieuMuon(docgia);
            this.DialogResult = DialogResult.Cancel;
            listSachCoSan = quanLiSach.DanhSachSachCoSan();
            initComboBoxListItems();
            cbTimSachTheoMa.Select();
        }

        private void initComboBoxListItems()
        {
            foreach (sachDTO sach in listSachCoSan)
            {
                cbTimSachTheoMa.Items.Add(sach.Masach + " - " + sach.Tensach);
            }
        }

        private void initFormPhieuMuon(docgiaDTO docgia)
        {
            txbTenBanDoc.Text = docgia.HoTen;
            txbMaTheBanDoc.Text = docgia.MaThe.ToString();
        }

        private void ScrollToBottom(Panel p)
        {
            using (Control c = new Control() { Parent = p, Dock = DockStyle.Bottom })
            {
                p.ScrollControlIntoView(c);
                c.Parent = null;
            }
        }

        private void initDongThongTinSach(sachDTO sach)
        {
            dongThongTinSach dongThongTin = new dongThongTinSach(sach);
            dongThongTin.changeEnable_CbTinhTrangSach(false);
            dongThongTin.chkChonSach.CheckState = CheckState.Checked;
            listDongThongTinSach.Add(dongThongTin);
            dongThongTin.Location = new Point(3, 3 + dongThongTin.Height * (listSach.Count() - 1));
            pnDanhSachSachMuon.Controls.Add(dongThongTin);
        }

        private void btnTaoPhieuMuon_Click(object sender, EventArgs e)
        {
            lbError.Text = "";
            if (cbTimSachTheoMa.Text != "")
            {
                if (cbTimSachTheoMa.SelectedIndex >= 0)
                {
                    sachDTO sach = quanLiSach.Timsachtheoma(listSachCoSan[cbTimSachTheoMa.SelectedIndex].Masach);
                    listSach.Add(sach);
                    listSachCoSan.RemoveAt(cbTimSachTheoMa.SelectedIndex);
                    initDongThongTinSach(sach);
                    cbTimSachTheoMa.Items.Clear();
                    initComboBoxListItems();
                    cbTimSachTheoMa.DroppedDown = false;
                }
                else
                {
                    lbError.Text = "Mã sách không tồn tại";
                }

                cbTimSachTheoMa.Text = "";
                ScrollToBottom(panel3);
            }
            else
            {
                List<sachDTO> listSachMuon = new List<sachDTO>();
                for (int i = 0; i < listDongThongTinSach.Count; i++)
                {
                    if (listDongThongTinSach[i].chkChonSach.Checked)
                    {
                        listSachMuon.Add(listSach[i]);
                    }
                }

                if (listSachMuon.Count != 0)
                {
                    if (quanLiMuonTraMat.MuonSach(docgia, listSachMuon))
                    {
                        MessageBox.Show("Tạo phiếu mượn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(BUS_notification.mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    lbError.Text = "Chưa nhập mã sách";
                }
            }
        }

        private void chkChonSach_CheckStateChanged(object sender, EventArgs e)
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
    }
}
