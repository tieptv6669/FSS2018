using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DAO
{
    /// <summary>
    /// Viết Tiệp
    /// 6/3/2018
    /// </summary>
    public class XuLyCuoiNgayDAO
    {
        /// <summary>
        /// Lấy ngày làm việc hiện tại
        /// </summary>
        /// <returns></returns>
        public static DateTime LayNgayLamViecHienTai()
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM THAMSOHETHONG";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                oracleDataReader.Read();

                return oracleDataReader.GetDateTime(0).Date;
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DateTime.Now;
            }
        }
    }
}
