using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDTO;
using dbConnection;
using System.Data;
using System.Data.SqlClient;

namespace QuanLiThuVienDAL
{
  public  class phieuthutienDAL
    {
      private dbconnection conn;

      public phieuthutienDAL()
      {
          conn = new dbconnection();

      }

      // danh sach pheiu thu 
      public bool danhsachPhieuThu(List<phieuthutienDTO> listPTTDTO)
      {

          string query = string.Format("select* from [phieuthutienphat] ");
          SqlParameter[] parm = new SqlParameter[1];
          // khong can nhung phai co 
          docgiaDTO dg = new docgiaDTO();
          parm[0] = new SqlParameter("@mathe", SqlDbType.Int);
          parm[0].Value = dg.MaThe;
          
          DataTable datatable = new DataTable();
          datatable = conn.excuteNonQuery(query, parm);

          //gan value trong datatable vao DTO 

          foreach (DataRow dr in datatable.Rows)
          {
              phieuthutienDTO pttDTO = new phieuthutienDTO();



              pttDTO.Ngaythu = DateTime.Parse(dr["ngaythu"].ToString());
              pttDTO.Tienthu = Int32.Parse(dr["tienthu"].ToString());
              pttDTO.Mathe = Int32.Parse(dr["mathe"].ToString());
              pttDTO.Maphieuthu = Int32.Parse(dr["maphieuthu"].ToString());

              listPTTDTO.Add(pttDTO);
          }




          return true;
      }


      // them phieu thu 

      public bool themPhieuThu (phieuthutienDTO pttDTO)
       {

            string query = string.Format("insert into [phieuthutienphat] values (@maphieuthu,@ngaythu,@tienthu,@mathe)");
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@mathe", SqlDbType.Int);
            param[0].Value = Convert.ToString(pttDTO.Mathe);
            param[1] = new SqlParameter("@tienthu", SqlDbType.Int);
            param[1].Value = Convert.ToString(pttDTO.Tienthu);
            param[2] = new SqlParameter("@maphieuthu", SqlDbType.Int );
            param[2].Value = Convert.ToString(pttDTO.Maphieuthu);
            param[3] = new SqlParameter("@ngaythu", SqlDbType.DateTime);
            param[3].Value = Convert.ToString(pttDTO.Ngaythu);
          
            conn.excuteNonQuery2(query, param);


            return true;
        
        }



    }
}
