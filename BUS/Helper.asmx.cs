using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Text;

/// <summary>
/// Viết Tiệp
/// 20/02/2018
/// </summary>
namespace BUS
{
    /// <summary>
    /// Summary description for Helper
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Helper : System.Web.Services.WebService
    {

        /// <summary>
        /// Kiểm tra một chuỗi ký tự chỉ chứa chữ cái
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ChiChuaChuCai(string str)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = str.Normalize(NormalizationForm.FormD);
            str = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

            foreach (char c in str)
            {
                if ((c < 'A' || (c > 'Z' && c < 'a') || c > 'z') && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Kiểm tra một chuỗi kí tự là số nguyên dương
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [WebMethod]
        public bool LaMotSoNguyenDuong(string str)
        {
            foreach(char c in str)
            {
                if(c < '0' || c > '9')
                {
                    return false;
                }
            }

            long temp = Int64.Parse(str);
            if(temp > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Kiểm tra một chuỗi ký tự chỉ chứa ký tự số
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        [WebMethod]
        public bool ChiChuaChuSo(string str)
        {
            foreach(char c in str)
            {
                if(c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
