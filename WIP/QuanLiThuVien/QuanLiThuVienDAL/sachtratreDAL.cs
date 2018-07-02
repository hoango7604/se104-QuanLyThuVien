using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dbConnection;

namespace QuanLiThuVienDAL
{
    public class sachtratreDAL
    {
        private dbconnection cn;
        public sachtratreDAL()
        {
            cn = new dbconnection();
        }
        public DataTable LayDSSachChuaTra(DateTime thangThongKe)
        {
            try
            {
                string SQL =string.Format("select s.tensach, pm.ngaymuon, DATEDIFF(day, pm.ngaymuon,GETDATE()) as songaytre from((sach s inner join ct_phieumuon ctpm on s.masach = ctpm.masach) inner join phieumuon pm on ctpm.mapm = pm.mapm) where (MONTH(pm.ngaymuon) = {0} and YEAR(pm.ngaymuon) = {1}) and s.masach not in  (select s1.masach from(sach s1 inner join ct_phieutra ctpt on s1.masach = ctpt.masach) inner join phieutra pt on ctpt.mapt = pt.mapt)", thangThongKe.Month, thangThongKe.Year);
                
                SqlDataAdapter da = new SqlDataAdapter(SQL, cn.openConnection());

                DataTable dt = new DataTable();

               

                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
