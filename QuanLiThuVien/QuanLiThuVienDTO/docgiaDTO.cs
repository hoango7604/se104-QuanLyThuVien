using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class docgiaDTO
    {
        private int  maThe;
        private string hoten;
        private string diachi;
        private string email;
        private DateTime  ngaysinh;
        private DateTime ngaydk;
        private int  tongtienno;

    

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

        public string Ngaydk
        {
            get
            {
                return Ngaydk;
            }

            set
            {
                Ngaydk = value;
            }
        }

        public string Tongtienno
        {
            get
            {
                return Tongtienno;
            }

            set
            {
                Tongtienno = value;
            }
        }

        private int  loaidocgia;
        /// <summary>
        /// Tạo 1 thẻ đọc giả với giá trị "" cho các thuộc tính string và 0 với Tongtienno
        /// </summary>


        public int  Loaidocgia
        {
            get { return loaidocgia; }
            set { loaidocgia = value; }
        }



    }
}
