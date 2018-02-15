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
    public partial class ThemUser : Form
    {
        public ThemUser()
        {
            InitializeComponent();
        }


        private void ThemUser_Load(object sender, EventArgs e)
        {
            lblError.ForeColor = Color.Red;
            cboChonQuyen.SelectedIndex = 0;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(btnHuy.Text == "Hủy")
            {
                Close();
            }
            else
            {
                txtHoTen.Enabled = true;
                txtChucVu.Enabled = true;
                txtPhongBan.Enabled = true;
                cboChonQuyen.Enabled = true;
                btnHuy.Text = "Hủy";
                btnXacNhan.Text = "Xác nhận";
                btnHuy.Image = Properties.Resources._168;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(btnXacNhan.Text == "Xác nhận")
            {
                NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
                switch (nguoiDungBUS.KTThongTinThemNguoiDung(txtHoTen.Text, txtChucVu.Text, txtPhongBan.Text, cboChonQuyen.SelectedItem.ToString()))
                {
                    case 1:
                        {
                            lblError.Text = "Bạn chưa nhập họ tên";
                            break;
                        }
                    case 2:
                        {
                            lblError.Text = "Bạn chưa nhập chức vụ";
                            break;
                        }
                    case 3:
                        {
                            lblError.Text = "Bạn chưa nhập phòng ban";
                            break;
                        }
                    case 4:
                        {
                            lblError.Text = "Bạn chưa chọn quyền";
                            break;
                        }
                    case 0:
                        {
                            lblError.Text = "";
                            btnXacNhan.Text = "Lưu";
                            btnHuy.Text = "Quay lại";
                            btnHuy.Image = Properties.Resources._101;
                            txtHoTen.Enabled = false;
                            txtChucVu.Enabled = false;
                            txtPhongBan.Enabled = false;
                            cboChonQuyen.Enabled = false;
                            break;
                        }
                }
            }
            else
            {

            }
        }
    }
}
