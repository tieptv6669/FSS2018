using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAO;
using DTO;
using Newtonsoft.Json;

namespace BUS
{
    /// <summary>
    /// Summary description for XuLyCuoiNgayBUS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class XuLyCuoiNgayBUS : System.Web.Services.WebService
    {

        /// <summary>
        /// Lấy ngày làm việc hiện tại
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string LayNgayLamViecHienTai()
        {
            return XuLyCuoiNgayDAO.LayNgayLamViecHienTai().ToShortDateString();
        }

        /// <summary>
        /// Kiểm tra thông tin xử lý qua ngày
        /// </summary>
        /// <param name="ngayLVHienTai"></param>
        /// <param name="ngayLVTiepTheo"></param>
        /// <returns></returns>
        [WebMethod]
        public int KTThongTinChayQuaNgay(string ngayLVHienTai, string ngayLVTiepTheo)
        {
            DateTime ngayHienTai = DateTime.Parse(ngayLVHienTai);
            DateTime ngayTiepTheo = DateTime.Parse(ngayLVTiepTheo);
            
            if(ngayTiepTheo.DayOfWeek == DayOfWeek.Sunday || ngayTiepTheo.DayOfWeek == DayOfWeek.Saturday)
            {
                return 1;
            }
            if((ngayTiepTheo - ngayHienTai).Days > 15)
            {
                return 2;
            }
            if((ngayTiepTheo - ngayHienTai).Days <= 0)
            {
                return 3;
            }

            return 0;
        }

        /// <summary>
        /// Xử lý cuối ngày
        /// </summary>
        /// <param name="ngayLVHienTai"></param>
        /// <param name="ngayLVTiepTheo"></param>
        /// <returns></returns>
        [WebMethod]
        public bool XuLyCuoiNgay(string ngayLVHienTai, string ngayLVTiepTheo)
        {
            // Xác định ngày
            DateTime ngayHienTai = DateTime.Parse(ngayLVHienTai);
            DateTime ngayTiepTheo = DateTime.Parse(ngayLVTiepTheo);
            int soNgayTinhLai = (ngayTiepTheo - ngayHienTai).Days;

            // Lấy danh sách các món giải ngân còn nợ
            List<GiaiNgan> listGN = XuLyCuoiNgayDAO.GetListGN();
            // Lấy danh sách sản phẩm tín dụng
            List<SanPhamTinDung> listSPTD = SanPhamTinDungDAO.GetListSPTD();
            
            // Tính lãi cho từng ngày
            DateTime tempNgayHienTai = ngayHienTai;
            for (int index = 1; index <= soNgayTinhLai; index++)
            {
                // Tính lãi cho từng món giải ngân
                foreach (GiaiNgan temp in listGN)
                {
                    // Khởi tạo một bản ghi log
                    XuLyCuoiNgay xuLyCuoiNgay = new XuLyCuoiNgay();
                    xuLyCuoiNgay.IdGN = temp.IDGN;
                    xuLyCuoiNgay.DuNoLaiTrongHan = temp.DuNoLaiTrongHan;
                    xuLyCuoiNgay.DuNoLaiQuaHan = temp.DuNoLaiNgoaiHan;
                    xuLyCuoiNgay.ThoiGian = tempNgayHienTai;

                    // Lấy sản phẩm tín dụng tương ứng
                    SanPhamTinDung sanPhamTinDung = new SanPhamTinDung();
                    foreach (SanPhamTinDung temp2 in listSPTD)
                    {
                        if (temp.IDSPTD == temp2.IdSPTD)
                        {
                            sanPhamTinDung = temp2;
                            break;
                        }
                    }

                    // Tính lãi
                    if(DateTime.Compare(tempNgayHienTai, temp.NgayDaoHan) <= 0)
                    {
                        double duNo = (double)(temp.DuNoGoc * sanPhamTinDung.LaiSuat) / 36000;
                        xuLyCuoiNgay.DuNoLaiTrongHan += (long)Math.Round(duNo);
                        temp.DuNoLaiTrongHan = xuLyCuoiNgay.DuNoLaiTrongHan;
                    }
                    else
                    {
                        double duNo = (double)(temp.DuNoGoc * sanPhamTinDung.LaiSuatQuaHan) / 36000;
                        xuLyCuoiNgay.DuNoLaiQuaHan += (long)Math.Round(duNo);
                        temp.DuNoLaiNgoaiHan = xuLyCuoiNgay.DuNoLaiQuaHan; 
                    }

                    // Insert dữ liệu vào bảng log
                    XuLyCuoiNgayDAO.ThemXLCN(xuLyCuoiNgay);
                }

                tempNgayHienTai = tempNgayHienTai.AddDays(1);

                // Nếu là ngày cuối cùng thì cập nhật dư nợ vào bảng giải ngân
                // Cập nhật dữ liệu bảng tham số hệ thống
                if (index == soNgayTinhLai)
                {
                    foreach (GiaiNgan temp in listGN)
                    {
                        // Update temp vào bảng GIAINGAN
                        XuLyCuoiNgayDAO.CapNhatDuNoBangGN(temp);
                    }
                    // Cập nhật tham số hệ thống
                    XuLyCuoiNgayDAO.CapNhatThamSoHeThong(ngayTiepTheo);
                }
            }

            return true;
        }
    }
}
