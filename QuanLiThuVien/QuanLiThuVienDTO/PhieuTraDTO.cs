using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
<<<<<<< HEAD:QuanLiThuVien/QuanLiThuVienDTO/PhieuTraDTO.cs
    public class PhieuTraDTO
=======
    public class PhieuTra
>>>>>>> 44a7782f9adfb6d612e6f162e5455e17e429be69:QuanLiThuVien/QuanLiThuVienDTO/PhieuTra.cs
    {
        public string MaPT  { get; set; }
        public string MaThe { get; set;  }
        public string NgayTra { get; set; }
        public int TienPhatKiNay { get; set; }

        /// <summary>
        /// Tạo 1 phiếu trả với các thuộc tính là "" và 0
        /// </summary>
        public PhieuTraDTO()
        {
            this.MaPT = "";
            this.MaThe = "";
            this.NgayTra = "";
            this.TienPhatKiNay = 0;
        }
    }
}
