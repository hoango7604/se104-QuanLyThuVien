using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
<<<<<<< HEAD:QuanLiThuVien/QuanLiThuVienDTO/PhieuMuonDTO.cs
    public class PhieuMuonDTO
=======
    public class PhieuMuon
>>>>>>> 44a7782f9adfb6d612e6f162e5455e17e429be69:QuanLiThuVien/QuanLiThuVienDTO/PhieuMuon.cs
    {
        public string MaPM { get; set; }
        public string MaThe { get; set; }
        public string NgayMuon { get; set;  }

        /// <summary>
        /// Tạo phiếu mượn với các thuộc tính là ""
        /// </summary>
        public PhieuMuonDTO()
        {
            this.MaPM = "";
            this.MaThe = "";
            this.NgayMuon = "";
        }
    }
}
