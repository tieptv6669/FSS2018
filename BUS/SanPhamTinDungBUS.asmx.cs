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
        /// <summary>
        /// Kiểm tra thông tin thêm mới SPTD
        /// </summary>
        /// <param name="tenSPTD"></param>
        /// <param name="thoiHanVay"></param>
        /// <param name="laiSuat"></param>
        /// <param name="laiSuatQuaHan"></param>
        /// <returns></returns>
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
        /// Lấy danh sách sản phẩm tín dụng  với trạng thái là Hoạt động
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string LayDanhSachSPTDHD(string tenSPTD)
        {
            List<SanPhamTinDung> list = SanPhamTinDungDAO.GetListSPTDHD(tenSPTD);
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

        /// <summary>
        /// Kiểm tra thông tin sửa sản phẩm tín dụng
        /// </summary>
        /// <param name="tenSPTD"></param>
        /// <param name="thoiHanVay"></param>
        /// <param name="laiSuat"></param>
        /// <param name="laiSuatQuaHan"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinSuaSPTD(string tenMoiSPTD, string tenCuSPTD, string thoiHanVay, string laiSuat, string laiSuatQuaHan)
        {
            Helper helper = new Helper();
            SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
            if (tenMoiSPTD == "")
            {
                return 1;
            }
            if (thoiHanVay == "")
            {
                return 2;
            }
            if (laiSuat == "")
            {
                return 3;
            }
            if (laiSuatQuaHan == "")
            {
                return 4;
            }
            if (!helper.ChiChuaChuCai(tenMoiSPTD))
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
            if (sanPhamTinDungBUS.KTThayDoiTenSPTD(tenMoiSPTD, tenCuSPTD) == false)
            {
                return 9;
            }

            return 0;
        }

        /// <summary>
        /// Kiểm tra thay đổi tên SPTD
        /// </summary>
        /// <param name="tenMoiSPTD"></param>
        /// <returns></returns>
        [WebMethod]
        public bool KTThayDoiTenSPTD(string tenMoiSPTD, string tenCuSPTD)
        {
            List<SanPhamTinDung> list = SanPhamTinDungDAO.GetListSPTD(tenCuSPTD);
            foreach(SanPhamTinDung temp in list)
            {
                if(temp.TenSPTD == tenMoiSPTD)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Sửa thông tin SPTD
        /// </summary>
        /// <param name="maSPTD"></param>
        /// <param name="tenSPTD"></param>
        /// <param name="thoiHanVay"></param>
        /// <param name="laiSuat"></param>
        /// <param name="laiSuatQuaHan"></param>
        /// <param name="trangThai"></param>
        /// <returns></returns>
        [WebMethod]
        public bool SuaSPTD(string maSPTD, string tenSPTD, int thoiHanVay, int laiSuat, int laiSuatQuaHan, string trangThai)
        {
            return SanPhamTinDungDAO.SuaSPTD(maSPTD, tenSPTD, thoiHanVay, laiSuat, laiSuatQuaHan, trangThai);
        }

        /// <summary>
        /// Lấy danh sách các sản phẩm tín dụng còn hoạt động
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetListSPTD()
        {
            List<SanPhamTinDung> list = SanPhamTinDungDAO.GetList();
            string jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        /// <summary>
        /// Lấy sản phẩm tín dụng khi biết mã SPTD
        /// </summary>
        /// <param name="maSPTD"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetSPTD(string maSPTD)
        {
            SanPhamTinDung sanPhamTinDung = SanPhamTinDungDAO.LaySanPhamTinDung(maSPTD);
            string jsonData = JsonConvert.SerializeObject(sanPhamTinDung);
            return jsonData;
        }
    }
}
