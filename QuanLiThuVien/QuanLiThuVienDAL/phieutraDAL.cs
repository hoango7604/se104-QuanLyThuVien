﻿using System;
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
    class phieutraDAL
    {

        
       private dbconnection conn;


       public phieutraDAL()
       {
           conn = new dbconnection(); 
       }
        // hien thi list dto 

        public bool danhsachPhieuTra (List<phieutraDTO > listPTDTO  )
        {

            string query = string.Format("select* from [phieutra] ");
            SqlParameter[] parm = new SqlParameter[1];

            DataTable datatable = new DataTable();
            datatable = conn.excuteNonQuery(query, parm);

            //gan value trong datatable vao DTO 

            foreach (DataRow dr in datatable.Rows)
            {
                phieutraDTO ptDTO = new phieutraDTO();

                ptDTO.Mapt = Int32.Parse( dr["mapt"].ToString());
                ptDTO.Ngaytra =DateTime.Parse( dr["ngaytra"].ToString()) ;
                ptDTO.Tienphatkinay = Int32.Parse(dr["tienphatkinay"].ToString());
                ptDTO.Mathe= Int32.Parse(dr["mathe"].ToString());
             
                listPTDTO.Add(ptDTO);
            }
        
       


            return true; 
        }


        public bool themPhieuTra(phieutraDTO ptDTO)
        {


            string query = string.Format("insert into [phieutra] value (mapt=@mapt,ngaytra=@ngaytra,tienphatkinay=@tienphatkinay,mathe=@mathe)");
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@mapt", SqlDbType.Int);
            param[0].Value = Convert.ToString(ptDTO.Mapt);
            param[1] = new SqlParameter("@ngaytra", SqlDbType.DateTime);
            param[1].Value = Convert.ToString(ptDTO.Ngaytra);
            param[2] = new SqlParameter("@tienphatkinay", SqlDbType.Int);
            param[2].Value = Convert.ToString(ptDTO.Tienphatkinay);
            param[3] = new SqlParameter("@mathe", SqlDbType.Int);
            param[3].Value = Convert.ToString(ptDTO.Mathe);

            conn.excuteNonQuery(query, param);


            return true;
        }

    
    }
}