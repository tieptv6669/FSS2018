using System;
using FormDesignFSS2.SanPhamTinDungWS;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormDesignFSS2.NguonWS;
using Newtonsoft.Json;
using DTO;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 4/3/2018
    /// </summary>
    public partial class SuaSPTD : Form
    {
        public SanPhamTinDung sanPhamTinDung;
        public DataGridView dataGridView;

        /// <summary>
        /// Khởi tạo form
        /// </summary>
        public SuaSPTD()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuaSPTD_Load(object sender, EventArgs e)
        {
            try
            {
                lblError.ForeColor = Color.Red;
                txtMaSPTD.Text = sanPhamTinDung.MaSPTD;
                txtTenSPTD.Text = sanPhamTinDung.TenSPTD;
                txtThoiHanVay.Text = sanPhamTinDung.ThoiHanVay.ToString();
                txtLaiSuat.Text = sanPhamTinDung.LaiSuat.ToString();
                txtLaiSuatQuaHan.Text = sanPhamTinDung.LaiSuatQuaHan.ToString();
                txtNguon.Text = sanPhamTinDung.TenNguon;
                // Thiết lập giá trị mặc định cho cbo trạng thái
                if (sanPhamTinDung.TrangThai == "Hoạt động")
                {
                    cboTrangThai.SelectedIndex = 0;
                }
                else
                {
                    cboTrangThai.SelectedIndex = 1;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if(btnXacNhan.Text == "Xác nhận")
                {
                    SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
                    switch(sanPhamTinDungBUS.KTThongTinSuaSPTD(txtTenSPTD.Text, sanPhamTinDung.TenSPTD, txtThoiHanVay.Text, txtLaiSuat.Text, txtLaiSuatQuaHan.Text))
                    {
                        case 1:
                            {
                                lblError.Text = "Bạn chưa nhập tên SPTD";
                                break;
                            }
                        case 2:
                            {
                                lblError.Text = "Bạn chưa nhập thời hạn vay";
                                break;
                            }
                        case 3:
                            {
                                lblError.Text = "Bạn chưa nhập lãi suất";
                                break;
                            }
                        case 4:
                            {
                                lblError.Text = "Bạn chưa nhập lãi suất quá hạn";
                                break;
                            }
                        case 5:
                            {
                                lblError.Text = "Tên SPTD không hợp lệ";
                                break;
                            }
                        case 6:
                            {
                                lblError.Text = "Thời hạn vay không hợp lệ";
                                break;
                            }
                        case 7:
                            {
                                lblError.Text = "Lãi suất không hợp lệ";
                                break;
                            }
                        case 8:
                            {
                                lblError.Text = "Lãi suất quá hạn không hợp lệ";
                                break;
                            }
                        case 9:
                            {
                                lblError.Text = "Tên SPTD đã tồn tại";
                                break;
                            }
                        case 0:
                            {
                                txtMaSPTD.Enabled = false;
                                txtTenSPTD.Enabled = false;
                                txtThoiHanVay.Enabled = false;
                                txtLaiSuat.Enabled = false;
                                txtLaiSuatQuaHan.Enabled = false;
                                txtNguon.Enabled = false;
                                cboTrangThai.Enabled = false;
                                btnHuy.Text = "Quay lại";
                                btnHuy.Image = Properties.Resources._101;
                                btnXacNhan.Text = "Lưu";
                                break;
                            }
                    }
                }
                else
                {
                    // Sửa SPTD
                    if(sanPhamTinDung.TenSPTD == txtTenSPTD.Text && sanPhamTinDung.ThoiHanVay == Int32.Parse(txtThoiHanVay.Text) 
                        && sanPhamTinDung.LaiSuat == Int32.Parse(txtLaiSuat.Text) && sanPhamTinDung.LaiSuatQuaHan == Int32.Parse(txtLaiSuatQuaHan.Text) 
                        && sanPhamTinDung.TrangThai == cboTrangThai.SelectedItem.ToString())
                    {
                        MessageBox.Show("Thao tác lỗi, bạn chưa thay đổi thông tin nào của SPTD", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
                        if(sanPhamTinDungBUS.SuaSPTD(txtMaSPTD.Text, txtTenSPTD.Text, Int32.Parse(txtThoiHanVay.Text), Int32.Parse(txtLaiSuat.Text), Int32.Parse(txtLaiSuatQuaHan.Text), cboTrangThai.SelectedItem.ToString()))
                        {
                            MessageBox.Show("Sửa thông tin sản phẩm tín dụng thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Cập nhật thông tin vào grid view
                            foreach(DataGridViewRow temp in dataGridView.Rows)
                            {
                                if(temp.Cells[0].Value.ToString() == txtMaSPTD.Text)
                                {
                                    temp.Cells[1].Value = txtTenSPTD.Text;
                                    temp.Cells[2].Value = txtNguon.Text;
                                    temp.Cells[3].Value = txtThoiHanVay.Text;
                                    temp.Cells[4].Value = txtLaiSuat.Text;
                                    temp.Cells[5].Value = txtLaiSuatQuaHan.Text;
                                    temp.Cells[6].Value = cboTrangThai.SelectedItem.ToString();
                                }
                            }
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi sảy ra, sửa thông tin sản phẩm tín dụng thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtMaSPTD.Enabled = true;
                txtTenSPTD.Enabled = true;
                txtThoiHanVay.Enabled = true;
                txtLaiSuat.Enabled = true;
                txtLaiSuatQuaHan.Enabled = true;
                txtNguon.Enabled = true;
                cboTrangThai.Enabled = true;
                btnHuy.Text = "Hủy";
                btnHuy.Image = Properties.Resources._168;
                btnXacNhan.Text = "Xác nhận";
            }
        }
    }
}
