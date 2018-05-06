using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
     public class cacloaidocgiaDTO
    {
        public cacloaidocgiaDTO()
        {

        }
        private int cacloai;

        public cacloaidocgiaDTO(int cacloai)
        {
            this.cacloai = cacloai;
        }

        public int Cacloai
        {
            get { return cacloai; }
            set { cacloai = value; }
        }

    }
}
