using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DTO;
using Newtonsoft.Json;
using DAO;

namespace BUS
{
    /// <summary>
    /// Summary description for GiaiNganBUS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GiaiNganBUS : System.Web.Services.WebService
    {
        /// <summary>
        /// Tìm kiếm giải ngân
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <returns></returns>
        [WebMethod]
        public string TimKiemGN(string soTKLK)
        {
            List<GN_KH> list = GiaiNganDAO.TimKiemGN(soTKLK);
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        /// <summary>
        /// Xem chi tiết giải ngân
        /// </summary>
        /// <param name="maGN"></param>
        /// <returns></returns>
        [WebMethod]
        public string xemChiTietGN(string maGN)
        {
            GN_SPTD_NGUON gN_SPTD = GiaiNganDAO.xemChiTietGN(maGN);
            string jsonData = JsonConvert.SerializeObject(gN_SPTD);
            return jsonData;

        }

        /// <summary>
        /// Kiểm tra thông tin nhập vào form thêm
        /// </summary>
        /// <param name="soTienGN"></param>
        /// <param name="SPTD"></param>
        /// <param name="ngayDH"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinNhap(string soTienGN,string SPTD, DateTime ngayDH)
        {
            Helper helper = new Helper();
            if(soTienGN == "")
            {
                return 1;
            }
            if(helper.LaMotSoNguyenDuong(soTienGN) == false)
            {
                return 2;
            }
            return 0;
        }

        /// <summary>
        /// Thêm mới giải ngân
        /// </summary>
        /// <param name="jsonDataGiaiNgan"></param>
        /// <returns></returns>
        [WebMethod]
        public bool themGiaiNgan(string jsonDataGiaiNgan)
        {
            GiaiNgan giaiNgan = JsonConvert.DeserializeObject<GiaiNgan>(jsonDataGiaiNgan);
            return GiaiNganDAO.themGN(giaiNgan);
        }

        [WebMethod]
        public string taoMaGN(string soTKLK)
        {
            List<GiaiNgan> list = GiaiNganDAO.layDSGN();
            List<string> listMaGN = new List<string>();
            foreach (GiaiNgan temp in list)
            {
                listMaGN.Add(temp.MaGN);
            }
            string resulf = "GN"+soTKLK;
            for (int index = 1; index <= 99; index++)
            {
                if (index.ToString().Length == 1)
                {
                    resulf += "0";
                    resulf += index.ToString();
                }
                else
                {
                    resulf += index.ToString();
                }
                if (!listMaGN.Contains(resulf))
                {
                    return resulf;
                }
                else
                {
                    resulf = "GN" + soTKLK;
                }
            }
            return resulf;
        }
    }
}
