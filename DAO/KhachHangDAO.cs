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
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy ra 1 khách hàng khi biết số TKLK
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <returns></returns>
        public static KhachHang layMotKhachHang(string soTKLK)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM KHACHHANG WHERE SOTKLK = :soTKLK";

                oracleCommand.Parameters.Add(new OracleParameter("soTKLK", soTKLK));

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    oracleDataReader.Read();
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

                    return khachHang;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <param name="hoTenKH"></param>
        /// <param name="loai"></param>
        /// <param name="ngaySinhKH"></param>
        /// <param name="gioiTinhKH"></param>
        /// <param name="ngheNghiepKH"></param>
        /// <param name="soCMNNKH"></param>
        /// <param name="diaChiKH"></param>
        /// <param name="emailKH"></param>
        /// <param name="SDTKH"></param>
        /// <param name="ghiChuKH"></param>
        /// <returns></returns>
        public static bool suaThongTinKH(string soTKLK, string hoTenKH, string loai, DateTime ngaySinhKH, 
            string gioiTinhKH, string ngheNghiepKH, string soCMNNKH, string diaChiKH, 
            string emailKH, string SDTKH, string ghiChuKH)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE KHACHHANG SET HOTENKH = :hoTenKH, LOAIKH = :loai," +
                    " NGAYSINH = :ngaySinhKH, GIOITINH = :gioiTinhKH, NGHENGHIEP = :ngheNghiepKH," +
                    " SOCMND = :soCMNNKH, DIACHI = :diaChiKH, EMAIL = :emailKH, SDT = :SDTKH," +
                    " GHICHU = :ghiChuKH WHERE SOTKLK = :soTKLK";
                oracleCommand.Parameters.Add(new OracleParameter("hoTenKH", hoTenKH));
                oracleCommand.Parameters.Add(new OracleParameter("loai", loai));
                oracleCommand.Parameters.Add(new OracleParameter("ngaySinhKH", ngaySinhKH));
                oracleCommand.Parameters.Add(new OracleParameter("gioiTinhKH", gioiTinhKH));
                oracleCommand.Parameters.Add(new OracleParameter("ngheNghiepKH", ngheNghiepKH));
                oracleCommand.Parameters.Add(new OracleParameter("soCMNNKH", soCMNNKH));
                oracleCommand.Parameters.Add(new OracleParameter("diaChiKH", diaChiKH));
                oracleCommand.Parameters.Add(new OracleParameter("emailKH", emailKH));
                oracleCommand.Parameters.Add(new OracleParameter("SDTKH", SDTKH));
                oracleCommand.Parameters.Add(new OracleParameter("ghiChuKH", ghiChuKH));
                oracleCommand.Parameters.Add(new OracleParameter("soTKLK", soTKLK));
                return DataProvider.ExcuteNonQuery(oracleCommand);
            }
            catch(Exception e)
            {
                MessageBox.Show("Lỗi: "+ e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Thêm khách hàng
        /// </summary>
        /// <param name="khachHang"></param>
        /// <returns></returns>
        public static bool ThemKH(KhachHang khachHang)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "INSERT INTO KHACHHANG (SOTKLK, HOTENKH, NGAYSINH, NGAYMOTK, NGHENGHIEP, SOCMND, EMAIL, GIOITINH, LOAIKH, DIACHI, SDT, GHICHU) " +
                    "VALUES (:soTKLK, :hotenKH, :ngaysinh, :ngayMoTK, :ngheNghiep, :soCMND, :email, :gioiTinh, :loaiKH, :diaChi, :sdt, :ghiChu)";
                oracleCommand.Parameters.Add("soTKLK", khachHang.STKLK);
                oracleCommand.Parameters.Add("hotenKH", khachHang.hoTenKH);
                oracleCommand.Parameters.Add("ngaysinh", khachHang.ngaySinhKH);
                oracleCommand.Parameters.Add("ngayMoTK", khachHang.ngayMoTKKH);
                oracleCommand.Parameters.Add("ngheNghiep", khachHang.ngheNghiepKH);
                oracleCommand.Parameters.Add("soCMND", khachHang.soCMNNKH);
                oracleCommand.Parameters.Add("email", khachHang.emailKH);
                oracleCommand.Parameters.Add("gioiTinh", khachHang.gioiTinhKH);
                oracleCommand.Parameters.Add("loaiKH", khachHang.loai);
                oracleCommand.Parameters.Add("diaChi", khachHang.diaChiKH);
                oracleCommand.Parameters.Add("sdt", khachHang.SDTKH);
                oracleCommand.Parameters.Add("ghiChu", khachHang.ghiChuKH);

                return DataProvider.ExcuteNonQuery(oracleCommand);
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
