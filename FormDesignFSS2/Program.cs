using System;
using System.Windows.Forms;
using FormDesignFSS2.GUI;

namespace FSS2018
{
    /// <summary>
    /// Viết Tiệp
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
        }
    }
}
