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
public    class phieumuonDAL
    {

       private dbconnection conn;


       public phieumuonDAL()
       {
           conn = new dbconnection(); 
       }


    
        public bool danhsachPM (List<phieumuonDTO > listPMDTO)
        {

            string query = string.Format("select* from [phieumuon] ");
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
                phieumuonDTO pmDTO = new phieumuonDTO();

                pmDTO.Mapm = int.Parse(dr["mapm"].ToString());
                pmDTO.Ngaymuon = DateTime.Parse(dr["ngaymuon"].ToString());
                pmDTO.Mathe = int.Parse(dr["mathe"].ToString());


                listPMDTO.Add(pmDTO);
            }
        
       
            return true; 
        }

        // tu sinh maphieumuon 

        ////public int taoMaPM()
        ////{
        ////    int mpm;

  



        ////    return 1; 
        
        ////}



        // them phieu muon // pm tu tang //ngay muon lon
    
        public bool themPhieuMuon(phieumuonDTO pmDTO )
        {


            string query = string.Format("insert into [phieumuon] values (@mapm,@ngaymuon,@mathe)");
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@mapm", SqlDbType.Int);
            param[0].Value = Convert.ToString(pmDTO.Mapm);
            param[1] = new SqlParameter("@ngaymuon", SqlDbType.DateTime);
            param[1].Value = Convert.ToString(pmDTO.Ngaymuon);
            param[2] = new SqlParameter("@mathe", SqlDbType.Int);
            param[2].Value = Convert.ToString(pmDTO.Mathe);
 
            conn.excuteNonQuery2(query, param);


            return true;
        }






    }
}
