using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormDesignFSS2.GUI;

namespace FSS2018
{
    /// <summary>
    /// Viết Tiệp abc
    /// 11/02/2018
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap());

            //NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
            //List<DTO.NguoiDung> list = new List<DTO.NguoiDung>();

            //string json = nguoiDungBUS.LayDSNguoiDung();

            //list = JsonConvert.DeserializeObject<List<DTO.NguoiDung>>(json);

            //foreach (DTO.NguoiDung x in list)
            //{
            //    Console.WriteLine(x.hoTenND);
            //}
        }
    }
}
