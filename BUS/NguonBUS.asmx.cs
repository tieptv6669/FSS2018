﻿using System;
using System.Collections.Generic;
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

            jsonData = JsonConvert.SerializeObject(list);
            return jsonData;
        }

        /// <summary>
        /// Tìm kiếm nguồn theo tên nguồn và mã nguồn
        /// </summary>
        /// <param name="tenNguon"></param>
        /// <returns></returns>
        [WebMethod]
        public string TimKiemNguon(string tenNguon, string maNguon)
        {
            List<Nguon> list = NguonDAO.TimKiemNguon(tenNguon, maNguon);
            string jsonData = JsonConvert.SerializeObject(list);

            return jsonData;
        }

        /// <summary>
        /// Tạo mã nguồn
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string TaoMaNguon()
        {
            string maNguon = "NG";
            // Lấy danh sách nguồn hiện có
            List<Nguon> list = new List<Nguon>();
            list = NguonDAO.LayDanhSachNguon();
            // Lấy danh sách mã nguồn hiện có
            List<string> listMaNguon = new List<string>();
            foreach(Nguon temp in list)
            {
                listMaNguon.Add(temp.maNg);
            }
         
            // Tạo tên nguồn
            for (int index = 1; index <= 999; index++)
            {
                maNguon = "NG";
                if (index.ToString().Length == 1)
                {
                    maNguon += "00";
                    maNguon += index.ToString();
                }
                if (index.ToString().Length == 2)
                {
                    maNguon += "0";
                    maNguon += index.ToString();
                }
                if (index.ToString().Length == 3)
                {
                    maNguon += index.ToString();
                }

                if (!listMaNguon.Contains(maNguon))
                {
                    return maNguon;
                }
            }

            return null;
        }

        /// <summary>
        /// Kiểm tra thông tin thêm nguồn mới
        /// </summary>
        /// <param name="tenNguon"></param>
        /// <param name="hanMuc"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinThemNguon(string tenNguon, string hanMuc)
        {
            Helper helper = new Helper();
            if(tenNguon == "")
            {
                return 1;
            }
            if(hanMuc == "")
            {
                return 2;
            }
            if (!helper.ChiChuaChuCai(tenNguon))
            {
                return 3;
            }
            if(hanMuc.Length > 14 || tenNguon.Length > 50)
            {
                return 6;
            }
            if (!helper.LaMotSoNguyenDuong(hanMuc))
            {
                return 4;
            }
            if(NguonDAO.GetNguon(tenNguon) != null)
            {
                return 5;
            }

            return 0;
        }

        /// <summary>
        /// Thêm nguồn mới
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ThemNguonMoi(string jsonData)
        {
            Nguon nguon = JsonConvert.DeserializeObject<Nguon>(jsonData);

            return NguonDAO.ThemNguon(nguon);
        }

        /// <summary>
        /// Kiểm tra thông tin sửa nguồn
        /// </summary>
        /// <param name="hanMuc"></param>
        /// <param name="soTienDaChoVay"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinSuaNguon(string hanMuc, string soTienDaChoVay)
        {
            Helper helper = new Helper();
            if(hanMuc == "")
            {
                return 1;
            }
            if(hanMuc.Length > 14)
            {
                return 4;
            }
            if (!helper.LaMotSoNguyenDuong(hanMuc))
            {
                return 2;
            }
            if(Int64.Parse(hanMuc) < Int64.Parse(soTienDaChoVay))
            {
                return 3;
            }

            return 0;
        }

        /// <summary>
        /// Sửa nguồn
        /// </summary>
        /// <param name="maNguon"></param>
        /// <param name="tenNguon"></param>
        /// <param name="hanMuc"></param>
        /// <param name="soTienDaChoVay"></param>
        /// <param name="soTienCoTheChoVay"></param>
        /// <returns></returns>
        [WebMethod]
        public bool SuaNguon(string maNguon, string hanMuc, string soTienCoTheChoVay)
        {
            return NguonDAO.SuaNguon(maNguon, hanMuc, soTienCoTheChoVay);
        }

        /// <summary>
        /// Xóa nguồn
        /// </summary>
        /// <param name="maNguon"></param>
        /// <returns></returns>
        [WebMethod]
        public bool XoaNguon(string maNguon)
        {
            return NguonDAO.XoaNguon(maNguon);
        }

        /// <summary>
        /// Lấy nguồn khi biết tên nguồn
        /// </summary>
        /// <param name="tenNguon"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetNguon(string tenNguon)
        {
            Nguon nguon = NguonDAO.GetNguon(tenNguon);
            string jsonData = JsonConvert.SerializeObject(nguon);
            return jsonData;
        }

        /// <summary>
        /// Update số tiền cho vay trong nguồn
        /// </summary>
        /// <param name="choVay"></param>
        /// <param name="idNguon"></param>
        /// <returns></returns>
        [WebMethod]
        public bool updateSoTien(long choVay, int idNguon,long coTheVay, long daChoVay)
        {
            return NguonDAO.updateSTien(choVay, idNguon, coTheVay, daChoVay);
        }

        /// <summary>
        /// Update lại số tiền khi sửa
        /// </summary>
        /// <param name="choVay"></param>
        /// <param name="idNguon"></param>
        /// <param name="coTheVay"></param>
        /// <param name="daChoVay"></param>
        /// <returns></returns>
        [WebMethod]
        public bool updateSoTienSua(long choVay, int idNguon, long coTheVay, long daChoVay)
        {
            return NguonDAO.updateSTienSua(choVay, idNguon, coTheVay, daChoVay);
        }

        /// <summary>
        /// Lấy nguồn khi biết id nguồn
        /// </summary>
        /// <param name="idNg"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetNguonWithID(int idNg)
        {
            return JsonConvert.SerializeObject(NguonDAO.GetNguon(idNg));
        }
    }
}
