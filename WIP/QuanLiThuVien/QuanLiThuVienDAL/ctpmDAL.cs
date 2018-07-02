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
    public class ctpmDAL
    {


        private dbconnection conn;


        public ctpmDAL()
        {
            conn = new dbconnection();
        }
        // hien thi list dto 

        public bool danhsachCTPM(List<ctpmDTO> listctpmDTO)
        {

            string query = string.Format("select* from [ct_phieumuon] ");
            SqlParameter[] parm = new SqlParameter[1];

            // ko can thiet nhung phai co 
            docgiaDTO dg = new docgiaDTO();
            parm[0] = new SqlParameter("@masach", SqlDbType.Int);
            parm[0].Value = dg.MaThe;

            DataTable datatable = new DataTable();
            datatable = conn.excuteNonQuery(query, parm);

            //gan value trong datatable vao DTO 

            foreach (DataRow dr in datatable.Rows)
            {
                ctpmDTO pmDTO = new ctpmDTO();
                pmDTO.Mapm = Int32.Parse(dr["mapm"].ToString());

                pmDTO.Masach = Int32.Parse(dr["masach"].ToString());


                listctpmDTO.Add(pmDTO);
            }




            return true;
        }




        public bool themCTPM(ctpmDTO ctpmDTO)
        {


            string query = string.Format("insert into [ct_phieumuon] values (@mapm,@masach)");
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@mapm", SqlDbType.Int);
            param[0].Value = Convert.ToString(ctpmDTO.Mapm);
            param[1] = new SqlParameter("@masach", SqlDbType.Int);
            param[1].Value = Convert.ToString(ctpmDTO.Masach);


            conn.excuteNonQuery2(query, param);


            return true;




        }
    }
}
