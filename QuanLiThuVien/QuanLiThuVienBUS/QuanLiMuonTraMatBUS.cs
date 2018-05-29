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
            quydinhDTO cacQuyDinh = new quydinhDTO();
            List<phieumuonDTO> danhsachphieuMuon = new List<phieumuonDTO>();
            List<DateTime> danhsachngaymuon = new List<DateTime>();

            sachDAL.SachDangMuon(bandoc.MaThe,cacSachdangmuon, danhsachngaymuon);
            
            quyDinhDAL.listquydinh(cacQuyDinh);
            phieuMuonDAL.danhsachPM(danhsachphieuMuon);

            //kiểm tra số luọng sách mươn
            if (cacSachdangmuon.Count  + sachs.Count >  cacQuyDinh.Sosachduocmuon )
            {
                BUS_notification.mess = "Không thể mượn sách vượt quá số lượng cho phép";
                return false;
            }

            //thêm phiếu mượn
            phieumuonDTO phieumuonDTO = new phieumuonDTO();
            phieumuonDTO.Mapm = danhsachphieuMuon.Count + 1;
            phieumuonDTO.Mathe = bandoc.MaThe;
            phieumuonDTO.Ngaymuon = DateTime.Now;
            if (!phieuMuonDAL.themPhieuMuon(phieumuonDTO))
            {
                BUS_notification.mess = "Không thể thêm phiếu mượn";
                return false;
            }

            //thêm chi tiết phiếu mượn
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

                //thêm vao bang gia han cho sach 
                GiaHanSachBUS ghsax = new GiaHanSachBUS();
                ghsax.TaoSoLanmuonsach(sach.Masach);

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
            giahanDAL giaHanDAL = new giahanDAL();

            List<sachDTO> sachdangmuon = new List<sachDTO>();
            List<DateTime> danhsachngaymuonsach = new List<DateTime>();
            List<phieutraDTO> danhsachphieutra = new List<phieutraDTO>();
            List<ctptDTO> danhsachchitietphieutra = new List<ctptDTO>();
            quydinhDTO danhsachquydinh = new quydinhDTO();

            quydinhDTO quydinh = new quydinhDTO();

            quyDinhDAL.listquydinh(danhsachquydinh);
            quydinh = danhsachquydinh;

            sachDAL.SachDangMuon(bandoc.MaThe, sachdangmuon, danhsachngaymuonsach);
            phieutraDAL.danhsachPhieuTra(danhsachphieutra);

        

            //Thêm phiếu trả
            phieutraDTO phieutra = new phieutraDTO();
            phieutra.Mapt = danhsachphieutra.Count + 1;
            phieutra.Mathe = bandoc.MaThe;
            phieutra.Ngaytra = DateTime.Now;
            phieutra.Tienphatkinay = 0;
            phieutraDAL.themPhieuTra(phieutra);

            int tienphatkinay = 0;

            foreach (sachDTO saxtra in sachtra )
            {
                giahanDTO giaHanDTO = new giahanDTO();
                giaHanDAL.laygiahancuasach(saxtra.Masach, giaHanDTO);


                // kiễm tra quá hạn , tính tiền phạt khi trễ, mất sách
                DateTime ngaymuonsach = LayDatetimeDcMuonCuaSach(saxtra.Masach, sachdangmuon, danhsachngaymuonsach);
                int songaydamuon = SoNgayMuon(ngaymuonsach, DateTime.Now);
                int tienphatsachnay = 0;

                if (saxtra.Trangthai == (int)TrangThaiSach.DaMat)
                {
                    tienphatsachnay = saxtra.Giatri;
                }
             
                if (songaydamuon > quydinh.Songayduocmuon + giaHanDTO.Solangiahan * 7)
                {
                    tienphatsachnay = (songaydamuon - (quydinh.Songayduocmuon + giaHanDTO.Solangiahan * 7)) * quydinh.Tienphattrasachtremoingay;
                }
                tienphatkinay += tienphatsachnay;


                //thêm chi tiết phiếu trả
                 ctptDTO ctptra = new ctptDTO();
                ctptra.Mapt = phieutra.Mapt;
                ctptra.Masach = saxtra.Masach;
                ctptra.Songaydamuon = songaydamuon;
                ctptra.Tienphatsach = tienphatsachnay;

                ctptDAL.themCTPT(ctptra);
                danhsachchitietphieutra.Add(ctptra);

                //quẳng sách lại zô kho
                QuanLiSachBUS qlsachBUS = new QuanLiSachBUS();
                if (saxtra.Trangthai != (int)TrangThaiSach.DaMat)
                {
                    qlsachBUS.Travekho(saxtra);
                }
                else qlsachBUS.MatSach(saxtra);


                //xóa ngày cho phép giữ sách
                GiaHanSachBUS ghsax = new GiaHanSachBUS();
                ghsax.XoaSoLanMuonSach(saxtra.Masach);
            }

            //sửa thông tin phiếu trả
            phieutra.Tienphatkinay = tienphatkinay;
            phieutraDAL.suaPhieuTra(phieutra);
          

            //thêm nợ vào bạn đọc
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


    }
}
