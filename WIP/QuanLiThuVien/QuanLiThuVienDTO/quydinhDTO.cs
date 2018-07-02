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
          
        
        public quydinhDTO(int tienphattrasachtremoingay, int tuoimax, int tuoimin,int songayduocmuon, int sosachduocmuon, int kcnamxuatban)
        {   
            Tienphattrasachtremoingay=tienphattrasachtremoingay;
            Tuoimax = tuoimax;
            Tuoimin = tuoimin;
            Songayduocmuon = songayduocmuon;
            Sosachduocmuon = sosachduocmuon; 
            Kcnamxuatban = kcnamxuatban;
        }
        
        private int tienphattrasachtremoingay ; 
        public int Tienphattrasachtremoingay
        {
            get { return tienphattrasachtremoingay; }
            set { tienphattrasachtremoingay = value; }
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
