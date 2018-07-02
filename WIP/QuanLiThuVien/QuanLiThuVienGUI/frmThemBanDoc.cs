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
    public partial class frmThemBanDoc : Form
    {
        private Form mainForm;
        public frmThemBanDoc(Form parent)
        {
            InitializeComponent();
            this.mainForm = parent;
        }

        private void btnHuyBanDoc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemBanDoc_Click(object sender, EventArgs e)
        {
            int loaiDocGia = 0;
            int tuoi = 0;

            if (txbTenBanDoc.Text != "" && txbEmailBanDoc.Text != "" && txbDiaChiBanDoc.Text != "" && txbCMNDBanDoc.Text != "" && dtpNgaySinhBanDoc.Text != "")
            {
                QuanLiBanDocBUS quanLiBanDocBUS = new QuanLiBanDocBUS();
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

                docgiaDTO dgDTO = new docgiaDTO(int.Parse(txbCMNDBanDoc.Text), txbTenBanDoc.Text, txbDiaChiBanDoc.Text, txbEmailBanDoc.Text, dtpNgaySinhBanDoc.Value, DateTime.Now, 0, loaiDocGia);
                if (quanLiBanDocBUS.ThemDocGia(dgDTO))
                {
                    MessageBox.Show("Đã thêm bạn đọc thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int index = 0;
                    for (int i = 0; i < quanLiBanDocBUS.DanhSachDocGia().Count; i++)
                    {
                        if (int.Parse(txbCMNDBanDoc.Text) == quanLiBanDocBUS.DanhSachDocGia()[i].MaThe)
                        {
                            index = i;
                        }
                    }

                    refresh();
                    (mainForm as frmManHinhChinh).loadDanhSachBanDoc(index);
                }
                else
                {
                    MessageBox.Show(BUS_notification.mess, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void refresh()
        {
            txbCMNDBanDoc.Text = "";
            txbDiaChiBanDoc.Text = "";
            txbEmailBanDoc.Text = "";
            txbTenBanDoc.Text = "";
            dtpNgaySinhBanDoc.Text = "";
            txbTenBanDoc.Focus();
        }

        private void dtpNgaySinhBanDoc_ValueChanged(object sender, EventArgs e)
        {
            quydinhBUS quydinhBUS = new quydinhBUS();
            quydinhDTO quydinhDTO = new quydinhDTO();
            quydinhBUS.ListQuyDinh(quydinhDTO);
            int namSinh = dtpNgaySinhBanDoc.Value.Year;
            int tuoiMin = quydinhDTO.Tuoimin;
            int tuoiMax = quydinhDTO.Tuoimax;
            if (DateTime.Now.Year - namSinh < tuoiMin || DateTime.Now.Year - namSinh > tuoiMax)
            {
                lbNgaySinhEX.Text = "Tuổi tối thiểu: " + tuoiMin + " - Tuổi tối đa: " + tuoiMax;
                btnThemBanDoc.Enabled = false;
            }
            else
            {
                lbNgaySinhEX.Text = "";
                btnThemBanDoc.Enabled = true;
            }
        }
    }
}
