using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using FormDesignFSS2.LichSuWS;
using DTO;
using FormDesignFSS2.KhachHangWS;
using FormDesignFSS2;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Thùy Linh
    /// 25/2/2018
    /// </summary>
    public partial class SuaKH : Form
    {
        public KhachHang khachHang;
        public NguoiDung nguoiDungHeThong;
        public DataGridView dataGridView;

        /// <summary>
        /// Khởi tạo form
        /// </summary>
        public SuaKH()
        {
            InitializeComponent();
            khachHang = new KhachHang();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuaKH_Load(object sender, EventArgs e)
        {
            txtSoTKLK.Text = khachHang.STKLK;
            txtHoTenKH.Text = khachHang.hoTenKH;
            dateNgaySinh.Text = khachHang.ngaySinhKH.ToLongDateString();
            txtNgayMoTK.Text = khachHang.ngayMoTKKH.ToString();
            txtNgheNghiep.Text = khachHang.ngheNghiepKH;
            txtSoCMND.Text = khachHang.soCMNNKH;
            txtEmail.Text = khachHang.emailKH;
            txtSDT.Text = khachHang.SDTKH;
            txtDiaChi.Text = khachHang.diaChiKH;
            txtGhiChu.Text = khachHang.ghiChuKH;
            lblError.ForeColor = Color.Red;
            if (khachHang.loai == "Classic")
            {
                cmbLoaiKH.SelectedIndex = 0;
            }
            if (khachHang.loai == "Silver")
            {
                cmbLoaiKH.SelectedIndex = 1;
            }
            if (khachHang.loai == "Gold")
            {
                cmbLoaiKH.SelectedIndex = 2;
            }
            if (khachHang.loai == "Diamond")
            {
                cmbLoaiKH.SelectedIndex = 3;
            }
            if(khachHang.gioiTinhKH == "Nam")
            {
                radioGTNam.Checked = true;
                radioGTNu.Checked = false;
            }
            else
            {
                radioGTNam.Checked = false;
                radioGTNu.Checked = true;
            }
        }

        /// <summary>
        /// Xử lý sự kiện click btn Xác Nhận
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
                    switch (khachHangBUS.KTThongTinSuaKH(Convert.ToDateTime(txtNgayMoTK.Text), txtHoTenKH.Text, dateNgaySinh.Value, txtNgheNghiep.Text, txtSoCMND.Text, txtDiaChi.Text, txtEmail.Text, txtSDT.Text))
                    {
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
                                lblError.Text = "Bạn chưa nhập số CMND/giấy phép kinh doanh";
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
                                lblError.Text = "Khách hàng chưa đủ 18 tuổi";
                                break;
                            }
                        case 9:
                            {
                                lblError.Text = "Tên nhập không hợp lệ";
                                break;
                            }
                        case 10:
                            {
                                lblError.Text = "Nghề nghiệp nhập không hợp lệ";
                                break;
                            }
                        case 11:
                            {
                                lblError.Text = "Số điện thoại không hợp lệ";
                                break;
                            }
                        case 12:
                            {
                                lblError.Text = "Số CMND không hợp lệ";
                                break;
                            }
                        case 13:
                            {
                                lblError.Text = "Độ dài vượt quá trường thông tin";
                                break;
                            }
                        case 0:
                            {
                                lblError.Text = "";
                                btnXacNhan.Text = "Lưu";
                                btnHuy.Text = "Quay lại";
                                btnHuy.Image = Properties.Resources._101;
                                if (txtGhiChu.Text.Length == 0)
                                {
                                    txtGhiChu.Text = " ";
                                }
                                txtSoTKLK.Enabled = false;
                                txtHoTenKH.Enabled = false;
                                cmbLoaiKH.Enabled = false;
                                dateNgaySinh.Enabled = false;
                                txtNgheNghiep.Enabled = false;
                                txtSoCMND.Enabled = false;
                                txtDiaChi.Enabled = false;
                                radioGTNam.Enabled = false;
                                radioGTNu.Enabled = false;
                                txtEmail.Enabled = false;
                                txtSDT.Enabled = false;
                                txtGhiChu.Enabled = false;
                                break;
                            }
                    }
                }
                else
                {
                    if (khachHang.hoTenKH == txtHoTenKH.Text && khachHang.loai == cmbLoaiKH.SelectedItem.ToString() &&
                         khachHang.ngaySinhKH == dateNgaySinh.Value && khachHang.ngheNghiepKH == txtNgheNghiep.Text &&
                         khachHang.soCMNNKH == txtSoCMND.Text
                         && khachHang.diaChiKH == txtDiaChi.Text && khachHang.emailKH == txtEmail.Text &&
                         khachHang.SDTKH == txtSDT.Text && khachHang.ghiChuKH == txtGhiChu.Text)
                    {
                        MessageBox.Show("Thao tác lỗi. Bạn chưa thay đổi thông tin nào của khách hàng", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        KhachHangBUS khachHangBUS = new KhachHangBUS();
                        string gioiTinh;
                        if (radioGTNam.Checked == true)
                        {
                            gioiTinh = "Nam";
                        }
                        else
                        {
                            gioiTinh = "Nữ";
                        }
                        if (khachHangBUS.suaThongTinKH(txtSoTKLK.Text, txtHoTenKH.Text, cmbLoaiKH.SelectedItem.ToString(), dateNgaySinh.Value, gioiTinh, txtNgheNghiep.Text, txtSoCMND.Text, txtDiaChi.Text, txtEmail.Text, txtSDT.Text, txtGhiChu.Text))
                        {
                            // Hiển thị lại dữ liệu lên grid view
                            foreach (DataGridViewRow temp in dataGridView.Rows)
                            {
                                if (temp.Cells[0].Value.ToString() == txtSoTKLK.Text)
                                {
                                    temp.Cells[1].Value = txtHoTenKH.Text;
                                    temp.Cells[2].Value = cmbLoaiKH.SelectedItem.ToString();
                                    temp.Cells[3].Value = txtSoCMND.Text;
                                    temp.Cells[4].Value = txtGhiChu.Text;
                                }
                            }
                            // Ghi log
                            LichSu lichSu = new LichSu();
                            lichSu.MaDT = khachHang.STKLK;
                            lichSu.NoiDung = "Sửa thông tin khách hàng";
                            lichSu.ThoiGian = DateTime.Now;
                            lichSu.GiaTriTruoc = JsonConvert.SerializeObject(khachHang);
                            KhachHang khachHangSau = new KhachHang();
                            khachHangSau.idKH = khachHang.idKH;
                            khachHangSau.STKLK = khachHang.STKLK;
                            khachHangSau.hoTenKH = txtHoTenKH.Text;
                            khachHangSau.ngaySinhKH = dateNgaySinh.Value;
                            khachHangSau.ngheNghiepKH = txtNgheNghiep.Text;
                            khachHangSau.soCMNNKH = txtSoCMND.Text;
                            khachHangSau.emailKH = txtEmail.Text;
                            khachHangSau.gioiTinhKH = gioiTinh;
                            khachHangSau.loai = cmbLoaiKH.SelectedItem.ToString();
                            khachHangSau.diaChiKH = txtDiaChi.Text;
                            khachHangSau.SDTKH = txtSDT.Text;
                            khachHangSau.ghiChuKH = txtGhiChu.Text;
                            lichSu.GiaTriSau = JsonConvert.SerializeObject(khachHangSau);
                            lichSu.TenDN = nguoiDungHeThong.tenDangNhapND;
                            lichSu.SoTKLK = khachHang.STKLK;
                            LichSuBUS lichSuBUS = new LichSuBUS();
                            lichSuBUS.ThemLichSu(JsonConvert.SerializeObject(lichSu));

                            MessageBox.Show("Sửa thông tin khách hàng thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi sảy ra, sửa thông tin khách hàng thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click btn Hủy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            if (btnHuy.Text == "Hủy")
            {
                Close();
            }
            else
            {
                txtSoTKLK.Enabled = false;
                txtHoTenKH.Enabled = true;
                cmbLoaiKH.Enabled = true;
                dateNgaySinh.Enabled = true;
                txtNgheNghiep.Enabled = true;
                txtSoCMND.Enabled = true;
                txtDiaChi.Enabled = true;
                radioGTNam.Enabled = true;
                radioGTNu.Enabled = true;
                txtEmail.Enabled = true;
                txtSDT.Enabled = true;
                txtGhiChu.Enabled = true;
                btnHuy.Image = Properties.Resources._168;
                btnHuy.Text = "Hủy";
                btnXacNhan.Text = "Xác nhận";
            }
        }
    }
}
