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
    /// Summary description for SanPhamTinDungBUS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SanPhamTinDungBUS : System.Web.Services.WebService
    {

        [WebMethod]
        public int KTThongTinThemMoiSPTD(string tenSPTD, string thoiHanVay, string laiSuat, string laiSuatQuaHan)
        {
            Helper helper = new Helper();
            if(tenSPTD == "")
            {
                return 1;
            }
            if(thoiHanVay == "")
            {
                return 2;
            }
            if(laiSuat == "")
            {
                return 3;
            }
            if(laiSuatQuaHan == "")
            {
                return 4;
            }
            if (!helper.ChiChuaChuCai(tenSPTD))
            {
                return 5;
            }
            if (!helper.LaMotSoNguyenDuong(thoiHanVay))
            {
                return 6;
            }
            if (!helper.LaMotSoNguyenDuong(laiSuat))
            {
                return 7;
            }
            if (!helper.LaMotSoNguyenDuong(laiSuatQuaHan))
            {
                return 8;
            }
            if(SanPhamTinDungDAO.GetSanPhamTinDung(tenSPTD) != null)
            {
                return 9;
            }

            return 0;
        }

        /// <summary>
        /// Lấy danh sách sản phẩm tín dụng 
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string LayDanhSachSPTD()
        {
            List<SanPhamTinDung> list = SanPhamTinDungDAO.GetListSPTD();
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        /// <summary>
        /// Tìm kiếm sản phẩm tín dụng theo tên, mã và nguồn
        /// </summary>
        /// <param name="tenSPTD"></param>
        /// <param name="maSPTD"></param>
        /// <param name="tenNguon"></param>
        /// <returns></returns>
        [WebMethod]
        public string TimKiemSPTD(string tenSPTD, string maSPTD, string tenNguon)
        {
            List<SanPhamTinDung> list = SanPhamTinDungDAO.TimKiemSPTD(tenSPTD, maSPTD, tenNguon);
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        /// <summary>
        /// Tạo mã SPTD
        /// </summary>
        /// <param name="prefixMaSPTD"></param>
        /// <returns></returns>
        [WebMethod]
        public string TaoMaSPTD(string prefixMaSPTD)
        {
            // Lấy danh sách SPTD hiện có
            List<SanPhamTinDung> list = SanPhamTinDungDAO.GetListSPTD();
            List<string> listMaSPTD = new List<string>();
            foreach(SanPhamTinDung temp in list)
            {
                listMaSPTD.Add(temp.MaSPTD);
            }
            // Tạo mã
            string fullCode = prefixMaSPTD;
            for(int index = 1; index <= 99; index++)
            {
                if(index.ToString().Length == 1)
                {
                    fullCode += "0";
                    fullCode += index.ToString();
                }
                else
                {
                    fullCode += index.ToString();
                }
                if (!listMaSPTD.Contains(fullCode))
                {
                    return fullCode;
                }
                else
                {
                    fullCode = prefixMaSPTD;
                }
            }

            return fullCode;
        }

        /// <summary>
        /// Thêm mới SPTD
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ThemMoiSPTD(string jsonData)
        {
            SanPhamTinDung sanPhamTinDung = JsonConvert.DeserializeObject<SanPhamTinDung>(jsonData);
            return SanPhamTinDungDAO.ThemMoiSPTD(sanPhamTinDung);
        }
    }
}
