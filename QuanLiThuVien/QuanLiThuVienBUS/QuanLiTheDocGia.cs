using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDTO;

namespace QuanLiThuVienBUS
{
    class QuanLiTheDocGia
    {
        /// <summary>
        /// Kiểm tra thông tin độc giả có tồn tại trong danh sách chưa ( kiểm tra thông qua MaThe )
        ///
        /// </summary>
        /// <param name="list"> Danh sách các độc giả có trong csdl </param>
        /// <param name="docgia"> Độc giả cần kiểm tra </param>
        /// <returns></returns>
        public bool KiemTraDaTonTai(List<TheDocGia> list, TheDocGia docgia)
        {
            foreach (TheDocGia tdg in list)
            {
                if (tdg.MaThe == docgia.MaThe)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
