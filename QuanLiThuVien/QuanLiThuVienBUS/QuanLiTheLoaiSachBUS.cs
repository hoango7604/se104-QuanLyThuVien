using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDAL;
using QuanLiThuVienDTO;

namespace QuanLiThuVienBUS
{
    public class QuanLiTheLoaiSachBUS
    {
        public  QuanLiTheLoaiSachBUS() { }

        /// <summary>
        /// Danh sách các loại sách
        /// </summary>
        /// <returns></returns>
        public List<loaisachDTO> LayDanhSachCacTheLoai()
        {
            cacloaisachDAL loaiSachDAL = new cacloaisachDAL();

            List<loaisachDTO> danhsachloaisach = new List<loaisachDTO>();

            if (loaiSachDAL.danhsachloaisach(danhsachloaisach))
            {
                return danhsachloaisach;
            }
            return new List<loaisachDTO>();
        }


        /// <summary>
        /// Thêm thể loại sách
        /// </summary>
        /// <param name="loaisach"></param>
        /// <returns></returns>
        public bool ThemTheLoaisach(loaisachDTO loaisach)
        {
            cacloaisachDAL loaisachDAL = new cacloaisachDAL();

            if (!loaisachDAL.themTheLoai(loaisach))
            {
                BUS_notification.mess = "Không thể thêm loại sách";
                return false;
            }
            return true;
        }
    }
}
