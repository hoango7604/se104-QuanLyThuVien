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
        private int loaidocgia;

        public docgiaDTO() { }

        public docgiaDTO(int maThe, string hoten, string diachi, string email, DateTime ngaysinh, DateTime ngaydk, int tongtienno, int loaidocgia)
        {
            this.maThe = maThe;
            this.hoten = hoten;
            this.diachi = diachi;
            this.email = email;
            this.ngaysinh = ngaysinh;
            this.ngaydk = ngaydk;
            this.tongtienno = tongtienno;
            this.loaidocgia = loaidocgia;
        }

        public int  MaThe
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
                return hoten;
            }

            set
            {
                hoten = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diachi;
            }

            set
            {
                diachi = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public DateTime NgaySinh
        {
            get
            {
                return ngaysinh;
            }

            set
            {
                ngaysinh = value;
            }
        }

        public DateTime Ngaydk
        {
            get
            {
                return ngaydk;
            }

            set
            {
                ngaydk = value;
            }
        }

        public int Tongtienno
        {
            get
            {
                return tongtienno;
            }

            set
            {
                tongtienno = value;
            }
        }

       
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
