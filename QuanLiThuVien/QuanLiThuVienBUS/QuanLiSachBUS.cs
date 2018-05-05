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
        public QuanLiSachBUS()
        {

        }

        /// <summary>
        /// Đưa ra danh sách các sách khả dụng trong thư viện
        /// </summary>
        /// <returns></returns>
        public List<sachDTO> DanhSachSach()
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

            if (sDTO.Masach == -1 || sDTO.Masach == null)
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
                        if (sax.Masach == int.Parse(masach) && sax.Trangthai == (int)TrangThaiSach.CoSan)
                        {
                            result.Add(sax);
                            return result;
                        }
                    }
                }

            }

            if (tensach!="")
            {
                foreach (sachDTO sach in list)
                {
                    if ( sach.Trangthai == (int)TrangThaiSach.CoSan && Levenshtein_Distance.Distance(sach.Tensach,tensach) <= max_name_distance)
                    {
                        if (result.IndexOf(sach)==-1)
                        {
                            result.Add(sach);
                        }
                    }
                }
            }

            if (theloai != "")
            {
                foreach (sachDTO sach in list)
                {
                    if (sach.Trangthai == (int)TrangThaiSach.CoSan  && sach.Theloai == theloai)
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
                    if (sach.Trangthai == (int)TrangThaiSach.CoSan && Levenshtein_Distance.Distance(sach.Tacgia,tacgia)<=max_author_distance)
                    {
                        if (result.IndexOf(sach) == -1)
                        {
                            result.Add(sach);
                        }
                    }
                }
            }

            if (nhaxuatban != "")
            {
                foreach (sachDTO sach in list)
                {
                    if (sach.Trangthai == (int)TrangThaiSach.CoSan  && Levenshtein_Distance.Distance(sach.Nxb,nhaxuatban)<= max_publishcompany_distance)
                    {
                        if (result.IndexOf(sach)==-1)
                        {
                            result.Add(sach);
                        }
                    }
                }
            }

            if (result.Count == 0)
            {
                return list;
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
            List<quydinhDTO> listquydinh = new List<quydinhDTO>();
            if (!quydinh.listquydinh(listquydinh))
            {
                return false;
            }
            System.DateTime date = DateTime.Now;
            int curyear = date.Year;
            if (curyear - sDTO.Ngayxb.Year > listquydinh[0].Kcnamxuatban)
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
       
        public bool BaoMatSach(sachDTO sDTO)
        {
            return true;
        }
    }
}
