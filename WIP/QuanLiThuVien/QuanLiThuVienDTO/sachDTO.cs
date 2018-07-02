using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
    public class sachDTO
    {

        public sachDTO() { }

        public sachDTO(int masach, string tensach, string theloai, string tacgia, string nxb, DateTime ngaynhap, DateTime ngayxb, int giatri, int trangthai)
        {
            this.masach = masach;
            this.tensach = tensach;
            this.theloai = theloai;
            this.tacgia = tacgia;
            this.nxb = nxb;
            this.ngaynhap = ngaynhap;
            this.ngayxb = ngayxb;
            this.giatri = giatri;
            this.trangthai = trangthai;
            
        }
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

        private string tacgia;

        public string Tacgia
        {
            get { return tacgia; }
            set { tacgia = value; }
        }


        private string nxb;


        public string Nxb
        {
            get { return nxb; }
            set { nxb = value; }
        }

        private DateTime ngaynhap;

        public DateTime Ngaynhap
        {
            get { return ngaynhap; }
            set { ngaynhap = value; }
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
