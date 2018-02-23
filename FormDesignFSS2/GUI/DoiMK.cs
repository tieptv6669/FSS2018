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

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 23/02/2018
    /// </summary>
    public partial class DoiMK : Form
    {
        public DoiMK()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoiMK_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = MainForm.nguoiDungHienTai.tenDangNhapND;
            lblError.ForeColor = Color.Red;
        }

        /// <summary>
        /// Xử lý sự kiện click button Hủy
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
                txtMatKhauCu.Enabled = true;
                txtMatKhauMoi.Enabled = true;
                txtNhapLaiMatKhauMoi.Enabled = true;
                btnXacNhan.Text = "Xác nhận";
                btnHuy.Text = "Hủy";
                btnHuy.Image = Properties.Resources._168;
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button xác nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(btnXacNhan.Text == "Xác nhận")
            {
                NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();

                switch(nguoiDungBUS.KTThongTinDoiMK(txtTenDangNhap.Text, txtMatKhauCu.Text, txtMatKhauMoi.Text, txtNhapLaiMatKhauMoi.Text))
                {
                    case 1:
                        {
                            lblError.Text = "Bạn chưa nhập mật khẩu cũ";
                            break;
                        }
                    case 2:
                        {
                            lblError.Text = "Bạn chưa nhập mật khẩu mới";
                            break;
                        }
                    case 3:
                        {
                            lblError.Text = "Bạn chưa nhập lại mật khẩu mới";
                            break;
                        }
                    case 4:
                        {
                            lblError.Text = "Mật khẩu cũ không chính xác";
                            break;
                        }
                    case 5:
                        {
                            lblError.Text = "Độ dài mật khẩu ít nhất là 6 kí tự";
                            break;
                        }
                    case 6:
                        {
                            lblError.Text = "Mật khẩu nhập lại không khớp";
                            break;
                        }
                    case 0:
                        {
                            lblError.Text = "";
                            txtMatKhauCu.Enabled = false;
                            txtMatKhauMoi.Enabled = false;
                            txtNhapLaiMatKhauMoi.Enabled = false;
                            btnXacNhan.Text = "Lưu";
                            btnHuy.Text = "Quay lại";
                            btnHuy.Image = Properties.Resources._101;
                            break;
                        }
                }
            }
            else
            {
                // Cập nhật mật khẩu mới
                NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
                
                if(nguoiDungBUS.DoiMatKhau(txtTenDangNhap.Text, txtMatKhauMoi.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi sảy ra, đổi mật khẩu thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
