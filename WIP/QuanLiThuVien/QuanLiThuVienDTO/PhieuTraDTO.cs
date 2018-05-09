using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class PhieuTraDTO
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
