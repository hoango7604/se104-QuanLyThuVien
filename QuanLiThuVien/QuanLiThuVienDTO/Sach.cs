using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class Sach
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TheLoai { get; set; }
        public string TacGia { get; set; }
        public string NXB { get; set; }
        public string NgayNhap { get; set; }
        public string NamXuatBan { get; set; }
        public int GiaTri { get; set; }
        public string TinhTrang { get; set; }

        public Sach()
        {
            this.MaSach = "";
            this.TenSach = "";
            this.TheLoai = "";
            this.TacGia = "";
            this.NXB = "";
            this.NgayNhap = "";
            this.NamXuatBan = "";
            this.GiaTri = 0;
            this.TinhTrang = "";
        }
    }
}
