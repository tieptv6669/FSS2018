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
                switch(traNoBUS.KTThongTinTraNo(txtMaGN.Text, txtSoTienTra.Text, txtDuNoGoc.Text.Replace(",", ""), txtDuNoLaiTrongHan.Text.Replace(",", ""), txtDuNoLaiQuaHan.Text.Replace(",", "")))
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
                    case 3:
                        {
                            lblError.Text = "Số tiền trả không hợp lệ";
                            break;
                        }
                    case 4:
                        {
                            lblError.Text = "Số tiền trả quá lớn";
                            break;
                        }
                    case 0:
                        {
                            lblError.Text = "";
                            txtSoTienTra.Text = Int64.Parse(txtSoTienTra.Text).ToString("#,##0");
                            btnXacNhan.Text = "Lưu";
                            btnHuy.Text = "Quay lại";
                            btnHuy.Image = Properties.Resources._101;
                            DisableElement();
                            break;
                        }
                }
            }
            else
            {
                // Thực hiện trả nợ
                ThucHienTraNo();
            }
        }

        /// <summary>
        /// Reset các textbox
        /// </summary>
        private void ResetElement()
        {
            lblError.Text = "";
            txtSoTienTra.Text = "";
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
        /// Disable các text box
        /// </summary>
        private void DisableElement()
        {
            txtMaGN.Enabled = false;
            txtMaTN.Enabled = false;
            txtTenKH.Enabled = false;
            txtGocBanDau.Enabled = false;
            txtDuNoGoc.Enabled = false;
            txtDuNoLaiTrongHan.Enabled = false;
            txtDuNoLaiQuaHan.Enabled = false;
            txtNgayDaoHan.Enabled = false;
            txtNgayTraNo.Enabled = false;
            txtSoNgayQuaHan.Enabled = false;
            txtSoTienTra.Enabled = false;
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
                // Tạo mã trả nợ
                string maTN = traNoBUS.TaoMaTraNo(giaiNgan.MaGN);
                // Hiển thị thông tin
                txtMaTN.Text = maTN;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void ThucHienTraNo()
        {
            long soTienTra = Int64.Parse(txtSoTienTra.Text.Replace(",", ""));
            long duNoGoc = Int64.Parse(txtDuNoGoc.Text.Replace(",", ""));
            long duNoLaiTrongHan = Int64.Parse(txtDuNoLaiTrongHan.Text.Replace(",", ""));
            long duNoLaiQuaHan = Int64.Parse(txtDuNoLaiQuaHan.Text.Replace(",", ""));

            MessageBox.Show(soTienTra.ToString());
            MessageBox.Show(duNoGoc.ToString());
            MessageBox.Show(duNoLaiTrongHan.ToString());
            MessageBox.Show(duNoLaiQuaHan.ToString());

            //if(soTienTra <= duNoLaiQuaHan)
            //{
            //    duNoLaiQuaHan -= soTienTra;
            //}
            //if(soTienTra > duNoLaiQuaHan && soTienTra <= (duNoLaiQuaHan + duNoLaiTrongHan))
            //{
            //    duNoLaiQuaHan = 0;
            //    soTienTra -= duNoLaiQuaHan;
            //    duNoLaiTrongHan -= soTienTra;
            //}
            //if(soTienTra > (duNoLaiQuaHan + duNoLaiTrongHan) && soTienTra <= (duNoGoc + duNoLaiQuaHan + duNoLaiTrongHan))
            //{
            //    duNoLaiQuaHan = 0;
            //    duNoLaiTrongHan = 0;
            //    soTienTra -= duNoLaiQuaHan;
            //    soTienTra -= duNoLaiTrongHan;
            //    duNoGoc -= soTienTra;
            //}

            //MessageBox.Show(duNoGoc.ToString() + '\n' + duNoLaiQuaHan.ToString() + '\n' + duNoLaiTrongHan.ToString());
        }
    }
}
