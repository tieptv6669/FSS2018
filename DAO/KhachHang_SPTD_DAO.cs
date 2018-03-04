using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Oracle.ManagedDataAccess.Client;

namespace DAO
{
    /// <summary>
    /// Viết Tiệp
    /// 4/3/2018
    /// </summary>
    public class KhachHang_SPTD_DAO
    {
        /// <summary>
        /// Tìm kiếm khách hàng đang sử dụng sản phẩm tín dụng nào
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <param name="tenKH"></param>
        /// <param name="maSPTD"></param>
        /// <returns></returns>
        public static List<KhachHang_SPTD> GetListKH_SPTD(string soTKLK, string tenKH, string maSPTD)
        {
            try
            {
                List<KhachHang_SPTD> list = new List<KhachHang_SPTD>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT SPTD.MASPTD, SPTD.TENSPTD, KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, " +
                    "SPTD.TENNGUON, KH_SPTD.TRANGTHAI FROM SPTD, KH_SPTD, KHACHHANG " +
                    "WHERE SPTD.IDSPTD = KH_SPTD.IDSPTD AND KH_SPTD.IDKH = KHACHHANG.IDKHACHHANG " +
                    "AND KHACHHANG.SOTKLK LIKE '%' || :soTKLK || '%' AND KHACHHANG.HOTENKH LIKE '%' || :tenKH || '%'" +
                    "AND SPTD.MASPTD LIKE '%' || :maSPTD || '%'";
                oracleCommand.Parameters.Add("soTKLK", soTKLK);
                oracleCommand.Parameters.Add("tenKH", tenKH);
                oracleCommand.Parameters.Add("maSPTD", maSPTD);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                if(oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        KhachHang_SPTD khachHang_SPTD = new KhachHang_SPTD();
                        khachHang_SPTD.MaSPTD = oracleDataReader.GetString(0);
                        khachHang_SPTD.TenSPTD = oracleDataReader.GetString(1);
                        khachHang_SPTD.SoTKLK = oracleDataReader.GetString(2);
                        khachHang_SPTD.TenKH = oracleDataReader.GetString(3);
                        khachHang_SPTD.TenNguon = oracleDataReader.GetString(4);
                        khachHang_SPTD.TrangThai = oracleDataReader.GetString(5);

                        list.Add(khachHang_SPTD);
                    }
                }

                return list;
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
