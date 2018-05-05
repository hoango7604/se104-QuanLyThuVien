using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
   public class phieumuonDTO
    {
        public phieumuonDTO()
        {

        }
        public phieumuonDTO(int maphieumuon,  DateTime ngaymuon, int mathe)
        {
            Maphieumuon = maphieumuon;
            
            Ngaymuon = ngaymuon;
           
            Mathe = mathe;
        }

        private int maphieumuon;

        public int Maphieumuon
        {
            get { return maphieumuon; }
            set { maphieumuon = value; }
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
