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

       public bool listquydinh(List<quydinhDTO> lqđTO)
       {


           string query = string.Format("select * from [quydinh] ");

           SqlParameter[] param = new SqlParameter[1]; 
           DataTable dt= new DataTable ();

           dt = conn.excuteNonQuery(query, param);

           foreach (DataRow dr in dt.Rows)
           {
               quydinhDTO qdDTO = new quydinhDTO();

               qdDTO.Tuoimax = Int32.Parse(dr["tuoimax"].ToString());
               qdDTO.Tuoimin = Int32.Parse(dr["tuoimin"].ToString());
               qdDTO.Songayduocmuon = Int32.Parse(dr["songayduocmuon"].ToString());
               qdDTO.Sosachduocmuon = Int32.Parse(dr["sosachduocmuon"].ToString());
               qdDTO.Kcnamxuatban = Int32.Parse(dr["kcnamxuatban"].ToString());

               lqđTO.Add(qdDTO);

           }


           return true;
       }


       public bool suaQuyDinh(quydinhDTO qdDTO)
       {
           string query = string.Format("update [quydinh] set tuoimax =@tuoimax ,tuoimin=@tuoimin , songayduocmuon=@songayduocmuon ,sosachduocmuon=@sosachduocmuon ,kcnamxuatban =@kcnamxuatban where ROWNUM <=3");
           

          SqlParameter [] param= new SqlParameter [5];
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


          conn.excuteNonQuery2(query, param);

          return true;

       }

    }
}
