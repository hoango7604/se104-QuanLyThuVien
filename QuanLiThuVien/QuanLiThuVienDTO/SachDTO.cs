using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
<<<<<<< HEAD:QuanLiThuVien/QuanLiThuVienDTO/SachDTO.cs
    public class SachDTO
=======
    public class Sach
>>>>>>> 44a7782f9adfb6d612e6f162e5455e17e429be69:QuanLiThuVien/QuanLiThuVienDTO/Sach.cs
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

        public SachDTO()
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
