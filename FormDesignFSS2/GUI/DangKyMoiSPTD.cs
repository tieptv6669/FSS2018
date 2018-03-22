using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FormDesignFSS2.SanPhamTinDungWS;
using FormDesignFSS2.KhachHangWS;
using FormDesignFSS2.KhachHang_SPTD_WS;
using FormDesignFSS2.LichSuWS;
using DTO;
using Newtonsoft.Json;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 5/3/2018
    /// </summary>
    public partial class DangKyMoiSPTD : Form
    {
        public KhachHang khachHang;
        public DataGridView dataGridView;
        public string gioHT;
        public NguoiDung nguoiDungHeThong;

        public DangKyMoiSPTD()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DangKyMoiSPTD_Load(object sender, EventArgs e)
        {
            try
            {
                lblError.ForeColor = Color.Red;
                // Lấy danh sách các SPTD còn hoạt động
                SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
                string jsonData = sanPhamTinDungBUS.GetListSPTD();
                List<SanPhamTinDung> list = JsonConvert.DeserializeObject<List<SanPhamTinDung>>(jsonData);
                // Hiển thị lên combobox
                cboSPTD.DataSource = list;
                cboSPTD.DisplayMember = "TenSPTD";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi lựa chọn combobox SPTD khác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSPTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            SanPhamTinDung sanPhamTinDung = (SanPhamTinDung)cboSPTD.SelectedItem;
            txtNguon.Text = sanPhamTinDung.TenNguon;
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
                KhachHang_SPTD_BUS khachHang_SPTD_BUS = new KhachHang_SPTD_BUS();
                SanPhamTinDung sanPhamTinDung = (SanPhamTinDung)cboSPTD.SelectedItem;
                if (btnXacNhan.Text == "Xác nhận")
                {
                    switch(khachHang_SPTD_BUS.KTThongTinDangKySPTD(txtSoTKLK.Text, txtTenKH.Text, txtDiaChi.Text, sanPhamTinDung.MaSPTD))
                    {
                        case 1:
                            {
                                lblError.Text = "Khách hàng không xác định";
                                break;
                            }
                        case 0:
                            {
                                lblError.Text = "";
                                txtSoTKLK.Enabled = false;
                                txtTenKH.Enabled = false;
                                txtDiaChi.Enabled = false;
                                txtNguon.Enabled = false;
                                cboSPTD.Enabled = false;
                                btnXacNhan.Text = "Lưu";
                                btnHuy.Text = "Quay lại";
                                btnHuy.Image = Properties.Resources._101;
                                break;
                            }
                    }
                }
                else
                {
                    int result = khachHang_SPTD_BUS.KiemTraTinhTrangSPTD(khachHang.idKH, sanPhamTinDung.IdSPTD);
                    if (result == 1)
                    {
                        // Đã đăng ký
                        MessageBox.Show("Bạn đã đăng ký sản phẩm tín dụng này, không cần đăng ký lại", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if(result == 2)
                    {
                        // Đăng ký lại
                        DialogResult dialogResult = MessageBox.Show("Bạn đã ngừng sử dụng sản phẩm tín dụng này. Bạn có muốn sử dụng lại?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(dialogResult == DialogResult.Yes)
                        {
                            if(khachHang_SPTD_BUS.SuDungLai(khachHang.idKH, sanPhamTinDung.IdSPTD))
                            {
                                // Cập nhật thông tin trạng thái lên grid view
                                foreach(DataGridViewRow temp in dataGridView.Rows)
                                {
                                    if(temp.Cells[0].Value.ToString() == sanPhamTinDung.MaSPTD && temp.Cells[2].Value.ToString() == khachHang.STKLK)
                                    {
                                        temp.Cells[5].Value = "Sử dụng";
                                    }
                                }
                                MessageBox.Show("Đăng ký sử dụng lại SPTD thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Đã có lỗi sảy ra, Đăng ký sử dụng lại SPTD thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    if(result == 3)
                    {
                        // Đăng ký mới
                        if(khachHang_SPTD_BUS.DangKyMoi(khachHang.idKH, sanPhamTinDung.IdSPTD))
                        {
                            // Ghi log
                            LichSu lichSu = new LichSu();
                            lichSu.MaDT = sanPhamTinDung.MaSPTD;
                            lichSu.NoiDung = "Đăng ký mới sản phẩm tín dụng";
                            lichSu.ThoiGian = DateTime.Parse(gioHT);
                            lichSu.GiaTriTruoc = "null";
                            lichSu.GiaTriSau = "null";
                            lichSu.TenDN = nguoiDungHeThong.tenDangNhapND;
                            lichSu.SoTKLK = txtSoTKLK.Text;
                            LichSuBUS lichSuBUS = new LichSuBUS();
                            lichSuBUS.ThemLichSu(JsonConvert.SerializeObject(lichSu));

                            MessageBox.Show("Đăng ký sử dụng SPTD thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi sảy ra, Đăng ký sử dụng SPTD thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if(result == 4)
                    {
                        MessageBox.Show("Đã có lỗi sảy ra, vui lòng thử lại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
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
                txtSoTKLK.Enabled = true;
                txtTenKH.Enabled = true;
                txtDiaChi.Enabled = true;
                txtNguon.Enabled = true;
                cboSPTD.Enabled = true;
                btnHuy.Text = "Hủy";
                btnXacNhan.Text = "Xác nhận";
                btnHuy.Image = Properties.Resources._168;
            }
        }
        
        /// <summary>
        /// Xử lý sự kiện rời khỏi textbox số TKLK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSoTKLK_Leave(object sender, EventArgs e)
        {
            try
            {
                KhachHangBUS khachHangBUS = new KhachHangBUS();
                string jsonData = khachHangBUS.layMotKhachHang(txtSoTKLK.Text);
                KhachHang khachHang = JsonConvert.DeserializeObject<KhachHang>(jsonData);
                txtTenKH.Text = khachHang.hoTenKH;
                txtDiaChi.Text = khachHang.diaChiKH;
                this.khachHang = khachHang;
            }catch(Exception ex)
            {
                khachHang = null;
                txtTenKH.Text = "";
                txtDiaChi.Text = "";
            }
        }
    }
}
