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
        const int MAX_LEVENSTEIN_DISTANCE = 12;

        public static string[] LoaiDocGia = new string[3] { "Học sinh", "Sinh viên", "Người đi làm" };

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
        public List<docgiaDTO> TimDocGia(string cmnd, string name)
        {
            //cmnd = cmnd.Replace(" ", "");
            if (cmnd == null) cmnd = "";
            if (name == null) name = "";
            List<docgiaDTO> result = new List<docgiaDTO>();
            List<docgiaDTO> danhsach = this.DanhSachDocGia();
            docgiaDAL docgiaDAL = new docgiaDAL();

        
            if (cmnd != "")
            {
                if (docgiaDAL.isDocGia(int.Parse(cmnd)))
                {
                    foreach (docgiaDTO dg in danhsach)
                    {
                        if (dg.MaThe == int.Parse(cmnd))
                        {
                            result.Add(dg);
                            return result;
                        }
                    }
                }
                else
                { 

                    foreach (docgiaDTO dg in danhsach)
                    {
                        if (Levenshtein_Distance.Distance(dg.MaThe.ToString(), cmnd) <= (MAX_LEVENSTEIN_DISTANCE / 2))
                        {
                            if (result.IndexOf(dg) == -1)
                            {
                                result.Add(dg);
                            }

                        }
                    }
                }

            }

            if (name != "")
            {
                List<ResultItem> item = new List<ResultItem>();
                foreach (docgiaDTO dg in danhsach)
                {
                    int check = TimKiemBUS.CheckisAvaiable(name, dg.HoTen);
                    if (check!= -1)
                    {
                        ResultItem rItem;
                        rItem.mark = check;
                        rItem.docgia = dg;
                        item.Add(rItem);
                    }
                }
                item.Sort((s1,s2)=> s1.mark.CompareTo(s2.mark));
                foreach (ResultItem i in item)
                {
                    result.Add(i.docgia);
                }
            }

            return result;


        }

        /// <summary>
        /// Thêm đọc giả
        /// </summary>
        /// <param name="docgia"></param>
        /// <returns></returns>
        public bool ThemDocGia(docgiaDTO docgia)
        {
            docgiaDAL dgDAL = new docgiaDAL();
            if (dgDAL.isDocGia(docgia.MaThe))
            {
                BUS_notification.mess = "Đã tạo thẻ với số CMND này. Vui lòng chọn số CMND khác";
                return false;
            }
            return dgDAL.themDocGia(docgia);
        }

        /// <summary>
        /// Sửa Đọc Giả 
        /// </summary>
        /// <param name="docgia"></param>
        /// <returns></returns>
        public bool SuaDocGia(docgiaDTO docgia)
        {
            docgiaDAL dgDAL = new docgiaDAL();
            if (dgDAL.isDocGia(docgia.MaThe))
            {
                return dgDAL.suaDocGia(docgia, docgia.MaThe);
            }
            BUS_notification.mess = "Không tồn tại mã thẻ";
            return false;
        }
         
        /// <summary>
        /// M thêm code vô đây
        /// , rep :ok gái
        /// </summary>
        /// <param name="docgia"></param>
        /// <returns></returns>
        public bool XoaDocGia(docgiaDTO docgia)
        {
            docgiaDAL doxgiaDAL = new docgiaDAL();
            if (!doxgiaDAL.isDocGia(docgia.MaThe))
            {
                BUS_notification.mess = "Không tồn tại mã thẻ";
                return false;
            }

            return doxgiaDAL.xoaDocGia(docgia.MaThe);
        }
         
        /// <summary>
        /// Trả về cac loại đọc giả
        /// </summary>
        /// <returns></returns>
        public List<loaidocgiaDTO> CacLoaiDocGia()
        {
            List<loaidocgiaDTO> list = new List<loaidocgiaDTO>();
            cacloaidocgiaDAL docgiasDAL = new cacloaidocgiaDAL();
            if (docgiasDAL.danhsachLoaiDG(list))
            {
                return list; 
            }
            return new List<loaidocgiaDTO>();
        }


        private struct ResultItem
        {
            public int mark;
            public docgiaDTO docgia;
        }
    }

}
