using System;
using Newtonsoft.Json;
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
using FormDesignFSS2.SanPhamTinDungWS;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 3/3/2018
    /// </summary>
    public partial class ThemMoiSPTD : Form
    {
        public ThemMoiSPTD()
        {
            InitializeComponent();
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
                cboChonNguon.Enabled = true;
                cboTrangThai.Enabled = true;
                btnXacNhan.Text = "Xác nhận";
                btnHuy.Text = "Hủy";
                btnHuy.Image = Properties.Resources._168;
            }
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemMoiSPTD_Load(object sender, EventArgs e)
        {
            try
            {
                lblError.ForeColor = Color.Red;
                // Lấy danh sách nguồn
                NguonBUS nguonBUS = new NguonBUS();
                string jsonData = nguonBUS.LayDSNguon();
                List<Nguon> list = JsonConvert.DeserializeObject<List<Nguon>>(jsonData);
                // Hiển thị danh sách nguồn lên combobox
                cboChonNguon.Refresh();
                cboChonNguon.DataSource = list;
                cboChonNguon.DisplayMember = "tenNg";
                // Đặt giá trị mặc định cho cbo trạng thái
                cboTrangThai.SelectedIndex = 0;
                // Sinh mã SPTD
                Nguon nguon = (Nguon)cboChonNguon.SelectedItem;
                string prefixMaSPTD = "SP" + nguon.maNg;
                SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
                string fullCode = sanPhamTinDungBUS.TaoMaSPTD(prefixMaSPTD);
                txtMaSPTD.Text = fullCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi chọn một nguồn khác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboChonNguon_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Sinh mã SPTD
            Nguon nguon = (Nguon)cboChonNguon.SelectedItem;
            string prefixMaSPTD = "SP" + nguon.maNg;
            SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
            string fullCode = sanPhamTinDungBUS.TaoMaSPTD(prefixMaSPTD);
            txtMaSPTD.Text = fullCode;
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
                    SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
                    switch (sanPhamTinDungBUS.KTThongTinThemMoiSPTD(txtTenSPTD.Text, txtThoiHanVay.Text, txtLaiSuat.Text, txtLaiSuatQuaHan.Text))
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
                                lblError.Text = "";
                                txtTenSPTD.Enabled = false;
                                txtMaSPTD.Enabled = false;
                                txtThoiHanVay.Enabled = false;
                                txtLaiSuat.Enabled = false;
                                txtLaiSuatQuaHan.Enabled = false;
                                cboChonNguon.Enabled = false;
                                cboTrangThai.Enabled = false;
                                btnXacNhan.Text = "Lưu";
                                btnHuy.Text = "Quay lại";
                                btnHuy.Image = Properties.Resources._101;
                                break;
                            }
                    }
                }
                else
                {
                    // Thêm mới SPTD
                    SanPhamTinDung sanPhamTinDung = new SanPhamTinDung();
                    Nguon nguon = (Nguon)cboChonNguon.SelectedItem;
                    sanPhamTinDung.MaSPTD = txtMaSPTD.Text;
                    sanPhamTinDung.TenSPTD = txtTenSPTD.Text;
                    sanPhamTinDung.ThoiHanVay = Int32.Parse(txtThoiHanVay.Text);
                    sanPhamTinDung.LaiSuat = Int32.Parse(txtLaiSuat.Text);
                    sanPhamTinDung.LaiSuatQuaHan = Int32.Parse(txtLaiSuatQuaHan.Text);
                    sanPhamTinDung.TrangThai = cboTrangThai.SelectedItem.ToString();
                    sanPhamTinDung.IdNguon = nguon.idNg;
                    sanPhamTinDung.TenNguon = nguon.tenNg;

                    string jsonData = JsonConvert.SerializeObject(sanPhamTinDung);
                    SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
                    if (sanPhamTinDungBUS.ThemMoiSPTD(jsonData))
                    {
                        MessageBox.Show("Thêm mới SPTD thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                        ThemMoiSPTD themMoiSPTD = new ThemMoiSPTD();
                        themMoiSPTD.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi sảy ra, thêm SPTD mới thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
