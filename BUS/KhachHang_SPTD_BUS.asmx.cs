using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}
