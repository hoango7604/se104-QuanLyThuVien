using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDAL;
using QuanLiThuVienDTO;

namespace QuanLiThuVienBUS
{
    class QuanLiMuonTraMatBUS
    {
        public QuanLiMuonTraMatBUS()
        {

        }

        public bool BaoMatSach(docgiaDTO bandoc, sachDTO sach)
        {
            return true;
        }

        /// <summary>
        /// Mượn sách
        /// </summary>
        /// <param name="bandoc">bạn đọc mượn</param>
        /// <param name="sachs">danh sách sách mượn , thông tin đúng </param>
        /// <returns></returns>
        public bool MuonSach(docgiaDTO bandoc, List<sachDTO> sachs)
        {
            docgiaDAL banDocDAL = new docgiaDAL();
            quydinhDAL quyDinhDAL = new quydinhDAL();
            phieumuonDAL phieuMuonDAL = new phieumuonDAL();
            ctpmDAL chiTietPhieuMuonDAL = new ctpmDAL();

            List<sachDTO> cacSachdangmuon = new List<sachDTO>();
            List<quydinhDTO> cacQuyDinh = new List<quydinhDTO>();
            List<phieumuonDTO> phieuMuon = new List<phieumuonDTO>();

            //banDocDAL.SachDangMuon(bandoc.MaThe++,cacSachdangmuon);
            
            quyDinhDAL.listquydinh(cacQuyDinh);

            //kiểm tra số luọng sách mươn
            if (cacSachdangmuon.Count  + sachs.Count >  cacQuyDinh[0].Sosachduocmuon )
            {
                BUS_notification.mess = "Không Thể mượn sách vượt quá số lượng cho phép";
                return false;
            }

            //thêm phiếu mượn
            phieumuonDTO phieumuonDTO = new phieumuonDTO();
            phieumuonDTO.Mapm = phieuMuon.Count + 1;
            phieumuonDTO.Mathe = bandoc.MaThe;
            phieumuonDTO.Ngaymuon = DateTime.Now;
            if (!phieuMuonDAL.themPhieuMuon(phieumuonDTO))
            {
                BUS_notification.mess = "Không thể thêm phiếu mượn";
                return false;
            }

            foreach (sachDTO sach in sachs)
            {
                ctpmDTO ctpm = new ctpmDTO();
                ctpm.Mapm = phieumuonDTO.Mapm;
                ctpm.Masach = sach.Masach;
                if (!chiTietPhieuMuonDAL.themCTPM(ctpm))
                {
                    BUS_notification.mess = "Có sự cố trong khi mượn sách " + sach.Tensach;
                    return false;
                }
                else
                {
                    QuanLiSachBUS sachBUS = new QuanLiSachBUS();
                    sachBUS.MuonSach(sach);
                }
            }
            return true;


        }

        /// <summary>
        /// Trả sách
        /// </summary>
        /// <param name="bandoc">số </param>
        /// <param name="sachs"></param>
        /// <returns></returns>
        public bool TraSach(docgiaDTO bandoc, List<sachDTO> sachs)
        {

        }

    }
}
