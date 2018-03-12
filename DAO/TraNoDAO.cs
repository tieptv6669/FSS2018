using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Oracle.ManagedDataAccess.Client;

namespace DAO
{
    /// <summary>
    /// Viết Tiệp
    /// 11/3/2018
    /// </summary>
    public class TraNoDAO
    {
        /// <summary>
        /// Lấy danh sách tất cả các món giải ngân còn nợ
        /// </summary>
        /// <returns></returns>
        public static List<GiaiNgan> GetListGN()
        {
            try
            {
                List<GiaiNgan> list = new List<GiaiNgan>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM GIAINGAN WHERE DUNOGOC <> '0' AND TRANGTHAI = 'Còn nợ'";

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
                        giaiNgan.TrangThai = oracleDataReader.GetString(10);

                        list.Add(giaiNgan);
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
        /// Lấy danh sách tất cả các món giải ngân còn nợ của KH có id = idKH
        /// </summary>
        /// <param name="idKH"></param>
        /// <returns></returns>
        public static List<GiaiNgan> GetListGN(int idKH)
        {
            try
            {
                List<GiaiNgan> list = new List<GiaiNgan>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM GIAINGAN WHERE IDKH = :idKH AND TRANGTHAI = 'Còn nợ'";
                oracleCommand.Parameters.Add("idKH", idKH);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
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
                        giaiNgan.TrangThai = oracleDataReader.GetString(10);

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

        /// <summary>
        /// Lấy món giải ngân còn nợ khi biết mã GN
        /// Nếu món không tồn tại hoặc đã trả hết nợ thì trả về null
        /// </summary>
        /// <param name="maGN"></param>
        /// <returns></returns>
        public static GiaiNgan GetGiaiNgan(string maGN)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM GIAINGAN WHERE MAGN = :maGN AND TRANGTHAI = 'Còn nợ'";
                oracleCommand.Parameters.Add("maGN", maGN);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if(oracleDataReader != null && oracleDataReader.HasRows)
                {
                    oracleDataReader.Read();
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
                    giaiNgan.TrangThai = oracleDataReader.GetString(10);

                    return giaiNgan;
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
