using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class ctpmDTO
    {
        public ctpmDTO()
        {

        }
        public ctpmDTO(int mapm, int masach)
        {
            Mapm = mapm;
            Masach = masach;
        }
        private int mapm;

        public int Mapm
        {
            get { return mapm; }
            set { mapm = value; }
        }
        private int masach;
       

        public int Masach
        {
            get { return masach; }
            set { masach = value; }
        }  
    }
}
