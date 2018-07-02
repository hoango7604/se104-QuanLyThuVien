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
    public class cacloaisachDAL
    {
        private dbConnection.dbconnection conn;

        public cacloaisachDAL()
        {
            conn = new dbconnection();
        }

        public bool danhsachloaisach(List<loaisachDTO> list)
        {
            string query = string.Format("select* from [cacloaisach] order by loaisach  asc ");
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
                loaisachDTO loaisach = new loaisachDTO();

                loaisach.Theloaisach = dr["loaisach"].ToString();

                list.Add(loaisach);
            }

            return true;
        }

        public DataTable LayDSLoaiSachDuocQuanTam(DateTime thangThongKe)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = string.Format("select s.theloai, COUNT(*) as SoLuong from(phieumuon pm inner join ct_phieumuon ctpm on pm.mapm = ctpm.mapm) inner join sach s on s.masach = ctpm.masach where MONTH(pm.ngaymuon) = {0} and YEAR(pm.ngaymuon) = {1} group by(s.theloai) order by SoLuong desc ", thangThongKe.Month, thangThongKe.Year);
                SqlDataAdapter da = new SqlDataAdapter(query, conn.openConnection());
              
                da.Fill(dt);


                return dt;
            }
            catch
            {
                return null;
            }
        }
         
        
        public bool themTheLoai (loaisachDTO lsDTO)
        {


            string query = string.Format("insert into [cacloaisach] values (@loaisach)");
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@loaisach", SqlDbType.NVarChar);
            param[0].Value = Convert.ToString(lsDTO.Theloaisach);

            conn.excuteNonQuery2(query, param);


            return true;


        }
    }
}
