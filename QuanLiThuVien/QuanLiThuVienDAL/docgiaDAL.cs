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
    public class docgiaDAL
    {  
       
       private dbconnection conn;


       public docgiaDAL()
       {
           conn = new dbconnection(); 
       }
        // hien thi list dto 

        public bool danhsachDG (List<docgiaDTO > listDGDTO  )
        {

            string query = string.Format("select* from [docgia] ");
            SqlParameter[] param = new SqlParameter[1];
            docgiaDTO dgDTO = new docgiaDTO();
            param[0] = new SqlParameter("@mathe", SqlDbType.Int);
            param[0].Value = Convert.ToString(dgDTO.MaThe);
            DataTable datatable = new DataTable();
            datatable = conn.excuteNonQuery(query, param);

            //gan value trong datatable vao DTO 

            foreach (DataRow dr in datatable.Rows)
            {
                //docgiaDTO tdgDTO = new docgiaDTO();
                dgDTO = new docgiaDTO();
                dgDTO.MaThe = int.Parse(dr["mathe"].ToString());
                dgDTO.HoTen = dr["hoten"].ToString();
                dgDTO.Email = dr["email"].ToString();
                dgDTO.Loaidocgia = Int32.Parse(dr["loaidocgia"].ToString());
                dgDTO.NgaySinh = DateTime.Parse( dr["ngaysinh"].ToString());
                dgDTO.Ngaydk = DateTime.Parse( dr["ngaydk"].ToString());
                dgDTO.DiaChi = dr["diachi"].ToString();
                dgDTO.Tongtienno = int.Parse(dr["tongtienno"].ToString());

                listDGDTO.Add(dgDTO);
            }
        
       


            return true; 
        }
       // kiem tra ton tai chua -> bool 
        public bool isDocGia(int mathe)
        {

            string query = string.Format("select * from [docgia] where mathe=@mathe");
            SqlParameter[] param = new SqlParameter[1];
            param[0]=new SqlParameter ("@mathe",SqlDbType.Int); 
            param[0].Value=mathe;

            DataTable dtb=new DataTable (); 
            dtb=conn.excuteNonQuery (query,param); 
           
            
            
            if (dtb.Rows.Count>0) 
                return true ;
            return false; 
        
        }

        public bool isDocGia(int mathe,ref docgiaDTO dgDTO)
        {

            string query = string.Format("select * from [docgia] where mathe=@mathe");
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@mathe", SqlDbType.Int);
            param[0].Value = mathe;

            DataTable dtb = new DataTable();

            dtb = conn.excuteNonQuery(query, param);

            if (dtb.Rows.Count > 0)
            {
                DataRow dr = dtb.Rows[0];
                dgDTO.MaThe = int.Parse(dr["mathe"].ToString());
                dgDTO.HoTen = dr["hoten"].ToString();
                dgDTO.Email = dr["email"].ToString();
                dgDTO.Loaidocgia = int.Parse(dr["loaidocgia"].ToString());
                dgDTO.NgaySinh = DateTime.Parse(dr["ngaysinh"].ToString());
                dgDTO.Ngaydk = DateTime.Parse(dr["ngaydk"].ToString());
                dgDTO.DiaChi = dr["diachi"].ToString();
                dgDTO.Tongtienno = int.Parse(dr["tongtienno"].ToString());


                return true;
            }
            return false;

        }
        // insert  bool ,dto (có chưa bảng qi định dto )

        public bool themDocGia(docgiaDTO dgDTO)
        {

            string query = string.Format("insert into [docgia] values (@mathe,@hoten,@email,@ngaysinh,@ngaydk,@diachi,@loaidocgia,@tongtienno)");
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@mathe", SqlDbType.Int);
            param[0].Value = Convert.ToString(dgDTO.MaThe);
            param[1] = new SqlParameter("@hoten", SqlDbType.NVarChar);
            param[1].Value = Convert.ToString(dgDTO.HoTen);
            param[2] = new SqlParameter("@email", SqlDbType.NVarChar);
            param[2].Value = Convert.ToString(dgDTO.Email);
            param[3] = new SqlParameter("@ngaysinh", SqlDbType.DateTime);
            param[3].Value = Convert.ToString(dgDTO.NgaySinh);
            param[4] = new SqlParameter("@ngaydk", SqlDbType.DateTime);
            param[4].Value = Convert.ToString(dgDTO.Ngaydk);
            param[5] = new SqlParameter("@diachi", SqlDbType.NVarChar);
            param[5].Value = Convert.ToString(dgDTO.DiaChi);
            param[6] = new SqlParameter("@loaidocgia", SqlDbType.Int);
            param[6].Value = Convert.ToString(dgDTO.Email);
            param[7] = new SqlParameter("@tongtienno", SqlDbType.Int);
            param[7].Value = Convert.ToString(dgDTO.Tongtienno);

            conn.excuteNonQuery(query, param);


            return true;
        
        }


       // update  bool ,dto 
        public bool suaDocGia(docgiaDTO dgDTO,int mathe )
        {

            string query = string.Format("update [docgia] set hoten=@hoten,email=@email,ngaysinh=@ngaysinh,ngaydk=@ngaydk,diachi=@diachi,loaidocgia=@loaidocgia,tongtienno=@tongtienno where mathe=@mathe ");
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@mathe", SqlDbType.Int);
            param[0].Value = Convert.ToString(mathe);
            param[1] = new SqlParameter("@hoten", SqlDbType.NVarChar);
            param[1].Value = Convert.ToString(dgDTO.HoTen);
            param[2] = new SqlParameter("@email", SqlDbType.NVarChar);
            param[2].Value = Convert.ToString(dgDTO.Email);
            param[3] = new SqlParameter("@ngaysinh", SqlDbType.DateTime);
            param[3].Value = Convert.ToString(dgDTO.NgaySinh);
            param[4] = new SqlParameter("@ngaydk", SqlDbType.DateTime);
            param[4].Value = Convert.ToString(dgDTO.Ngaydk);
            param[5] = new SqlParameter("@diachi", SqlDbType.NVarChar);
            param[5].Value = Convert.ToString(dgDTO.DiaChi);
            param[6] = new SqlParameter("@loaidocgia", SqlDbType.Int);
            param[6].Value = Convert.ToString(dgDTO.Email);
            param[7] = new SqlParameter("@tongtienno", SqlDbType.Money);
            param[7].Value = Convert.ToString(dgDTO.Tongtienno);

            conn.excuteNonQuery(query, param);


            return true;

        }




       // del bool , dto 
       // con sach k , con tien ko , 
        public bool xoaDocGia(int mathe)
        { 

        return  true ;
        }


    }
}
