using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using DTO;
using System.Windows.Forms;

namespace DAO
{
    /// <summary>
    /// Thùy Linh
    /// 5/3/2018
    /// </summary>
    public class GiaiNganDAO
    {
        /// <summary>
        /// Tìm kiếm giải ngân theo số TKLK
        /// </summary>
        /// <param name="soTKLK"></param>
        /// <returns></returns>
        public static List<GN_KH> TimKiemGN(string soTKLK)
        {
            try
            {
                List<GN_KH> list = new List<GN_KH>();
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT KHACHHANG.SOTKLK,GIAINGAN.MAGN,GIAINGAN.SOTIENGN,GIAINGAN.TRANGTHAI,GIAINGAN.DUNOGOC,GIAINGAN.DUNOLAITRONGHAN,GIAINGAN.DUNOLAINGOAIHAN,KHACHHANG.HOTENKH " +
                    "FROM GIAINGAN,KHACHHANG " +
                    "WHERE GIAINGAN.IDKH = KHACHHANG.IDKHACHHANG AND SOTKLK = :SOTKLK";
                oracleCommand.Parameters.Add(new OracleParameter("SOTKLK", soTKLK));

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        GN_KH gN_KH = new GN_KH();
                        gN_KH.SoTKLK = oracleDataReader.GetString(0);
                        gN_KH.MaGN = oracleDataReader.GetString(1);
                        gN_KH.SoTienGN = oracleDataReader.GetInt32(2);
                        gN_KH.TrangThai = oracleDataReader.GetString(3);
                        gN_KH.DuNoGoc = oracleDataReader.GetInt32(4);
                        gN_KH.DuNoLaiTrongHan = oracleDataReader.GetInt32(5);
                        gN_KH.DuNoLaiQuaHan = oracleDataReader.GetInt32(6);
                        gN_KH.TenKH = oracleDataReader.GetString(7);
                        list.Add(gN_KH);
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
        /// Xem chi tiết giải ngân
        /// </summary>
        /// <param name="maGN"></param>
        /// <returns></returns>
        public static GN_SPTD_NGUON xemChiTietGN(string maGN)
        {
            try
            {
                GN_SPTD_NGUON gn_sptd_nguon = new GN_SPTD_NGUON();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "select KHACHHANG.SOTKLK,GIAINGAN.MAGN,SPTD.TENSPTD,SPTD.LAISUAT,SPTD.LAISUATQUAHAN,SPTD.THOIHANVAY,GIAINGAN.DUNOGOC,GIAINGAN.DUNOLAITRONGHAN,GIAINGAN.DUNOLAINGOAIHAN,KHACHHANG.HOTENKH,GIAINGAN.SOTIENGN,GIAINGAN.TRANGTHAI,NGUON.TENNGUON,GIAINGAN.NGAYGN,GIAINGAN.NGAYDAOHAN,GIAINGAN.GHICHU" +
                    " from KHACHHANG,SPTD,GIAINGAN,NGUON " +
                     "where GIAINGAN.IDSPTD = SPTD.IDSPTD and SPTD.IDNGUON = NGUON.IDNGUON " +
                     "and GIAINGAN.IDKH = KHACHHANG.IDKHACHHANG and GIAINGAN.MAGN = :maGN";
                 oracleCommand.Parameters.Add(new OracleParameter("maGN", maGN));

                 OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                 if (oracleDataReader != null && oracleDataReader.HasRows)
                 {
                    oracleDataReader.Read();

                    gn_sptd_nguon.SoTKLK = oracleDataReader.GetString(0);
                    gn_sptd_nguon.MaGN = oracleDataReader.GetString(1);
                    gn_sptd_nguon.TenSPTD = oracleDataReader.GetString(2);
                    gn_sptd_nguon.LaiSuat = oracleDataReader.GetInt32(3);
                    gn_sptd_nguon.LaiSuatQuaHan = oracleDataReader.GetInt32(4);
                    gn_sptd_nguon.KyHan = oracleDataReader.GetInt32(5);
                    gn_sptd_nguon.DuNoGoc = oracleDataReader.GetInt32(6);
                    gn_sptd_nguon.DuNoLaiNH = oracleDataReader.GetInt32(8);
                    gn_sptd_nguon.TenKH = oracleDataReader.GetString(9);
                    gn_sptd_nguon.SoTienGN = oracleDataReader.GetInt32(10);
                    gn_sptd_nguon.TrangThai = oracleDataReader.GetString(11);
                    gn_sptd_nguon.TenNguon = oracleDataReader.GetString(12);
                    gn_sptd_nguon.NgayGN = oracleDataReader.GetDateTime(13);
                    gn_sptd_nguon.NgayDH = oracleDataReader.GetDateTime(14);
                    gn_sptd_nguon.GhiChu = oracleDataReader.GetString(15);

                    return gn_sptd_nguon;
                }
                else {
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
        /// Thêm giải ngân
        /// </summary>
        /// <param name="giaiNgan"></param>
        /// <returns></returns>
        public static bool themGN(GiaiNgan giaiNgan)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "INSERT INTO GIAINGAN (IDGN, MAGN, SOTIENGN, DUNOGOC, DUNOLAITRONGHAN, DUNOLAINGOAIHAN, NGAYGN, NGAYDAOHAN, IDKH, IDSPTD, TRANGTHAI, GHICHU) " +
                    "VALUES (:idGN, :maGN, :soTienGN, :duNoGoc, :duNoLaiTH, :duNoLaiNH, :ngayGN, :ngayDH, :idKH, :idSPTD, :trangThai, :ghiChu)";
                oracleCommand.Parameters.Add(new OracleParameter("idGN", giaiNgan.IDGN));
                oracleCommand.Parameters.Add(new OracleParameter("maGN", giaiNgan.MaGN));
                oracleCommand.Parameters.Add(new OracleParameter("soTienGN", giaiNgan.SoTienGN));
                oracleCommand.Parameters.Add(new OracleParameter("duNoGoc", giaiNgan.DuNoGoc));
                oracleCommand.Parameters.Add(new OracleParameter("duNoLaiTH", giaiNgan.DuNoLaiTrongHan));
                oracleCommand.Parameters.Add(new OracleParameter("duNoLaiNH", giaiNgan.DuNoLaiNgoaiHan));
                oracleCommand.Parameters.Add(new OracleParameter("ngayGN", giaiNgan.NgayGN));
                oracleCommand.Parameters.Add(new OracleParameter("ngayDH", giaiNgan.NgayDaoHan));
                oracleCommand.Parameters.Add(new OracleParameter("idKH", giaiNgan.IDKH));
                oracleCommand.Parameters.Add(new OracleParameter("idKH", giaiNgan.IDSPTD));
                oracleCommand.Parameters.Add(new OracleParameter("trangThai", giaiNgan.TrangThai));
                oracleCommand.Parameters.Add(new OracleParameter("ghiChu", giaiNgan.GhiChu));

                return DataProvider.ExcuteNonQuery(oracleCommand);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách giải ngân hiện có
        /// </summary>
        /// <returns></returns>
        public static List<GiaiNgan> layDSGN()
        {
            try
            {
                List<GiaiNgan> list = new List<GiaiNgan>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM GIAINGAN";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        GiaiNgan giaiNgan = new GiaiNgan();
                        giaiNgan.MaGN = oracleDataReader.GetString(1);
                        giaiNgan.SoTienGN = oracleDataReader.GetInt32(2);
                        giaiNgan.DuNoGoc = oracleDataReader.GetInt32(2);
                        giaiNgan.DuNoLaiTrongHan = oracleDataReader.GetInt32(2);
                        giaiNgan.DuNoLaiNgoaiHan = oracleDataReader.GetInt32(2);
                        giaiNgan.NgayGN = oracleDataReader.GetDateTime(2);
                        giaiNgan.NgayDaoHan = oracleDataReader.GetDateTime(2);
                        giaiNgan.IDKH = oracleDataReader.GetInt32(2);
                        giaiNgan.IDSPTD = oracleDataReader.GetInt32(2);
                        giaiNgan.TrangThai = oracleDataReader.GetString(2);
                        giaiNgan.GhiChu = oracleDataReader.GetString(2);

                        list.Add(giaiNgan);
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
