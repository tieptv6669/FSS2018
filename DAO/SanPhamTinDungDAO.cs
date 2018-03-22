using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using DTO;

namespace DAO
{
    /// <summary>
    /// Viết Tiệp
    /// 3/3/2018
    /// </summary>
    public class SanPhamTinDungDAO
    {
        /// <summary>
        /// Lấy danh sách sản phẩm tín dụng hiện có
        /// </summary>
        /// <returns></returns>
        public static List<SanPhamTinDung> GetListSPTD()
        {
            try
            {
                List<SanPhamTinDung> list = new List<SanPhamTinDung>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM SPTD";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        SanPhamTinDung sanPhamTinDung = new SanPhamTinDung();
                        sanPhamTinDung.IdSPTD = oracleDataReader.GetInt32(0);
                        sanPhamTinDung.MaSPTD = oracleDataReader.GetString(1);
                        sanPhamTinDung.TenSPTD = oracleDataReader.GetString(2);
                        sanPhamTinDung.ThoiHanVay = oracleDataReader.GetInt32(3);
                        sanPhamTinDung.LaiSuat = oracleDataReader.GetInt32(4);
                        sanPhamTinDung.LaiSuatQuaHan = oracleDataReader.GetInt32(5);
                        sanPhamTinDung.TrangThai = oracleDataReader.GetString(6);
                        sanPhamTinDung.IdNguon = oracleDataReader.GetInt32(7);
                        sanPhamTinDung.TenNguon = oracleDataReader.GetString(8);

                        list.Add(sanPhamTinDung);
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

        /// <summary>
        /// Tìm kiếm sản phẩn tín dụng theo tên, mã và nguồn
        /// </summary>
        /// <param name="tenSPTD"></param>
        /// <param name="maSPTD"></param>
        /// <param name="tenNguon"></param>
        /// <returns></returns>
        public static List<SanPhamTinDung> TimKiemSPTD(string tenSPTD, string maSPTD, string tenNguon)
        {
            try
            {
                List<SanPhamTinDung> list = new List<SanPhamTinDung>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM NGUON JOIN SPTD ON NGUON.IDNGUON = SPTD.IDNGUON " +
                    "WHERE SPTD.TENSPTD LIKE '%' || :tenSPTD || '%' AND SPTD.MASPTD LIKE '%' || :maSPTD || '%' " +
                    "AND NGUON.TENNGUON LIKE '%' || :tenNguon || '%'";
                oracleCommand.Parameters.Add("tenSPTD", tenSPTD);
                oracleCommand.Parameters.Add("maSPTD", maSPTD);
                oracleCommand.Parameters.Add("tenNguon", tenNguon);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        SanPhamTinDung sanPhamTinDung = new SanPhamTinDung();
                        sanPhamTinDung.IdSPTD = oracleDataReader.GetInt32(6);
                        sanPhamTinDung.MaSPTD = oracleDataReader.GetString(7);
                        sanPhamTinDung.TenSPTD = oracleDataReader.GetString(8);
                        sanPhamTinDung.ThoiHanVay = oracleDataReader.GetInt32(9);
                        sanPhamTinDung.LaiSuat = oracleDataReader.GetInt32(10);
                        sanPhamTinDung.LaiSuatQuaHan = oracleDataReader.GetInt32(11);
                        sanPhamTinDung.TrangThai = oracleDataReader.GetString(12);
                        sanPhamTinDung.IdNguon = oracleDataReader.GetInt32(13);
                        sanPhamTinDung.TenNguon = oracleDataReader.GetString(2);

                        list.Add(sanPhamTinDung);
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

        /// <summary>
        /// Lấy một SPTD theo tên
        /// </summary>
        /// <param name="tenSPTD"></param>
        /// <returns></returns>
        public static SanPhamTinDung GetSanPhamTinDung(string tenSPTD)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM SPTD WHERE TENSPTD = :tenSPTD";
                oracleCommand.Parameters.Add("tenSPTD", tenSPTD);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    SanPhamTinDung sanPhamTinDung = new SanPhamTinDung();
                    oracleCommand.Connection.Close();
                    oracleCommand.Connection.Dispose();
                    return sanPhamTinDung;
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
        /// Thêm mới sản phẩm tín dụng
        /// </summary>
        /// <param name="sanPhamTinDung"></param>
        /// <returns></returns>
        public static bool ThemMoiSPTD(SanPhamTinDung sanPhamTinDung)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "INSERT INTO SPTD (MASPTD, TENSPTD, THOIHANVAY, LAISUAT, LAISUATQUAHAN, TRANGTHAI, IDNGUON, TENNGUON)" +
                    "VALUES (:maSPTD, :tenSPTD, :thoiHanVay, :laiSuat, :laiSuatQuaHan, :trangThai, :idNguon, :tenNguon)";
                oracleCommand.Parameters.Add("maSPTD", sanPhamTinDung.MaSPTD);
                oracleCommand.Parameters.Add("tenSPTD", sanPhamTinDung.TenSPTD);
                oracleCommand.Parameters.Add("thoiHanVay", sanPhamTinDung.ThoiHanVay);
                oracleCommand.Parameters.Add("laiSuat", sanPhamTinDung.LaiSuat);
                oracleCommand.Parameters.Add("laiSuatQuaHan", sanPhamTinDung.LaiSuatQuaHan);
                oracleCommand.Parameters.Add("trangThai", sanPhamTinDung.TrangThai);
                oracleCommand.Parameters.Add("idNguon", sanPhamTinDung.IdNguon);
                oracleCommand.Parameters.Add("tenNguon", sanPhamTinDung.TenNguon);

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
        /// Lấy danh sách sản phẩm tín dụng ngoại trừ sản phẩm tín dụng có tên 'tenSPTD'
        /// </summary>
        /// <param name="tenSPTD"></param>
        /// <returns></returns>
        public static List<SanPhamTinDung> GetListSPTD(string tenSPTD)
        {
            try
            {
                List<SanPhamTinDung> list = new List<SanPhamTinDung>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM SPTD WHERE TENSPTD <> :tenSPTD";
                oracleCommand.Parameters.Add("tenSPTD", tenSPTD);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        SanPhamTinDung sanPhamTinDung = new SanPhamTinDung();
                        sanPhamTinDung.IdSPTD = oracleDataReader.GetInt32(0);
                        sanPhamTinDung.MaSPTD = oracleDataReader.GetString(1);
                        sanPhamTinDung.TenSPTD = oracleDataReader.GetString(2);
                        sanPhamTinDung.ThoiHanVay = oracleDataReader.GetInt32(3);
                        sanPhamTinDung.LaiSuat = oracleDataReader.GetInt32(4);
                        sanPhamTinDung.LaiSuatQuaHan = oracleDataReader.GetInt32(5);
                        sanPhamTinDung.TrangThai = oracleDataReader.GetString(6);
                        sanPhamTinDung.IdNguon = oracleDataReader.GetInt32(7);

                        list.Add(sanPhamTinDung);
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
        public static bool SuaSPTD(string maSPTD, string tenSPTD, int thoiHanVay, int laiSuat, int laiSuatQuaHan, string trangThai)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE SPTD SET TENSPTD = :tenSPTD, THOIHANVAY = :thoiHanVay, " +
                    "LAISUAT = :laiSuat, LAISUATQUAHAN = :laiSuatQuaHan, " +
                    "TRANGTHAI = :trangThai WHERE MASPTD = :maSPTD";
                oracleCommand.Parameters.Add("tenSPTD", tenSPTD);
                oracleCommand.Parameters.Add("thoiHanVay", thoiHanVay);
                oracleCommand.Parameters.Add("laiSuat", laiSuat);
                oracleCommand.Parameters.Add("laiSuatQuaHan", laiSuatQuaHan);
                oracleCommand.Parameters.Add("trangThai", trangThai);
                oracleCommand.Parameters.Add("maSPTD", maSPTD);

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
        /// Lấy danh sách các SPTD còn hoạt động
        /// </summary>
        /// <returns></returns>
        public static List<SanPhamTinDung> GetList()
        {
            try
            {
                List<SanPhamTinDung> list = new List<SanPhamTinDung>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM SPTD WHERE TRANGTHAI = 'Hoạt động'";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        SanPhamTinDung sanPhamTinDung = new SanPhamTinDung();
                        sanPhamTinDung.IdSPTD = oracleDataReader.GetInt32(0);
                        sanPhamTinDung.MaSPTD = oracleDataReader.GetString(1);
                        sanPhamTinDung.TenSPTD = oracleDataReader.GetString(2);
                        sanPhamTinDung.ThoiHanVay = oracleDataReader.GetInt32(3);
                        sanPhamTinDung.LaiSuat = oracleDataReader.GetInt32(4);
                        sanPhamTinDung.LaiSuatQuaHan = oracleDataReader.GetInt32(5);
                        sanPhamTinDung.TrangThai = oracleDataReader.GetString(6);
                        sanPhamTinDung.IdNguon = oracleDataReader.GetInt32(7);
                        sanPhamTinDung.TenNguon = oracleDataReader.GetString(8);

                        list.Add(sanPhamTinDung);
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

        /// <summary>
        /// Lấy một sptd khi biết mã SPTD
        /// </summary>
        /// <param name="maSPTD"></param>
        /// <returns></returns>
        public static SanPhamTinDung LaySanPhamTinDung(string maSPTD)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM SPTD WHERE MASPTD = :maSPTD";
                oracleCommand.Parameters.Add("maSPTD", maSPTD);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    oracleDataReader.Read();
                    SanPhamTinDung sanPhamTinDung = new SanPhamTinDung();
                    sanPhamTinDung.IdSPTD = oracleDataReader.GetInt32(0);
                    sanPhamTinDung.MaSPTD = oracleDataReader.GetString(1);
                    sanPhamTinDung.TenSPTD = oracleDataReader.GetString(2);
                    sanPhamTinDung.ThoiHanVay = oracleDataReader.GetInt32(3);
                    sanPhamTinDung.LaiSuat = oracleDataReader.GetInt32(4);
                    sanPhamTinDung.LaiSuatQuaHan = oracleDataReader.GetInt32(5);
                    sanPhamTinDung.TrangThai = oracleDataReader.GetString(6);
                    sanPhamTinDung.IdNguon = oracleDataReader.GetInt32(7);
                    sanPhamTinDung.TenNguon = oracleDataReader.GetString(8);

                    oracleCommand.Connection.Close();
                    oracleCommand.Connection.Dispose();
                    return sanPhamTinDung;
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
        /// Lấy ds sản phẩm tín dụng có trạng thái Hoạt động
        /// </summary>
        /// <returns></returns>
        public static List<SanPhamTinDung> GetListSPTDHD(string tenSPTD)
        {
            try
            {
                List<SanPhamTinDung> list = new List<SanPhamTinDung>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM SPTD WHERE TRANGTHAI = 'Hoạt động' AND TENSPTD = :tenSPTD";
                oracleCommand.Parameters.Add("tenSPTD", tenSPTD);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        SanPhamTinDung sanPhamTinDung = new SanPhamTinDung();
                        sanPhamTinDung.IdSPTD = oracleDataReader.GetInt32(0);
                        sanPhamTinDung.MaSPTD = oracleDataReader.GetString(1);
                        sanPhamTinDung.TenSPTD = oracleDataReader.GetString(2);
                        sanPhamTinDung.ThoiHanVay = oracleDataReader.GetInt32(3);
                        sanPhamTinDung.LaiSuat = oracleDataReader.GetInt32(4);
                        sanPhamTinDung.LaiSuatQuaHan = oracleDataReader.GetInt32(5);
                        sanPhamTinDung.TrangThai = oracleDataReader.GetString(6);
                        sanPhamTinDung.IdNguon = oracleDataReader.GetInt32(7);
                        sanPhamTinDung.TenNguon = oracleDataReader.GetString(8);

                        list.Add(sanPhamTinDung);
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

        /// <summary>
        /// Lấy sản phẩm tín dụng khi biết id sptd
        /// </summary>
        /// <param name="idSPTD"></param>
        /// <returns></returns>
        public static SanPhamTinDung GetSanPhamTinDungWithID(int idSPTD)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM SPTD WHERE IDSPTD = :idSPTD";
                oracleCommand.Parameters.Add("idSPTD", idSPTD);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if(oracleDataReader != null && oracleDataReader.HasRows)
                {
                    oracleDataReader.Read();
                    SanPhamTinDung sanPhamTinDung = new SanPhamTinDung();
                    sanPhamTinDung.IdSPTD = oracleDataReader.GetInt32(0);
                    sanPhamTinDung.MaSPTD = oracleDataReader.GetString(1);
                    sanPhamTinDung.TenSPTD = oracleDataReader.GetString(2);
                    sanPhamTinDung.ThoiHanVay = oracleDataReader.GetInt32(3);
                    sanPhamTinDung.LaiSuat = oracleDataReader.GetInt32(4);
                    sanPhamTinDung.LaiSuatQuaHan = oracleDataReader.GetInt32(5);
                    sanPhamTinDung.TrangThai = oracleDataReader.GetString(6);
                    sanPhamTinDung.IdNguon = oracleDataReader.GetInt32(7);
                    sanPhamTinDung.TenNguon = oracleDataReader.GetString(8);

                    oracleCommand.Connection.Close();
                    oracleCommand.Connection.Dispose();
                    return sanPhamTinDung;
                }
                else
                {
                    return null;
                }
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
