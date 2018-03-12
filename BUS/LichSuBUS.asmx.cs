using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using DTO;
using DAO;

namespace BUS
{
    /// <summary>
    /// Summary description for LichSuBUS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LichSuBUS : System.Web.Services.WebService
    {

        /// <summary>
        /// Tìm kiếm lịch sử
        /// </summary>
        /// <param name="tenDangNhap"></param>
        /// <param name="soTKLK"></param>
        /// <param name="maDT"></param>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        /// <returns></returns>
        [WebMethod]
        public string TimKiemLichSu(string tenDangNhap, string soTKLK, string maDT, string startDate, string finishDate)
        {
            DateTime from = DateTime.Parse(startDate);
            DateTime to = DateTime.Parse(finishDate);

            List<LichSu> list = LichSuDAO.TimKiemLS(tenDangNhap, soTKLK, maDT, from, to);

            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// Thêm lịch sử mới 
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ThemLichSu(string jsonData)
        {
            LichSu lichSu = JsonConvert.DeserializeObject<LichSu>(jsonData);
            LichSuDAO.ThemLichSu(lichSu);
            return true;
        }
    }
}
