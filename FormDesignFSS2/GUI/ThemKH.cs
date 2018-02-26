using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormDesignFSS2.KhachHangWS;
using DTO;
using Newtonsoft.Json;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 26/2/2018
    /// </summary>
    public partial class ThemKH : Form
    {
        /// <summary>
        /// Khởi tạo form
        /// </summary>
        public ThemKH()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemKH_Load(object sender, EventArgs e)
        {
            txtNgayMoTK.Text = DateTime.Now.Date.ToShortDateString();
            lblError.ForeColor = Color.Red;
            cboLoaiKH.SelectedIndex = 0;
        }

        /// <summary>
        /// Xử lý sự kiện click button xác nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXacNhan_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Xử lý sự kiện click button hủy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(btnHuy.Text == "Hủy")
            {
                Close();
            }
            else
            {

            }
        }

        /// <summary>
        /// Xử lý sự kiện click button sinh ngẫu nhiên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSinhNgauNhien_Click(object sender, EventArgs e)
        {
            string prefix = "";
            Random random = new Random();
            int num = random.Next(1, 999999);
            switch (num.ToString().Length)
            {
                case 1:
                    {
                        prefix += "00000";
                        break;
                    }
                case 2:
                    {
                        prefix += "0000";
                        break;
                    }
                case 3:
                    {
                        prefix += "000";
                        break;
                    }
                case 4:
                    {
                        prefix += "00";
                        break;
                    }
                case 5:
                    {
                        prefix += "0";
                        break;
                    }
            }
            prefix += num.ToString();

            txtSoTKLK2.Text = prefix;
        }
    }
}
