using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDTO;
using QuanLiThuVienDAL;

namespace QuanLiThuVienBUS
{
    public enum TrangThaiSach
    {
        DaChoMuon = 0,
        CoSan = 1,
        DaMat = 2
    }

    public class QuanLiSachBUS
    {
        public static string[] DanhSachTrangThaiSach = new string[3] { "Đang cho mượn", "Có sẵn", "Đã mất"};

        public QuanLiSachBUS()
        {

        }

        /// <summary>
        /// Đưa ra danh sách các sách khả dụng trong thư viện
        /// </summary>
        /// <returns></returns>
         public List<sachDTO> DanhSachSachCoSan()
        {
            List<sachDTO> list = new List<sachDTO>();
            List<sachDTO> result = new List<sachDTO>();
            sachDAL saxDAL = new sachDAL();
            if (saxDAL.tatcaSach(list))
            {
                foreach (sachDTO sax in list)
                {
                    if (sax.Trangthai == (int)TrangThaiSach.CoSan)
                    {
                        result.Add(sax);
                    }
                }

                return result;
            }  
            return new List<sachDTO>();
        }

        /// <summary>
        /// Đưa ra danh sách sách bao gồm cả sách không khả dụng
        /// </summary>
        /// <returns></returns>
        public List<sachDTO> DanhSachSach()
        {
            List<sachDTO> list = new List<sachDTO>();
            sachDAL saxDAL = new sachDAL();
            if (saxDAL.tatcaSach(list))
            {
                return list;
            }
            return new List<sachDTO>();
        }

        /// <summary>
        /// Lấy thông tin sách theo mã
        /// </summary>
        /// <param name="Masach"></param>
        /// <returns></returns>
        public sachDTO Timsachtheoma(int Masach)
        {
            List<sachDTO> list = DanhSachSach();
            foreach (sachDTO sach in list)
            {
                if (sach.Masach == Masach)
                {
                    return sach;
                }
            }
            return new sachDTO();
        }

        /// <summary>
        /// Tìm sách có sặn trong thư viện
        /// </summary>
        /// <param name="sDTO"></param>
        /// <returns></returns>
        public List<sachDTO> TimSach(sachDTO sDTO)
        {
            List<sachDTO> list = new List<sachDTO>();
            List<sachDTO> result = new List<sachDTO>();
           
            string tensach = sDTO.Tensach; 
            string theloai = sDTO.Theloai;
            string tacgia = sDTO.Tacgia;
            string nhaxuatban = sDTO.Nxb;
            string masach;

            if (sDTO.Masach == -1)
            {
                masach = "";
            }
            else masach = sDTO.Masach.ToString();
            if (tensach == null) tensach = "";
            if (theloai == null) theloai = "";
            if (tacgia == null) tacgia = "";
            if (nhaxuatban == null) nhaxuatban = "";    

            int max_masach_distance = masach.ToString().Length / 2;
            int max_name_distance = tensach.Length / 2;
            int max_author_distance = tacgia.Length / 2;
            int max_publishcompany_distance = nhaxuatban.Length / 2;

            sachDAL saxDAL = new sachDAL();
            sachDTO temp = new sachDTO();
            list = DanhSachSach();

            //if(masach != "")
            //if (saxDAL.isSach(sDTO.Masach,ref temp))
            //{
            //    result.Add(temp);
            //}

            if (masach != "")
            {
                if (saxDAL.isSach(sDTO.Masach))
                {
                    foreach (sachDTO sax in list)
                    {
                        if (sax.Masach == int.Parse(masach) )
                        {
                            result.Add(sax);
                            return result;
                        }
                    }
                }

            }

            if (tensach!="")
            {
                List<ResultItem> item = new List<ResultItem>();
                foreach (sachDTO sa in list)
                {
                    int check = TimKiemBUS.CheckisAvaiable(tensach,sa.Tensach);
                    if (check != -1)
                    {
                        ResultItem rItem;
                        rItem.mark = check;
                        rItem.sach = sa;
                        item.Add(rItem);
                    }
                }
                item.Sort((s1, s2) => s1.mark.CompareTo(s2.mark));
                foreach (ResultItem i in item)
                {
                    result.Add(i.sach);
                }
            }

            if (theloai != "")
            {
                foreach (sachDTO sach in list)
                {
                    if (sach.Theloai == theloai)
                    {
                        if (result.IndexOf(sach) == -1)
                        {
                            result.Add(sach);
                        }
                    }
                }

            }

            if (tacgia != "")
            {
                foreach (sachDTO sach in list)
                {
                    if (TimKiemBUS.CheckisAvaiable(tacgia,sach.Tacgia)!= -1)
                    {
                        if (result.IndexOf(sach) == -1)
                        {
                            result.Add(sach);
                        }
                    }
                }
            }

            if (nhaxuatban != "" )
            {
                foreach (sachDTO sach in list)
                {
                    if (Levenshtein_Distance.Distance(sach.Nxb, nhaxuatban) <= sach.Nxb.Length)
                    {
                        if (result.IndexOf(sach) == -1)
                        {
                            result.Add(sach);
                        }
                    }
                }

            }

            
            return result;
        }

        /// <summary>
        /// Thêm sách mới
        /// </summary>
        /// <param name="sDTO"></param>
        /// <returns></returns> 
        public bool ThemSach(sachDTO sDTO)
        {
            sachDAL saxDal = new sachDAL();

            //kiểm tra các điều kiện
            if (saxDal.isSach(sDTO.Masach))
            {
                return false;
            }
            quydinhDAL quydinh = new quydinhDAL();
            quydinhDTO listquydinh = new quydinhDTO();
            if (!quydinh.listquydinh(listquydinh))
            {
                return false;
            }
            System.DateTime date = DateTime.Now;
            int curyear = date.Year;
            if (curyear - sDTO.Ngayxb.Year > listquydinh.Kcnamxuatban)
            {
                return false;
            }

            //tạo 
            List<sachDTO> list = new List<sachDTO>() ;
            if (!saxDal.tatcaSach(list))
            {
                return false;
            }

            // sDTO.Masach = list.Count + 1;
            sDTO.Trangthai = 1;
            return saxDal.themSach(sDTO);
        }

        /// <summary>
        /// Sửa thông tin sách
        /// </summary>
        /// <param name="sach"></param>
        /// <returns></returns>
        public bool SuaSach(sachDTO sach)
        {
            sachDAL saxDAL = new sachDAL();
            if (saxDAL.isSach(sach.Masach))
            {
                return saxDAL.suaSach(sach, sach.Masach);
            }
            return false;
        }

        /// <summary>
        /// M thêm code vô đây
        /// </summary>
        /// <param name="sDTO"></param>
        /// <returns></returns>
        public bool XoaSach(sachDTO sDTO)
        {
            return false;
        }

        /// Danh sách các tựa sách mà đọc giả đang lượng
        /// </summary>
        /// <param name="docgia"></param>
        /// <returns></returns>
        public List<sachDTO> DanhSachDocGiaDangMuon(docgiaDTO docgia, List<DateTime> listngaymuon)
        {
            docgiaDAL docGiaDAL = new docgiaDAL();
            sachDAL saxDAL = new sachDAL();

            List<sachDTO> listsach = new List<sachDTO>();
            //List<DateTime> listngaymuon = new List<DateTime>();

            if (!docGiaDAL.isDocGia(docgia.MaThe))
            {
                BUS_notification.mess = "Không tồn tại đọc giả";
                return new List<sachDTO>();
            }

            if (!saxDAL.SachDangMuon(docgia.MaThe, listsach, listngaymuon))
            {
                return new List<sachDTO>();
            }
            return listsach;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////// Khu vực Internal ///////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////

        #region Internal

        /// <summary>
        /// cập nhật thông tin cho sách đã mất
        /// </summary>
        /// <param name="sDTO"></param>
        /// <returns></returns>
        internal bool MatSach(sachDTO sDTO)
        {
            sachDAL saxDAL = new sachDAL();
            if (saxDAL.isSach(sDTO.Masach))
            {
                sDTO.Trangthai = (int)TrangThaiSach.DaMat;
                return SuaSach(sDTO);
            }

            return false;
        }

        /// <summary>
        /// Cập nhật thông tin cho sách đã mượn
        /// </summary>
        /// <param name="sDTO"></param>
        /// <returns></returns>
        internal bool MuonSach(sachDTO sDTO)
        {
            sachDAL saxDAL = new sachDAL();
            if (saxDAL.isSach(sDTO.Masach))
            {
                sDTO.Trangthai = (int)TrangThaiSach.DaChoMuon;
                return SuaSach(sDTO);
            }
             
            return false;
        }

        /// <summary>
        /// Cập nhật thông tin cho sách đã trả về kho
        /// </summary>
        /// <param name="sDTO"></param>
        /// <returns></returns>
        internal bool Travekho(sachDTO sDTO)
        {
            sachDAL saxDAL = new sachDAL();
            if (saxDAL.isSach(sDTO.Masach))
            {
                sDTO.Trangthai = (int)TrangThaiSach.CoSan;
                return SuaSach(sDTO);
            }

            return false;
        }

        /// <summary>

        #endregion

        private struct ResultItem
        {
            public  int mark;
            public  sachDTO sach;
        }
    }
}
