using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using DAO;
using DTO;

/// <summary>
/// Viết Tiệp
/// 12/02/2018
/// </summary>
namespace BUS
{
    /// <summary>
    /// Summary description for NguoiDungBUS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NguoiDungBUS : System.Web.Services.WebService
    {
        /// <summary>
        /// Xác thực form đăng nhập
        /// </summary>
        /// <param name="tenDangNhap"></param>
        /// <param name="matKhau"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinDangNhap(string tenDangNhap, string matKhau)
        {
            if (tenDangNhap == "")
            {
                return 1;
            }
            if (matKhau == "")
            {
                return 2;
            }

            return 0;
        }

        /// <summary>
        /// Kiểm tra tên đăng nhập & mật khẩu hợp lệ
        /// Lấy dữ liệu người dùng
        /// </summary>
        /// <param name="tenDangNhap"></param>
        /// <param name="matKhau"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetNguoiDung(string tenDangNhap, string matKhau)
        {
            NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();

            NguoiDung nguoiDung;
            nguoiDung = nguoiDungDAO.TaiKhoanChinhXac(tenDangNhap, matKhau);

            if(nguoiDung != null)
            {
                string jsonData = JsonConvert.SerializeObject(nguoiDung);

                return jsonData;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Xác thực form thêm người dùng
        /// </summary>
        /// <param name="hoTen"></param>
        /// <param name="chucVu"></param>
        /// <param name="phongBan"></param>
        /// <param name="quyen"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinThemNguoiDung(string hoTen, string chucVu, string phongBan, string quyen)
        {
            if(hoTen == "")
            {
                return 1;
            }
            if(chucVu == "")
            {
                return 2;
            }
            if(phongBan == "")
            {
                return 3;
            }
            if(quyen == "")
            {
                return 4;
            }

            return 0;
        }

        /// <summary>
        /// Lấy danh sách người dùng hiện tại
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string LayDSNguoiDung()
        {
            List<NguoiDung> list = new List<NguoiDung>();
            list = NguoiDungDAO.LayDSNguoiDung();

            if(list != null)
            {
                string jsonData = JsonConvert.SerializeObject(list);
                return jsonData;
            }
            else
            {
                return null;
            }
        }
    }
}
