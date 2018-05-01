using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class PhieuThuTienPhatDTO
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
