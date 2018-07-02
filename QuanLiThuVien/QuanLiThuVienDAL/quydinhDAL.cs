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
   public  class quydinhDAL
   {
       
       private dbconnection conn;


       public quydinhDAL()
       {
           conn = new dbconnection(); 
       }
        // hien thi list dto 

       public bool listquydinh(quydinhDTO qdDTO)
       {


           string query = string.Format("select * from quydinh ");

           SqlParameter[] param = new SqlParameter[1]; 
           DataTable dt= new DataTable ();
            // ko can thiet nhung phai co 
            docgiaDTO dg = new docgiaDTO();
            param[0] = new SqlParameter("@masach", SqlDbType.Int);
            param[0].Value = dg.MaThe;
            dt = conn.excuteNonQuery(query, param);

            qdDTO.Tuoimax = int.Parse(dt.Rows[0]["tuoimax"].ToString());
            qdDTO.Tuoimin = int.Parse(dt.Rows[0]["tuoimin"].ToString());
            qdDTO.Songayduocmuon = int.Parse(dt.Rows[0]["songayduocmuon"].ToString());
            qdDTO.Sosachduocmuon = int.Parse(dt.Rows[0]["sosachduocmuon"].ToString());
            qdDTO.Kcnamxuatban = int.Parse(dt.Rows[0]["kcnamxuatban"].ToString());
            qdDTO.Tienphattrasachtremoingay = int.Parse(dt.Rows[0]["tienphattrasachtremoingay"].ToString());



            return true;
       }


       public bool suaQuyDinh(quydinhDTO qdDTO)
       {
           string query = string.Format("update [quydinh] set tienphattrasachtremoingay=@tienphattrasachtremoingay, tuoimax =@tuoimax ,tuoimin=@tuoimin , songayduocmuon=@songayduocmuon ,sosachduocmuon=@sosachduocmuon ,kcnamxuatban =@kcnamxuatban where ( 1=1 )");
           

           SqlParameter [] param= new SqlParameter [6];
           param[0] = new SqlParameter("@tuoimax", SqlDbType.Int);
           param[0].Value = Convert.ToString(qdDTO.Tuoimax);
           param[1] = new SqlParameter("@tuoimin", SqlDbType.Int);
           param[1].Value = Convert.ToString(qdDTO.Tuoimin);
           param[2] = new SqlParameter("@songayduocmuon", SqlDbType.Int);
           param[2].Value = Convert.ToString(qdDTO.Songayduocmuon);
           param[3] = new SqlParameter("@sosachduocmuon", SqlDbType.Int);
           param[3].Value = Convert.ToString(qdDTO.Sosachduocmuon);
           param[4] = new SqlParameter("@kcnamxuatban", SqlDbType.Int);
           param[4].Value = Convert.ToString(qdDTO.Kcnamxuatban);
           param[5] = new SqlParameter("@tienphattrasachtremoingay", SqlDbType.Int);
           param[5].Value = Convert.ToString(qdDTO.Tienphattrasachtremoingay);

           conn.excuteNonQuery2(query, param);

          return true;

       }

   }
}
