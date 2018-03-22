using System;
using System.Collections.Generic;
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

                oracleCommand.Connection.Close();
                oracleCommand.Connection.Dispose();
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

                    oracleCommand.Connection.Close();
                    oracleCommand.Connection.Dispose();
                    return giaiNgan;
                }
                else
                {
                    oracleCommand.Connection.Close();
                    oracleCommand.Connection.Dispose();
                    return null;
                }
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Lấy ID giải ngân khi biết mã GN
        /// </summary>
        /// <param name="maGN"></param>
        /// <returns></returns>
        public static int GetIDGN(string maGN)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT IDGN FROM GIAINGAN WHERE MAGN = :maGN";
                oracleCommand.Parameters.Add("maGN", maGN);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if (oracleDataReader != null && oracleDataReader.HasRows)
                {
                    oracleDataReader.Read();
                    int id = oracleDataReader.GetInt32(0);
                    oracleCommand.Connection.Close();
                    oracleCommand.Connection.Dispose();
                    return id; 
                }
                else
                {
                    oracleCommand.Connection.Close();
                    oracleCommand.Connection.Dispose();
                    return 0;
                }
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Lấy danh sách các lần trả nợ cho món giải ngân có id = idGN
        /// </summary>
        /// <param name="idGN"></param>
        /// <returns></returns>
        public static List<TraNo> GetListTN(int idGN)
        {
            try
            {
                List<TraNo> list = new List<TraNo>();

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM TRANO WHERE IDGN = :idGN";
                oracleCommand.Parameters.Add("idGN", idGN);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if(oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        TraNo traNo = new TraNo();
                        traNo.IdTN = oracleDataReader.GetInt32(0);
                        traNo.MaTN = oracleDataReader.GetString(1);
                        traNo.TenKH = oracleDataReader.GetString(2);
                        traNo.SoTienTra = oracleDataReader.GetInt64(3);
                        traNo.SoTienTraGoc = oracleDataReader.GetInt64(4);
                        traNo.SoTienTraLai = oracleDataReader.GetInt64(5);
                        traNo.NgayTraNo = oracleDataReader.GetDateTime(6);
                        traNo.IdGN = oracleDataReader.GetInt32(7);

                        list.Add(traNo);
                    }
                }

                oracleCommand.Connection.Close();
                oracleCommand.Connection.Dispose();
                return list;
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Thêm trả nợ mới
        /// </summary>
        /// <param name="traNo"></param>
        /// <returns></returns>
        public static bool ThemTN(TraNo traNo)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "INSERT INTO TRANO (MATN, TENKH, SOTIENTRA, SOTIENTRAGOC, SOTIENTRALAI, NGAYTRA, IDGN) " +
                    "VALUES (:maTN, :tenKH, :soTienTra, :soTienTraGoc, :soTienTraLai, :ngayTra, :idGN)";
                oracleCommand.Parameters.Add("maTN", traNo.MaTN);
                oracleCommand.Parameters.Add("tenKH", traNo.TenKH);
                oracleCommand.Parameters.Add("soTienTra", traNo.SoTienTra);
                oracleCommand.Parameters.Add("soTienTraGoc", traNo.SoTienTraGoc);
                oracleCommand.Parameters.Add("soTienTraLai", traNo.SoTienTraLai);
                oracleCommand.Parameters.Add("ngayTra", traNo.NgayTraNo);
                oracleCommand.Parameters.Add("idGN", traNo.IdGN);

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
        /// Cập nhật dư nợ cho món giải ngân
        /// </summary>
        /// <param name="maGN"></param>
        /// <param name="duNoGoc"></param>
        /// <param name="duNoLaiTrongHan"></param>
        /// <param name="duNoLaiQuaHan"></param>
        /// <returns></returns>
        public static bool CapNhatDuNo(string maGN, long duNoGoc, long duNoLaiTrongHan, long duNoLaiQuaHan)
        {
            try
            {
                string trangThai;
                if(duNoGoc > 0)
                {
                    trangThai = "Còn nợ";
                }
                else
                {
                    trangThai = "Hoàn thành";
                }
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE GIAINGAN SET DUNOGOC = :duNoGoc, DUNOLAITRONGHAN = :duNoLaiTrongHan, DUNOLAINGOAIHAN = :duNOLAINGOAIHAN, TRANGTHAI = :trangThai WHERE MAGN = :maGN";

                oracleCommand.Parameters.Add("duNoGoc", duNoGoc);
                oracleCommand.Parameters.Add("duNoLaiTrongHan", duNoLaiTrongHan);
                oracleCommand.Parameters.Add("duNOLAINGOAIHAN",duNoLaiQuaHan);
                oracleCommand.Parameters.Add("trangThai", trangThai);
                oracleCommand.Parameters.Add("maGN", maGN);

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
        /// Cập nhật số tiền cho nguồn
        /// </summary>
        /// <param name="idNg"></param>
        /// <param name="tienDaChoVay"></param>
        /// <param name="tienCoTheChoVay"></param>
        /// <returns></returns>
        public static bool CapNhatNguon(int idNg, long tienDaChoVay, long tienCoTheChoVay)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE NGUON SET SOTIENDACHOVAY = :sOTIENDACHOVAY, " +
                    "SOTIENCOTHECHOVAY = :sOTIENCOTHECHOVAY WHERE IDNGUON = :iDNGUON";

                oracleCommand.Parameters.Add("sOTIENDACHOVAY", tienDaChoVay);
                oracleCommand.Parameters.Add("sOTIENCOTHECHOVAY", tienCoTheChoVay);
                oracleCommand.Parameters.Add("iDNGUON", idNg);

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
    }
}
