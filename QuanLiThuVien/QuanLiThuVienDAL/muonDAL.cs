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
    public class muonDAL
    {

        private dbConnection conn;
        public muonDAL()
        {
            conn = new dbConnection(); 
        }

         // nhap id -> kiem tra thong tin (select ) -> tra ve kq  
        public bool infoDG (TheDocGiaDTO tdgDTO ,  string mathe)
        {

            return true;
        }

        // cho muon 
        public bool chomuonthemSach(SachDTO sachDTO, string masach)
        {

            return true; 
        }
        // nhap sach - > insert vao db   ->ok/err 

        //
    }

}
