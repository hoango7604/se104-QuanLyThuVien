using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
   public class sachdangmuonDTO 
   {
       public sachdangmuonDTO()
       {

       }

       public sachdangmuonDTO(int masach ,int trangthai , DateTime ngaymuon ) 
       {
           Masach = masach;
           Trangthai = trangthai;
           Ngaymuon = ngaymuon; 

       }

        private int masach;

        public int Masach
        {
            get { return masach; }
            set { masach = value; }
        }
        private int trangthai;

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }
        private DateTime ngaymuon;

        public DateTime Ngaymuon
        {
            get { return ngaymuon; }
            set { ngaymuon = value; }
        } 



    }
}
