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

                oracleCommand.CommandText = "SELECT * FROM NGUOIDUNG WHERE TENDANGNHAP = :tenDangNhap AND MATKHAU = :matKhau AND TRANGTHAI = '1'";
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
                    nguoiDung.trangthaiND = oracleDataReader.GetInt32(7);

                    oracleCommand.Connection.Dispose();
                    return nguoiDung;
                }
                else
                {
                    oracleCommand.Connection.Dispose();
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
                oracleCommand.CommandText = "SELECT * FROM NGUOIDUNG WHERE TRANGTHAI = '1'";

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
                        nguoiDung.trangthaiND = oracleDataReader.GetInt32(7);

                        list.Add(nguoiDung);
                    }
                }

                oracleCommand.Connection.Dispose();
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Thêm người dùng mới vào CSDL
        /// </summary>
        /// <param name="nguoiDung"></param>
        /// <returns></returns>
        public static bool ThemNguoiDung(NguoiDung nguoiDung)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "INSERT INTO NGUOIDUNG (TENDANGNHAP, MATKHAU, HOTEN, CHUCVU, PHONGBAN, QUYEN, TRANGTHAI) " +
                    "VALUES (:tenDangNhap, :matKhau, :hoTen, :chucVu, :phongBan, :quyen, :trangThai)";
                oracleCommand.Parameters.Add(new OracleParameter("tenDangNhap", nguoiDung.tenDangNhapND));
                oracleCommand.Parameters.Add(new OracleParameter("matKhau", nguoiDung.matKhauND));
                oracleCommand.Parameters.Add(new OracleParameter("hoTen", nguoiDung.hoTenND));
                oracleCommand.Parameters.Add(new OracleParameter("chucVu", nguoiDung.chucVuND));
                oracleCommand.Parameters.Add(new OracleParameter("phongBan", nguoiDung.phongBanND));
                oracleCommand.Parameters.Add(new OracleParameter("quyen", nguoiDung.quyenND));
                oracleCommand.Parameters.Add(new OracleParameter("trangThai", nguoiDung.trangthaiND));

                bool kt = DataProvider.ExcuteNonQuery(oracleCommand);
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
        /// Tìm kiếm người dùng theo tên người dùng và tên đăng nhập
        /// </summary>
        /// <param name="tenNguoiDung"></param>
        /// <param name="tenDangNhap"></param>
        /// <returns></returns>
        public static List<NguoiDung> TimKiemNguoiDung(string tenNguoiDung, string tenDangNhap)
        {
            try
            {
                List<NguoiDung> list = new List<NguoiDung>();
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM NGUOIDUNG " +
                    "WHERE TRANGTHAI = '1' AND HOTEN LIKE '%' || :tenNguoiDung || '%' " +
                    "AND TENDANGNHAP LIKE '%' || :tenDangNhap || '%'";
                oracleCommand.Parameters.Add(new OracleParameter("tenNguoiDung", tenNguoiDung));
                oracleCommand.Parameters.Add(new OracleParameter("tenDangNhap", tenDangNhap));

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if(oracleDataReader != null && oracleDataReader.HasRows)
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
                        nguoiDung.trangthaiND = oracleDataReader.GetInt32(7);

                        list.Add(nguoiDung);
                    }
                }

                oracleCommand.Connection.Dispose();
                return list;
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Sửa thông tin người dùng 
        /// </summary>
        /// <param name="tenDN"></param>
        /// <param name="hoTen"></param>
        /// <param name="chucVu"></param>
        /// <param name="phongBan"></param>
        /// <param name="quyen"></param>
        /// <returns></returns>
        public static bool SuaThongTinNguoiDung(string tenDN, string hoTen, string chucVu, string phongBan, string quyen)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE NGUOIDUNG SET HOTEN = :hoTen, " +
                    "CHUCVU = :chucVu, " +
                    "PHONGBAN = :phongBan, " +
                    "QUYEN = :quyen WHERE TENDANGNHAP = :tenDN";
                oracleCommand.Parameters.Add(new OracleParameter("hoTen", hoTen));
                oracleCommand.Parameters.Add(new OracleParameter("chucVu", chucVu));
                oracleCommand.Parameters.Add(new OracleParameter("phongBan", phongBan));
                oracleCommand.Parameters.Add(new OracleParameter("quyen", quyen));
                oracleCommand.Parameters.Add(new OracleParameter("tenDN", tenDN));

                bool kt = DataProvider.ExcuteNonQuery(oracleCommand);
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
        /// Xóa người dùng
        /// </summary>
        /// <param name="tenDN"></param>
        /// <returns></returns>
        public static bool XoaNguoiDung(string tenDN)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE NGUOIDUNG SET TRANGTHAI = '0' WHERE TENDANGNHAP = :tenDN";
                oracleCommand.Parameters.Add(new OracleParameter("tenDN", tenDN));

                bool kt = DataProvider.ExcuteNonQuery(oracleCommand);
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
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="tenDN"></param>
        /// <param name="MatKhauMoi"></param>
        /// <returns></returns>
        public static bool DoiMatKhau(string tenDN, string MatKhauMoi)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE NGUOIDUNG SET MATKHAU = :matKhau WHERE TENDANGNHAP = :tenDN";
                oracleCommand.Parameters.Add(new OracleParameter("matKhau", MatKhauMoi));
                oracleCommand.Parameters.Add(new OracleParameter("tenDN", tenDN));

                bool kt = DataProvider.ExcuteNonQuery(oracleCommand);
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
        /// Reset mật khẩu người dùng 
        /// </summary>
        /// <param name="tenDN"></param>
        /// <returns></returns>
        public static bool ResetMatKhau(string tenDN)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE NGUOIDUNG SET MATKHAU = :matKhau WHERE TENDANGNHAP = :tenDN";
                oracleCommand.Parameters.Add(new OracleParameter("matKhau", tenDN));
                oracleCommand.Parameters.Add(new OracleParameter("tenDN", tenDN));

                bool kt = DataProvider.ExcuteNonQuery(oracleCommand);
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
        /// Lấy người dùng khi biết tên đăng nhập
        /// </summary>
        /// <param name="tenDN"></param>
        /// <returns></returns>
        public static NguoiDung GetNguoiDung(string tenDN)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM NGUOIDUNG WHERE TENDANGNHAP = :tenDangNhap AND TRANGTHAI = '1'";
                oracleCommand.Parameters.Add("tenDangNhap", tenDN);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                oracleDataReader.Read();
                NguoiDung nguoiDung = new NguoiDung();
                nguoiDung.matKhauND = oracleDataReader.GetString(2);

                oracleCommand.Connection.Dispose();
                return nguoiDung;
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}

