using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using DTO;
using System.Windows.Forms;

namespace DAO
{
    /// <summary>
    /// Viết Tiệp
    /// 11/02/2018
    /// </summary>
    public class NguoiDungDAO
    {
        /// <summary>
        /// Kiểm tra tài khoản người dùng có chính xác hay không
        /// Trả về đối tượng người dùng nếu tài khoản người dùng chính xác
        /// </summary>
        /// <param name="tenDangNhap"></param>
        /// <param name="matKhau"></param>
        /// <returns></returns>
        public NguoiDung TaiKhoanChinhXac(string tenDangNhap, string matKhau)
        {
            try
            {
                NguoiDung nguoiDung = new NguoiDung();

                OracleDataReader oracleDataReader;
                OracleCommand oracleCommand = new OracleCommand();

                oracleCommand.CommandText = "SELECT * FROM NGUOIDUNG WHERE TENDANGNHAP = :tenDangNhap AND MATKHAU = :matKhau";
                oracleCommand.Parameters.Add(new OracleParameter("tenDangNhap", tenDangNhap));
                oracleCommand.Parameters.Add(new OracleParameter("matKhau", matKhau));

                oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows) 
                {
                    
                    oracleDataReader.Read();

                    nguoiDung.idND = oracleDataReader.GetInt32(0);
                    nguoiDung.tenDangNhapND = oracleDataReader.GetString(1);
                    nguoiDung.matKhauND = oracleDataReader.GetString(2);
                    nguoiDung.hoTenND = oracleDataReader.GetString(3);
                    nguoiDung.chucVuND = oracleDataReader.GetString(4);
                    nguoiDung.phongBanND = oracleDataReader.GetString(5);
                    nguoiDung.quyenND = oracleDataReader.GetString(6);

                    return nguoiDung;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách người dùng 
        /// </summary>
        /// <returns></returns>
        public static List<NguoiDung> LayDSNguoiDung()
        {
            try
            {
                List<NguoiDung> list = new List<NguoiDung>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM NGUOIDUNG";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        NguoiDung nguoiDung = new NguoiDung();

                        nguoiDung.idND = oracleDataReader.GetInt32(0);
                        nguoiDung.tenDangNhapND = oracleDataReader.GetString(1);
                        nguoiDung.matKhauND = oracleDataReader.GetString(2);
                        nguoiDung.hoTenND = oracleDataReader.GetString(3);
                        nguoiDung.chucVuND = oracleDataReader.GetString(4);
                        nguoiDung.phongBanND = oracleDataReader.GetString(5);
                        nguoiDung.quyenND = oracleDataReader.GetString(6);

                        list.Add(nguoiDung);
                    }
                }

                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

