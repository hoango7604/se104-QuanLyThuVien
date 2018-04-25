    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
<<<<<<< HEAD:QuanLiThuVien/QuanLiThuVienDTO/TheDocGiaDTO.cs
    public class TheDocGiaDTO
=======
    public class TheDocGia
>>>>>>> 44a7782f9adfb6d612e6f162e5455e17e429be69:QuanLiThuVien/QuanLiThuVienDTO/TheDocGia.cs
    {
        /// <summary>
        /// Số Cmnd
        /// </summary>
        private string maThe;
        private string hoten;
        private string diachi;
        private string email;
        private string ngaysinh;
        private string ngayDK; 


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

        public string NgayDK
        {
            get
            {
                return NgayDK;
            }

            set
            {
                NgayDK = value;
            }
        }

        public string TongTienNo
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

        private string loaidocgia;
        /// <summary>
        /// Tạo 1 thẻ đọc giả với giá trị "" cho các thuộc tính string và 0 với Tongtienno
        /// </summary>
        

public string Loaidocgia
{
  get { return loaidocgia; }
  set { loaidocgia = value; }
}
        
        
        
        public TheDocGiaDTO()
        {
            this.maThe = "";
            this.HoTen = "";
            this.DiaChi = "";
            this.Email = "";
            this.NgaySinh = "";
            this.NgayDK = "";
            this.TongTienNo ="";

        }
    }
}
