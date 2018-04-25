using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class ChiTietPhieuTraDTO
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
