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

                if(oracleDataReader != null && oracleDataReader.HasRows)
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

                return list;
            }catch(Exception e)
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

                return list;
            }
            catch(Exception e)
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
