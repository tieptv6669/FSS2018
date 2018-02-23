using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

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

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int KTThongTinThemKH(string soTKLK, DateTime ngayMoTK, string hoTen, DateTime ngaySinh, string ngheNghiep, string soCMTNN, string diaChi, string email, string SDT)
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
            if (soCMTNN == "")
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
    }
}
