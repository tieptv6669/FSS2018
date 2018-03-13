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

        /// <summary>
        /// Lấy danh sách các món giải ngân còn nợ
        /// </summary>
        /// <returns></returns>
        public static List<GiaiNgan> GetListGN()
        {
            try
            {
                List<GiaiNgan> list = new List<GiaiNgan>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM GIAINGAN WHERE TRANGTHAI = '1'";
                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if(oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        GiaiNgan giaiNgan = new GiaiNgan();
                        giaiNgan.IDGN = oracleDataReader.GetInt32(0);
                        giaiNgan.MaGN = oracleDataReader.GetString(1);
                        giaiNgan.SoTienGN = oracleDataReader.GetInt64(2);
                        giaiNgan.DuNoGoc = oracleDataReader.GetInt64(3);
                        giaiNgan.DuNoLaiTrongHan = oracleDataReader.GetInt64(4);
                        giaiNgan.DuNoLaiNgoaiHan = oracleDataReader.GetInt64(5);
                        giaiNgan.NgayGN = oracleDataReader.GetDateTime(6);
                        giaiNgan.NgayDaoHan = oracleDataReader.GetDateTime(7);
                        giaiNgan.IDKH = oracleDataReader.GetInt32(8);
                        giaiNgan.IDSPTD = oracleDataReader.GetInt32(9);

                        list.Add(giaiNgan);
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
        /// Thêm một dòng dữ liệu vào bảng LOG
        /// </summary>
        /// <param name="xuLyCuoiNgay"></param>
        public static void ThemXLCN(XuLyCuoiNgay xuLyCuoiNgay)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "INSERT INTO LOG (DUNOLAITRONGHAN, DUNOLAIQUAHAN, THOIGIAN, IDGN) " +
                    "VALUES (:dUNOLAITRONGHAN, :dUNOLAIQUAHAN, :tHOIGIAN, :iDGN)";
                oracleCommand.Parameters.Add("dUNOLAITRONGHAN", xuLyCuoiNgay.DuNoLaiTrongHan);
                oracleCommand.Parameters.Add("dUNOLAIQUAHAN", xuLyCuoiNgay.DuNoLaiQuaHan);
                oracleCommand.Parameters.Add("tHOIGIAN", xuLyCuoiNgay.ThoiGian);
                oracleCommand.Parameters.Add("iDGN", xuLyCuoiNgay.IdGN);

                DataProvider.ExcuteNonQuery(oracleCommand);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật dư nợ vào bảng giải ngân
        /// </summary>
        /// <param name="giaiNgan"></param>
        public static void CapNhatDuNoBangGN(GiaiNgan giaiNgan)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE GIAINGAN SET DUNOLAITRONGHAN = :dUNOLAITRONGHAN, " +
                    "DUNOLAINGOAIHAN = :dUNOLAINGOAIHAN WHERE IDGN = :iDGN";
                oracleCommand.Parameters.Add("dUNOLAITRONGHAN", giaiNgan.DuNoLaiTrongHan);
                oracleCommand.Parameters.Add("dUNOLAINGOAIHAN", giaiNgan.DuNoLaiNgoaiHan);
                oracleCommand.Parameters.Add("iDGN", giaiNgan.IDGN);

                DataProvider.ExcuteNonQuery(oracleCommand);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật tham số hệ thống
        /// </summary>
        /// <param name="dateTime"></param>
        public static void CapNhatThamSoHeThong(DateTime dateTime)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE THAMSOHETHONG SET TODAY = :tODAY WHERE ID = '1'";
                oracleCommand.Parameters.Add("TODAY", dateTime);

                DataProvider.ExcuteNonQuery(oracleCommand);
            }
            catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
