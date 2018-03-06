using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAO;
using Newtonsoft.Json;

namespace BUS
{
    /// <summary>
    /// Summary description for XuLyCuoiNgayBUS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class XuLyCuoiNgayBUS : System.Web.Services.WebService
    {

        /// <summary>
        /// Lấy ngày làm việc hiện tại
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string LayNgayLamViecHienTai()
        {
            return XuLyCuoiNgayDAO.LayNgayLamViecHienTai().ToShortDateString();
        }

        /// <summary>
        /// Kiểm tra thông tin xử lý qua ngày
        /// </summary>
        /// <param name="ngayLVHienTai"></param>
        /// <param name="ngayLVTiepTheo"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinChayQuaNgay(string ngayLVHienTai, string ngayLVTiepTheo)
        {
            DateTime ngayHienTai = DateTime.Parse(ngayLVHienTai);
            DateTime ngayTiepTheo = DateTime.Parse(ngayLVTiepTheo);
            
            if(ngayTiepTheo.DayOfWeek == DayOfWeek.Sunday || ngayTiepTheo.DayOfWeek == DayOfWeek.Saturday)
            {
                return 1;
            }
            if((ngayTiepTheo - ngayHienTai).Days > 15)
            {
                return 2;
            }
            if((ngayTiepTheo - ngayHienTai).Days <= 0)
            {
                return 3;
            }

            return 0;
        }
    }
}
