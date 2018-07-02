using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDAL;
namespace QuanLiThuVienBUS
{
    public class thongketheloaiBUS
    {
        cacloaisachDAL dalSachTraTre = new cacloaisachDAL();
        public DataTable layDSLoaiSachDuocQuanTam(DateTime thangThongKe)
        {
            DataTable dt = dalSachTraTre.LayDSLoaiSachDuocQuanTam(thangThongKe);
            if (dt == null)
            {
                return null;
            }
            else
            {
                dt.Columns["theloai"].ColumnName = "Thể Loại";
                dt.Columns["soluong"].ColumnName = "Số Lượt Mượn";
                return dt;
            }
        }
    }
}
