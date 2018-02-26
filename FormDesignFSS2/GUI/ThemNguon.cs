using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormDesignFSS2.NguonWS;
using DTO;
using Newtonsoft.Json;

/// <summary>
/// Viết Tiệp
/// 25/2/2018
/// </summary>
namespace FormDesignFSS2.GUI
{
    public partial class ThemNguon : Form
    {
        public ThemNguon()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemNguon_Load(object sender, EventArgs e)
        {
            NguonBUS nguonBUS = new NguonBUS();
            lblError.ForeColor = Color.Red;
            txtMaNguon.Text = nguonBUS.TaoMaNguon();
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
                NguonBUS nguonBUS = new NguonBUS();
                switch (nguonBUS.KTThongTinThemNguon(txtTenNguon.Text, txtHanMuc.Text))
                {
                    case 1:
                        {
                            lblError.Text = "Bạn chưa nhập tên nguồn"; 
                            break;
                        }
                    case 2:
                        {
                            lblError.Text = "Bạn chưa nhập hạn mức";
                            break;
                        }
                    case 3:
                        {
                            lblError.Text = "Tên nguồn không hợp lệ";
                            break;
                        }
                    case 4:
                        {
                            lblError.Text = "Hạn mức không hợp lệ";
                            break;
                        }
                    case 0:
                        {
                            lblError.Text = "";
                            txtTenNguon.Enabled = false;
                            txtHanMuc.Enabled = false;
                            btnXacNhan.Text = "Lưu";
                            btnHuy.Text = "Quay lại";
                            btnHuy.Image = Properties.Resources._101;
                            break;
                        }
                }
            }
            else
            {
                NguonBUS nguonBUS = new NguonBUS();

                Nguon nguon = new Nguon();
                nguon.maNg = txtMaNguon.Text;
                nguon.tenNg = txtTenNguon.Text;
                nguon.hanMucNg = long.Parse(txtHanMuc.Text);
                nguon.tienDaChoVay = 0;
                nguon.tienCoTheChoVay = nguon.hanMucNg;

                string jsonData = JsonConvert.SerializeObject(nguon);

                if (nguonBUS.ThemNguonMoi(jsonData))
                {
                    MessageBox.Show("Thêm nguồn mới thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    ThemNguon themNguon = new ThemNguon();
                    themNguon.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi sảy ra, thêm nguồn mới thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                txtTenNguon.Enabled = true;
                txtHanMuc.Enabled = true;
                btnXacNhan.Text = "Xác nhận";
                btnHuy.Text = "Hủy";
                btnHuy.Image = Properties.Resources._168;
            }
        }
    }
}
