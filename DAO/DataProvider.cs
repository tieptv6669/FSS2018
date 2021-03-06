﻿using System;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace DAO
{
    /// <summary>
    /// Viết Tiệp
    /// 10/02/2018
    /// </summary>
    public class DataProvider
    {
        /// <summary>
        /// Chuỗi kết nối
        /// </summary>
        public static string connectionString = ConfigurationManager.ConnectionStrings["oracleDB"].ConnectionString;

        /// <summary>
        /// Lấy kết nối đến CSDL
        /// </summary>
        /// <returns>Kết nối đến CSDL</returns>
        public static OracleConnection GetOracleConnection()
        {
            try
            {
                // Xây dựng chuỗi kết nối
                OracleConnectionStringBuilder oracleConnectionStringBuilder = new OracleConnectionStringBuilder();
                oracleConnectionStringBuilder.ConnectionString = connectionString;
                oracleConnectionStringBuilder.UserID = "tieptv6669";
                oracleConnectionStringBuilder.Password = "123456";
                // Tạo kết nối
                OracleConnection oracleConnection = new OracleConnection(oracleConnectionStringBuilder.ConnectionString);
                oracleConnection.Open();

                return oracleConnection;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối, vui lòng kiểm tra lại đường truyền \n" + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Thực thi câu lệnh truy vấn
        /// </summary>
        /// <param name="oracleCmd"></param>
        /// <returns></returns>
        public static OracleDataReader GetOracleDataReader(OracleCommand oracleCmd)
        {
            try
            {
                OracleDataReader oracleDataReader;
                oracleCmd.Connection = GetOracleConnection();
                oracleDataReader = oracleCmd.ExecuteReader();

                return oracleDataReader;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi truy vấn CSDL \n" + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Thực thi câu lệnh non query
        /// </summary>
        /// <param name="oracleCommand"></param>
        /// <returns></returns>
        public static bool ExcuteNonQuery(OracleCommand oracleCommand)
        {
            try
            {
                oracleCommand.Connection = GetOracleConnection();
                oracleCommand.ExecuteNonQuery();

                return true;
            }catch(Exception e)
            {
                MessageBox.Show("Lỗi truy vấn CSDL \n" + e.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
