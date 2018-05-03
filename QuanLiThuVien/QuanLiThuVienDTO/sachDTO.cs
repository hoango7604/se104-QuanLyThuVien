using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class sachDTO
    {
        private int masach;

        public int Masach
        {
            get { return masach; }
            set { masach = value; }
        }
        private string tensach;

        public string Tensach
        {
            get { return tensach; }
            set { tensach = value; }
        }
        private string theloai;

        public string Theloai
        {
            get { return theloai; }
            set { theloai = value; }
        }
        private string nxb;


        public string Nxb
        {
            get { return nxb; }
            set { nxb = value; }
        }
        private DateTime ngayxb;

        public DateTime Ngayxb
        {
            get { return ngayxb; }
            set { ngayxb = value; }
        }
        private int giatri;

        public int Giatri
        {
            get { return giatri; }
            set { giatri = value; }
        }
        private int trangthai;

        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        } 

    }
}
