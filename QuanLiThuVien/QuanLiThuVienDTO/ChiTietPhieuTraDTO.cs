using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
<<<<<<< HEAD:QuanLiThuVien/QuanLiThuVienDTO/ChiTietPhieuTraDTO.cs
    public class ChiTietPhieuTraDTO
=======
    public class ChiTietPhieuTra
>>>>>>> 44a7782f9adfb6d612e6f162e5455e17e429be69:QuanLiThuVien/QuanLiThuVienDTO/ChiTietPhieuTra.cs
    {
        public string MaPT { get; set; }
        public string MaSach { get; set; }
        public int TienPhatChoSachNay { get; set; }

        /// <summary>
        /// Tạo 1 chi tiết phiếu trả với các giá trị là "" và 0
        /// </summary>
        public ChiTietPhieuTraDTO()
        {
            this.MaPT = "";
            this.MaSach = "";
            this.TienPhatChoSachNay = 0;
        }
    }
}
