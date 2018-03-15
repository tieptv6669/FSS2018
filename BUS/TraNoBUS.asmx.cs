using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using DAO;
using DTO;

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
        public int KTThongTinTraNo(string maGN, string soTienTra, string duNoGoc, string duNoLaiTrongHan, string duNoLaiQuaHan)
        {
            Helper helper = new Helper();
            //if(maGN == "")
            //{
            //    return 1;
            //}
            //if(TraNoDAO.GetGiaiNgan(maGN) == null)
            //{
            //    return 2;
            //}
            if (soTienTra.Length > 13 || soTienTra == "" || !helper.LaMotSoNguyenDuong(soTienTra))
            {
                return 3;
            }
            if (Int64.Parse(soTienTra) > Int64.Parse(duNoGoc) + Int64.Parse(duNoLaiTrongHan) + Int64.Parse(duNoLaiQuaHan))
            {
                return 4;
            }

            return 0;
        }

        /// <summary>
        /// Tạo mã trả nợ khi biết mã giải ngân
        /// </summary>
        /// <param name="maGN"></param>
        /// <returns></returns>
        [WebMethod]
        public string TaoMaTraNo(string maGN)
        {
            string result = "TN";
            string sufix = maGN.Substring(2, 8);
            result += sufix;
            // Lấy id giải ngân khi biết mã giải ngân
            int idGN = TraNoDAO.GetIDGN(maGN);
            // Lấy danh sách các lần trả nợ cho món giải ngân
            List<TraNo> list = TraNoDAO.GetListTN(idGN);
            // Lấy danh sách mã trả nợ
            List<string> listMaTN = new List<string>();
            foreach (TraNo temp in list)
            {
                listMaTN.Add(temp.MaTN);
            }
            // Tạo mã trả nợ
            for (int index = 1; index <= 99; index++)
            {
                if (index.ToString().Length == 1)
                {
                    result += "0";
                }
                result += index.ToString();
                if (!listMaTN.Contains(result))
                {
                    return result;
                }
                else
                {
                    result = "TN" + sufix;
                }
            }

            return result;
        }

        /// <summary>
        /// Thêm trả nợ mới
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ThemTN(string jsonData)
        {
            return TraNoDAO.ThemTN(JsonConvert.DeserializeObject<TraNo>(jsonData));
        }

        /// <summary>
        /// Cập nhật dư nợ cho món giải ngân
        /// </summary>
        /// <param name="maGN"></param>
        /// <param name="duNoGoc"></param>
        /// <param name="duNoLaiTrongHan"></param>
        /// <param name="duNoLaiQuaHan"></param>
        /// <returns></returns>
        [WebMethod]
        public bool CapNhatDuNo(string maGN, long duNoGoc, long duNoLaiTrongHan, long duNoLaiQuaHan)
        {
            return TraNoDAO.CapNhatDuNo(maGN, duNoGoc, duNoLaiTrongHan, duNoLaiQuaHan);
        }

        /// <summary>
        /// Cập nhật số tiền cho nguồn
        /// </summary>
        /// <param name="idNg"></param>
        /// <param name="tienDaChoVay"></param>
        /// <param name="tienCoTheChoVay"></param>
        /// <returns></returns>
        [WebMethod]
        public bool CapNhatNguon(int idNg, long tienDaChoVay, long tienCoTheChoVay)
        {
            return TraNoDAO.CapNhatNguon(idNg, tienDaChoVay, tienCoTheChoVay);
        }

        /// <summary>
        /// Lấy id giải ngân khi biết mã giải ngân
        /// </summary>
        /// <param name="maGN"></param>
        /// <returns></returns>
        [WebMethod]
        public int GetIDGN(string maGN)
        {
            return TraNoDAO.GetIDGN(maGN);
        }

        /// <summary>
        /// Lấy danh sách các lần trả nợ cho món giải ngân có id = idGN
        /// </summary>
        /// <param name="idGN"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetListTN(int idGN)
        {
            return JsonConvert.SerializeObject(TraNoDAO.GetListTN(idGN));
        }
    }
}
