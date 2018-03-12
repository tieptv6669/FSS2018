using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using DAO;

namespace BUS
{
    /// <summary>
    /// Summary description for TraNoBUS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TraNoBUS : System.Web.Services.WebService
    {

        /// <summary>
        /// Lấy danh sách tất cả các món giải ngân còn nợ
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetListGN()
        {
            return JsonConvert.SerializeObject(TraNoDAO.GetListGN());
        }

        /// <summary>
        /// Lấy danh sách tất cả các món giải ngân còn nợ của KH có id = idKH
        /// </summary>
        /// <param name="idKH"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetListGNWithIdKH(int idKH)
        {
            return JsonConvert.SerializeObject(TraNoDAO.GetListGN(idKH));
        }

        /// <summary>
        /// Lấy món giải ngân còn nợ khi biết mã GN
        /// </summary>
        /// <param name="maGN"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetGN(string maGN)
        {
            return JsonConvert.SerializeObject(TraNoDAO.GetGiaiNgan(maGN));
        }

        /// <summary>
        /// Kiểm tra thông tin trả nợ
        /// </summary>
        /// <param name="maGN"></param>
        /// <param name="soTienTra"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinTraNo(string maGN, string soTienTra)
        {
            if(maGN == "")
            {
                return 1;
            }
            if(TraNoDAO.GetGiaiNgan(maGN) == null)
            {
                return 2;
            }
            return 0;

        }
    }
}
