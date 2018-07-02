using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
   public class phieumuonDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public phieumuonDTO()
        {

        }
        public phieumuonDTO(int mapm,  DateTime ngaymuon, int mathe)
        {
           Mapm = mapm;
            
            Ngaymuon = ngaymuon;
           
            Mathe = mathe;
        }

        private int mapm;

        public int Mapm
        {
            get { return mapm; }
            set { mapm = value; }
        }
        private DateTime ngaymuon;

        public DateTime Ngaymuon
        {
            get { return ngaymuon; }
            set { ngaymuon = value; }
        }
        private int mathe;

       
        public int Mathe
        {
            get { return mathe; }
            set { mathe = value; }
        } 



    }
}
