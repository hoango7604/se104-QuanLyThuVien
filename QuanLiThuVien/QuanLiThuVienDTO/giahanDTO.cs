using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
   public class giahanDTO
    {
       public giahanDTO()
       {

       }
       public giahanDTO(int solangiahan , int masach )
       {
           Solangiahan = solangiahan;
           Masach = masach;

       }


        private int solangiahan;

        public int Solangiahan
        {
            get { return solangiahan; }
            set { solangiahan = value; }
        }
        private int masach;

        public int Masach
        {
            get { return masach; }
            set { masach = value; }
        } 

    }
}
