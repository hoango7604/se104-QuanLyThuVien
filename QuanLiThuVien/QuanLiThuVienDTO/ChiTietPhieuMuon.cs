using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class ChiTietPhieuMuon
    {
        public string MaPM { get; set; }
        public string MaSach { get; set;  }

        /// <summary>
        /// Tạo 1 đối tượng với các thuộc tính là ""
        /// </summary>
        public ChiTietPhieuMuon()
        {
            this.MaPM = "";
            this.MaSach = "";
        }
    }
}
