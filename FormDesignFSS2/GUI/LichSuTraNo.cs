using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 5/3/2018
    /// </summary>
    public partial class LichSuTraNo : Form
    {
        // Mã giải ngân
        public string maGN;
        public LichSuTraNo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý sự kiện click button đóng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LichSuTraNo_Load(object sender, EventArgs e)
        {

        }
    }
}
