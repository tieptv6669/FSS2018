using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace DAO
{
    /// <summary>
    /// Viết Tiệp
    /// 19/3/2018
    /// </summary>
    public class ReportDAO
    {
        /// <summary>
        /// Lấy DS KH có lớn hơn 3 món GN nợ quá hạn
        /// </summary>
        /// <returns></returns>
        public static List<DSDuNoA> GetListDSDuNoA(DateTime ngayHT)
        {
            try
            {
                List<DSDuNoA> list = new List<DSDuNoA>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, KHACHHANG.SOCMND, KHACHHANG.SDT, COUNT(*) AS SLGN " +
                    "FROM KHACHHANG,GIAINGAN WHERE KHACHHANG.IDKHACHHANG = GIAINGAN.IDKH AND GIAINGAN.NGAYDAOHAN < :ngayHT AND TRANGTHAI = 'Còn nợ' " +
                    "GROUP BY KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, KHACHHANG.SOCMND, KHACHHANG.SDT HAVING COUNT(*) > 3";
                oracleCommand.Parameters.Add("ngayHT", ngayHT);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        DSDuNoA dSDuNoA = new DSDuNoA();
                        dSDuNoA.STKLK = oracleDataReader.GetString(0);
                        dSDuNoA.TenKH = oracleDataReader.GetString(1);
                        dSDuNoA.SoCMND = oracleDataReader.GetString(2);
                        dSDuNoA.SDT = oracleDataReader.GetString(3);
                        dSDuNoA.SLGNQuaHan = oracleDataReader.GetInt32(4);

                        list.Add(dSDuNoA);
                    }
                }

                oracleCommand.Connection.Dispose();
                return list;
            } catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy danh sách KH có nhiều hơn 5 món giải ngân đang nợ
        /// </summary>
        /// <returns></returns>
        public static List<DSDuNoB> GetListDSDuNoB()
        {
            try
            {
                List<DSDuNoB> list = new List<DSDuNoB>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, KHACHHANG.SOCMND, KHACHHANG.SDT, COUNT(*) AS SLGN " +
                    "FROM KHACHHANG,GIAINGAN WHERE KHACHHANG.IDKHACHHANG = GIAINGAN.IDKH AND TRANGTHAI = 'Còn nợ' " +
                    "GROUP BY KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, KHACHHANG.SOCMND, KHACHHANG.SDT HAVING COUNT(*) > 5";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        DSDuNoB dSDuNoB = new DSDuNoB();
                        dSDuNoB.STKLK = oracleDataReader.GetString(0);
                        dSDuNoB.TenKH = oracleDataReader.GetString(1);
                        dSDuNoB.SoCMND = oracleDataReader.GetString(2);
                        dSDuNoB.SDT = oracleDataReader.GetString(3);
                        dSDuNoB.SLGN = oracleDataReader.GetInt32(4);

                        list.Add(dSDuNoB);
                    }
                }

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
        /// Lấy danh sách các khách hàng không có món giải ngân nào quá hạn
        /// </summary>
        /// <param name="ngayHT"></param>
        /// <returns></returns>
        public static List<DSDuNoC> GetListDSDuNoC(DateTime ngayHT)
        {
            try
            {
                List<DSDuNoC> list = new List<DSDuNoC>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, KHACHHANG.SOCMND, KHACHHANG.SDT, KHACHHANG.LOAIKH " +
                    "FROM KHACHHANG,GIAINGAN WHERE GIAINGAN.IDKH NOT IN " +
                    "(SELECT GIAINGAN.IDKH FROM GIAINGAN WHERE GIAINGAN.NGAYDAOHAN < :ngayHT AND GIAINGAN.TRANGTHAI = 'Còn nợ') " +
                    "AND KHACHHANG.IDKHACHHANG = GIAINGAN.IDKH GROUP BY KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, KHACHHANG.SOCMND, KHACHHANG.SDT, KHACHHANG.LOAIKH";
                oracleCommand.Parameters.Add("ngayHT", ngayHT);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        DSDuNoC dSDuNoC = new DSDuNoC();
                        dSDuNoC.SoTKLK = oracleDataReader.GetString(0);
                        dSDuNoC.TenKH = oracleDataReader.GetString(1);
                        dSDuNoC.SoCMND = oracleDataReader.GetString(2);
                        dSDuNoC.SDT = oracleDataReader.GetString(3);
                        dSDuNoC.LoaiKH = oracleDataReader.GetString(4);

                        list.Add(dSDuNoC);
                    }
                }

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
        /// Lấy danh sách các khách hàng đã hoàn thành tất cả các món giải ngân hiện có
        /// </summary>
        /// <returns></returns>
        public static List<DSDuNoC> GetListDSHetNo()
        {
            try
            {
                List<DSDuNoC> list = new List<DSDuNoC>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, KHACHHANG.SOCMND, KHACHHANG.SDT, KHACHHANG.LOAIKH " +
                    "FROM KHACHHANG,GIAINGAN WHERE GIAINGAN.IDKH NOT IN (SELECT GIAINGAN.IDKH FROM GIAINGAN " +
                    "WHERE GIAINGAN.TRANGTHAI = 'Còn nợ') AND KHACHHANG.IDKHACHHANG = GIAINGAN.IDKH " +
                    "GROUP BY KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, KHACHHANG.SOCMND, KHACHHANG.SDT, KHACHHANG.LOAIKH";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        DSDuNoC dSDuNoC = new DSDuNoC();
                        dSDuNoC.SoTKLK = oracleDataReader.GetString(0);
                        dSDuNoC.TenKH = oracleDataReader.GetString(1);
                        dSDuNoC.SoCMND = oracleDataReader.GetString(2);
                        dSDuNoC.SDT = oracleDataReader.GetString(3);
                        dSDuNoC.LoaiKH = oracleDataReader.GetString(4);

                        list.Add(dSDuNoC);
                    }
                }

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
        /// Lấy danh sách KH có tổng dư nợ > 500 triệu
        /// </summary>
        /// <returns></returns>
        public static List<DSDuNoE> GetListDSDuNoE()
        {
            try
            {
                List<DSDuNoE> list = new List<DSDuNoE>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, KHACHHANG.SOCMND, " +
                    "KHACHHANG.SDT, SUM(DUNOGOC + DUNOLAINGOAIHAN + DUNOLAITRONGHAN) " +
                    "FROM KHACHHANG,GIAINGAN WHERE KHACHHANG.IDKHACHHANG = GIAINGAN.IDKH AND GIAINGAN.TRANGTHAI = 'Còn nợ' " +
                    "GROUP BY KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, KHACHHANG.SOCMND, KHACHHANG.SDT " +
                    "HAVING SUM(DUNOGOC + DUNOLAINGOAIHAN + DUNOLAITRONGHAN) > 500000000";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        DSDuNoE dSDuNoE = new DSDuNoE();
                        dSDuNoE.SoTKLK = oracleDataReader.GetString(0);
                        dSDuNoE.TenKH = oracleDataReader.GetString(1);
                        dSDuNoE.SoCMND = oracleDataReader.GetString(2);
                        dSDuNoE.SDT = oracleDataReader.GetString(3);
                        dSDuNoE.TongDuNo = oracleDataReader.GetInt64(4).ToString("#,##0");

                        list.Add(dSDuNoE);
                    }
                }

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
        /// Lấy danh sách sản phẩm tín dụng có ít hơn 5 KH sử dụng 
        /// </summary>
        /// <returns></returns>
        public static List<DSSPTDA> GetListDSSPTDA()
        {
            try
            {
                List<DSSPTDA> list = new List<DSSPTDA>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT SPTD.MASPTD, SPTD.TENSPTD, SPTD.TENNGUON, COUNT(*) " +
                    "FROM SPTD,KH_SPTD WHERE KH_SPTD.IDSPTD = SPTD.IDSPTD AND KH_SPTD.TRANGTHAI = 'Sử dụng' " +
                    "GROUP BY SPTD.MASPTD, SPTD.TENSPTD, SPTD.TENNGUON HAVING COUNT(*) < 5";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if(oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        DSSPTDA dSSPTDA = new DSSPTDA();
                        dSSPTDA.MaSPTD = oracleDataReader.GetString(0);
                        dSSPTDA.TenSPTD = oracleDataReader.GetString(1);
                        dSSPTDA.TenNguon = oracleDataReader.GetString(2);
                        dSSPTDA.SlKH = oracleDataReader.GetInt32(3);

                        list.Add(dSSPTDA);
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
        /// Lấy danh sách các sản phẩm tín dụng có nhiều hơn 10 KH sử dụng
        /// </summary>
        /// <returns></returns>
        public static List<DSSPTDB> GetListDSSPTDB()
        {
            try
            {
                List<DSSPTDB> list = new List<DSSPTDB>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT SPTD.MASPTD, SPTD.TENSPTD, SPTD.TENNGUON, COUNT(*) " +
                    "FROM SPTD,KH_SPTD WHERE KH_SPTD.IDSPTD = SPTD.IDSPTD AND KH_SPTD.TRANGTHAI = 'Sử dụng' " +
                    "GROUP BY SPTD.MASPTD, SPTD.TENSPTD, SPTD.TENNGUON HAVING COUNT(*) > 10";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        DSSPTDB dSSPTDB = new DSSPTDB();
                        dSSPTDB.MaSPTD = oracleDataReader.GetString(0);
                        dSSPTDB.TenSPTD = oracleDataReader.GetString(1);
                        dSSPTDB.TenNguon = oracleDataReader.GetString(2);
                        dSSPTDB.SlKH = oracleDataReader.GetInt32(3);

                        list.Add(dSSPTDB);
                    }
                }

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
        /// Lấy DS các món GN nợ quá hạn từ 2 tháng trở lên
        /// </summary>
        /// <param name="gioHT"></param>
        /// <returns></returns>
        public static List<DSGNA> GetListDSGNA(DateTime gioHT)
        {
            try
            {
                gioHT = gioHT.AddMonths(-2);

                List<DSGNA> list = new List<DSGNA>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT GIAINGAN.MAGN, KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, " +
                    "GIAINGAN.DUNOGOC + GIAINGAN.DUNOLAITRONGHAN + GIAINGAN.DUNOLAINGOAIHAN, GIAINGAN.NGAYDAOHAN " +
                    "FROM GIAINGAN, KHACHHANG WHERE GIAINGAN.IDKH = KHACHHANG.IDKHACHHANG " +
                    "AND GIAINGAN.TRANGTHAI = 'Còn nợ' AND GIAINGAN.NGAYDAOHAN < :gioHT";
                oracleCommand.Parameters.Add("gioHT", gioHT);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                if(oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        DSGNA dSGNA = new DSGNA();
                        dSGNA.MaGN = oracleDataReader.GetString(0);
                        dSGNA.SoTKLK = oracleDataReader.GetString(1);
                        dSGNA.TenKH = oracleDataReader.GetString(2);
                        dSGNA.DuNo = oracleDataReader.GetInt64(3).ToString("#,##0");
                        dSGNA.NgayDH = oracleDataReader.GetDateTime(4).ToShortDateString();

                        list.Add(dSGNA);
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
        /// Lấy danh sách các món GN có dư nợ lãi > 10 triệu
        /// </summary>
        /// <returns></returns>
        public static List<DSGNB> GetListDSGNB()
        {
            try
            {
                List<DSGNB> list = new List<DSGNB>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT GIAINGAN.MAGN, KHACHHANG.SOTKLK, KHACHHANG.HOTENKH, " +
                    "GIAINGAN.DUNOLAITRONGHAN + GIAINGAN.DUNOLAINGOAIHAN, GIAINGAN.NGAYDAOHAN " +
                    "FROM GIAINGAN, KHACHHANG WHERE GIAINGAN.IDKH = KHACHHANG.IDKHACHHANG " +
                    "AND GIAINGAN.TRANGTHAI = 'Còn nợ' AND GIAINGAN.DUNOLAITRONGHAN + GIAINGAN.DUNOLAINGOAIHAN > 10000000";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        DSGNB dSGNB = new DSGNB();
                        dSGNB.MaGN = oracleDataReader.GetString(0);
                        dSGNB.SoTKLK = oracleDataReader.GetString(1);
                        dSGNB.TenKH = oracleDataReader.GetString(2);
                        dSGNB.DuNoLai = oracleDataReader.GetInt64(3).ToString("#,##0");
                        dSGNB.NgayDH = oracleDataReader.GetDateTime(4).ToShortDateString();

                        list.Add(dSGNB);
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
        /// Lấy danh sách các nguồn có số tiền còn có thể cho vay < 100 triệu
        /// </summary>
        /// <returns></returns>
        public static List<DSNguonA> GetListDSNGA()
        {
            try
            {
                List<DSNguonA> list = new List<DSNguonA>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT MANGUON, TENNGUON, HANMUC, SOTIENDACHOVAY, SOTIENCOTHECHOVAY " +
                    "FROM NGUON WHERE SOTIENCOTHECHOVAY < 100000000";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        DSNguonA dSNG = new DSNguonA();
                        dSNG.MaNg = oracleDataReader.GetString(0);
                        dSNG.TenNg = oracleDataReader.GetString(1);
                        dSNG.HanMuc = oracleDataReader.GetInt64(2).ToString("#,##0");
                        dSNG.SoTienDaChoVay = oracleDataReader.GetInt64(3).ToString("#,##0");
                        dSNG.SoTienCoTheChoVay = oracleDataReader.GetInt64(4).ToString("#,##0");

                        list.Add(dSNG);
                    }
                }

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
