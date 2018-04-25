using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
<<<<<<< HEAD:QuanLiThuVien/QuanLiThuVienDTO/PhieuThuTienPhatDTO.cs
    public class PhieuThuTienPhatDTO
=======
    public class PhieuThuTienPhat
>>>>>>> 44a7782f9adfb6d612e6f162e5455e17e429be69:QuanLiThuVien/QuanLiThuVienDTO/PhieuThuTienPhat.cs
    {
        public string MaPTTT { get; set; }
        public string MaThe { get; set; }
        public int SoTienTra { get; set;  }

        /// <summary>
        /// Tạo 1 thuộc tính có các giá trị là "" hoặc 0 
        /// </summary>
        public PhieuThuTienPhatDTO()
        {
            this.MaPTTT = "";
            this.MaThe = "";
            this.SoTienTra = 0;
        }
    }
}
