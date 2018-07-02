using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVienDTO
{
   public class phieuthutienDTO
    {

        public phieuthutienDTO(int maphieuthu, DateTime ngaythu , int tienthu , int mathe )

        {
            this.Maphieuthu = maphieuthu;
            this.Ngaythu = ngaythu;
            this.Tienthu = tienthu;
            this.Mathe = tienthu; 
        }

        public phieuthutienDTO()
        {

        }

        private int maphieuthu;

        public int Maphieuthu
        {
            get { return maphieuthu; }
            set { maphieuthu = value; }
        }
        private DateTime ngaythu;

        public DateTime Ngaythu
        {
            get { return ngaythu; }
            set { ngaythu = value; }
        }
        private int tienthu;

        public int Tienthu
        {
            get { return tienthu; }
            set { tienthu = value; }
        }
        private int mathe;

        public int Mathe
        {
            get { return mathe; }
            set { mathe = value; }
        } 


    }
}
