using System.Collections.Generic;
using System.Web.Services;
using DAO;
using DTO;
using Newtonsoft.Json;

namespace BUS
{
    /// <summary>
    /// Summary description for KhachHang_SPTD_BUS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KhachHang_SPTD_BUS : System.Web.Services.WebService
    {

        /// <summary>
        /// Tìm kiếm khách hàng đang sử dụng sản phẩm tín dụng nào
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <param name="tenKH"></param>
        /// <param name="maSPTD"></param>
        /// <returns></returns>
        [WebMethod]
        public string LayDSKH_SPTD(string soTKLK, string tenKH, string maSPTD)
        {
            List<KhachHang_SPTD> list = KhachHang_SPTD_DAO.GetListKH_SPTD(soTKLK, tenKH, maSPTD);
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        /// <summary>
        /// Lấy ds SPTD của KH có thể dùng
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <param name="tenKH"></param>
        /// <param name="maSPTD"></param>
        /// <returns></returns>
        [WebMethod]
        public string LayDSKH_SPTD_SD(string soTKLK)
        {
            List<KhachHang_SPTD> list = KhachHang_SPTD_DAO.GetListKH_SPTD_SD(soTKLK);
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        /// <summary>
        /// Kiểm tra thông tin đăng ký sản phẩm tín dụng
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <param name="tenKH"></param>
        /// <param name="diaChi"></param>
        /// <param name="maSPTD"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinDangKySPTD(string soTKLK, string tenKH, string diaChi, string maSPTD)
        {
            if(soTKLK == "" || tenKH == "" || diaChi == "")
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Kiểm tra khách hàng đã đăng ký sử dụng sptd chưa
        /// Nếu đã đăng ký thì trạng thái là sử dụng hay ngừng sử dụng
        /// </summary>
        /// <param name="idKH"></param>
        /// <param name="idSPTD"></param>
        /// <returns></returns>
        [WebMethod]
        public int KiemTraTinhTrangSPTD(int idKH, int idSPTD)
        {
            return KhachHang_SPTD_DAO.KiemTraTinhTrangSPTD(idKH, idSPTD);
        }

        /// <summary>
        /// Đăng ký mới SPTD
        /// </summary>
        /// <param name="idKH"></param>
        /// <param name="idSPTD"></param>
        /// <returns></returns>
        [WebMethod]
        public bool DangKyMoi(int idKH, int idSPTD)
        {
            return KhachHang_SPTD_DAO.DangKyMoi(idKH, idSPTD);
        }

        /// <summary>
        /// Sử dụng lại SPTD
        /// </summary>
        /// <param name="idKH"></param>
        /// <param name="idSPTD"></param>
        /// <returns></returns>
        [WebMethod]
        public bool SuDungLai(int idKH, int idSPTD)
        {
            return KhachHang_SPTD_DAO.SuDungLai(idKH, idSPTD);
        }

        /// <summary>
        /// Hủy đăng ký sản phẩm tín dụng
        /// </summary>
        /// <param name="idKH"></param>
        /// <param name="idSPTD"></param>
        /// <returns></returns>
        [WebMethod]
        public bool HuyDangKy(int idKH, int idSPTD)
        {
            return KhachHang_SPTD_DAO.HuyDangKy(idKH, idSPTD);
        }
    }
}
