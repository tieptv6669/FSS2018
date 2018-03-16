using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormDesignFSS2.TraNoWS;
using FormDesignFSS2.KhachHangWS;
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
            lblError.ForeColor = Color.Red;
            txtMaGN.Text = maGN;
            // Lấy món GN
            TraNoBUS traNoBUS = new TraNoBUS();
            GiaiNgan giaiNgan = JsonConvert.DeserializeObject<GiaiNgan>(traNoBUS.GetGN(maGN));
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
            txtNgayHienTai.Text = DateTime.Now.ToShortDateString();
        }
    }
}
