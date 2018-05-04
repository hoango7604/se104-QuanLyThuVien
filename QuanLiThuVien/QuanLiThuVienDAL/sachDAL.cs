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
            sachDTO sDTO = new sachDTO();
            parm[0] = new SqlParameter("@masach", SqlDbType.Int);
            parm[0].Value = Convert.ToString(sDTO.Masach);
            DataTable datatable = new DataTable();
            datatable = conn.excuteNonQuery(query, parm);

            //gan value trong datatable vao DTO 

            foreach (DataRow dr in datatable.Rows)
            {
                //sachDTO sDTO = new sachDTO();

                sDTO = new sachDTO();
                sDTO.Masach= int.Parse( dr["masach"].ToString());
                sDTO.Tensach = dr["tensach"].ToString();
                sDTO.Theloai = dr["theloai"].ToString();
                sDTO.Nxb = dr["nxb"].ToString();
                sDTO.Ngaynhap = DateTime.Parse(dr["ngaynhap"].ToString());
                sDTO.Ngayxb =DateTime.Parse(dr["ngayxb"].ToString());
                sDTO.Giatri = int.Parse(dr["giatri"].ToString());
                sDTO.Trangthai = int.Parse(dr["trangthai"].ToString());
                sDTO.Tacgia = dr["tacgia"].ToString();
                lsachDTO.Add(sDTO);
            }
        




           return true; 

       }
      
      // them sach

       public bool themSach(sachDTO sDTO)
       {
            string query = string.Format("insert into [sach] value (@masach,@tensach,@theloai,@nxb,@ngayxb,@giatri,@trangthai,@tacgia)");
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@masach", SqlDbType.Int);
            param[0].Value = Convert.ToString(sDTO.Masach);
            param[1] = new SqlParameter("@tensach", SqlDbType.NVarChar);
            param[1].Value = Convert.ToString(sDTO.Tensach);
            param[2] = new SqlParameter("@theloai", SqlDbType.VarChar);
            param[2].Value = Convert.ToString(sDTO.Theloai);
            param[3] = new SqlParameter("@nxb", SqlDbType.NVarChar);
            param[3].Value = Convert.ToString(sDTO.Nxb);
            param[4] = new SqlParameter("@ngaynhap", SqlDbType.DateTime);
            param[4].Value = Convert.ToString(sDTO.Ngaynhap);
            param[5] = new SqlParameter("@ngayxb", SqlDbType.DateTime);
            param[5].Value = Convert.ToString(sDTO.Ngayxb);
            param[6] = new SqlParameter("@giatri", SqlDbType.Int);
            param[6].Value = Convert.ToString(sDTO.Giatri);
            param[7] = new SqlParameter("@trangthai", SqlDbType.Int);
            param[7].Value = Convert.ToString(sDTO.Trangthai);
            param[8] = new SqlParameter("@tacgia", SqlDbType.NVarChar);
            param[8].Value = Convert.ToString(sDTO.Tacgia);

            conn.excuteNonQuery(query, param);

            return true;
       
       }

      // update sach 
       public bool suaSach(sachDTO sDTO, int masach)
       {
            string query = string.Format("  update [sach] set  tensach=@tensach,tensach=@tensach,nxb=@nxb,ngayxb=@ngayxb,giatri=@giatri,trangthai=@trangthai,tacgia=@tacgia where mathe=@masach ");
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@masach", SqlDbType.Int);
            param[0].Value = Convert.ToString(sDTO.Masach);
            param[1] = new SqlParameter("@tensach", SqlDbType.NVarChar);
            param[1].Value = Convert.ToString(sDTO.Tensach);
            param[2] = new SqlParameter("@theloai", SqlDbType.VarChar);
            param[2].Value = Convert.ToString(sDTO.Theloai);
            param[3] = new SqlParameter("@nxb", SqlDbType.NVarChar);
            param[3].Value = Convert.ToString(sDTO.Nxb);
            param[4] = new SqlParameter("@ngaynhap", SqlDbType.DateTime);
            param[4].Value = Convert.ToString(sDTO.Ngaynhap);
            param[5] = new SqlParameter("@ngayxb", SqlDbType.DateTime);
            param[5].Value = Convert.ToString(sDTO.Ngayxb);
            param[6] = new SqlParameter("@giatri", SqlDbType.Int);
            param[6].Value = Convert.ToString(sDTO.Giatri);
            param[7] = new SqlParameter("@trangthai", SqlDbType.Int);
            param[7].Value = Convert.ToString(sDTO.Trangthai);
            param[8] = new SqlParameter("@tacgia", SqlDbType.NVarChar);
            param[8].Value = Convert.ToString(sDTO.Tacgia);



            conn.excuteNonQuery(query, param);


            return true; 
       
       }

        // kiem tra ma sach co ton tai trong db hay khong
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

        public bool isSach(int masach, ref sachDTO sDTO)
        {

            string query = string.Format("select * from [sach] where masach=@masach");
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@masach", SqlDbType.Int);
            param[0].Value = masach;

            DataTable dtb = new DataTable();
            dtb = conn.excuteNonQuery(query, param);
            if (dtb.Rows.Count > 0)
            {
                DataRow dr = dtb.Rows[0];
                sDTO.Masach = int.Parse(dr["mathe"].ToString());
                sDTO.Tensach = dr["tensach "].ToString();
                sDTO.Theloai = dr["Theloai"].ToString();
                sDTO.Nxb = dr["nxb"].ToString();
                sDTO.Ngayxb = DateTime.Parse(dr["ngayxb"].ToString());
                sDTO.Giatri = int.Parse(dr["giatri"].ToString());
                sDTO.Trangthai = int.Parse(dr["trangthai"].ToString());
                sDTO.Tacgia = dr["tacgia"].ToString();

                return true;
            }
            return false;

        }
    }
}
