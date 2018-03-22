using System;
using System.Web.Services;
using Newtonsoft.Json;
using DAO;

namespace BUS
{
    /// <summary>
    /// Summary description for ReportBUS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ReportBUS : System.Web.Services.WebService
    {

        /// <summary>
        /// Lấy danh sách các KH có nhiều hơn 3 món GN nợ quá hạn 
        /// </summary>
        /// <param name="ngayHT"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetListDSDuNoA(string ngayHT)
        {
            return JsonConvert.SerializeObject(ReportDAO.GetListDSDuNoA(DateTime.Parse(ngayHT)));
        }

        /// <summary>
        /// Lấy danh sách các KH có nhiều hơn 5 món giải ngân đang nợ
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetListDSDuNoB()
        {
            return JsonConvert.SerializeObject(ReportDAO.GetListDSDuNoB());
        }

        /// <summary>
        /// Lấy danh sách các KH không có món GN nào quá hạn
        /// </summary>
        /// <param name="ngayHT"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetListDSDuNoC(string ngayHT)
        {
            return JsonConvert.SerializeObject(ReportDAO.GetListDSDuNoC(DateTime.Parse(ngayHT)));
        }

        /// <summary>
        /// Lấy danh sách các KH đã hoàn thành tất cả các món GN 
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetListDSKHHetNo()
        {
            return JsonConvert.SerializeObject(ReportDAO.GetListDSHetNo());
        }

        /// <summary>
        /// Lấy danh sách KH có tổng dư nợ > 500 triệu
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetListDSDuNoE()
        {
            return JsonConvert.SerializeObject(ReportDAO.GetListDSDuNoE());
        }

        /// <summary>
        /// Lấy danh sách SPTD có ít hơn 5 KH sử dụng
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetListDSSPTDA()
        {
            return JsonConvert.SerializeObject(ReportDAO.GetListDSSPTDA());
        }

        /// <summary>
        /// Lấy danh sách SPTD có nhiều hơn 10 KH sử dụng
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetListDSSPTDB()
        {
            return JsonConvert.SerializeObject(ReportDAO.GetListDSSPTDB());
        }

        /// <summary>
        /// Lấy danh sách các món GN nợ quá hạn từ 2 tháng trở lên
        /// </summary>
        /// <param name="gioHT"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetListDSGNA(string gioHT)
        {
            return JsonConvert.SerializeObject(ReportDAO.GetListDSGNA(DateTime.Parse(gioHT)));
        }

        /// <summary>
        /// Lấy danh sách các món GN có dư nợ lãi > 10 triệu
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetListDSGNB()
        {
            return JsonConvert.SerializeObject(ReportDAO.GetListDSGNB());
        }

        /// <summary>
        /// Lấy danh sách các nguồn có số tiền có thể cho vay < 100 triệu
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetListDSNguonA()
        {
            return JsonConvert.SerializeObject(ReportDAO.GetListDSNGA());
        }
    }
}
