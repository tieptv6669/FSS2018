using System;
using System.Drawing;
using System.Windows.Forms;
using FormDesignFSS2.TraNoWS;
using FormDesignFSS2.KhachHangWS;
using FormDesignFSS2.SanPhamTinDungWS;
using DTO;
using Newtonsoft.Json;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 16/3/2018
    /// </summary>
    public partial class DuTinhLai : Form
    {
        public string maGN;
        public SanPhamTinDung sanPhamTinDung;
        public string gioHT;

        public DuTinhLai()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý sự kiện click button thoát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DuTinhLai_Load(object sender, EventArgs e)
        {
            try
            {
                lblError.ForeColor = Color.Red;
                txtMaGN.Text = maGN;
                // Lấy món GN
                TraNoBUS traNoBUS = new TraNoBUS();
                GiaiNgan giaiNgan = JsonConvert.DeserializeObject<GiaiNgan>(traNoBUS.GetGN(maGN));
                // Lấy SPTD
                SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
                sanPhamTinDung = JsonConvert.DeserializeObject<SanPhamTinDung>(sanPhamTinDungBUS.GetSPTDWithID(giaiNgan.IDSPTD));
                // Lấy khách hàng
                KhachHangBUS khachHangBUS = new KhachHangBUS();
                KhachHang khachHang = JsonConvert.DeserializeObject<KhachHang>(khachHangBUS.GetKHWithID(giaiNgan.IDKH));
                // Hiển thị thông tin
                txtSoTKLK.Text = khachHang.STKLK;
                txtTenKH.Text = khachHang.hoTenKH;
                txtSoTienGN.Text = giaiNgan.SoTienGN.ToString("#,##0");
                txtNgayGN.Text = giaiNgan.NgayGN.ToShortDateString();
                txtNgayDH.Text = giaiNgan.NgayDaoHan.ToShortDateString();
                txtDuNoGoc.Text = giaiNgan.DuNoGoc.ToString("#,##0");
                txtDuNoLaiTrongHan.Text = giaiNgan.DuNoLaiTrongHan.ToString("#,##0");
                txtDuNoLaiQuaHan.Text = giaiNgan.DuNoLaiNgoaiHan.ToString("#,##0");
                txtNgayHienTai.Text = gioHT;
                dateTimePickerNgayTN.Value = DateTime.Parse(gioHT);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Xử lý sự kiện click button dự tính lãi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDuTinh_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayTN = DateTime.Parse(dateTimePickerNgayTN.Value.ToShortDateString());
                DateTime ngayHienTai = DateTime.Parse(txtNgayHienTai.Text);
                DateTime ngayDH = DateTime.Parse(txtNgayDH.Text);
                long duNoGoc = Int64.Parse(txtDuNoGoc.Text.Replace(",", ""));
                long duNoLaiTrongHan = Int64.Parse(txtDuNoLaiTrongHan.Text.Replace(",", ""));
                long duNoLaiQuaHan = Int64.Parse(txtDuNoLaiQuaHan.Text.Replace(",", ""));
                txtDuTinhLaiTrongHan.Text = "";
                txtDuTinhLaiQuaHan.Text = "";
                if (ngayTN <= ngayHienTai)
                {
                    lblError.Text = "Ngày trả nợ không hợp lệ";
                }
                else
                {
                    lblError.Text = "";
                    DuTinhLaiChoGN(ngayHienTai, ngayDH, ngayTN, duNoGoc, duNoLaiTrongHan, duNoLaiQuaHan, sanPhamTinDung.LaiSuat, sanPhamTinDung.LaiSuatQuaHan);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Dự tính lãi
        /// </summary>
        /// <param name="ngayHT"></param>
        /// <param name="ngayDH"></param>
        /// <param name="ngayTN"></param>
        /// <param name="duNoGoc"></param>
        /// <param name="duNoLaiTrongHanHT"></param>
        /// <param name="duNoLaiQuaHanHT"></param>
        private void DuTinhLaiChoGN(DateTime ngayHT, DateTime ngayDH, DateTime ngayTN, long duNoGoc, long duNoLaiTrongHanHT, long duNoLaiQuaHanHT, int laiSuatTH, int laiSuatQH)
        {
            try
            {
                long duNoLaiTrongHanTemp = duNoLaiTrongHanHT;
                long duNoLaiQuaHanTemp = duNoLaiQuaHanHT;
                if (ngayTN <= ngayDH)
                {
                    int soNgayTinhLai = (ngayTN - ngayHT).Days;
                    double duNo = (double)(soNgayTinhLai * laiSuatTH * duNoGoc) / 36000;
                    duNoLaiTrongHanTemp += (long)Math.Round(duNo);
                }
                else
                {
                    if (ngayHT <= ngayDH)
                    {
                        int soNgayTinhLaiTrongHan = (ngayDH - ngayHT).Days;
                        int soNgayTinhLaiQuaHan = (ngayTN - ngayDH).Days;
                        double duNoTH = (double)(soNgayTinhLaiTrongHan * laiSuatTH * duNoGoc) / 36000;
                        double duNoQH = (double)(soNgayTinhLaiQuaHan * laiSuatQH * duNoGoc) / 36000;
                        duNoLaiTrongHanTemp += (long)Math.Round(duNoTH);
                        duNoLaiQuaHanTemp += (long)Math.Round(duNoQH);
                    }
                    else
                    {
                        int soNgayTinhLaiQuaHan = (ngayTN - ngayHT).Days;
                        double duNoQH = (double)(soNgayTinhLaiQuaHan * laiSuatQH * duNoGoc) / 36000;
                        duNoLaiQuaHanTemp += (long)Math.Round(duNoQH);
                    }
                }

                txtDuTinhLaiTrongHan.Text = duNoLaiTrongHanTemp.ToString("#,##0");
                txtDuTinhLaiQuaHan.Text = duNoLaiQuaHanTemp.ToString("#,##0");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
