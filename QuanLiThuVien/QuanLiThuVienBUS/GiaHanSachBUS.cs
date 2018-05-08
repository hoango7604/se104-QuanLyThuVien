﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiThuVienDAL;
using QuanLiThuVienDTO;

namespace QuanLiThuVienBUS
{
    public class GiaHanSachBUS
    {
        public bool TaoThoigianmuonsach(int masach)
        {
            return true;
        }

        public bool GiaHan( int masach)
        {
            giahanDAL giahanDAL = new giahanDAL();
            quydinhDAL quydinhDAL = new quydinhDAL();

            giahanDTO giahanDTO = new giahanDTO();
            quydinhDTO quydinhDTO = new quydinhDTO();
            List<quydinhDTO> list = new List<quydinhDTO>();

            quydinhDAL.listquydinh(list);

            //kiểm tra điều kiện 
            int solangiahan = SoLanMuonSachHienTai(masach);
            if (solangiahan == -1)
            {
                //đã mess
                return false;
            }
            if (solangiahan == 2 )
            {
                BUS_notification.mess = "Đã gia hạn quá số lần cho phép";
                return false;
            }

            solangiahan++;

            giahanDTO.Solangiahan = solangiahan;
            giahanDTO.Masach = masach;

            //update số ngày cho phép mượn
            giahanDAL.sualangiahan(giahanDTO.Masach,giahanDTO);

            return true;

        }

        public bool XoaThoiGianMuonSach(int masach)
        {
            giahanDAL giahanDAL = new giahanDAL();
            giahanDTO giahanDTO = new giahanDTO();
            if (!giahanDAL.xoagiahan(masach))
            {
                BUS_notification.mess = "Không thể lấy số ngày sách đã mượn. Vui lòng kiểm tra Database  ";
                return false;
            }
            return true;
        }

        public int SoLanMuonSachHienTai(int masach)
        {
            giahanDAL giahanDAL = new giahanDAL();
            giahanDTO giahanDTO = new giahanDTO();
            if (!giahanDAL.laygiahancuasach(masach,giahanDTO))
            {
                BUS_notification.mess = "Không thể lấy số ngày sách đã mượn. Vui lòng kiểm tra Database ";
                return -1;
            }
            return giahanDTO.Solangiahan;
        }


    }
}
