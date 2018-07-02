using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public  class sachdatraDTO
    {
        public sachdatraDTO()
        {

        }

        public sachdatraDTO(int masach , DateTime ngaytra )
        {
            Masach = masach;
            Ngaytra = ngaytra; 

        }

        private int masach;

        public int Masach
        {
            get { return masach; }
            set { masach = value; }
        }
        private DateTime ngaytra;

        public DateTime Ngaytra
        {
            get { return ngaytra; }
            set { ngaytra = value; }
        } 


    }
}
