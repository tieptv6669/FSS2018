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
using FormDesignFSS2.NguonWS;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 26/2/2018
    /// </summary>
    public partial class SuaNguon : Form
    {
        // Nguồn cần sửa
        public Nguon nguon;

        /// <summary>
        /// Khởi tạo form
        /// </summary>
        public SuaNguon()
        {
            nguon = new Nguon();
            InitializeComponent();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuaNguon_Load(object sender, EventArgs e)
        {
            lblError.ForeColor = Color.Red;
            txtMaNguon.Text = nguon.maNg;
            txtTenNguon.Text = nguon.tenNg;
            txtHanMuc.Text = nguon.hanMucNg.ToString();
            txtTienDaChoVay.Text = nguon.tienDaChoVay.ToString();
            txtTienCoTheChoVay.Text = nguon.tienCoTheChoVay.ToString();
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
                switch(nguonBUS.KTThongTinSuaNguon(txtHanMuc.Text, txtTienDaChoVay.Text))
                {
                    case 1:
                        {
                            lblError.Text = "Bạn chưa nhập hạn mức";
                            break;
                        }
                    case 2:
                        {
                            lblError.Text = "Hạn mức không hợp lệ";
                            break;
                        }
                    case 3:
                        {
                            lblError.Text = "Hạn mức phải lớn hơn số tiền đã cho vay";
                            break;
                        }
                    case 0:
                        {
                            lblError.Text = "";
                            txtMaNguon.Enabled = false;
                            txtTenNguon.Enabled = false;
                            txtHanMuc.Enabled = false;
                            txtTienDaChoVay.Enabled = false;
                            txtTienCoTheChoVay.Text = (Int64.Parse(txtHanMuc.Text) - Int64.Parse(txtTienDaChoVay.Text)).ToString();
                            txtTienCoTheChoVay.Enabled = false;
                            btnXacNhan.Text = "Lưu";
                            btnHuy.Text = "Quay lại";
                            btnHuy.Image = Properties.Resources._101;
                            break;
                        }
                }
            }
            else
            {
                // Sửa nguồn
                NguonBUS nguonBUS = new NguonBUS();
                if (nguonBUS.SuaNguon(txtMaNguon.Text, txtHanMuc.Text, txtTienCoTheChoVay.Text))
                {
                    MessageBox.Show("Sửa thông tin nguồn thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi sảy ra, sửa thông tin nguồn thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtMaNguon.Enabled = true;
                txtTenNguon.Enabled = true;
                txtHanMuc.Enabled = true;
                txtTienDaChoVay.Enabled = true;
                txtTienCoTheChoVay.Enabled = true;
                btnHuy.Text = "Hủy";
                btnXacNhan.Text = "Xác nhận";
                btnHuy.Image = Properties.Resources._168;
            }
        }
    }
}
