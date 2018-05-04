using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDTO;
using QuanLiThuVienDAL;

namespace QuanLiThuVienBUS
{
    public class QuanLiBanDocBUS
    {
        const int MAX_LEVENSTEIN_DISTANCE = 10;

        public QuanLiBanDocBUS()
        {
            
        }
        /// <summary>
        /// Trả về sanh sách độc giả
        /// </summary>
        /// <returns></returns>
        public List<docgiaDTO> DanhSachDocGia()
        {
            List<docgiaDTO> list = new List<docgiaDTO>();
            docgiaDAL docgias = new docgiaDAL();
            if (docgias.danhsachDG(list))
            {
                return list;
            }
            return new List<docgiaDTO>();
        }

        /// <summary>
        /// Tìm đọc giả theo tên và số cmnd 
        /// </summary>
        /// <param name="cmnd"> Mã số cmnd </param>
        /// <param name="name"> Họ tên bạn đọc </param>
        /// <returns></returns>
        public List<docgiaDTO> TimDocGia(string cmnd,string name)
        {
            //cmnd = cmnd.Replace(" ", "");
            if (cmnd == null) cmnd = "";
            if (name == null) name = "";
            List<docgiaDTO> result = new List<docgiaDTO>();
            List<docgiaDTO> danhsach = this.DanhSachDocGia();
            docgiaDAL docgia = new docgiaDAL();
            if (docgia.isDocGia(int.Parse(cmnd)))
            {
                foreach (docgiaDTO dg in danhsach)
                {
                    if (dg.MaThe==Int32.Parse(cmnd))
                    {
                        result.Add(dg);
                    }
                }
                 
            }
            else
            {
                if (name=="")
                {
                    foreach (docgiaDTO dg in danhsach)
                    {
                        if (Levenshtein_Distance.Distance(cmnd, dg.MaThe.ToString()) <= MAX_LEVENSTEIN_DISTANCE/2)
                        {
                            result.Add(dg);
                        }
                    }
                }
                else
                {
                    foreach (docgiaDTO dg in danhsach)
                    {
                        if (Levenshtein_Distance.Distance(name, dg.HoTen) <= MAX_LEVENSTEIN_DISTANCE)
                        {
                            result.Add(dg);
                        }
                    }
                }
                
            }
            return result;

        }

        public bool ThemDocGia(docgiaDTO docgia)
        {
            docgiaDAL dgDAL = new docgiaDAL();
            if (dgDAL.isDocGia(docgia.MaThe))
            {
                return false;
            }
            return dgDAL.themDocGia(docgia);
        }

        public bool SuaDocGia(docgiaDTO docgia)
        {
            docgiaDAL dgDAL = new docgiaDAL();
            if (dgDAL.isDocGia(docgia.MaThe))
            {
                return dgDAL.suaDocGia(docgia, docgia.MaThe);
            }
            return false;
        }

        /// <summary>
        /// M thêm code vô đây
        /// </summary>
        /// <param name="docgia"></param>
        /// <returns></returns>
        public bool XoaDocGia(docgiaDTO docgia)
        {
            return false;
        }

     
    }
}
