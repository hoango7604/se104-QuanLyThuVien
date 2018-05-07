using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDAL;
using QuanLiThuVienDTO;

namespace QuanLiThuVienBUS
{
    public class QuanLiMuonTraMatBUS
    {
        public enum MuonTraTag
        {
            Muon = 0,
            Tra = 1
        }

        public QuanLiMuonTraMatBUS()
        {

        }

        public bool BaoMatSach(docgiaDTO bandoc, sachDTO sach)
        {
            return true;
        }

        #region Mượn sách

        /// <summary>
        /// Mượn sách
        /// </summary>
        /// <param name="bandoc">bạn đọc mượn</param>
        /// <param name="sachs">danh sách sách mượn , thông tin đúng </param>
        /// <returns></returns>
        public bool MuonSach(docgiaDTO bandoc, List<sachDTO> sachs)
        {
            sachDAL sachDAL = new sachDAL();
            quydinhDAL quyDinhDAL = new quydinhDAL();
            phieumuonDAL phieuMuonDAL = new phieumuonDAL();
            ctpmDAL chiTietPhieuMuonDAL = new ctpmDAL();

            List<sachDTO> cacSachdangmuon = new List<sachDTO>();
            List<quydinhDTO> cacQuyDinh = new List<quydinhDTO>();
            List<phieumuonDTO> phieuMuon = new List<phieumuonDTO>();
            List<DateTime> danhsachngaymuon = new List<DateTime>();

            sachDAL.SachDangMuon(bandoc.MaThe,cacSachdangmuon, danhsachngaymuon);
            
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

        #endregion

        #region Trả sách


        /// <summary>
        /// Trả sách
        /// </summary>
        /// <param name="bandoc">Mã bạn đọc </param>
        /// <param name="sachs">danh sách các bạn đọc </param>
        /// <returns></returns>
        public List<ctptDTO> TraSach(docgiaDTO bandoc, List<sachDTO> sachtra)
        {
            docgiaDAL banDocDAL = new docgiaDAL();
            sachDAL sachDAL = new sachDAL();
            quydinhDAL quyDinhDAL = new quydinhDAL();
            phieutraDAL phieutraDAL = new phieutraDAL();
            ctptDAL ctptDAL = new ctptDAL();


            List<sachDTO> sachdangmuon = new List<sachDTO>();
            List<DateTime> danhsachngaymuonsach = new List<DateTime>();
            List<phieutraDTO> danhsachphieutra = new List<phieutraDTO>();
            List<ctptDTO> danhsachchitietphieutra = new List<ctptDTO>();

            sachDAL.SachDangMuon(bandoc.MaThe, sachdangmuon, danhsachngaymuonsach);
            phieutraDAL.danhsachPhieuTra(danhsachphieutra);

            phieutraDTO phieutra = new phieutraDTO();
            phieutra.Mapt = danhsachphieutra.Count + 1;
            phieutra.Mathe = bandoc.MaThe;
            phieutra.Ngaytra = DateTime.Now;

            int tienphatkinay = 0;

            foreach (sachDTO saxtra in sachtra )
            {
                /// kiễm tra quá hạn
                DateTime ngaymuonsach = LayDatetimeDcMuonCuaSach(saxtra.Masach, sachdangmuon, danhsachngaymuonsach);
                int songaydamuon = SoNgayMuon(ngaymuonsach, DateTime.Now);
                int tienphatsachnay = 0;
                if (songaydamuon > 14)
                {
                    tienphatsachnay = (songaydamuon - 14) * 5000;
                }
                tienphatkinay += tienphatsachnay;

                ///quẳng sách lại zô kho
                QuanLiSachBUS qlsachBUS = new QuanLiSachBUS();
                qlsachBUS.Travekho(saxtra);

                ///thêm chi tiết phiếu trả
                ctptDTO ctptra = new ctptDTO();
                ctptra.Mapt = phieutra.Mapt;
                ctptra.Masach = saxtra.Masach;
                ctptra.Songaydamuon = songaydamuon;
                ctptra.Tienphatsach = tienphatsachnay;

                ctptDAL.themCTPT(ctptra);
                danhsachchitietphieutra.Add(ctptra);
            }

            phieutra.Tienphatkinay = tienphatkinay;
            phieutraDAL.themPhieuTra(phieutra);

            ///thêm nợ vào bạn đọc
            bandoc.Tongtienno += tienphatkinay;
            banDocDAL.suaDocGia(bandoc, bandoc.MaThe);

            return danhsachchitietphieutra;

        }

        private DateTime LayDatetimeDcMuonCuaSach(int masach,List<sachDTO> listsach, List<DateTime> listtime)
        {
            for (int i = 0; i< listsach.Count; i++)
            {
                if (listsach[i].Masach == masach)
                {
                    return listtime[i];
                }
            }
            return DateTime.Now;
        }

        private int SoNgayMuon(DateTime ngaymuon, DateTime ngaytra)
        {
            TimeSpan tp = ngaytra.Subtract(ngaymuon);
            return (int)tp.TotalDays;
        }

        #endregion


        #region Mất sách

        public bool Matsach(docgiaDTO bandoc,sachDTO sachmat)
        {
            docgiaDAL BanDocDAL = new docgiaDAL();
            QuanLiSachBUS qlSachBuss = new QuanLiSachBUS();


            bandoc.Tongtienno += sachmat.Giatri;
            BanDocDAL.suaDocGia(bandoc, bandoc.MaThe);

            if (qlSachBuss.MatSach(sachmat))
            {
                return true;
            }
            BUS_notification.mess = "Lỗi khi báo mất sách";
            return false;
        }
        #endregion
    }
}
