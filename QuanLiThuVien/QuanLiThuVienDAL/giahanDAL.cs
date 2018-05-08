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
    public class giahanDAL
    {
        private dbconnection conn ;

        public giahanDAL()
        { 
        
        
        }

        public bool laygiahancuasach(int masach, giahanDTO ghDTO)
        {
            string query = string.Format("select * from [giahan] where masach=@masach");
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@masach", SqlDbType.Int);
            param[0].Value = masach;
            DataTable dtb = new DataTable();
            dtb = conn.excuteNonQuery(query, param);

            if (dtb.Rows.Count > 0)
            {
         

                 DataRow dr = dtb.Rows[0];  

              //   giahanDTO ghDTO = new giahanDTO(); 

                ghDTO.Masach = int.Parse(dr["masach"].ToString());
                ghDTO.Solangiahan = int.Parse(dr["solangiahan"].ToString()); 


     return true    ; 

            }


            
              
            return false;
 
        }


        public bool sualangiahan (int masach,giahanDTO DTO )
        {
            string query = string.Format("select * from [giahan] where masach=@masach");
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@masach", SqlDbType.Int);
            param[0].Value = masach;
            DataTable dtb = new DataTable();
            dtb = conn.excuteNonQuery(query, param);



          return true    ; 

        
        }

        public bool themgiahan (int masach , giahanDTO ghDTO  )
        {
        
        
          return true    ; 

        }

        public bool xoagiahan (int masach )
        {
  return true    ; 
        
        }
    }
}
