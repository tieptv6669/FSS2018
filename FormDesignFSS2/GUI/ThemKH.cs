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
            try
            {
                if (btnXacNhan.Text == "Xác nhận")
                {
                    KhachHangBUS khachHangBUS = new KhachHangBUS();
                    switch (khachHangBUS.KTThongTinThemKH(txtSoTKLK.Text + txtSoTKLK2.Text, DateTime.Now, txtHoTen.Text, dateTimePickerNgaySinh.Value, txtNgheNghiep.Text, txtSoCMND.Text, txtDiaChi.Text, txtEmail.Text, txtSDT.Text))
                    {
                        case 1:
                            {
                                lblError.Text = "Bạn chưa nhập số TKLK";
                                break;
                            }
                        case 2:
                            {
                                lblError.Text = "Bạn chưa nhập họ tên";
                                break;
                            }
                        case 3:
                            {
                                lblError.Text = "Bạn chưa nhập nghề nghiệp";
                                break;
                            }
                        case 4:
                            {
                                lblError.Text = "Bạn chưa nhập số CMND";
                                break;
                            }
                        case 5:
                            {
                                lblError.Text = "Bạn chưa nhập địa chỉ";
                                break;
                            }
                        case 6:
                            {
                                lblError.Text = "Bạn chưa nhập email";
                                break;
                            }
                        case 7:
                            {
                                lblError.Text = "Bạn chưa nhập số điện thoại";
                                break;
                            }
                        case 8:
                            {
                                lblError.Text = "Bạn chưa đủ 18 tuổi";
                                break;
                            }
                        case 9:
                            {
                                lblError.Text = "Họ tên không hợp lệ";
                                break;
                            }
                        case 10:
                            {
                                lblError.Text = "Nghề nghiệp không hợp lệ";
                                break;
                            }
                        case 11:
                            {
                                lblError.Text = "Số CMND không hợp lệ";
                                break;
                            }
                        case 12:
                            {
                                lblError.Text = "Số điện thoại không hợp lệ";
                                break;
                            }
                        case 13:
                            {
                                lblError.Text = "Số TKLK đã tồn tại";
                                break;
                            }
                        case 14:
                            {
                                lblError.Text = "Số TKLK không hợp lệ";
                                break;
                            }
                        case 15:
                            {
                                lblError.Text = "Số CMND đã tồn tại";
                                break;
                            }
                        case 0:
                            {
                                lblError.Text = "";
                                txtSoTKLK2.Enabled = false;
                                txtHoTen.Enabled = false;
                                cboLoaiKH.Enabled = false;
                                dateTimePickerNgaySinh.Enabled = false;
                                radioNam.Enabled = false;
                                radioNu.Enabled = false;
                                txtNgheNghiep.Enabled = false;
                                txtSoCMND.Enabled = false;
                                txtDiaChi.Enabled = false;
                                txtEmail.Enabled = false;
                                txtSDT.Enabled = false;
                                txtGhiChu.Enabled = false;
                                btnSinhNgauNhien.Enabled = false;
                                btnXacNhan.Text = "Lưu";
                                btnHuy.Text = "Quay lại";
                                btnHuy.Image = Properties.Resources._101;
                                break;
                            }
                    }
                }
                else
                {
                    // Thêm KH mới
                    KhachHang khachHang = new KhachHang();
                    khachHang.STKLK = txtSoTKLK.Text + txtSoTKLK2.Text;
                    khachHang.hoTenKH = txtHoTen.Text;
                    khachHang.ngaySinhKH = dateTimePickerNgaySinh.Value;
                    khachHang.ngayMoTKKH = DateTime.Now;
                    khachHang.ngheNghiepKH = txtNgheNghiep.Text;
                    khachHang.soCMNNKH = txtSoCMND.Text;
                    khachHang.emailKH = txtEmail.Text;
                    if (radioNam.Checked == true)
                    {
                        khachHang.gioiTinhKH = "Nam";
                    }
                    else
                    {
                        khachHang.gioiTinhKH = "Nữ";
                    }
                    khachHang.loai = cboLoaiKH.SelectedItem.ToString();
                    khachHang.diaChiKH = txtDiaChi.Text;
                    khachHang.SDTKH = txtSDT.Text;
                    if (txtGhiChu.Text.Length == 0)
                    {
                        khachHang.ghiChuKH = " ";
                    }
                    else
                    {
                        khachHang.ghiChuKH = txtGhiChu.Text;
                    }

                    string jsonData = JsonConvert.SerializeObject(khachHang);
                    KhachHangBUS khachHangBUS = new KhachHangBUS();
                    if (khachHangBUS.ThemKH(jsonData))
                    {
                        MessageBox.Show("Thêm khách hàng mới thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        ThemKH themKH = new ThemKH();
                        themKH.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi sảy ra, thêm khách hàng mới thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtSoTKLK2.Enabled = true;
                txtHoTen.Enabled = true;
                cboLoaiKH.Enabled = true;
                dateTimePickerNgaySinh.Enabled = true;
                radioNam.Enabled = true;
                radioNu.Enabled = true;
                txtNgheNghiep.Enabled = true;
                txtSoCMND.Enabled = true;
                txtDiaChi.Enabled = true;
                txtEmail.Enabled = true;
                txtSDT.Enabled = true;
                txtGhiChu.Enabled = true;
                btnSinhNgauNhien.Enabled = true;
                btnXacNhan.Text = "Xác nhận";
                btnHuy.Text = "Hủy";
                btnHuy.Image = Properties.Resources._168;
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
