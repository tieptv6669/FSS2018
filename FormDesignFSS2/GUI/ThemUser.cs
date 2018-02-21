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
using Newtonsoft.Json;
using DTO;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 20/02/2018
    /// </summary>
    public partial class ThemUser : Form
    {
        public ThemUser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemUser_Load(object sender, EventArgs e)
        {
            NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
            // Lấy danh sách người dùng hiện tại
            List<NguoiDung> listNguoiDung = new List<NguoiDung>();
            listNguoiDung = JsonConvert.DeserializeObject<List<NguoiDung>>(nguoiDungBUS.LayDSNguoiDung());
            // Lấy danh sách tên đăng nhập hiện tại
            List<string> listTenDangNhap = new List<string>();
            foreach(NguoiDung temp in listNguoiDung)
            {
                listTenDangNhap.Add(temp.tenDangNhapND);
            }
            // Tạo tên đăng nhập
            string tenDangNhap = nguoiDungBUS.TaoTenDangNhap(listTenDangNhap.ToArray());

            txtTenDangNhap.Text = tenDangNhap;
            txtMatKhau.Text = tenDangNhap;
            lblError.ForeColor = Color.Red;
            cboChonQuyen.SelectedIndex = 0;
        }

        /// <summary>
        /// Xử lý sự kiện click nút Hủy
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
                txtHoTen.Enabled = true;
                txtChucVu.Enabled = true;
                txtPhongBan.Enabled = true;
                cboChonQuyen.Enabled = true;
                btnHuy.Text = "Hủy";
                btnXacNhan.Text = "Xác nhận";
                btnHuy.Image = Properties.Resources._168;
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút Xác nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    case 5:
                        {
                            lblError.Text = "Họ tên không hợp lệ";
                            break;
                        }
                    case 6:
                        {
                            lblError.Text = "Tên chức vụ không hợp lệ";
                            break;
                        }
                    case 7:
                        {
                            lblError.Text = "Tên phòng ban không hợp lệ";
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
                // Thêm người dùng mới vào CSDL
                NguoiDung nguoiDung = new NguoiDung();
                nguoiDung.tenDangNhapND = txtTenDangNhap.Text;
                nguoiDung.matKhauND = txtMatKhau.Text;
                nguoiDung.hoTenND = txtHoTen.Text;
                nguoiDung.chucVuND = txtChucVu.Text;
                nguoiDung.phongBanND = txtPhongBan.Text;
                nguoiDung.quyenND = cboChonQuyen.SelectedItem.ToString();
                try
                {
                    NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
                    string jsonData = JsonConvert.SerializeObject(nguoiDung);
                    if (nguoiDungBUS.ThemNguoiDung(jsonData))
                    {
                        MessageBox.Show("Thêm người dùng mới thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        ThemUser themUser = new ThemUser();
                        themUser.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi sảy ra, thêm người dùng mới thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
