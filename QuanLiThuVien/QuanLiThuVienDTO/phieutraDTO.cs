using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
   public class phieutraDTO
    {
        public phieutraDTO()
        {

        }
        public phieutraDTO(int mapt, DateTime ngaytra, int tienphatkinay, int mathe)
        {
            Mapt = mapt;

            Ngaytra = ngaytra;
            Tienphatkinay = tienphatkinay;

            Mathe = mathe;
        }
        private int mapt;

        public int Mapt
        {
            get { return mapt; }
            set { mapt = value; }
        }
        private DateTime ngaytra;

        public DateTime Ngaytra
        {
            get { return ngaytra; }
            set { ngaytra = value; }
        }
        private int tienphatkinay;

        public int Tienphatkinay
        {
            get { return tienphatkinay; }
            set { tienphatkinay = value; }
        }
        private int mathe;


        public int Mathe
        {
            get { return mathe; }
            set { mathe = value; }
        } 


    }
}
