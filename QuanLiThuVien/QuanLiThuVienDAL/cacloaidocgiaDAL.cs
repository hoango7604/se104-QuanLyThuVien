using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbConnection;
using QuanLiThuVienDTO;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiThuVienDAL
{
   public class cacloaidocgiaDAL
    {
          
       private dbconnection conn;


       public cacloaidocgiaDAL()
       {
           conn = new dbconnection(); 
       }




       public bool danhsachLoaiDG(List<cacloaidocgiaDTO> listLoaiDGDTO)
       {

           string query = string.Format("select* from [cacloaidocgia] ");
           SqlParameter[] parm = new SqlParameter[1];

           DataTable datatable = new DataTable();
           datatable = conn.excuteNonQuery(query, parm);

           //gan value trong datatable vao DTO 

           foreach (DataRow dr in datatable.Rows)
           {
               cacloaidocgiaDTO cacloaiDGDTO = new cacloaidocgiaDTO();

               cacloaiDGDTO.Cacloai = int.Parse(dr["loaidg"].ToString());
              
               listLoaiDGDTO.Add(cacloaiDGDTO);
           }




           return true;
       }


    }
}
