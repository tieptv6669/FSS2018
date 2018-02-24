using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using DTO;
using System.Windows.Forms;

namespace DAO
{
    /// <summary>
    /// Thùy Linh
    /// 24/02/2018
    /// </summary>
    public class KhachHangDAO
    {
        /// <summary>
        /// Lấy damh sách khách hàng
        /// </summary>
        /// <returns></returns>
        public static List<KhachHang> layDSKhachHang()
        {
            try
            {
                List<KhachHang> list = new List<KhachHang>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM KHACHHANG";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        KhachHang khachHang = new KhachHang();

                        khachHang.idKH = oracleDataReader.GetInt32(0);
                        khachHang.STKLK = oracleDataReader.GetString(1);
                        khachHang.hoTenKH = oracleDataReader.GetString(2);
                        khachHang.ngaySinhKH = oracleDataReader.GetDateTime(3);
                        khachHang.ngayMoTKKH = oracleDataReader.GetDateTime(4);
                        khachHang.ngheNghiepKH = oracleDataReader.GetString(5);
                        khachHang.soCMNNKH = oracleDataReader.GetString(6);
                        khachHang.emailKH = oracleDataReader.GetString(7);
                        khachHang.gioiTinhKH = oracleDataReader.GetString(8);
                        khachHang.loai = oracleDataReader.GetString(9);
                        khachHang.diaChiKH = oracleDataReader.GetString(10);
                        khachHang.SDTKH = oracleDataReader.GetString(11);
                        khachHang.ghiChuKH = oracleDataReader.GetString(12);
                        
                        list.Add(khachHang);
                    }
                }
                return list;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Tìm kiếm khách hàng
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <param name="hoTenKH"></param>
        /// <param name="soCMND"></param>
        /// <returns></returns>
        public static List<KhachHang> TimKiemKH(string soTKLK, string hoTenKH, string soCMND)
        {
            try
            {
                List<KhachHang> list = new List<KhachHang>();
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM KHACHHANG " +
                    "WHERE SOTKLK LIKE '%' || :soTKLK || '%' " +
                    "AND HOTENKH LIKE '%' || :hoTenKH || '%' " + 
                    "AND SOCMND LIKE '%' || :soCMND || '%'";
                oracleCommand.Parameters.Add(new OracleParameter("soTKLK", soTKLK));
                oracleCommand.Parameters.Add(new OracleParameter("hoTenKH", hoTenKH));
                oracleCommand.Parameters.Add(new OracleParameter("soCMND", soCMND));

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        KhachHang khachHang = new KhachHang();

                        khachHang.idKH = oracleDataReader.GetInt32(0);
                        khachHang.STKLK = oracleDataReader.GetString(1);
                        khachHang.hoTenKH = oracleDataReader.GetString(2);
                        khachHang.ngaySinhKH = oracleDataReader.GetDateTime(3);
                        khachHang.ngayMoTKKH = oracleDataReader.GetDateTime(4);
                        khachHang.ngheNghiepKH = oracleDataReader.GetString(5);
                        khachHang.soCMNNKH = oracleDataReader.GetString(6);
                        khachHang.emailKH = oracleDataReader.GetString(7);
                        khachHang.gioiTinhKH = oracleDataReader.GetString(8);
                        khachHang.loai = oracleDataReader.GetString(9);
                        khachHang.diaChiKH = oracleDataReader.GetString(10);
                        khachHang.SDTKH = oracleDataReader.GetString(11);
                        if(oracleDataReader.GetString(12) != null)
                        {
                            khachHang.ghiChuKH = oracleDataReader.GetString(12);
                        }
                        else
                        {
                            khachHang.ghiChuKH = "";
                        }
                        list.Add(khachHang);
                    }
                }

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
