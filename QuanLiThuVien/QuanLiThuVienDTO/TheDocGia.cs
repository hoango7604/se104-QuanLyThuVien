using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class TheDocGia
    {
        /// <summary>
        /// Số Cmnd
        /// </summary>
        private string maThe;

        public string MaThe
             {
                get
                    {
                        return maThe;
                    }

                set
                    {
                        maThe = value;
                    }
            }

        public string HoTen
        {
            get
            {
                return HoTen;
            }

            set
            {
                HoTen = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return DiaChi;
            }

            set
            {
                DiaChi = value;
            }
        }

        public string Email
        {
            get
            {
                return Email;
            }

            set
            {
                Email = value;
            }
        }

        public string NgaySinh
        {
            get
            {
                return NgaySinh;
            }

            set
            {
                NgaySinh = value;
            }
        }

        public string NgayTaoThe
        {
            get
            {
                return NgayTaoThe;
            }

            set
            {
                NgayTaoThe = value;
            }
        }

        public int TongTienNo
        {
            get
            {
                return TongTienNo;
            }

            set
            {
                TongTienNo = value;
            }
        }

        /// <summary>
        /// Tạo 1 thẻ đọc giả với giá trị "" cho các thuộc tính string và 0 với Tongtienno
        /// </summary>
        public TheDocGia()
        {
            this.maThe = "";
            this.HoTen = "";
            this.DiaChi = "";
            this.Email = "";
            this.NgaySinh = "";
            this.NgayTaoThe = "";
            this.TongTienNo = 0;

        }
    }
}
