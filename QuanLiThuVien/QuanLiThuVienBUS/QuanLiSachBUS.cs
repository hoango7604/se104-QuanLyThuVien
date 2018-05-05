using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDTO;
using QuanLiThuVienDAL;

namespace QuanLiThuVienBUS
{
    public class QuanLiSachBUS
    {
        public QuanLiSachBUS()
        {

        }

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
                        if (sax.Masach == int.Parse(masach))
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
                    if (Levenshtein_Distance.Distance(sach.Tensach,tensach) <= max_name_distance)
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
                    if (Levenshtein_Distance.Distance(sach.Tacgia,tacgia)<=max_author_distance)
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
                    if (Levenshtein_Distance.Distance(sach.Nxb,nhaxuatban)<= max_publishcompany_distance)
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
            return saxDal.themSach(sDTO);
        }

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
       
    }
}
