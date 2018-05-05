using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLiThuVienDTO
{
    public class quydinhDTO
    {
        public quydinhDTO()
        {

        }
        public quydinhDTO(int tuoimax, int tuoimin, int sosachduocmuon, int kcnamxuatban)
        {
            Tuoimax = tuoimax;

            Tuoimin = tuoimin;
            Songayduocmuon = songayduocmuon;


            Kcnamxuatban = kcnamxuatban;
        }

        private int tuoimax;

        public int Tuoimax
        {
            get { return tuoimax; }
            set { tuoimax = value; }
        }
        private int tuoimin;

        public int Tuoimin
        {
            get { return tuoimin; }
            set { tuoimin = value; }
        }
        private int songayduocmuon;

        public int Songayduocmuon
        {
            get { return songayduocmuon; }
            set { songayduocmuon = value; }
        }
        private int sosachduocmuon;

        public int Sosachduocmuon
        {
            get { return sosachduocmuon; }
            set { sosachduocmuon = value; }
        }
        private int kcnamxuatban;

        public int Kcnamxuatban
        {
            get { return kcnamxuatban; }
            set { kcnamxuatban = value; }
        } 
 


    }
}
