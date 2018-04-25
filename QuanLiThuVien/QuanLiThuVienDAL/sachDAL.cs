using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data; 
using QuanLiThuVienDTO;
using DBconnection ;
namespace QuanLiThuVienDAL
{
    public class sachDAL
    {
        private dbConnection conn;

        public sachDAL()
        {
            conn = new dbConnection(); 

        
        }


        public void taoMaSachMoi()
        { }
        public void layTatCaSach(List<SachDTO> sachDTO)
        { }
        public bool timkiem (List<SachDTO> sachDTO ,string search , int loaiSearch )
        {   
            DataTable datatable = new DataTable();



            return true; 
    
        }
        

        public bool them (SachDTO sachDTO)
        { return true; }
        public bool  xoa (string masach )
        { return true; }
        public bool sua(string masach)
        { return true;  }


    }
}
