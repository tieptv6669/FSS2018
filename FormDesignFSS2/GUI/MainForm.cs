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
using FormDesignFSS2.LichSuWS;
using FormDesignFSS2.NguoiDungWS;
using FormDesignFSS2.TraNoWS;
using FormDesignFSS2.KhachHangWS;
using FormDesignFSS2.NguonWS;
using FormDesignFSS2.SanPhamTinDungWS;
using FormDesignFSS2.Report;
using FormDesignFSS2.KhachHang_SPTD_WS;
using FormDesignFSS2.GiaiNganWS;
using FormDesignFSS2.XuLyCuoiNgayWS;
using Newtonsoft.Json;
using Microsoft.Reporting.WinForms;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 11/02/2018
    /// </summary>
    public partial class MainForm : Form
    {
        public static NguoiDung nguoiDungHienTai;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTime.ForeColor = Color.Purple;
            lblTDN.ForeColor = Color.Blue;
            lblQuyen.ForeColor = Color.Blue;

            lblTDN.Text = nguoiDungHienTai.tenDangNhapND;
            lblQuyen.Text = nguoiDungHienTai.quyenND;

            AcceptButton = btnTimKiemTabUser;

            // Lấy ngày hệ thống
            XuLyCuoiNgayBUS xuLyCuoiNgayBUS = new XuLyCuoiNgayBUS();
            lblTime.Text = xuLyCuoiNgayBUS.LayNgayLamViecHienTai();

            string quyen = nguoiDungHienTai.quyenND;
            // Phân quyền người dùng
            if (quyen == "Quản lý")
            {
                tabControl.TabPages.RemoveAt(0);
                btnChayQuaNgay.Enabled = false;
                AcceptButton = btnTimKiemTabKH;
            }
            if (quyen == "Nhân viên")
            {
                AcceptButton = btnTimKiemTabKH;
                tabControl.TabPages.RemoveAt(0);
                btnChayQuaNgay.Enabled = false;
                btnSuaTabUser.Enabled = false;
                btnXoaTabUser.Enabled = false;
                btnResetTabUser.Enabled = false;
                btnSuaTabKH.Enabled = false;
                btnSuaTabSPTD.Enabled = false;
                btnHuyDangKySPTD.Enabled = false;
                btnSuaTabNguon.Enabled = false;
                btnXoaTabNguon.Enabled = false;
                btnSuaTabGN.Enabled = false;
            }
            reportViewerBC.RefreshReport();
            reportViewerBC.RefreshReport();
            cboLoaiBC.SelectedIndex = 0;

            dateTimePickerST.Value = DateTime.Parse(lblTime.Text);
            dateTimePickerFT.Value = DateTime.Parse(lblTime.Text);
        }

        /// <summary>
        /// Xử lý sự kiện click button chạy qua ngày 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChayQuaNgay_Click(object sender, EventArgs e)
        {
            ChayQuaNgay cqnForm = new ChayQuaNgay();
            cqnForm.labelNgayHeThong = lblTime;
            cqnForm.nguoiDungHeThong = nguoiDungHienTai;
            cqnForm.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện click button đăng xuất
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Hide();
            DangNhap dangNhap = new DangNhap();
            dangNhap.ShowDialog();
            Close();
        }

        /// <summary>
        /// Xử lý sự kiện click button thoát 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn thoát khỏi chương trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Xử lý sự kiện click button thêm người dùng mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemTabUser_Click(object sender, EventArgs e)
        {
            ThemUser themUser = new ThemUser();
            themUser.nguoiDung = nguoiDungHienTai;
            themUser.gioHT = lblTime.Text;
            themUser.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện click button tìm kiếm người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemTabUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa dữ liệu hiển thị cũ
                gridTabUser.Rows.Clear();
                // Lấy DS người dùng
                List<NguoiDung> list = new List<NguoiDung>();

                NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
                string jsonData = nguoiDungBUS.TimKiemNguoiDung(txtTenNhanVien.Text, txtTenDangNhap.Text);

                list = JsonConvert.DeserializeObject<List<NguoiDung>>(jsonData);

                // Hiển thị danh sách người dùng lên grid view
                foreach (NguoiDung temp in list)
                {
                    gridTabUser.Rows.Add(temp.tenDangNhapND, temp.hoTenND, temp.chucVuND, temp.phongBanND, temp.quyenND);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button sửa người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaTabUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridTabUser.RowCount > 0 && gridTabUser.SelectedRows.Count > 0)
                {
                    SuaUser suaUser = new SuaUser();
                    suaUser.nguoiDung.tenDangNhapND = gridTabUser.SelectedRows[0].Cells[0].Value.ToString();
                    suaUser.nguoiDung.hoTenND = gridTabUser.SelectedRows[0].Cells[1].Value.ToString();
                    suaUser.nguoiDung.chucVuND = gridTabUser.SelectedRows[0].Cells[2].Value.ToString();
                    suaUser.nguoiDung.phongBanND = gridTabUser.SelectedRows[0].Cells[3].Value.ToString();
                    suaUser.nguoiDung.quyenND = gridTabUser.SelectedRows[0].Cells[4].Value.ToString();
                    suaUser.dataGridView = gridTabUser;
                    suaUser.nguoiDungHeThong = nguoiDungHienTai;
                    suaUser.gioHT = lblTime.Text;

                    suaUser.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn người dùng nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Xử lý sự kiện click button xóa người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaTabUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridTabUser.RowCount > 0 && gridTabUser.SelectedRows.Count > 0)
                {
                    if(gridTabUser.SelectedRows[0].Cells[4].Value.ToString() == "Admin")
                    {
                        MessageBox.Show("Bạn không thể xóa người dùng có quyền Admin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa " + gridTabUser.SelectedRows[0].Cells[1].Value.ToString() + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
                            if (nguoiDungBUS.XoaNguoiDung(gridTabUser.SelectedRows[0].Cells[0].Value.ToString()))
                            {
                                // Ghi log
                                LichSu lichSu = new LichSu();
                                lichSu.MaDT = gridTabUser.SelectedRows[0].Cells[0].Value.ToString();
                                lichSu.NoiDung = "Xóa người dùng";
                                lichSu.ThoiGian = DateTime.Parse(lblTime.Text);
                                lichSu.GiaTriTruoc = "null";
                                lichSu.GiaTriSau = "null";
                                lichSu.TenDN = nguoiDungHienTai.tenDangNhapND;
                                lichSu.SoTKLK = "null";
                                LichSuBUS lichSuBUS = new LichSuBUS();
                                lichSuBUS.ThemLichSu(JsonConvert.SerializeObject(lichSu));
                                // Cập nhật grid view
                                gridTabUser.Rows.Remove(gridTabUser.SelectedRows[0]);
                                MessageBox.Show("Xóa người dùng thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                MessageBox.Show("Đã có lỗi sảy ra, xóa người dùng thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn người dùng nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button đổi mật khẩu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMK doiMK = new DoiMK();
            doiMK.gioHT = lblTime.Text;
            doiMK.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện click button tìm kiếm khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemTabKH_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa dữ liệu hiển thị cũ
                gridTabKH.Rows.Clear();
                // Lấy DS khách hàng
                List<KhachHang> list = new List<KhachHang>();

                KhachHangBUS khachHangBUS = new KhachHangBUS();
                string jsonData = khachHangBUS.TimKiemKH(txtSoTKLKTabKH.Text, txtTenKHTabKH.Text, txtSoCMNDTabKH.Text);

                list = JsonConvert.DeserializeObject<List<KhachHang>>(jsonData);

                // Hiển thị danh sách khách hàng lên grid view
                foreach (KhachHang temp in list)
                {
                    gridTabKH.Rows.Add(temp.STKLK, temp.hoTenKH, temp.loai, temp.soCMNNKH, temp.ghiChuKH);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// Xử lý sự kiện click button reset mật khẩu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetTabUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridTabUser.RowCount > 0 && gridTabUser.SelectedRows.Count > 0)
                {
                    string tenDN = gridTabUser.SelectedRows[0].Cells[0].Value.ToString();
                    string tenNguoiDung = gridTabUser.SelectedRows[0].Cells[1].Value.ToString();
                    DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn reset mật khẩu cho " + tenNguoiDung + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // reset mật khẩu cho người dùng 
                        NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
                        NguoiDung nguoiDung = JsonConvert.DeserializeObject<NguoiDung>(nguoiDungBUS.LayNguoiDung(tenDN));
                        if (nguoiDungBUS.ResetMatKhau(tenDN))
                        {
                            // Ghi log
                            LichSu lichSu = new LichSu();
                            lichSu.MaDT = tenDN;
                            lichSu.NoiDung = "Reset mật khẩu";
                            lichSu.ThoiGian = DateTime.Parse(lblTime.Text);
                            lichSu.GiaTriTruoc = nguoiDung.matKhauND;
                            lichSu.GiaTriSau = tenDN;
                            lichSu.TenDN = nguoiDungHienTai.tenDangNhapND;
                            lichSu.SoTKLK = "null";
                            LichSuBUS lichSuBUS = new LichSuBUS();
                            lichSuBUS.ThemLichSu(JsonConvert.SerializeObject(lichSu));

                            MessageBox.Show("Reset mật khẩu thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi sảy ra, reset mật khẩu người dùng thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn người dùng nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button Xem chi tiết khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXemChiTietTabKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridTabKH.RowCount > 0 && gridTabKH.SelectedRows.Count > 0)
                {
                    XemChiTietKH xemChiTietKH = new XemChiTietKH();
                    KhachHangBUS khachHangBUS = new KhachHangBUS();
                    KhachHang khachHang = new KhachHang();
                    string jsonData = khachHangBUS.layMotKhachHang(gridTabKH.SelectedRows[0].Cells[0].Value.ToString());
                    khachHang = JsonConvert.DeserializeObject<KhachHang>(jsonData);
                    xemChiTietKH.khachHang = khachHang;
                    xemChiTietKH.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn khách hàng nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button sửa khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaTabKH_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridTabKH.RowCount > 0 && gridTabKH.SelectedRows.Count > 0)
                {
                    SuaKH suaKH = new SuaKH();
                    suaKH.dataGridView = gridTabKH;
                    KhachHang khachHang = new KhachHang();
                    KhachHangBUS khachHangBUS = new KhachHangBUS();
                    string jsonData = khachHangBUS.layMotKhachHang(gridTabKH.SelectedRows[0].Cells[0].Value.ToString());

                    khachHang = JsonConvert.DeserializeObject<KhachHang>(jsonData);

                    suaKH.khachHang = khachHang;
                    suaKH.nguoiDungHeThong = nguoiDungHienTai;
                    suaKH.gioHT = lblTime.Text;

                    suaKH.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn khách hàng nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị danh sách các nguồn hiện có 
        /// </summary>
        public void HienThiDSNguon()
        {
            try
            {
                // Xóa dữ liệu hiển thị cũ 
                gridDSNguon.Rows.Clear();
                // Lấy danh sách nguồn
                NguonBUS nguonBUS = new NguonBUS();
                List<Nguon> list = new List<Nguon>();
                string jsonData = nguonBUS.LayDSNguon();

                if (jsonData != null)
                {
                    // Hiển thị danh sách nguồn lên gridview 
                    list = JsonConvert.DeserializeObject<List<Nguon>>(jsonData);
                    foreach (Nguon temp in list)
                    {
                        gridDSNguon.Rows.Add(temp.maNg, temp.tenNg, temp.hanMucNg, temp.tienDaChoVay, temp.tienCoTheChoVay);
                    }
                    if (gridDSNguon.RowCount > 1)
                    {
                        gridDSNguon.Rows[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button thêm nguồn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemTabNguon_Click(object sender, EventArgs e)
        {
            ThemNguon themNguon = new ThemNguon();
            themNguon.nguoiDungHeThong = nguoiDungHienTai;
            themNguon.gioHT = lblTime.Text;

            themNguon.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện click button sửa nguồn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaTabNguon_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridDSNguon.RowCount > 0 && gridDSNguon.SelectedRows.Count > 0)
                {
                    SuaNguon suaNguon = new SuaNguon();
                    suaNguon.dataGridView = gridDSNguon;
                    suaNguon.nguon.maNg = gridDSNguon.SelectedRows[0].Cells[0].Value.ToString();
                    suaNguon.nguon.tenNg = gridDSNguon.SelectedRows[0].Cells[1].Value.ToString();
                    suaNguon.nguon.hanMucNg = Int64.Parse(gridDSNguon.SelectedRows[0].Cells[2].Value.ToString().Replace(",", ""));
                    suaNguon.nguon.tienDaChoVay = Int64.Parse(gridDSNguon.SelectedRows[0].Cells[3].Value.ToString().Replace(",", ""));
                    suaNguon.nguon.tienCoTheChoVay = Int64.Parse(gridDSNguon.SelectedRows[0].Cells[4].Value.ToString().Replace(",", ""));
                    suaNguon.nguoiDungHeThong = nguoiDungHienTai;
                    suaNguon.gioHT = lblTime.Text;

                    suaNguon.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn nguồn nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện xóa nguồn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaTabNguon_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridDSNguon.RowCount > 0 && gridDSNguon.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nguồn " + gridDSNguon.SelectedRows[0].Cells[1].Value.ToString() + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // Lấy mã của nguồn được chọn
                        string maNguon = gridDSNguon.SelectedRows[0].Cells[0].Value.ToString();

                        NguonBUS nguonBUS = new NguonBUS();
                        if (nguonBUS.XoaNguon(maNguon))
                        {
                            // Ghi log
                            LichSu lichSu = new LichSu();
                            lichSu.MaDT = gridDSNguon.SelectedRows[0].Cells[0].Value.ToString();
                            lichSu.NoiDung = "Xóa nguồn";
                            lichSu.ThoiGian = DateTime.Parse(lblTime.Text);
                            lichSu.GiaTriTruoc = "null";
                            lichSu.GiaTriSau = "null";
                            lichSu.TenDN = nguoiDungHienTai.tenDangNhapND;
                            lichSu.SoTKLK = "null";
                            LichSuBUS lichSuBUS = new LichSuBUS();
                            lichSuBUS.ThemLichSu(JsonConvert.SerializeObject(lichSu));

                            gridDSNguon.Rows.Remove(gridDSNguon.SelectedRows[0]);
                            MessageBox.Show("Xóa nguồn thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi sảy ra, xóa nguồn thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn nguồn nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button tìm kiếm nguồn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemTabNguon_Click(object sender, EventArgs e)
        {
            try
            {
                gridDSNguon.Rows.Clear();

                NguonBUS nguonBUS = new NguonBUS();
                string jsonData = nguonBUS.TimKiemNguon(txtTenNguon.Text, txtMaNguon.Text);

                List<Nguon> list = JsonConvert.DeserializeObject<List<Nguon>>(jsonData);
                if (list != null && list.Count > 0)
                {
                    foreach (Nguon temp in list)
                    {
                        gridDSNguon.Rows.Add(temp.maNg, temp.tenNg, temp.hanMucNg.ToString("#,##0"), temp.tienDaChoVay.ToString("#,##0"), temp.tienCoTheChoVay.ToString("#,##0"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button thêm giải ngân 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemTabGN_Click(object sender, EventArgs e)
        {
            ThemGN themGN = new ThemGN();
            themGN.gioHT = lblTime.Text;
            themGN.nguoiDungHeThong = nguoiDungHienTai;
            themGN.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện click button thêm khách hàng 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemTabKH_Click(object sender, EventArgs e)
        {
            ThemKH themKH = new ThemKH();
            themKH.nguoiDungHeThong = nguoiDungHienTai;
            themKH.gioHT = lblTime.Text;
            themKH.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện click button xuất báo cáo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXuatBC_Click(object sender, EventArgs e)
        {
            XuatBC xuatBC = new XuatBC();
            xuatBC.reportViewerBC = reportViewerBC;
            xuatBC.gioHT = lblTime.Text;

            switch (cboLoaiBC.SelectedIndex)
            {
                case 0:
                    {
                        xuatBC.BCDuNoA();
                        break;
                    }
                case 1:
                    {
                        xuatBC.BCDuNoB();
                        break;
                    }
                case 2:
                    {
                        xuatBC.BCDuNoC();
                        break;
                    }
                case 3:
                    {
                        xuatBC.BCDuNoD();
                        break;
                    }
                case 4:
                    {
                        xuatBC.BCDuNoE();
                        break;
                    }
                case 5:
                    {
                        xuatBC.BCDSSPTDA();
                        break;
                    }
                case 6:
                    {
                        xuatBC.BCDSSPTDB();
                        break;
                    }
                case 7:
                    {
                        xuatBC.BCDSGNA();
                        break;
                    }
                case 8:
                    {
                        xuatBC.BCDSGNB();
                        break;
                    }
                case 9:
                    {
                        xuatBC.BCDSNguonA();
                        break;
                    }
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button tìm kiếm sản phẩm tín dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemTabSPTD_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách SPTD
                SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
                string jsonData = sanPhamTinDungBUS.TimKiemSPTD(txtTenSPTDTabSPTD.Text, txtMaSPTDTabSPTD.Text, txtNguonTabSPTD.Text);
                List<SanPhamTinDung> list = JsonConvert.DeserializeObject<List<SanPhamTinDung>>(jsonData);
                // Hiển thị danh sách
                gridDSSPTD.Rows.Clear();
                foreach (SanPhamTinDung temp in list)
                {
                    gridDSSPTD.Rows.Add(temp.MaSPTD, temp.TenSPTD, temp.TenNguon, temp.ThoiHanVay, temp.LaiSuat, temp.LaiSuatQuaHan, temp.TrangThai);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button thêm sản phẩm tín dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThemTabSPTD_Click(object sender, EventArgs e)
        {
            ThemMoiSPTD themMoiSPTD = new ThemMoiSPTD();
            themMoiSPTD.nguoiDungHeThong = nguoiDungHienTai;
            themMoiSPTD.gioHT = lblTime.Text;
            themMoiSPTD.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện click button sửa sản phẩm tín dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaTabSPTD_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridDSSPTD.RowCount > 0 && gridDSSPTD.SelectedRows.Count > 0)
                {
                    SuaSPTD suaSPTD = new SuaSPTD();
                    // Lấy sản phẩm tín dụng được chọn
                    SanPhamTinDung sanPhamTinDung = new SanPhamTinDung();
                    sanPhamTinDung.MaSPTD = gridDSSPTD.SelectedRows[0].Cells[0].Value.ToString();
                    sanPhamTinDung.TenSPTD = gridDSSPTD.SelectedRows[0].Cells[1].Value.ToString();
                    sanPhamTinDung.TenNguon = gridDSSPTD.SelectedRows[0].Cells[2].Value.ToString();
                    sanPhamTinDung.ThoiHanVay = Int32.Parse(gridDSSPTD.SelectedRows[0].Cells[3].Value.ToString());
                    sanPhamTinDung.LaiSuat = Int32.Parse(gridDSSPTD.SelectedRows[0].Cells[4].Value.ToString());
                    sanPhamTinDung.LaiSuatQuaHan = Int32.Parse(gridDSSPTD.SelectedRows[0].Cells[5].Value.ToString());
                    sanPhamTinDung.TrangThai = gridDSSPTD.SelectedRows[0].Cells[6].Value.ToString();

                    suaSPTD.sanPhamTinDung = sanPhamTinDung;
                    suaSPTD.dataGridView = gridDSSPTD;
                    suaSPTD.nguoiDungHeThong = nguoiDungHienTai;
                    suaSPTD.gioHT = lblTime.Text;

                    suaSPTD.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn SPTD nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button tìm kiếm khách hàng & sptd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách KH & SPTD
                KhachHang_SPTD_BUS khachHang_SPTD_BUS = new KhachHang_SPTD_BUS();
                string jsonData = khachHang_SPTD_BUS.LayDSKH_SPTD(txtSoTKLK.Text, txtTenKH.Text, txtMaSPTD.Text);
                List<KhachHang_SPTD> list = JsonConvert.DeserializeObject<List<KhachHang_SPTD>>(jsonData);
                // Hiển thị lên grid view
                gridDSKHSPTD.Rows.Clear();
                foreach (KhachHang_SPTD temp in list)
                {
                    gridDSKHSPTD.Rows.Add(temp.MaSPTD, temp.TenSPTD, temp.SoTKLK, temp.TenKH, temp.TenNguon, temp.TrangThai);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button đăng ký mới sptd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDangKyMoiSPTD_Click(object sender, EventArgs e)
        {
            DangKyMoiSPTD dangKyMoiSPTD = new DangKyMoiSPTD();
            dangKyMoiSPTD.dataGridView = gridDSKHSPTD;
            dangKyMoiSPTD.gioHT = lblTime.Text;
            dangKyMoiSPTD.nguoiDungHeThong = nguoiDungHienTai;
            dangKyMoiSPTD.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện click button hủy đăng ký sử dụng sptd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuyDangKySPTD_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridDSKHSPTD.RowCount > 0 && gridDSKHSPTD.SelectedRows.Count > 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn hủy đăng ký SPTD này?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (gridDSKHSPTD.SelectedRows[0].Cells[5].Value.ToString() == "Ngừng sử dụng")
                        {
                            MessageBox.Show("Bạn đã ngừng sử dụng SPTD, không cần hủy", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Hủy đăng ký
                            KhachHangBUS khachHangBUS = new KhachHangBUS();
                            string jsonDataKH = khachHangBUS.layMotKhachHang(gridDSKHSPTD.SelectedRows[0].Cells[2].Value.ToString());
                            KhachHang khachHang = JsonConvert.DeserializeObject<KhachHang>(jsonDataKH);
                            SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
                            string jsonDataSPTD = sanPhamTinDungBUS.GetSPTD(gridDSKHSPTD.SelectedRows[0].Cells[0].Value.ToString());
                            SanPhamTinDung sanPhamTinDung = JsonConvert.DeserializeObject<SanPhamTinDung>(jsonDataSPTD);

                            KhachHang_SPTD_BUS khachHang_SPTD_BUS = new KhachHang_SPTD_BUS();
                            if (khachHang_SPTD_BUS.HuyDangKy(khachHang.idKH, sanPhamTinDung.IdSPTD))
                            {
                                // Ghi log
                                LichSu lichSu = new LichSu();
                                lichSu.MaDT = sanPhamTinDung.MaSPTD;
                                lichSu.NoiDung = "Hủy đăng ký sử dụng SPTD";
                                lichSu.ThoiGian = DateTime.Parse(lblTime.Text);
                                lichSu.GiaTriTruoc = "null";
                                lichSu.GiaTriSau = "null";
                                lichSu.TenDN = nguoiDungHienTai.tenDangNhapND;
                                lichSu.SoTKLK = khachHang.STKLK;
                                LichSuBUS lichSuBUS = new LichSuBUS();
                                lichSuBUS.ThemLichSu(JsonConvert.SerializeObject(lichSu));

                                MessageBox.Show("Hủy đăng ký sử dụng SPTD thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Cập nhật grid view
                                foreach (DataGridViewRow temp in gridDSKHSPTD.Rows)
                                {
                                    if (temp.Cells[0].Value.ToString() == sanPhamTinDung.MaSPTD && temp.Cells[2].Value.ToString() == khachHang.STKLK)
                                    {
                                        temp.Cells[5].Value = "Ngừng sử dụng";
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn SPTD nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tìm kiếm giải ngân
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemTabGN_Click(object sender, EventArgs e)
        {
            try
            {
                GiaiNganBUS giaiNganBUS = new GiaiNganBUS();
                //lấy DS GN của số TKLK 
                string jsonData = giaiNganBUS.TimKiemGN(txtSoTKLKTabGN.Text);
                List<GN_KH> list = JsonConvert.DeserializeObject<List<GN_KH>>(jsonData);
                // Lấy danh sách số TKLK
                List<string> listSTKLK = new List<string>();
                foreach(GN_KH temp in list)
                {
                    listSTKLK.Add(temp.SoTKLK);
                }
                //lấy tất cả các GN
                string json = giaiNganBUS.layDSGN();
                List<GN_KH> listAll = JsonConvert.DeserializeObject<List<GN_KH>>(json);

                gridDSMonGN.Rows.Clear();
                
                if(txtSoTKLKTabGN.Text == "")
                {
                    foreach (GN_KH temp in listAll)
                    {
                        gridDSMonGN.Rows.Add(temp.SoTKLK, temp.MaGN, temp.SoTienGN.ToString("#,##0"), temp.TrangThai, temp.DuNoGoc.ToString("#,##0"), temp.DuNoLaiTrongHan.ToString("#,##0"), temp.DuNoLaiQuaHan.ToString("#,##0"));
                    }
                    txtTenKHTabGN.Text = "";
                }
                else if(txtSoTKLKTabGN.Text.Length == 10 && listSTKLK.Contains(txtSoTKLKTabGN.Text))
                {
                    foreach (GN_KH temp in list)
                    {
                        if (txtSoTKLKTabGN.Text == temp.SoTKLK)
                        {
                            txtTenKHTabGN.Text = temp.TenKH;
                            gridDSMonGN.Rows.Add(temp.SoTKLK, temp.MaGN, temp.SoTienGN.ToString("#,##0"), temp.TrangThai, temp.DuNoGoc.ToString("#,##0"), temp.DuNoLaiTrongHan.ToString("#,##0"), temp.DuNoLaiQuaHan.ToString("#,##0"));
                        }
                        else
                        {
                            txtTenKHTabGN.Text = "";
                        }
                    }
                }
                else
                {
                    txtTenKHTabGN.Text = "";
                    MessageBox.Show("Số TKLK không tồn tại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xem chi tiết giải ngân
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXemChiTietTabGN_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridDSMonGN.RowCount > 0 && gridDSMonGN.SelectedRows.Count > 0)
                {
                    XemChiTietGN xemChiTietGN = new XemChiTietGN();
                    GiaiNganBUS giaiNganBUS = new GiaiNganBUS();
                    GN_SPTD_NGUON gN_SPTD_ = new GN_SPTD_NGUON();
                    string jsonData = giaiNganBUS.xemChiTietGN(gridDSMonGN.SelectedRows[0].Cells[1].Value.ToString());
                    gN_SPTD_ = JsonConvert.DeserializeObject<GN_SPTD_NGUON>(jsonData);

                    xemChiTietGN.GN_SPTD_ = gN_SPTD_;
                    xemChiTietGN.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn giải ngân nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// Xử lý sự kiện click button lịch sử trả nợ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLichSuTN_Click(object sender, EventArgs e)
        {
            try
            {
                if(gridDSMonNo.Rows.Count > 0 && gridDSMonNo.SelectedRows.Count > 0)
                {
                    LichSuTraNo lichSuTraNo = new LichSuTraNo();
                    // Lấy mã giải ngân của món giải ngân được chọn
                    string maGN = gridDSMonNo.SelectedRows[0].Cells[0].Value.ToString();
                    // Lấy id giải ngân khi biết mã giải ngân
                    TraNoBUS traNoBUS = new TraNoBUS();
                    int idGN = traNoBUS.GetIDGN(maGN);

                    lichSuTraNo.maGN = maGN;
                    lichSuTraNo.idGN = idGN;

                    lichSuTraNo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn món giải ngân nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Xử lý sự kiện click button sửa giải ngân
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaTabGN_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridDSMonGN.RowCount > 0 && gridDSMonGN.SelectedRows.Count > 0)
                {
                    SuaGN suaGN = new SuaGN();
                    suaGN.dataGridView = gridDSMonGN;
                    GN_SPTD_NGUON gN_SPTD_ = new GN_SPTD_NGUON();
                    GiaiNganBUS giaiNganBUS = new GiaiNganBUS();
                    string jsonData = giaiNganBUS.xemChiTietGN(gridDSMonGN.SelectedRows[0].Cells[1].Value.ToString());
                    gN_SPTD_ = JsonConvert.DeserializeObject<GN_SPTD_NGUON>(jsonData);
                    suaGN.giaiNgan = gN_SPTD_;
                    if (gN_SPTD_.DuNoLaiTH > 0 || gN_SPTD_.TrangThai == "Hoàn thành")
                    {
                        MessageBox.Show("Không thể sửa giải ngân này", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        suaGN.nguoiDungHeThong = nguoiDungHienTai;
                        suaGN.gioHT = lblTime.Text;
                        suaGN.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn giải ngân nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi chọn một tab khác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Text == "User")
            {
                AcceptButton = btnTimKiemTabUser;
            }
            if (tabControl.SelectedTab.Text == "Khách hàng")
            {
                AcceptButton = btnTimKiemTabKH;
            }
            if (tabControl.SelectedTab.Text == "Sản phẩm tín dụng")
            {
                AcceptButton = btnTimKiemTabSPTD;
            }
            if (tabControl.SelectedTab.Text == "Đăng ký sản phẩm tín dụng")
            {
                AcceptButton = btnTimKiem;
            }
            if (tabControl.SelectedTab.Text == "Nguồn")
            {
                AcceptButton = btnTimKiemTabNguon;
            }
            if (tabControl.SelectedTab.Text == "Giải ngân")
            {
                AcceptButton = btnTimKiemTabGN;
            }
            if (tabControl.SelectedTab.Text == "Trả nợ")
            {
                AcceptButton = btnTimKiemTabTN;
            }
            if (tabControl.SelectedTab.Text == "Lịch sử")
            {
                AcceptButton = btnTimKiemTabLS;
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button trả nợ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTraNo_Click(object sender, EventArgs e)
        {
            try
            {
                if(gridDSMonNo.Rows.Count > 0 && gridDSMonNo.SelectedRows.Count > 0)
                {
                    TraNo traNo = new TraNo();
                    traNo.maGNTN = gridDSMonNo.SelectedRows[0].Cells[0].Value.ToString();
                    traNo.nguoiDungHeThong = nguoiDungHienTai;
                    traNo.dataGridView = gridDSMonNo;
                    traNo.gioHT = lblTime.Text;
                    traNo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn món giải ngân nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Xử lý sự kiện click button tìm kiếm lịch sử
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemTabLS_Click(object sender, EventArgs e)
        {
            // Lấy danh sách kết quả
            string from = dateTimePickerST.Value.ToShortDateString();
            string to = dateTimePickerFT.Value.ToShortDateString();
            LichSuBUS lichSuBUS = new LichSuBUS();
            List<LichSu> list = new List<LichSu>();
            list = JsonConvert.DeserializeObject<List<LichSu>>(lichSuBUS.TimKiemLichSu(txtTDNTabLS.Text, txtSoTKLKTabLS.Text, txtMaDTTabLS.Text, from, to));
            // Hiển thị kết quả
            gridLog.Rows.Clear();
            foreach (LichSu temp in list)
            {
                gridLog.Rows.Add(temp.TenDN, temp.SoTKLK, temp.MaDT, temp.GiaTriTruoc, temp.GiaTriSau, temp.NoiDung, temp.ThoiGian);
            }
            gridLog.Refresh();
        }

        /// <summary>
        /// Xử lý sự kiện click button tìm kiếm tab trả nợ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemTabTN_Click(object sender, EventArgs e)
        {
            gridDSMonNo.Rows.Clear();
            txtTenKHTabTN.Text = "";
            if (txtSoTKLKTabTN.Text == "")
            {
                // Lấy danh sách tất cả các món giải ngân còn nợ của tất cả các KH
                TraNoBUS traNoBUS = new TraNoBUS();
                List<GiaiNgan> list = JsonConvert.DeserializeObject<List<GiaiNgan>>(traNoBUS.GetListGN());
                // Hiển thị kết quả
                foreach (GiaiNgan temp in list)
                {
                    gridDSMonNo.Rows.Add(temp.MaGN, temp.DuNoGoc.ToString("#,##0"), temp.DuNoLaiTrongHan.ToString("#,##0"), temp.DuNoLaiNgoaiHan.ToString("#,##0"), temp.NgayDaoHan);
                }
                gridDSMonNo.Refresh();
            }
            else
            {
                // Lấy KH theo số TKLK
                KhachHangBUS khachHangBUS = new KhachHangBUS();
                string jsonData = khachHangBUS.layMotKhachHang(txtSoTKLKTabTN.Text);
                if (jsonData != "null")
                {
                    KhachHang khachHang = JsonConvert.DeserializeObject<KhachHang>(jsonData);
                    // Lấy danh sách các món giải ngân còn nợ của KH
                    TraNoBUS traNoBUS = new TraNoBUS();
                    List<GiaiNgan> list = JsonConvert.DeserializeObject<List<GiaiNgan>>(traNoBUS.GetListGNWithIdKH(khachHang.idKH));
                    // Hiển thị kết quả
                    txtTenKHTabTN.Text = khachHang.hoTenKH;
                    foreach (GiaiNgan temp in list)
                    {
                        gridDSMonNo.Rows.Add(temp.MaGN, temp.DuNoGoc.ToString("#,##0"), temp.DuNoLaiTrongHan.ToString("#,##0"), temp.DuNoLaiNgoaiHan.ToString("#,##0"), temp.NgayDaoHan);
                    }
                    gridDSMonNo.Refresh();
                }
                else
                {
                    MessageBox.Show("Số TKLK không tồn tại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button dự tính lãi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDuTinhLai_Click(object sender, EventArgs e)
        {
            try
            {
                if(gridDSMonNo.Rows.Count > 0 && gridDSMonNo.SelectedRows.Count > 0)
                {
                    if(Int64.Parse(gridDSMonNo.SelectedRows[0].Cells[1].Value.ToString().Replace(",","")) > 0)
                    {
                        DuTinhLai duTinhLai = new DuTinhLai();
                        duTinhLai.maGN = gridDSMonNo.SelectedRows[0].Cells[0].Value.ToString();
                        duTinhLai.gioHT = lblTime.Text;
                        duTinhLai.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Món giải ngân đã trả hết nợ, không thể dự tính lãi", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Thao tác lỗi. Bạn chưa chọn món giải ngân nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

