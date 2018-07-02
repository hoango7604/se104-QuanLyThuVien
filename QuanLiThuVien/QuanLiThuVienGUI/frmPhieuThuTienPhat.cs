using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiThuVienDTO;
using QuanLiThuVienBUS;

namespace QuanLiThuVienGUI
{
    public partial class frmPhieuThuTienPhat : Form
    {
        docgiaDTO docgia;
        Form mainForm;
        public frmPhieuThuTienPhat(docgiaDTO docgia, Form parent)
        {
            InitializeComponent();
            this.docgia = docgia;
            this.mainForm = parent;
            initPhieuThuTienPhat();
        }

        private void initPhieuThuTienPhat()
        {
            txbTenBanDoc.Text = docgia.HoTen;
            txbTongTienNoBanDoc.Text = docgia.Tongtienno.ToString();
            if (txbSoTienThu.Text == "")
            {
                txbSoTienConLai.Text = txbTongTienNoBanDoc.Text;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                QuanLiBanDocBUS quanLiBanDocBUS = new QuanLiBanDocBUS();
                if (quanLiBanDocBUS.SuaDocGia(new docgiaDTO(docgia.MaThe, docgia.HoTen, docgia.DiaChi, docgia.Email, docgia.NgaySinh, docgia.Ngaydk, int.Parse(txbSoTienConLai.Text), docgia.Loaidocgia)))
                {
                    int index = 0;
                    for (int i = 0; i < quanLiBanDocBUS.DanhSachDocGia().Count; i++)
                    {
                        if (docgia.MaThe == quanLiBanDocBUS.DanhSachDocGia()[i].MaThe)
                        {
                            index = i;
                        }
                    }
                    MessageBox.Show("Thu tiền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    (mainForm as frmManHinhChinh).loadDanhSachBanDoc(index);
                    Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Thu tiền thất bại. Vui lòng thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(error.ToString());
            }
        }

        private void txbSoTienThu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbSoTienThuEx.Text = "";
                if (txbSoTienThu.Text == "")
                {
                    txbSoTienConLai.Text = txbTongTienNoBanDoc.Text;
                }
                else
                {
                    if (int.Parse(txbSoTienThu.Text) == 0)
                    {
                        btnTaoPhieu.Enabled = false;
                    }
                    else
                    {
                        if (int.Parse(txbTongTienNoBanDoc.Text) - int.Parse(txbSoTienThu.Text) >= 0)
                        {
                            btnTaoPhieu.Enabled = true;
                            txbSoTienConLai.Text = (int.Parse(txbTongTienNoBanDoc.Text) - int.Parse(txbSoTienThu.Text)).ToString();
                        }
                        else
                        {
                            btnTaoPhieu.Enabled = false;
                            lbSoTienThuEx.Text = "Số tiền thu không được vượt quá tổng tiền nợ";
                        }
                    }
                }
            }
            catch (FormatException error)
            {
                lbSoTienThuEx.Text = "Số tiền thu chỉ được nhập số!";
                btnTaoPhieu.Enabled = false;
                Console.WriteLine(error.ToString());
            }
        }
    }
}
