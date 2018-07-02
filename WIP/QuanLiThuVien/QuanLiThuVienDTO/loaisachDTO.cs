using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class loaisachDTO
    {
        public loaisachDTO() { }
       
        private string loaisach;

        public string Theloaisach
        {
            get
            {
                return loaisach;
            }

            set
            {
                loaisach = value;
            }
        }

        public loaisachDTO(string loai)
        {
            this.Theloaisach = loai;
        }

    }
}
