using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDAL;
using QuanLiThuVienDTO;

namespace QuanLiThuVienBUS
{
    public class quydinhBUS
    {
        public bool ListQuyDinh(quydinhDTO qdDTO)
        {
            try
            {
                quydinhDAL quydinhDAL = new quydinhDAL();
                return quydinhDAL.listquydinh(qdDTO);
            }
            catch
            {
                return false;
            }
        }

        public bool SuaQuyDinh(quydinhDTO qdDTO)
        {
            try
            {
                quydinhDAL quydinhDAL = new quydinhDAL();
                return quydinhDAL.suaQuyDinh(qdDTO);
            }
            catch
            {
                return false;
            }
        }
    }
}
