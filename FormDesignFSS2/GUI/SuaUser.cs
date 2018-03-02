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
using FormDesignFSS2.NguoiDungWS; 

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 21/02/2018
    /// </summary>
    public partial class SuaUser : Form
    {
        public NguoiDung nguoiDung;
        public DataGridView dataGridView;

        /// <summary>
        /// Khởi tạo form
        /// </summary>
        public SuaUser()
        {
            InitializeComponent();
            nguoiDung = new NguoiDung();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuaUser_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = nguoiDung.tenDangNhapND;
            txtHoTen.Text = nguoiDung.hoTenND;
            txtChucVu.Text = nguoiDung.chucVuND;
            txtPhongBan.Text = nguoiDung.phongBanND;
            lblError.ForeColor = Color.Red;
            if(nguoiDung.quyenND == "Nhân viên")
            {
                cboQuyen.SelectedIndex = 0;
            }
            if(nguoiDung.quyenND == "Quản lý")
            {
                cboQuyen.SelectedIndex = 1;
            }
            if(nguoiDung.quyenND == "Admin")
            {
                cboQuyen.SelectedIndex = 2;
            }
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
                    NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
                    switch (nguoiDungBUS.KTThongTinThemNguoiDung(txtHoTen.Text, txtChucVu.Text, txtPhongBan.Text, cboQuyen.SelectedItem.ToString()))
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
                                cboQuyen.Enabled = false;
                                break;
                            }
                    }
                }
                else
                {
                    if (nguoiDung.hoTenND == txtHoTen.Text && nguoiDung.chucVuND == txtChucVu.Text &&
                         nguoiDung.phongBanND == txtPhongBan.Text && nguoiDung.quyenND == cboQuyen.SelectedItem.ToString())
                    {
                        MessageBox.Show("Thao tác lỗi. Bạn chưa thay đổi thông tin nào của người dùng", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
                        if (nguoiDungBUS.SuaThongTinNguoiDung(txtTenDangNhap.Text, txtHoTen.Text, txtChucVu.Text, txtPhongBan.Text, cboQuyen.SelectedItem.ToString()))
                        {
                            // Hiển thị lại danh sách người dùng lên grid view
                            foreach (DataGridViewRow temp in dataGridView.Rows)
                            {
                                if (temp.Cells[0].Value.ToString() == txtTenDangNhap.Text)
                                {
                                    temp.Cells[1].Value = txtHoTen.Text;
                                    temp.Cells[2].Value = txtChucVu.Text;
                                    temp.Cells[3].Value = txtPhongBan.Text;
                                    temp.Cells[4].Value = cboQuyen.SelectedItem.ToString();
                                }
                            }
                            MessageBox.Show("Sửa thông tin người dùng thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi sảy ra, sửa người dùng mới thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
                txtHoTen.Enabled = true;
                txtChucVu.Enabled = true;
                txtPhongBan.Enabled = true;
                cboQuyen.Enabled = true;
                btnHuy.Image = Properties.Resources._168;
                btnHuy.Text = "Hủy";
                btnXacNhan.Text = "Xác nhận";
            }
        }
    }
}
