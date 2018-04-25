using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class PhieuMuonDTO
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
