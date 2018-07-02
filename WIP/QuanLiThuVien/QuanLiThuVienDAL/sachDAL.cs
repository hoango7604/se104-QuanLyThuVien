
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
  public class sachDAL 
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
            // ko can thiet nhung phai co 
            docgiaDTO dg = new docgiaDTO();
            parm[0] = new SqlParameter("@masach", SqlDbType.Int);
            parm[0].Value = dg.MaThe;


            DataTable datatable = new DataTable();
            datatable = conn.excuteNonQuery(query, parm);

            //gan value trong datatable vao DTO 

            foreach (DataRow dr in datatable.Rows)
            {
                sachDTO sDTO = new sachDTO();

                sDTO.Masach = int.Parse(dr["masach"].ToString());
                sDTO.Tensach = dr["tensach"].ToString();
                sDTO.Theloai = dr["Theloai"].ToString();
                sDTO.Tacgia = dr["tacgia"].ToString();
                sDTO.Nxb = dr["nxb"].ToString();
                sDTO.Ngaynhap = DateTime.Parse(dr["ngaynhap"].ToString());
                sDTO.Ngayxb = DateTime.Parse(dr["ngayxb"].ToString());
                sDTO.Giatri = int.Parse(dr["giatri"].ToString());
                sDTO.Trangthai = int.Parse(dr["trangthai"].ToString());

                lsachDTO.Add(sDTO);
            }





            return true;

        }
        // check sach co trong db k 
        public bool isSach(int masach)
       {

           string query = string.Format("select * from [sach] where masach=@masach");
           SqlParameter[] param = new SqlParameter[1];
           param[0] = new SqlParameter("@masach", SqlDbType.Int);
           param[0].Value = masach;

           DataTable dtb = new DataTable();
           dtb = conn.excuteNonQuery(query, param);



           if (dtb.Rows.Count > 0)
               return true;
           return false;

       }

        public sachDTO thongtinSach(int masach)
        {
            sachDTO sDTO= new sachDTO () ; 

            string query = string.Format("select * from [sach] where masach=@masach");
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@masach", SqlDbType.Int);
            param[0].Value = masach;

            DataTable dtb = new DataTable();
            dtb = conn.excuteNonQuery(query, param);

            if (dtb.Rows.Count > 0)
            {
                DataRow dr = dtb.Rows[0];

                sDTO.Masach = int.Parse(dr["masach"].ToString());
                sDTO.Tensach = dr["tensach"].ToString();
                sDTO.Theloai = dr["Theloai"].ToString();
                sDTO.Tacgia = dr["tacgia"].ToString();
                sDTO.Nxb = dr["nxb"].ToString();
                sDTO.Ngaynhap = DateTime.Parse(dr["ngaynhap"].ToString());
                sDTO.Ngayxb = DateTime.Parse(dr["ngayxb"].ToString());
                sDTO.Giatri = int.Parse(dr["giatri"].ToString());
                sDTO.Trangthai = int.Parse(dr["trangthai"].ToString());
            }
            return sDTO; 
         
        
        }
         
      // them sach

       public bool themSach(sachDTO sDTO)
       {
           string query = string.Format("insert into [sach] values (@masach,@tensach,@theloai,@tacgia,@nxb,@ngaynhap,@ngayxb,@giatri,@trangthai)");
           SqlParameter[] param = new SqlParameter[9];
           param[0] = new SqlParameter("@masach", SqlDbType.Int);
           param[0].Value = Convert.ToString(sDTO.Masach);
           param[1] = new SqlParameter("@tensach", SqlDbType.NVarChar);
           param[1].Value = Convert.ToString(sDTO.Tensach);
           param[2] = new SqlParameter("@theloai", SqlDbType.NVarChar);
           param[2].Value = Convert.ToString(sDTO.Theloai);
           param[3] = new SqlParameter("@tacgia", SqlDbType.NVarChar);
           param[3].Value = Convert.ToString(sDTO.Tacgia);
           param[4] = new SqlParameter("@nxb", SqlDbType.NVarChar);
           param[4].Value = Convert.ToString(sDTO.Nxb);
           param[5] = new SqlParameter("@ngaynhap", SqlDbType.DateTime);
           param[5].Value = Convert.ToString(sDTO.Ngaynhap);
           param[6] = new SqlParameter("@ngayxb", SqlDbType.DateTime);
           param[6].Value = Convert.ToString(sDTO.Ngayxb);
           param[7] = new SqlParameter("@giatri", SqlDbType.Int);
           param[7].Value = Convert.ToString(sDTO.Giatri);
           param[8] = new SqlParameter("@trangthai", SqlDbType.Int);
           param[8].Value = Convert.ToString(sDTO.Trangthai);

           conn.excuteNonQuery2(query, param);

           return true;
       
       }

      // update sach 
       public bool suaSach(sachDTO sDTO, int masach)
       {
           string query = string.Format("  update [sach] set  tensach=@tensach,theloai=@theloai,tacgia=@tacgia, nxb=@nxb,ngaynhap=@ngaynhap,ngayxb=@ngayxb,giatri=@giatri,trangthai=@trangthai where masach=@masach ");
           SqlParameter[] param = new SqlParameter[9];
           param[0] = new SqlParameter("@masach", SqlDbType.Int);
           param[0].Value = Convert.ToString(sDTO.Masach);
           param[1] = new SqlParameter("@tensach", SqlDbType.NVarChar);
           param[1].Value = Convert.ToString(sDTO.Tensach);
           param[2] = new SqlParameter("@theloai", SqlDbType.NVarChar);
           param[2].Value = Convert.ToString(sDTO.Theloai);
           param[3] = new SqlParameter("@tacgia", SqlDbType.NVarChar);
           param[3].Value = Convert.ToString(sDTO.Tacgia);
           param[4] = new SqlParameter("@nxb", SqlDbType.NVarChar);
           param[4].Value = Convert.ToString(sDTO.Nxb);
           param[5] = new SqlParameter("@ngaynhap", SqlDbType.DateTime);
           param[5].Value = Convert.ToString(sDTO.Ngaynhap);
           param[6] = new SqlParameter("@ngayxb", SqlDbType.DateTime);
           param[6].Value = Convert.ToString(sDTO.Ngayxb);
           param[7] = new SqlParameter("@giatri", SqlDbType.Int);
           param[7].Value = Convert.ToString(sDTO.Giatri);
           param[8] = new SqlParameter("@trangthai", SqlDbType.Int);
           param[8].Value = Convert.ToString(sDTO.Trangthai);
           

           conn.excuteNonQuery2(query, param);


           return true; 
       
       }


    /// <summary>
        /// M Thêm cái hàm đây nhá Hiếu
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
       public bool SachDangMuon(int mathe, List<sachDTO> sachList, List<DateTime> ngaymuoncuasachList)
        {
            DataTable s1, s2;
            s1 = new DataTable();
            s2 = new DataTable();

            List<sachdangmuonDTO> Lsdm = new List<sachdangmuonDTO>();
            List<sachdatraDTO> Lsdt = new List<sachdatraDTO>();
            sachdangmuonDTO sdmDTO;



            List<int> masachLIST =new List<int>() ;  

            // ds sach dang muon nhung chua biet ai muon 
            string query1 = string.Format(" SELECT s.masach, trangthai ,MAX(ngaymuon) as ngaymuon FROM dbo.sach s, dbo.ct_phieumuon ct, dbo.phieumuon pm WHERE s.masach = ct.masach AND s.trangthai = 0  AND ct.mapm = pm.mapm AND pm.mapm IN(  SELECT mapm  FROM dbo.phieumuon pm, dbo.docgia dg   WHERE pm.mathe = dg.mathe and dg.mathe=@mathe ) GROUP BY s.masach ,s.trangthai "); 
            SqlParameter[] param1 = new SqlParameter[1];
            param1[0] = new SqlParameter("@mathe", SqlDbType.Int);
            param1[0].Value = Convert.ToString(mathe );
            s1= conn.excuteNonQuery(query1, param1);
            foreach (DataRow dr in s1.Rows)
            {
                sdmDTO = new sachdangmuonDTO();

                sdmDTO.Masach = int.Parse(dr["masach"].ToString()); 
                sdmDTO.Trangthai = int.Parse(dr["trangthai"].ToString());
                sdmDTO.Ngaymuon = DateTime.Parse(dr["ngaymuon"].ToString () );
                Lsdm.Add(sdmDTO); 

            }


            // ds sach tra cua doc gia 
            string query2 = string.Format("  SELECT s.masach, MAX(pt.ngaytra) as ngaytra FROM dbo.sach s, dbo.ct_phieutra ct, dbo.phieutra pt  WHERE s.masach = ct.masach  AND ct.mapt = pt.mapt AND pt.mapt IN(  SELECT mapt   FROM dbo.phieutra, dbo.docgia dg   WHERE pt.mathe = dg.mathe and dg.mathe=@mathe ) GROUP BY s.masach    ");
            SqlParameter[] param2 = new SqlParameter[1];
            param2[0] = new SqlParameter("@mathe", SqlDbType.Int);
            param2[0].Value = Convert.ToString(mathe);
            s2 = conn.excuteNonQuery(query2, param2);

            foreach (DataRow dr in s2.Rows)
            {
                sachdatraDTO sdtDTO = new sachdatraDTO(); 


                sdtDTO.Masach = int.Parse(dr["masach"].ToString());
                   sdtDTO.Ngaytra = DateTime.Parse(dr["ngaytra"].ToString());


                Lsdt.Add(sdtDTO);

            }
            // chọn ra sách đang mượn của độc giả này 
            // dk chọn là : ngày mượn lớn hơn ngày trả và không có ngày trả  

            int fl= 0; 


            foreach (sachdangmuonDTO sdm in Lsdm)
            {
                fl = 0;

                foreach (sachdatraDTO sdt in Lsdt)
                {
                    if (sdm.Masach== sdt.Masach )
                    {
                        fl = 1; 
                        if (sdm.Ngaymuon > sdt.Ngaytra )
                        {
                            masachLIST.Add(sdm.Masach);
                            ngaymuoncuasachList.Add(sdm.Ngaymuon);

                        }
                         
                    }

                  
                }
                if (fl == 0)
                {
                    masachLIST.Add(sdm.Masach);
                    ngaymuoncuasachList.Add(sdm.Ngaymuon);
                }
                


            }

            // gan list masach  dang muon vao list sachDTO 


            foreach ( int  masach in masachLIST)
            {
                 sachList.Add (thongtinSach(masach));
            }



            return true; 
        }

        // tim kiem doc gia theo ten 
        public bool timkiemsach(string field, string Searchstr, List<sachDTO> listSach)
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

            string query = string.Format("select * from [sach] where " + field + " like @" + field);
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@" + field, SqlDbType.NVarChar);
            param[0].Value = Convert.ToString("%" + Searchstr + "%");

            DataTable dtb = new DataTable();
            dtb = conn.excuteNonQuery(query, param);

            foreach (DataRow dr in dtb.Rows)
            {
                sachDTO sDTO = new sachDTO();

                sDTO.Masach = int.Parse(dr["masach"].ToString());
                sDTO.Tensach = dr["tensach"].ToString();
                sDTO.Theloai = dr["Theloai"].ToString();
                sDTO.Tacgia = dr["tacgia"].ToString();
                sDTO.Nxb = dr["nxb"].ToString();
                sDTO.Ngaynhap = DateTime.Parse(dr["ngaynhap"].ToString());
                sDTO.Ngayxb = DateTime.Parse(dr["ngayxb"].ToString());
                sDTO.Giatri = int.Parse(dr["giatri"].ToString());
                sDTO.Trangthai = int.Parse(dr["trangthai"].ToString());

                listSach.Add(sDTO);
            }


            if (dtb.Rows.Count > 0)
            {
                return true;
            }

            return false;

        }

    }
}
