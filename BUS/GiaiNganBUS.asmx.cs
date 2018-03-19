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
        /// Lấy danh sách GN
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string layDSGN()
        {
            List<GN_KH> list = GiaiNganDAO.layGN();
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
        public int KTThongTinNhap(string soTKLK,  string soTienGN, long soTienCoTheChoVay, string loaiKH)
        {
            Helper helper = new Helper();
            if(soTKLK == "" || soTKLK.Length != 10)
            {
                return 1;
            }
            if(soTienGN == "")
            {
                return 2;
            }
            if(helper.LaMotSoNguyenDuong(soTienGN.ToString()) == false)
            {
                return 3;
            }
            if(soTienCoTheChoVay < long.Parse(soTienGN))
            {
                return 4;
            }
            if(soTKLK == "")
            {
                return 5;
            }
            if(loaiKH == "Classic" && long.Parse(soTienGN) > 100000000)
            {
                return 6;
            }
            if (loaiKH == "Silver" && long.Parse(soTienGN) > 200000000)
            {
                return 6;
            }
            if (loaiKH == "Gold" && long.Parse(soTienGN) > 500000000)
            {
                return 6;
            }
            if (loaiKH == "Diamond" && long.Parse(soTienGN) > 1000000000)
            {
                return 6;
            }
            if (soTienGN.Length > 13)
            {
                return 7;
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

        /// <summary>
        /// tạo mã giải ngân
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <returns></returns>
        [WebMethod]
        public string taoMaGN(string soTKLK)
        {
            //Lấy danh sách giải ngân
            List<GiaiNgan> list = GiaiNganDAO.layDSGN();
            var listMaGN = new List<string>();
            //Lấy các mã giải ngân đã tồn tại
            foreach (GiaiNgan temp in list)
            {
                listMaGN.Add(temp.MaGN);
            }
            //Cắt lấy 6 số cuối của số TKLK
            string st = soTKLK.Substring(4, 6);
            //Sinh mã
            string resulf = "GN" + st;
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
                //Kiểm tra mã
                if (!listMaGN.Contains(resulf))
                {
                    return resulf;
                }
                else
                {
                    resulf = "GN" + st;
                }
            }
            return resulf;
        }

        /// <summary>
        /// Kiểm tra thông tin sửa giải ngân
        /// </summary>
        /// <param name="ngayGN"></param>
        /// <param name="soTienGN"></param>
        /// <param name="soTienCoTheChoVay"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTTTSuaGN(string soTKLK, DateTime ngayGN, string soTienGN, long soTienCoTheChoVay, string loaiKH)
        {
            Helper helper = new Helper();
            DateTime date = DateTime.Now;
            if (soTKLK == "" || soTKLK.Length != 10)
            {
                return 1;
            }
            if(soTienGN == "")
            {
                return 6;
            }
            if (helper.LaMotSoNguyenDuong(soTienGN.ToString()) == false)
            {
                return 2;
            }
            if (soTienCoTheChoVay < long.Parse(soTienGN))
            {
                return 3;
            }
            if (loaiKH == "Classic" && long.Parse(soTienGN) > 100000000)
            {
                return 4;
            }
            if (loaiKH == "Silver" && long.Parse(soTienGN) > 200000000)
            {
                return 4;
            }
            if (loaiKH == "Gold" && long.Parse(soTienGN) > 500000000)
            {
                return 4;
            }
            if (loaiKH == "Diamond" && long.Parse(soTienGN) > 1000000000)
            {
                return 4;
            }
            if (soTienGN.Length > 13)
            {
                return 5;
            }
            return 0;
        }

        /// <summary>
        /// Sửa giải ngân
        /// </summary>
        /// <param name="maGN"></param>
        /// <param name="soTienGN"></param>
        /// <param name="idSPTD"></param>
        /// <param name="ghiChu"></param>
        /// <returns></returns>
        [WebMethod]
        public bool SuaGN(string maGN, long soTienGN, int idSPTD, string ghiChu)
        {
            return GiaiNganDAO.suaGN(maGN, soTienGN, idSPTD, ghiChu);
        }
    }
}
