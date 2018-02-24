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
            Helper helper = new Helper();
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
            if (helper.ChiChuaChuCai(hoTen) == false)
            {
                return 5;
            }
            if (helper.ChiChuaChuCai(chucVu) == false)
            {
                return 6;
            }
            if (helper.ChiChuaChuCai(phongBan) == false)
            {
                return 7;
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

        /// <summary>
        /// Tạo tên đăng nhập cho người dùng
        /// </summary>
        /// <param name="DSTenDangNhapDaCo"></param>
        /// <returns></returns>
        [WebMethod]
        public string TaoTenDangNhap(List<string> DSTenDangNhapDaCo)
        {
            string result = "NV";

            for (int x = 1; x <= 99999; x++)
            {
                int lengthIndex = x.ToString().Length;
                switch (lengthIndex)
                {
                    case 1:
                        {
                            result += "0000";
                            break;
                        }
                    case 2:
                        {
                            result += "000";
                            break;
                        }
                    case 3:
                        {
                            result += "00";
                            break;
                        }
                    case 4:
                        {
                            result += "0";
                            break;
                        }
                }
                result += x.ToString();
                if (!DSTenDangNhapDaCo.Contains(result))
                {
                    return result;
                }
                else
                {
                    result = "NV";
                }
            }
            return result;
        }

        /// <summary>
        /// Thêm người dùng mới
        /// </summary>
        /// <param name="nguoiDung"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ThemNguoiDung(string jsonDataNguoiDung)
        {
            NguoiDung nguoiDung = JsonConvert.DeserializeObject<NguoiDung>(jsonDataNguoiDung);
            return NguoiDungDAO.ThemNguoiDung(nguoiDung);
        }

        /// <summary>
        /// Tìm kiếm người dùng theo tên người dùng và tên đăng nhập
        /// </summary>
        /// <param name="tenNguoiDung"></param>
        /// <param name="tenDangNhap"></param>
        /// <returns></returns>
        [WebMethod]
        public string TimKiemNguoiDung(string tenNguoiDung, string tenDangNhap)
        {
            List<NguoiDung> list = NguoiDungDAO.TimKiemNguoiDung(tenNguoiDung, tenDangNhap);
            string jsonData = JsonConvert.SerializeObject(list);

            return jsonData;
        }

        /// <summary>
        /// Sửa thông tin người dùng 
        /// </summary>
        /// <param name="tenDN"></param>
        /// <param name="hoTen"></param>
        /// <param name="chucVu"></param>
        /// <param name="phongBan"></param>
        /// <param name="quyen"></param>
        /// <returns></returns>
        [WebMethod]
        public bool SuaThongTinNguoiDung(string tenDN, string hoTen, string chucVu, string phongBan, string quyen)
        {
            return NguoiDungDAO.SuaThongTinNguoiDung(tenDN, hoTen, chucVu, phongBan, quyen);
        }

        /// <summary>
        /// Xóa người dùng 
        /// </summary>
        /// <param name="tenDN"></param>
        /// <returns></returns>
        [WebMethod]
        public bool XoaNguoiDung(string tenDN)
        {
            return NguoiDungDAO.XoaNguoiDung(tenDN);
        }

        /// <summary>
        /// Kiểm tra thông tin đổi mật khẩu
        /// </summary>
        /// <param name="tenDN"></param>
        /// <param name="MKCu"></param>
        /// <param name="MKMoi"></param>
        /// <param name="nhapLaiMK"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinDoiMK(string tenDN, string MKCu, string MKMoi, string nhapLaiMK)
        {
            NguoiDungDAO nguoiDungDAO = new NguoiDungDAO();

            if(MKCu == "")
            {
                return 1;
            }
            if(MKMoi == "")
            {
                return 2;
            }
            if(nhapLaiMK == "")
            {
                return 3;
            }
            if(nguoiDungDAO.TaiKhoanChinhXac(tenDN, MKCu) == null)
            {
                return 4;
            }
            if(MKMoi.Length < 6)
            {
                return 5;
            }
            if(MKMoi != nhapLaiMK)
            {
                return 6;
            }

            return 0;
        }

        /// <summary>
        /// Đổi mật khẩu người dùng
        /// </summary>
        /// <param name="tenDN"></param>
        /// <param name="MatKhauMoi"></param>
        /// <returns></returns>
        [WebMethod]
        public bool DoiMatKhau(string tenDN, string MatKhauMoi)
        {
            return NguoiDungDAO.DoiMatKhau(tenDN, MatKhauMoi);
        }

        /// <summary>
        /// Reset mật khẩu cho người dùng
        /// </summary>
        /// <param name="tenDN"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ResetMatKhau(string tenDN)
        {
            return NguoiDungDAO.ResetMatKhau(tenDN);
        }
    }
}
