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
    }
}
