using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDAL;

namespace QuanLiThuVienBUS
{
    public class sachtratreBUS
    {
        sachtratreDAL dalSachTraTre = new sachtratreDAL();
        public DataTable LayDSSachChuaTra(DateTime thangThongKe)
        {
            DataTable dt = dalSachTraTre.LayDSSachChuaTra(thangThongKe);
            if(dt == null)
            {
                return null;
            }
            else
            {
                dt.Columns["tensach"].ColumnName = "Tên Sách";
                dt.Columns["ngaymuon"].ColumnName = "Ngày Mượn";
                dt.Columns["songaytre"].ColumnName = "Số Ngày Trễ";

                return dt;
            }
        
            
        }
    }
}
