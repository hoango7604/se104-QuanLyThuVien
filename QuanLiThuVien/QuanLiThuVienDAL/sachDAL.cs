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
  public    class sachDAL
    {
             private dbconnection conn;


       public sachDAL()
       {
           conn = new dbconnection(); 
       }


      //hien thi danh sach 
       public bool tatcaSach(List<sachDTO> lsachDTO)
       {
           
      

            string query = string.Format("select* from [sach] ");
            SqlParameter[] parm = new SqlParameter[1];

            DataTable datatable = new DataTable();
            datatable = conn.excuteNonQuery(query, parm);

            //gan value trong datatable vao DTO 

            foreach (DataRow dr in datatable.Rows)
            {
                sachDTO sDTO = new sachDTO();

                sDTO.Masach= Int32.Parse( dr["mathe"].ToString());
                sDTO.Tensach = dr["tensach "].ToString();
                sDTO.Theloai = dr["Theloai"].ToString();
                sDTO.Nxb = dr["nxb"].ToString();
                sDTO.Ngayxb =DateTime.Parse(dr["ngayxb"].ToString());
                sDTO.Giatri = Int32.Parse(dr["giatri"].ToString());
                sDTO.Trangthai = Int32.Parse(dr["trangthai"].ToString());
                lsachDTO.Add(sDTO);
            }
        




           return true; 

       }
      
      // them sach

       public bool themSach(sachDTO sDTO)
       {
           string query = string.Format("insert into [sach] value (@masach,@tensach,@theloai,@nxb,@ngayxb,@giatri,@trangthai)");
           SqlParameter[] param = new SqlParameter[7];
           param[0] = new SqlParameter("@masach", SqlDbType.Int);
           param[0].Value = Convert.ToString(sDTO.Masach);
           param[1] = new SqlParameter("@tensach", SqlDbType.NVarChar);
           param[1].Value = Convert.ToString(sDTO.Tensach);
           param[2] = new SqlParameter("@theloai", SqlDbType.VarChar);
           param[2].Value = Convert.ToString(sDTO.Theloai);
           param[3] = new SqlParameter("@nxb", SqlDbType.NVarChar);
           param[3].Value = Convert.ToString(sDTO.Nxb);
           param[4] = new SqlParameter("@ngayxb", SqlDbType.DateTime);
           param[4].Value = Convert.ToString(sDTO.Ngayxb);
           param[5] = new SqlParameter("@giatri", SqlDbType.Int);
           param[5].Value = Convert.ToString(sDTO.Giatri);
           param[6] = new SqlParameter("@trangthai", SqlDbType.Int);
           param[6].Value = Convert.ToString(sDTO.Trangthai);


           conn.excuteNonQuery(query, param);

           return true;
       
       }

      // update sach 
       public bool suaSach(sachDTO sDTO, int masach)
       {
           string query = string.Format("  update [sach] set  tensach=@tensach,tensach=@tensach,nxb=@nxb,ngayxb=@ngayxb,giatri=@giatri,trangthai=@trangthai where mathe=@masach ");
           SqlParameter[] param = new SqlParameter[7];
           param[0] = new SqlParameter("@masach", SqlDbType.Int);
           param[0].Value = Convert.ToString(sDTO.Masach);
           param[1] = new SqlParameter("@tensach", SqlDbType.NVarChar);
           param[1].Value = Convert.ToString(sDTO.Tensach);
           param[2] = new SqlParameter("@theloai", SqlDbType.VarChar);
           param[2].Value = Convert.ToString(sDTO.Theloai);
           param[3] = new SqlParameter("@nxb", SqlDbType.NVarChar);
           param[3].Value = Convert.ToString(sDTO.Nxb);
           param[4] = new SqlParameter("@ngayxb", SqlDbType.DateTime);
           param[4].Value = Convert.ToString(sDTO.Ngayxb);
           param[5] = new SqlParameter("@giatri", SqlDbType.Int);
           param[5].Value = Convert.ToString(sDTO.Giatri);
           param[6] = new SqlParameter("@trangthai", SqlDbType.Int);
           param[6].Value = Convert.ToString(sDTO.Trangthai);


           conn.excuteNonQuery(query, param);


           return true; 
       
       }


    }
}