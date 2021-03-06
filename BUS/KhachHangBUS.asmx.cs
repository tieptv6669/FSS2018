﻿using System;
using System.Collections.Generic;
using System.Web.Services;
using Newtonsoft.Json;
using DAO;
using DTO;

namespace BUS
{
    /// <summary>
    /// Summary description for KhachHangBUS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KhachHangBUS : System.Web.Services.WebService
    {

        /// <summary>
        /// Kiểm tra thông tin thêm khách hàng
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <param name="ngayMoTK"></param>
        /// <param name="hoTen"></param>
        /// <param name="ngaySinh"></param>
        /// <param name="ngheNghiep"></param>
        /// <param name="soCMNN"></param>
        /// <param name="diaChi"></param>
        /// <param name="email"></param>
        /// <param name="SDT"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinThemKH(string soTKLK, DateTime ngayMoTK, string hoTen, DateTime ngaySinh, string ngheNghiep, string soCMND, string diaChi, string email, string SDT, string ghiChu)
        {
            DateTime ngayDu18Tuoi = ngaySinh.AddYears(18);
            Helper helper = new Helper();
            if (soTKLK.Length == 4)
            {
                return 1;
            }
            if (hoTen == "")
            {
                return 2;
            }
            if (ngheNghiep == "")
            {
                return 3;
            }
            if (soCMND == "")
            {
                return 4;
            }
            if (diaChi == "")
            {
                return 5;
            }
            if (email == "")
            {
                return 6;
            }
            if (SDT == "")
            {
                return 7;
            }
            if (ngayMoTK < ngayDu18Tuoi)
            {
                return 8;
            }
            if (helper.ChiChuaChuCai(hoTen) == false)
            {
                return 9;
            }
            if (helper.ChiChuaChuCai(ngheNghiep) == false)
            {
                return 10;
            }
            if (!helper.ChiChuaChuSo(soCMND))
            {
                return 11;
            }
            if(!helper.ChiChuaChuSo(SDT))
            {
                return 12;
            }
            if(KhachHangDAO.layMotKhachHang(soTKLK) != null)
            {
                return 13;
            }
            if(soTKLK.Length != 10 || !helper.ChiChuaChuSo(soTKLK.Substring(4, 6)))
            {
                return 14;
            }
            if(KhachHangDAO.GetKhachHang(soCMND) != null)
            {
                return 15;
            }
            if(hoTen.Length > 50 || ngheNghiep.Length > 50 || soCMND.Length > 12 || SDT.Length > 11 || email.Length > 50 || diaChi.Length > 50 || ghiChu.Length > 100)
            {
                return 16;
            }
            return 0;
        }

        /// <summary>
        /// Kiểm tra thông tin sửa KH
        /// </summary>
        /// <param name="ngayMoTK"></param>
        /// <param name="hoTenKH"></param>
        /// <param name="ngaySinh"></param>
        /// <param name="ngheNghiep"></param>
        /// <param name="soCMND"></param>
        /// <param name="diaChi"></param>
        /// <param name="email"></param>
        /// <param name="sdt"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinSuaKH(DateTime ngayMoTK, string hoTenKH, DateTime ngaySinh, string ngheNghiep, string soCMND, string soCMNDCu, string diaChi, string email, string sdt, string ghiChu)
        {
            DateTime ngayDu18Tuoi = ngaySinh.AddYears(18);
            Helper helper = new Helper();
            if(hoTenKH == "")
            {
                return 2;
            }
            if(ngheNghiep == "")
            {
                return 3;
            }
            if(soCMND == "")
            {
                return 4;
            }
            if(diaChi == "")
            {
                return 5;
            }
            if(email == "")
            {
                return 6;
            }
            if(sdt == "")
            {
                return 7;
            }
            if(ngayMoTK < ngayDu18Tuoi)
            {
                return 8;
            }
            if (!helper.ChiChuaChuCai(hoTenKH))
            {
                return 9;
            }
            if (!helper.ChiChuaChuCai(ngheNghiep))
            {
                return 10;
            }
            if (!helper.ChiChuaChuSo(sdt))
            {
                return 11;
            }
            if (!helper.ChiChuaChuSo(soCMND))
            {
                return 12;
            }
            if(hoTenKH.Length > 50 || ngheNghiep.Length > 50 || soCMND.Length > 12 || diaChi.Length > 50 || sdt.Length > 11 || email.Length > 50 || ghiChu.Length > 100)
            {
                return 13;
            }
            if(KhachHangDAO.GetKhachHang(soCMND) != null && soCMND != soCMNDCu)
            {
                return 14;
            }
            return 0;
        }

        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string layDSKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();
            list = KhachHangDAO.layDSKhachHang();

            if (list != null)
            {
                string jsonData = JsonConvert.SerializeObject(list);
                return jsonData;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Lấy ra một khách hàng khi biết số TKLK
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <returns></returns>
        [WebMethod]
        public string layMotKhachHang(string soTKLK)
        {
            KhachHang khachHang = KhachHangDAO.layMotKhachHang(soTKLK);
            string jsonData = JsonConvert.SerializeObject(khachHang);
            return jsonData;
        }

        /// <summary>
        /// Lấy ra một khách hàng khi biết số cmnd
        /// </summary>
        /// <param name="soCMND"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetKH(string soCMND)
        {
            KhachHang khachHang = KhachHangDAO.GetKhachHang(soCMND);
            string jsonData = JsonConvert.SerializeObject(khachHang);
            return jsonData;
        }

        /// <summary>
        /// Tìm kiếm khách hàng
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <param name="hoTenKH"></param>
        /// <param name="soCMND"></param>
        /// <returns></returns>
        [WebMethod]
        public string TimKiemKH(string soTKLK, string hoTenKH, string soCMND)
        {
            List<KhachHang> list = KhachHangDAO.TimKiemKH(soTKLK, hoTenKH, soCMND);
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <param name="hoTenKH"></param>
        /// <param name="loaiKH"></param>
        /// <param name="ngaySinhKH"></param>
        /// <param name="gioiTinhKH"></param>
        /// <param name="ngheNghiep"></param>
        /// <param name="soCMND"></param>
        /// <param name="diaChiKH"></param>
        /// <param name="emailKH"></param>
        /// <param name="SDT"></param>
        /// <param name="ghiChu"></param>
        /// <returns></returns>
        [WebMethod]
        public bool suaThongTinKH(string soTKLK, string hoTenKH, string loaiKH, DateTime ngaySinhKH, string gioiTinhKH, string ngheNghiep, string soCMND, string diaChiKH, string emailKH, string SDT, string ghiChu)
        {
            return KhachHangDAO.suaThongTinKH(soTKLK, hoTenKH, loaiKH, ngaySinhKH, gioiTinhKH, ngheNghiep, soCMND, diaChiKH, emailKH, SDT, ghiChu);
        }

        /// <summary>
        /// Thêm khách hàng
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ThemKH(string jsonData)
        {
            KhachHang khachHang = new KhachHang();
            khachHang = JsonConvert.DeserializeObject<KhachHang>(jsonData);
            return KhachHangDAO.ThemKH(khachHang);
        }

        /// <summary>
        /// Lấy KH khi biết ID khách hàng
        /// </summary>
        /// <param name="idKH"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetKHWithID(int idKH)
        {
            return JsonConvert.SerializeObject(KhachHangDAO.GetKhachHang(idKH));
        }
    }
}
