using System;
using System.Windows.Forms;
using DTO;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Thùy Linh
    /// 24/2/2018
    /// </summary>
    public partial class XemChiTietKH : Form
    {
        public KhachHang khachHang;

        /// <summary>
        /// Khởi tạo form

        /// </summary>
        public XemChiTietKH()
        {
            InitializeComponent();
            khachHang = new KhachHang();
        }
        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XemChiTietKH_Load(object sender, EventArgs e)
        {
            txtSoTKLK.Text = khachHang.STKLK;
            txtHoTenKH.Text = khachHang.hoTenKH;
            txtNgaySinhKH.Text = khachHang.ngaySinhKH.ToString();
            txtNgayMoTK.Text = khachHang.ngayMoTKKH.ToString();
            txtNgheNghiep.Text = khachHang.ngheNghiepKH;
            txtSoCMND.Text = khachHang.soCMNNKH;
            txtEmail.Text = khachHang.emailKH;
            txtGioiTinh.Text = khachHang.gioiTinhKH;
            txtLoaiKH.Text = khachHang.loai;
            txtSDT.Text = khachHang.SDTKH;
            txtDiaChi.Text = khachHang.diaChiKH;
            txtGhiChu.Text = khachHang.ghiChuKH;
        }

        /// <summary>
        /// Xử lý sự kiện click button đóng 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
