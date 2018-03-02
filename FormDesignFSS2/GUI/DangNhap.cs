using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormDesignFSS2.NguoiDungWS;
using DTO;
using Newtonsoft.Json;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 11/02/2018
    /// </summary>
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DangNhap_Load(object sender, EventArgs e)
        {
            lblError.ForeColor = Color.Red;
        }

        /// <summary>
        /// Xử lý sự kiện click button đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();

                switch (nguoiDungBUS.KTThongTinDangNhap(txtTenDangNhap.Text, txtMatKhau.Text))
                {
                    case 1:
                        {
                            lblError.Text = "Bạn chưa nhập tên đăng nhập";
                            break;
                        }
                    case 2:
                        {
                            lblError.Text = "Bạn chưa nhập mật khẩu";
                            break;
                        }
                    case 0:
                        {
                            string jsonNguoiDung = nguoiDungBUS.GetNguoiDung(txtTenDangNhap.Text, txtMatKhau.Text);

                            if (jsonNguoiDung != null)
                            {
                                MainForm mainForm = new MainForm();
                                NguoiDung nguoiDungDTO = JsonConvert.DeserializeObject<NguoiDung>(jsonNguoiDung);

                                Hide();
                                MainForm.nguoiDungHienTai = nguoiDungDTO;
                                mainForm.ShowDialog();
                                Close();
                            }
                            else
                            {
                                lblError.Text = "Tên đăng nhập hoặc mật khẩu không chính xác";
                            }

                            break;
                        }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button thoát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
