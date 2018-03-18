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
    /// 8/3/2018
    /// </summary>
    public class LichSuDAO
    {
        /// <summary>
        /// Thêm lịch sử mới
        /// </summary>
        /// <param name="lichSu"></param>
        public static void ThemLichSu(LichSu lichSu)
        {
            try
            {
                OracleCommand oracleCommand = new OracleCommand();
                oracleCommand.CommandText = "INSERT INTO LICHSU (MADOITUONG, NOIDUNG, THOIGIAN, " +
                    "GIATRITRUOC, GIATRISAU, TENDANGNHAP, SOTKLK) " +
                    "VALUES (:mADOITUONG, :nOIDUNG, :tHOIGIAN, :gIATRITRUOC, " +
                    ":gIATRISAU, :tENDANGNHAP, :sOTKLK)";
                oracleCommand.Parameters.Add("mADOITUONG", lichSu.MaDT);
                oracleCommand.Parameters.Add("nOIDUNG", lichSu.NoiDung);
                oracleCommand.Parameters.Add("tHOIGIAN", lichSu.ThoiGian);
                oracleCommand.Parameters.Add("gIATRITRUOC", lichSu.GiaTriTruoc);
                oracleCommand.Parameters.Add("gIATRISAU", lichSu.GiaTriSau);
                oracleCommand.Parameters.Add("tENDANGNHAP", lichSu.TenDN);
                oracleCommand.Parameters.Add("sOTKLK", lichSu.SoTKLK);

                DataProvider.ExcuteNonQuery(oracleCommand);
                oracleCommand.Connection.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tìm kiếm lịch sử
        /// </summary>
        /// <param name="tenDangNhap"></param>
        /// <param name="soTKLK"></param>
        /// <param name="maDT"></param>
        /// <param name="startDate"></param>
        /// <param name="finishDate"></param>
        /// <returns></returns>
        public static List<LichSu> TimKiemLS(string tenDangNhap, string soTKLK, string maDT, DateTime startDate, DateTime finishDate)
        {
            try
            {
                List<LichSu> list = new List<LichSu>();

                OracleCommand oracleCommand = new OracleCommand();
                
                if(startDate == finishDate)
                {
                    oracleCommand.CommandText = "SELECT * FROM LICHSU WHERE TENDANGNHAP LIKE '%' || :tenDANGNHAP || '%' " +
                    "AND SOTKLK LIKE '%' || :sOTKLK || '%' AND MADOITUONG LIKE '%' || :mADOITUONG || '%' " +
                    "AND THOIGIAN = :fromDate";
                    oracleCommand.Parameters.Add("tenDANGNHAP", tenDangNhap);
                    oracleCommand.Parameters.Add("sOTKLK", soTKLK);
                    oracleCommand.Parameters.Add("mADOITUONG", maDT);
                    oracleCommand.Parameters.Add("fromDate", startDate);
                }
                else
                {
                    oracleCommand.CommandText = "SELECT * FROM LICHSU WHERE TENDANGNHAP LIKE '%' || :tenDANGNHAP || '%' " +
                    "AND SOTKLK LIKE '%' || :sOTKLK || '%' AND MADOITUONG LIKE '%' || :mADOITUONG || '%' " +
                    "AND THOIGIAN BETWEEN :fromDate AND :toDate";
                    oracleCommand.Parameters.Add("tenDANGNHAP", tenDangNhap);
                    oracleCommand.Parameters.Add("sOTKLK", soTKLK);
                    oracleCommand.Parameters.Add("mADOITUONG", maDT);
                    oracleCommand.Parameters.Add("fromDate", startDate);
                    oracleCommand.Parameters.Add("toDate", finishDate);
                }

                OracleDataReader oracleDataReader = DataProvider.GetOracleDataReader(oracleCommand);
                if(oracleDataReader != null && oracleDataReader.HasRows)
                {
                    while (oracleDataReader.Read())
                    {
                        LichSu lichSu = new LichSu();
                        lichSu.IdLS = oracleDataReader.GetInt32(0);
                        lichSu.MaDT = oracleDataReader.GetString(1);
                        lichSu.NoiDung = oracleDataReader.GetString(2);
                        lichSu.ThoiGian = oracleDataReader.GetDateTime(3);
                        lichSu.GiaTriTruoc = oracleDataReader.GetString(4);
                        lichSu.GiaTriSau = oracleDataReader.GetString(5);
                        lichSu.TenDN = oracleDataReader.GetString(6);
                        lichSu.SoTKLK = oracleDataReader.GetString(7);

                        list.Add(lichSu);
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
    }
}
