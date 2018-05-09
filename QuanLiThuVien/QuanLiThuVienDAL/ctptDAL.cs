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
    public class ctptDAL
    {

        
       private dbconnection conn;


       public ctptDAL()
       {
           conn = new dbconnection(); 
       }
        // hien thi list dto 

        public bool danhsachCTPT(List<ctptDTO> listctptDTO  )
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
                 ctptDTO ctphieutraDTO = new ctptDTO();

                 ctphieutraDTO .Mapt = Int32.Parse( dr["mapt"].ToString());
                 ctphieutraDTO.Masach = Int32.Parse(dr["masach"].ToString());
                 ctphieutraDTO.Songaydamuon=Int32.Parse(dr["songaydamuon"].ToString());
                 ctphieutraDTO.Tienphatsach=Int32.Parse(dr["tienphatsach"].ToString());

                 listctptDTO.Add(ctphieutraDTO); 
            }
        
       


            return true; 
        }

        public bool themCTPT(ctptDTO ctptDTO)
        {


            string query = string.Format("insert into [ct_phieutra] values( @songaydamuon,@tienphatsach, @mapt, @masach)");
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@songaydamuon", SqlDbType.Int);
            param[0].Value = Convert.ToString(ctptDTO.Songaydamuon);
            param[1] = new SqlParameter("@tienphatsach", SqlDbType.Int);
            param[1].Value = Convert.ToString(ctptDTO.Tienphatsach);

            param[2] = new SqlParameter("@mapt", SqlDbType.Int);
            param[2].Value = Convert.ToString(ctptDTO.Mapt);
            param[3] = new SqlParameter("@masach", SqlDbType.Int);
            param[3].Value = Convert.ToString(ctptDTO.Masach);


            conn.excuteNonQuery2(query, param);


            return true;




        }
        
        //chưa kiểm duyệt
        //public bool suaCTPT(ctptDTO ctptDTO)
        //{


        //    string query = string.Format("update [ (songaydamuon=@songaydamuon,tienphatsach=@tienphatsach, mapt=@mapt, masach=@masach)");
        //    SqlParameter[] param = new SqlParameter[4];

        //    param[0] = new SqlParameter("@songaydamuon", SqlDbType.Int);
        //    param[0].Value = Convert.ToString(ctptDTO.Songaydamuon);
        //    param[1] = new SqlParameter("@tienphatsach", SqlDbType.Int);
        //    param[1].Value = Convert.ToString(ctptDTO.Tienphatsach);

        //    param[2] = new SqlParameter("@mapt", SqlDbType.Int);
        //    param[2].Value = Convert.ToString(ctptDTO.Mapt);
        //    param[3] = new SqlParameter("@masach", SqlDbType.Int);
        //    param[3].Value = Convert.ToString(ctptDTO.Masach);


        //    conn.excuteNonQuery2(query, param);


        //    return true;
        //}

    }
}
