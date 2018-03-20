﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}
