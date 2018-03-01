﻿using System;
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
using FormDesignFSS2.KhachHangWS;
using FormDesignFSS2.NguonWS;
using FormDesignFSS2.Report;
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
            //DateTime date = DateTime.Now;
            //Console.WriteLine(date.DayOfWeek.ToString());
            string quyen = nguoiDungHienTai.quyenND;

            // Phân quyền người dùng
            if(quyen == "Quản lý")
            {
                tabControl.TabPages.RemoveAt(0);
                btnChayQuaNgay.Enabled = false;
            }
            if(quyen == "Nhân viên")
            {
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
        }

        /// <summary>
        /// Xử lý sự kiện click button chạy qua ngày 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChayQuaNgay_Click(object sender, EventArgs e)
        {
            ChayQuaNgay cqnForm = new ChayQuaNgay();
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
            themUser.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện click button tìm kiếm người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemTabUser_Click(object sender, EventArgs e)
        {
            // Xóa dữ liệu hiển thị cũ
            gridTabUser.Rows.Clear();
            // Lấy DS người dùng
            List<NguoiDung> list = new List<NguoiDung>();

            NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
            string jsonData = nguoiDungBUS.TimKiemNguoiDung(txtTenNhanVien.Text, txtTenDangNhap.Text);

            list = JsonConvert.DeserializeObject<List<NguoiDung>>(jsonData);

            // Hiển thị danh sách người dùng lên grid view
            foreach(NguoiDung temp in list)
            {
                gridTabUser.Rows.Add(temp.tenDangNhapND, temp.hoTenND, temp.chucVuND, temp.phongBanND, temp.quyenND);
            }
            if(list.Count > 0)
            {
                gridTabUser.Rows[0].Selected = true;
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button sửa người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaTabUser_Click(object sender, EventArgs e)
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

                suaUser.ShowDialog();
            }
            else
            {
                MessageBox.Show("Thao tác lỗi. Bạn chưa chọn người dùng nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button xóa người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaTabUser_Click(object sender, EventArgs e)
        {
            if(gridTabUser.RowCount > 0 && gridTabUser.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa " + gridTabUser.SelectedRows[0].Cells[1].Value.ToString() + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); 
                if(dialogResult == DialogResult.Yes)
                {
                    NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
                    if (nguoiDungBUS.XoaNguoiDung(gridTabUser.SelectedRows[0].Cells[0].Value.ToString()))
                    {
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
            else
            {
                MessageBox.Show("Thao tác lỗi. Bạn chưa chọn người dùng nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            doiMK.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện click button tìm kiếm khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemTabKH_Click(object sender, EventArgs e)
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
            if (list.Count > 0)
            {
                gridTabKH.Rows[0].Selected = true;
            }

        }

        /// Xử lý sự kiện click button reset mật khẩu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetTabUser_Click(object sender, EventArgs e)
        {
            if(gridTabUser.RowCount > 0 && gridTabUser.SelectedRows.Count > 0)
            {
                string tenDN = gridTabUser.SelectedRows[0].Cells[0].Value.ToString();
                string tenNguoiDung = gridTabUser.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn reset mật khẩu cho " + tenNguoiDung + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialogResult == DialogResult.Yes)
                {
                    // reset mật khẩu cho người dùng 
                    NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
                    if (nguoiDungBUS.ResetMatKhau(tenDN)){
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

        /// <summary>
        /// Xử lý sự kiện click button Xem chi tiết khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXemChiTietTabKH_Click(object sender, EventArgs e)
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
        }

        /// <summary>
        /// Xử lý sự kiện click button sửa khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaTabKH_Click(object sender, EventArgs e)
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

                suaKH.ShowDialog();
            }
            else
            {
                MessageBox.Show("Thao tác lỗi. Bạn chưa chọn khách hàng nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hiển thị danh sách các nguồn hiện có 
        /// </summary>
        public void HienThiDSNguon()
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
                foreach(Nguon temp in list)
                {
                    gridDSNguon.Rows.Add(temp.maNg, temp.tenNg, temp.hanMucNg, temp.tienDaChoVay, temp.tienCoTheChoVay);
                }
                if(gridDSNguon.RowCount > 1)
                {
                    gridDSNguon.Rows[0].Selected = true; 
                }
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
            themNguon.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện click button sửa nguồn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuaTabNguon_Click(object sender, EventArgs e)
        {
            if(gridDSNguon.RowCount > 0 && gridDSNguon.SelectedRows.Count > 0)
            {
                SuaNguon suaNguon = new SuaNguon();
                suaNguon.dataGridView = gridDSNguon;
                suaNguon.nguon.maNg = gridDSNguon.SelectedRows[0].Cells[0].Value.ToString();
                suaNguon.nguon.tenNg = gridDSNguon.SelectedRows[0].Cells[1].Value.ToString();
                suaNguon.nguon.hanMucNg = Int64.Parse(gridDSNguon.SelectedRows[0].Cells[2].Value.ToString().Replace(",", ""));
                suaNguon.nguon.tienDaChoVay = Int64.Parse(gridDSNguon.SelectedRows[0].Cells[3].Value.ToString().Replace(",", ""));
                suaNguon.nguon.tienCoTheChoVay = Int64.Parse(gridDSNguon.SelectedRows[0].Cells[4].Value.ToString().Replace(",", ""));

                suaNguon.ShowDialog();
            }
            else
            {
                MessageBox.Show("Thao tác lỗi. Bạn chưa chọn nguồn nào", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện xóa nguồn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXoaTabNguon_Click(object sender, EventArgs e)
        {
            if(gridDSNguon.RowCount > 0 && gridDSNguon.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nguồn " + gridDSNguon.SelectedRows[0].Cells[1].Value.ToString() + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialogResult == DialogResult.Yes)
                {
                    // Lấy mã của nguồn được chọn
                    string maNguon = gridDSNguon.SelectedRows[0].Cells[0].Value.ToString();

                    NguonBUS nguonBUS = new NguonBUS();
                    if (nguonBUS.XoaNguon(maNguon))
                    {
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

        /// <summary>
        /// Xử lý sự kiện click button tìm kiếm nguồn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiemTabNguon_Click(object sender, EventArgs e)
        {
            gridDSNguon.Rows.Clear();

            NguonBUS nguonBUS = new NguonBUS();
            string jsonData = nguonBUS.TimKiemNguon(txtTenNguon.Text, txtMaNguon.Text);

            List<Nguon> list = JsonConvert.DeserializeObject<List<Nguon>>(jsonData);
            if(list != null && list.Count > 0)
            {
                foreach(Nguon temp in list)
                {
                    gridDSNguon.Rows.Add(temp.maNg, temp.tenNg, temp.hanMucNg.ToString("#,##0"), temp.tienDaChoVay.ToString("#,##0"), temp.tienCoTheChoVay.ToString("#,##0"));
                }
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
            themKH.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện click button xuất báo cáo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXuatBC_Click(object sender, EventArgs e)
        {
            // Lấy danh sách khách hàng
            KhachHangBUS khachHangBUS = new KhachHangBUS();
            string jsonData = khachHangBUS.KhachHangReport();
            List<KhachHangReport> list = JsonConvert.DeserializeObject<List<KhachHangReport>>(jsonData);
            // Chuyển danh sách khách hàng sang data table
            DataTable dataTable = DataTableConvert.ConvertToDataTable(list);
            // Add data table vào dataset
            DataSet dataSet = new DataSet("DSKH");
            dataSet.Tables.Add(dataTable);
            // Parameter
            string name = "Trần Viết Tiệp";
            string name2 = "Trần Viết Nhật";
            // Thiết lập báo cáo
            reportViewerBC.LocalReport.ReportPath = "Report/DanhSachKH.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            ReportParameter[] reportParameter = new ReportParameter[2];
            reportParameter[0] = new ReportParameter("demoParameter", name, true);
            reportParameter[1] = new ReportParameter("demoParameter2", name2, true);
            reportViewerBC.LocalReport.SetParameters(reportParameter);

            reportDataSource.Name = "DSKH";
            reportDataSource.Value = dataSet.Tables[0];
            reportViewerBC.LocalReport.DataSources.Add(reportDataSource);
            // Hiển thị báo cáo
            reportViewerBC.RefreshReport();
        }
    }
}
