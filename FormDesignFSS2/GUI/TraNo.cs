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
    public partial class TraNo : Form
    {
        public TraNo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TraNo_Load(object sender, EventArgs e)
        {
            lblError.ForeColor = Color.Red;
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
                txtMaGN.Enabled = true;
                txtMaTN.Enabled = true;
                txtTenKH.Enabled = true;
                txtGocBanDau.Enabled = true;
                txtDuNoGoc.Enabled = true;
                txtDuNoLaiTrongHan.Enabled = true;
                txtDuNoLaiQuaHan.Enabled = true;
                txtNgayDaoHan.Enabled = true;
                txtNgayTraNo.Enabled = true;
                txtSoNgayQuaHan.Enabled = true;
                txtSoTienTra.Enabled = true;
                btnXacNhan.Text = "Xác nhận";
                btnHuy.Text = "Hủy";
                btnHuy.Image = Properties.Resources._168;
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button xác nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(btnXacNhan.Text == "Xác nhận")
            {
                TraNoBUS traNoBUS = new TraNoBUS();
                switch(traNoBUS.KTThongTinTraNo(txtMaGN.Text, txtSoTienTra.Text))
                {
                    case 1:
                        {
                            lblError.Text = "Bạn chưa nhập mã giải ngân";
                            break;
                        }
                    case 2:
                        {
                            lblError.Text = "Mã giải ngân không tồn tại hoặc đã trả hết nợ";
                            break;
                        }
                    case 0:
                        {
                            lblError.Text = "";
                            break;
                        }
                }
            }
            else
            {

            }
        }

        /// <summary>
        /// Reset các textbox
        /// </summary>
        private void ResetElement()
        {
            txtMaTN.Text = "";
            txtTenKH.Text = "";
            txtGocBanDau.Text = "";
            txtDuNoGoc.Text = "";
            txtDuNoLaiTrongHan.Text = "";
            txtDuNoLaiQuaHan.Text = "";
            txtNgayDaoHan.Text = "";
            txtNgayTraNo.Text = "";
            txtSoNgayQuaHan.Text = "";
        }

        /// <summary>
        /// Xử lý sự kiện nhấn tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMaGN_Leave(object sender, EventArgs e)
        {
            TraNoBUS traNoBUS = new TraNoBUS();
            ResetElement();
            // Lấy thông tin món giải ngân
            GiaiNgan giaiNgan = JsonConvert.DeserializeObject<GiaiNgan>(traNoBUS.GetGN(txtMaGN.Text));
            if(giaiNgan != null)
            {
                // Lấy thông tin KH
                KhachHangBUS khachHangBUS = new KhachHangBUS();
                KhachHang khachHang = JsonConvert.DeserializeObject<KhachHang>(khachHangBUS.GetKHWithID(giaiNgan.IDKH));
                // Hiển thị thông tin
                txtTenKH.Text = khachHang.hoTenKH;
                txtGocBanDau.Text = giaiNgan.SoTienGN.ToString("#,##0");
                txtDuNoGoc.Text = giaiNgan.DuNoGoc.ToString("#,##0");
                txtDuNoLaiTrongHan.Text = giaiNgan.DuNoLaiTrongHan.ToString("#,##0");
                txtDuNoLaiQuaHan.Text = giaiNgan.DuNoLaiNgoaiHan.ToString("#,##0");
                txtNgayDaoHan.Text = giaiNgan.NgayDaoHan.ToShortDateString();
                txtNgayTraNo.Text = DateTime.Now.ToShortDateString();
                if (DateTime.Parse(txtNgayTraNo.Text) <= DateTime.Parse(txtNgayDaoHan.Text))
                {
                    txtSoNgayQuaHan.Text = "0";
                }
                else
                {
                    txtSoNgayQuaHan.Text = (DateTime.Parse(txtNgayTraNo.Text) - DateTime.Parse(txtNgayDaoHan.Text)).Days.ToString();
                }
            }
        }
    }
}
