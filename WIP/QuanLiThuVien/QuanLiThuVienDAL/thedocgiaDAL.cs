using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBconnection ; 
using QuanLiThuVienDTO;
using System.Data.SqlClient;
using System.Data;
namespace QuanLiThuVienDAL
{
   public  class thedocgiaDAL
    {


       private dbConnection conn;


       public thedocgiaDAL()
       {
           conn = new dbConnection(); 
       }

       public void layDanhSachDG(List<TheDocGiaDTO> ltdgDTO)
       {
           string query = string.Format("select* form [thedocgia] ");
           SqlParameter[] parm = new SqlParameter[1];

           DataTable datatable = new DataTable();
           datatable = conn.excuteNonQuery(query, parm);

           //gan value trong datatable vao DTO 

           foreach (DataRow dr in datatable.Rows)
           {
               TheDocGiaDTO tdgDTO = new TheDocGiaDTO();

               tdgDTO.MaThe = dr["mathe"].ToString();
               tdgDTO.HoTen = dr["hoten"].ToString();
               tdgDTO.Email = dr["email"].ToString();
               tdgDTO.Loaidocgia = dr["loaidocgia"].ToString();
               tdgDTO.NgaySinh = dr["ngaysinh"].ToString();
               tdgDTO.NgayDK = dr["ngaydk"].ToString();
               tdgDTO.DiaChi = dr["diachi"].ToString();
               tdgDTO.TongTienNo = dr["tongtienno"].ToString();

               ltdgDTO.Add(tdgDTO);
           }
        
       
       }

       public void layLoaiDG(List<loaidocgiaDTO> lldgDTO)
       {


           string query = string.Format("select * form [thedocgia]");
           SqlParameter[] parm = new SqlParameter[1];


           DataTable datatable = new DataTable();
           datatable = conn.excuteNonQuery(query, parm);

           foreach (DataRow dr in datatable.Rows)
           {
               loaidocgiaDTO ldgDTO = new loaidocgiaDTO();

               ldgDTO.Loaidocgia = dr["loaidocgia"].ToString();

               lldgDTO.Add(ldgDTO);
           }





       }

       public bool themDG(TheDocGiaDTO tdgDTO)
       {
           string query = string.Format("insert into [thedocgia] value (@mathe,@hoten,@loaidocgia,@email,@ngaysinh,@ngaydk,@diachi,@tongtienno)");
           SqlParameter[] param = new SqlParameter[8];
           param[0] = new SqlParameter("@mathe", SqlDbType.NChar);
           param[0].Value = Convert.ToString(tdgDTO.MaThe);
           param[1] = new SqlParameter("@hoten", SqlDbType.NChar);
           param[1].Value = Convert.ToString(tdgDTO.MaThe);
           param[2] = new SqlParameter("@loaidocgia", SqlDbType.NChar);
           param[2].Value = Convert.ToString(tdgDTO.MaThe);
           param[3] = new SqlParameter("@email", SqlDbType.NChar);
           param[3].Value = Convert.ToString(tdgDTO.MaThe);
           param[4] = new SqlParameter("@ngaysinh", SqlDbType.NChar);
           param[4].Value = Convert.ToString(tdgDTO.MaThe);
           param[5] = new SqlParameter("@ngaydk", SqlDbType.NChar);
           param[5].Value = Convert.ToString(tdgDTO.MaThe);
           param[6] = new SqlParameter("@diachi", SqlDbType.NChar);
           param[6].Value = Convert.ToString(tdgDTO.MaThe);
           param[7] = new SqlParameter("@tongtienno", SqlDbType.NChar);
           param[7].Value = Convert.ToString(tdgDTO.MaThe);

           conn.excuteNonQuery(query, param);

           return true 
               ;
       }
       public bool xoa(string mathe) { return true;  }
       public bool sua(string mathe) { return true;  }

       
    }
}
