
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbConnection; 
using QuanLiThuVienDTO;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions; 

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
            SqlParameter[] parm = new SqlParameter[1];
            docgiaDTO dg = new docgiaDTO();
            parm[0] = new SqlParameter("@mathe", SqlDbType.Int);
            parm[0].Value = dg.MaThe;
             
            DataTable datatable = new DataTable();
            datatable = conn.excuteNonQuery(query, parm);

            //gan value trong datatable vao DTO 

            foreach (DataRow dr in datatable.Rows)
            {
                docgiaDTO tdgDTO = new docgiaDTO();

                tdgDTO.MaThe = Int32.Parse( dr["mathe"].ToString());
                tdgDTO.HoTen = dr["hoten"].ToString();
                tdgDTO.Email = dr["email"].ToString();
                tdgDTO.Loaidocgia = Int32.Parse(dr["loaidocgia"].ToString());
                tdgDTO.NgaySinh = DateTime.Parse( dr["ngaysinh"].ToString());
                tdgDTO.Ngaydk = DateTime.Parse( dr["ngaydk"].ToString());
                tdgDTO.DiaChi = dr["diachi"].ToString();
                tdgDTO.Tongtienno = Int32.Parse(dr["tongtienno"].ToString ());

                listDGDTO.Add(tdgDTO);
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
            param[6].Value = Convert.ToString(dgDTO.Loaidocgia);
            param[7] = new SqlParameter("@tongtienno", SqlDbType.Int);
            param[7].Value = Convert.ToString(dgDTO.Tongtienno);

            conn.excuteNonQuery2(query, param);


            return true;
        
        }


       // update  bool ,dto 
        public bool suaDocGia(docgiaDTO dgDTO, int mathe)
        {

            string query = string.Format("update [docgia] set mathe=@mathe, hoten=@hoten,email=@email,ngaysinh=@ngaysinh,ngaydk=@ngaydk,diachi=@diachi, tongtienno=@tongtienno, loaidocgia=@loaidocgia where mathe=@mathe ");
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
            param[6] = new SqlParameter("@tongtienno", SqlDbType.Int);
            param[6].Value = Convert.ToString(dgDTO.Tongtienno);
            param[7] = new SqlParameter("@loaidocgia", SqlDbType.Int);
            param[7].Value = Convert.ToString(dgDTO.Loaidocgia);
            conn.excuteNonQuery2(query, param);


            return true;

        }

        
        public bool xoaDocGia( int mathe)
        {
            string query = string.Format("delete from [docgia] where mathe=@mathe");
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@mathe", SqlDbType.Int);
            param[0].Value = Convert.ToString(mathe);
            conn.excuteNonQuery2(query, param);
            return  true ;
        }

                  public  string ConvertToUnSign(string text) 
    {
        for (int i = 33; i < 48; i++)
        {
            text = text.Replace(((char)i).ToString(), "");
        }

        for (int i = 58; i < 65; i++)
        {
            text = text.Replace(((char)i).ToString(), "");
        }

        for (int i = 91; i < 97; i++)
        {
            text = text.Replace(((char)i).ToString(), "");
        }
         for (int i = 123; i < 127; i++)
        {
            text = text.Replace(((char)i).ToString(), "");
        }
        text = text.Replace(" ", "-");
        Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
        string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
        return regex.Replace(strFormD, String.Empty).Replace('\u0111','d').Replace('\u0110', 'D');
    }


        // tim kiem doc gia theo ten 
        public bool timkiemDG(string Searchstr, List<docgiaDTO> ldgDTO)
        {   
             //****** ưu tiên chuỗi đầu tien hơn 


            // tìm vs chuỗi vào có dấu 
            // thêm vào list 
            // tạo một list tạm 
            // chuyển tất cả các tên trong list thành không dấu vào list tạm 
            // chuyển searchstr thành ko dấu 
            // tim trong list ko dấu vs str ko dau

            // add

            //string searchStr2=ConvertToUnSign(Searchstr); 

            string query = string.Format("select * from [docgia] where hoten like @hoten");
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@hoten", SqlDbType.NVarChar);
            param[0].Value = Convert.ToString("%" + Searchstr + "%");

            DataTable dtb = new DataTable();
            dtb = conn.excuteNonQuery(query, param);

            foreach (DataRow dr in dtb.Rows)
            {
                docgiaDTO tdgDTO = new docgiaDTO();

                tdgDTO.MaThe = Int32.Parse(dr["mathe"].ToString());
                tdgDTO.HoTen = dr["hoten"].ToString();
                tdgDTO.Email = dr["email"].ToString();
                tdgDTO.Loaidocgia = Int32.Parse(dr["loaidocgia"].ToString());
                tdgDTO.NgaySinh = DateTime.Parse(dr["ngaysinh"].ToString());
                tdgDTO.Ngaydk = DateTime.Parse(dr["ngaydk"].ToString());
                tdgDTO.DiaChi = dr["diachi"].ToString();
                tdgDTO.Tongtienno = Int32.Parse(dr["tongtienno"].ToString());

                ldgDTO.Add(tdgDTO);
            }


            if (dtb.Rows.Count > 0)
            {
                return true;
            }
                
            return false; 
        
        }
     
    }
}
