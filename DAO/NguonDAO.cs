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

        /// <summary>
        /// Tìm kiếm nguồn theo tên nguồn và mã nguồn
        /// </summary>
        /// <param name="tenNguon"></param>
        /// <returns></returns>
        public static List<Nguon> TimKiemNguon(string tenNguon, string maNguon)
        {
            try
            {
                List<Nguon> list = new List<Nguon>();
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM NGUON WHERE TENNGUON LIKE '%' || :tenNguon || '%' " +
                    "AND MANGUON LIKE '%' || :maNguon || '%'";
                oracleCommand.Parameters.Add(new OracleParameter("tenNguon", tenNguon));
                oracleCommand.Parameters.Add(new OracleParameter("maNguon", maNguon));

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

        /// <summary>
        /// Thêm nguồn
        /// </summary>
        /// <param name="nguon"></param>
        /// <returns></returns>
        public static bool ThemNguon(Nguon nguon)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "INSERT INTO NGUON (MANGUON, TENNGUON, HANMUC, SOTIENDACHOVAY, SOTIENCOTHECHOVAY) VALUES " +
                    "(:maNguon, :tenNguon, :hanMuc, :soTienDaChoVay, :soTienCoTheChoVay)";
                oracleCommand.Parameters.Add(new OracleParameter("maNguon", nguon.maNg));
                oracleCommand.Parameters.Add(new OracleParameter("tenNguon", nguon.tenNg));
                oracleCommand.Parameters.Add(new OracleParameter("hanMuc", nguon.hanMucNg));
                oracleCommand.Parameters.Add(new OracleParameter("soTienDaChoVay", nguon.tienDaChoVay));
                oracleCommand.Parameters.Add(new OracleParameter("soTienCoTheChoVay", nguon.tienCoTheChoVay));

                return DataProvider.ExcuteNonQuery(oracleCommand);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Sửa nguồn
        /// </summary>
        /// <param name="maNguon"></param>
        /// <param name="hanMuc"></param>
        /// <param name="tienCoTheChoVay"></param>
        /// <returns></returns>
        public static bool SuaNguon(string maNguon, string hanMuc, string tienCoTheChoVay)
        {
            try
            {
                long hanMucNg = Int64.Parse(hanMuc);
                long soTienCoTheChoVay = Int64.Parse(tienCoTheChoVay);

                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "UPDATE NGUON SET HANMUC = :hanMuc, SOTIENCOTHECHOVAY = :tienCoTheChoVay WHERE MANGUON = :maNguon";
                oracleCommand.Parameters.Add(new OracleParameter("hanMuc", hanMucNg));
                oracleCommand.Parameters.Add(new OracleParameter("tienCoTheChoVay", soTienCoTheChoVay));
                oracleCommand.Parameters.Add(new OracleParameter("maNguon", maNguon));

                return DataProvider.ExcuteNonQuery(oracleCommand);
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Xóa nguồn
        /// </summary>
        /// <param name="maNguon"></param>
        /// <returns></returns>
        public static bool XoaNguon(string maNguon)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "DELETE FROM NGUON WHERE MANGUON = :maNguon";
                oracleCommand.Parameters.Add("maNguon", maNguon);

                return DataProvider.ExcuteNonQuery(oracleCommand);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        /// <summary>
        /// Lấy nguồn khi biết tên nguồn
        /// </summary>
        /// <param name="tenNguon"></param>
        /// <returns></returns>
        public static Nguon GetNguon(string tenNguon)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "SELECT * FROM NGUON WHERE TENNGUON = :tenNguon";
                oracleCommand.Parameters.Add("tenNguon", tenNguon);

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);

                if(oracleDataReader != null && oracleDataReader.HasRows)
                {
                    oracleDataReader.Read();

                    Nguon nguon = new Nguon();
                    nguon.idNg = oracleDataReader.GetInt32(0);
                    nguon.maNg = oracleDataReader.GetString(1);
                    nguon.tenNg = oracleDataReader.GetString(2);
                    nguon.hanMucNg = oracleDataReader.GetInt64(3);
                    nguon.tienDaChoVay = oracleDataReader.GetInt64(4);
                    nguon.tienCoTheChoVay = oracleDataReader.GetInt64(5);

                    return nguon;
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
