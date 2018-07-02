using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class ctptDTO
    {
        public ctptDTO()
        {

        }
        public ctptDTO(int mapt, int masach, int tienphatsach, int songaydamuon)
        {
            Mapt = mapt;
            Masach = masach;
            Tienphatsach = tienphatsach;
            Songaydamuon = songaydamuon;
        }
        private int mapt;

        public int Mapt
        {
            get { return mapt; }
            set { mapt = value; }
        }
        private int masach;

        public int Masach
        {
            get { return masach; }
            set { masach = value; }
        }
        private int tienphatsach;

        public int Tienphatsach
        {
            get { return tienphatsach; }
            set { tienphatsach = value; }
        }   
        private int songaydamuon;

        public int Songaydamuon
        {
            get { return songaydamuon; }
            set { songaydamuon = value; }
        } 

       
    }
}
