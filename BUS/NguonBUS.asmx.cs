using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DTO;
using DAO;
using Newtonsoft.Json;

/// <summary>
/// Viết Tiệp
/// 24/02/2018
/// </summary>
namespace BUS
{
    /// <summary>
    /// Summary description for NguonBUS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NguonBUS : System.Web.Services.WebService
    {

        /// <summary>
        /// Lấy danh sách nguồn
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string LayDSNguon()
        {
            string jsonData = "";
            List<Nguon> list = new List<Nguon>();
            list = NguonDAO.LayDanhSachNguon();

            if(list != null)
            {
                jsonData = JsonConvert.SerializeObject(list);

                return jsonData;
            }
            else
            {
                return null;
            }
        }
    }
}
