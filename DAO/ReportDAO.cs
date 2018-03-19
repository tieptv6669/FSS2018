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

                return list;
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
