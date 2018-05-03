using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDTO;
using QuanLiThuVienDAL;

namespace QuanLiThuVienBUS
{
    class QuanLiSachBUS
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

        public List<sachDTO> TimSach(string masach,string tensach,string theloai,string tacgia)
        {
            List<sachDTO> list = new List<sachDTO>();
            List<sachDTO> result = new List<sachDTO>();
            int max_masach_distance = masach.Length / 2;
            int max_name_distance = tensach.Length / 2;
            int max_author_distance = tacgia.Length / 2;
            sachDAL saxDAL = new sachDAL();

            list = DanhSachSach();
            if (saxDAL.isSach(masach))
            {
                foreach (sachDTO sach in list)
                {
                    if (sach.Masach==Int32.Parse(masach))
                    {
                        result.Add(sach);
                    }
                }
            }
            else
            {
                if (masach != "")
                {
                    foreach(sachDTO sach in list)
                    {
                        if (Levenshtein_Distance.Distance(sach.Masach.ToString(),masach) <= max_masach_distance)
                        {
                            result.Add(sach);
                            list.Remove(sach);
                        }
                    }
                }

                if (tensach != "")
                {
                    foreach (sachDTO sach in list)
                    {
                        if (Levenshtein_Distance.Distance(sach.Tensach.ToString(), tensach) <= max_name_distance)
                        {
                            result.Add(sach);
                            list.Remove(sach);
                        }
                    }
                }

                if (theloai != "")
                {
                    foreach (sachDTO sach in list)
                    {
                        if (sach.Theloai == theloai)
                        {
                            result.Add(sach);
                            list.Remove(sach);
                        }
                    }
                }

                if (tacgia !="null")
                {
                    foreach (sachDTO sach in list)
                    {
                        if (Levenshtein_Distance.Distance(sach.Nxb.ToString(), tacgia) <= max_author_distance)
                        {
                            result.Add(sach);
                            list.Remove(sach);
                        }
                    }
                }
            }
            return result;
        }

        public bool ThemSach(sachDTO sDTO)
        {
            sachDAL saxDal = new sachDAL();
            if (saxDal.isSach(sDTO.Masach.ToString()))
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
            return saxDal.themSach(sDTO);
        }

        public bool SuaSach(sachDTO sach)
        {
            sachDAL saxDAL = new sachDAL();
            if (saxDAL.isSach(sach.Masach.ToString()))
            {
                return saxDAL.suaSach(sach, sach.Masach);
            }
            return false;
        }
       
    }
}
