using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public int KTThongTinThemKH(string soTKLK, DateTime ngayMoTK, string hoTen, DateTime ngaySinh, string ngheNghiep, string soCMNN, string diaChi, string email, string SDT)
        {
            Helper helper = new Helper();
            if (soTKLK == "")
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
            if (soCMNN == "")
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
            if (ngayMoTK.Year - ngaySinh.Year < 18)
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
    }
}
