using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DAO
{
    /// <summary>
    /// Viết Tiệp
    /// 24/02/2018
    /// </summary>
    public class NguonDAO
    {
        /// <summary>
        /// Lấy danh sách các nguồn hiện có
        /// </summary>
        /// <returns></returns>
        public static List<Nguon> LayDanhSachNguon()
        {
            try
            {
                List<Nguon> list = new List<Nguon>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM NGUON";

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                if(oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        Nguon nguon = new Nguon();

                        nguon.idNg = oracleDataReader.GetInt32(0);
                        nguon.maNg = oracleDataReader.GetString(1);
                        nguon.tenNg = oracleDataReader.GetString(2);
                        nguon.hanMucNg = oracleDataReader.GetInt64(3);
                        nguon.tienDaChoVay = oracleDataReader.GetInt64(4);
                        nguon.tienCoTheChoVay = oracleDataReader.GetInt64(5);

                        list.Add(nguon);
                    }
                }

                return list;
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
