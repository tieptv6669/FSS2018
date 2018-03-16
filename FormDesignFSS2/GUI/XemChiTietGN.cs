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
using FormDesignFSS2.GiaiNganWS;


namespace FormDesignFSS2.GUI
{
    public partial class XemChiTietGN : Form
    {
        public GN_SPTD_NGUON GN_SPTD_;

        public XemChiTietGN()
        {
            InitializeComponent();
            GN_SPTD_ = new GN_SPTD_NGUON();
        }

        private void XemChiTietGN_Load(object sender, EventArgs e)
        {
            txtSoTKLK.Text = GN_SPTD_.SoTKLK;
            txtMaGN.Text = GN_SPTD_.MaGN;
            txtSPTD.Text = GN_SPTD_.TenSPTD;
            txtLaiSuat.Text = GN_SPTD_.LaiSuat.ToString();
            txtLaiQuaHan.Text = GN_SPTD_.LaiSuatQuaHan.ToString();
            txtKyHan.Text = GN_SPTD_.KyHan.ToString();
            txtDuNoGoc.Text = GN_SPTD_.DuNoGoc.ToString("#,##0");
            txtDuNoLaiTrongHan.Text = GN_SPTD_.DuNoLaiTH.ToString("#,##0");
            txtDuNoLaiNgoaiHan.Text = GN_SPTD_.DuNoLaiNH.ToString("#,##0");
            txtTenKH.Text = GN_SPTD_.TenKH;
            txtSoTienGN.Text = GN_SPTD_.SoTienGN.ToString("#,##0");
            txtTrangThai.Text = GN_SPTD_.TrangThai;
            txtNguon.Text = GN_SPTD_.TenNguon;
            txtNgayGN.Text = GN_SPTD_.NgayGN.ToString();
            txtNgayDH.Text = GN_SPTD_.NgayDH.ToString();
            txtGhiChu.Text = GN_SPTD_.GhiChu;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
