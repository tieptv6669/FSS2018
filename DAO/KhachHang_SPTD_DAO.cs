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

                oracleCommand.Connection.Close();
                oracleCommand.Connection.Dispose();
                return list;
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Kiểm tra khách hàng đã đăng ký sử dụng sptd chưa
        /// Nếu đã đăng ký thì trạng thái là sử dụng hay ngừng sử dụng
        /// </summary>
        /// <param name="idKH"></param>
        /// <param name="idSPTD"></param>
        /// <returns></returns>
        public static int KiemTraTinhTrangSPTD(int idKH, int idSPTD)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM KH_SPTD WHERE IDKH = :idKH AND IDSPTD = :idSPTD";
                oracleCommand.Parameters.Add("idKH", idKH);
                oracleCommand.Parameters.Add("idSPTD", idSPTD);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if(oracleDataReader != null && oracleDataReader.HasRows)
                {
                    oracleDataReader.Read();
                    if(oracleDataReader.GetString(2) == "Sử dụng")
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    return 3;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 4;
            }
        }

        /// <summary>
        /// Đăng ký mới sản phẩm tín dụng
        /// </summary>
        /// <param name="idKH"></param>
        /// <param name="idSPTD"></param>
        /// <returns></returns>
        public static bool DangKyMoi(int idKH, int idSPTD)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "INSERT INTO KH_SPTD (IDKH, IDSPTD, TRANGTHAI) VALUES (:idKH, :idSPTD, 'Sử dụng')";
                oracleCommand.Parameters.Add("idKH", idKH);
                oracleCommand.Parameters.Add("idSPTD", idSPTD);

                bool kt = DataProvider.ExcuteNonQuery(oracleCommand);
                oracleCommand.Connection.Close();
                oracleCommand.Connection.Dispose();
                return kt;
            }
            catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Sử dụng lại sptd
        /// </summary>
        /// <param name="idKH"></param>
        /// <param name="idSPTD"></param>
        /// <returns></returns>
        public static bool SuDungLai(int idKH, int idSPTD)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE KH_SPTD SET TRANGTHAI = 'Sử dụng' WHERE IDKH = :idKH AND IDSPTD = :idSPTD";
                oracleCommand.Parameters.Add("idKH", idKH);
                oracleCommand.Parameters.Add("idSPTD", idSPTD);

                bool kt = DataProvider.ExcuteNonQuery(oracleCommand);
                oracleCommand.Connection.Close();
                oracleCommand.Connection.Dispose();
                return kt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Hủy đăng ký sptd
        /// </summary>
        /// <param name="idKH"></param>
        /// <param name="idSPTD"></param>
        /// <returns></returns>
        public static bool HuyDangKy(int idKH, int idSPTD)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE KH_SPTD SET TRANGTHAI = 'Ngừng sử dụng' " +
                    "WHERE IDKH = :idKH AND idSPTD = :idSPTD";
                oracleCommand.Parameters.Add("idKH", idKH);
                oracleCommand.Parameters.Add("idSPTD", idSPTD);

                bool kt = DataProvider.ExcuteNonQuery(oracleCommand);
                oracleCommand.Connection.Close();
                oracleCommand.Connection.Dispose();
                return kt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách SPTD của KH có thể dùng
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <returns></returns>
        public static List<KhachHang_SPTD> GetListKH_SPTD_SD(string soTKLK)
        {
            try
            {
                List<KhachHang_SPTD> list = new List<KhachHang_SPTD>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT SPTD.TENSPTD FROM SPTD, KH_SPTD, KHACHHANG " +
                    "WHERE SPTD.IDSPTD = KH_SPTD.IDSPTD AND KH_SPTD.IDKH = KHACHHANG.IDKHACHHANG " +
                    "AND KHACHHANG.SOTKLK LIKE '%' || :soTKLK || '%' AND KH_SPTD.TRANGTHAI = 'Sử dụng'" +
                    "AND SPTD.TRANGTHAI = 'Hoạt động'";
                oracleCommand.Parameters.Add("soTKLK", soTKLK);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        KhachHang_SPTD khachHang_SPTD = new KhachHang_SPTD();
                        khachHang_SPTD.TenSPTD = oracleDataReader.GetString(0);

                        list.Add(khachHang_SPTD);
                    }
                }

                oracleCommand.Connection.Close();
                oracleCommand.Connection.Dispose();
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
