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
using FormDesignFSS2.SanPhamTinDungWS;
using FormDesignFSS2.LichSuWS;
using FormDesignFSS2.NguonWS;
using DTO;
using Newtonsoft.Json;

namespace FormDesignFSS2.GUI
{
    public partial class TraNo : Form
    {
        // Mã giải ngân của món giải ngân được chọn để trả nợ
        public string maGNTN;
        // ID của món giải ngân được chọn để trả nợ
        public int idGNTN;
        // ID của nguồn của món giải ngân
        public int idNguonGNTN;
        // Số TKLK của KH
        public string soTKLK;
        // Người dùng hệ thống
        public NguoiDung nguoiDungHeThong;
        // Gridview
        public DataGridView dataGridView;

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
            TraNoBUS traNoBUS = new TraNoBUS();
            txtMaGN.Text = maGNTN;
            // Lấy thông tin món giải ngân
            GiaiNgan giaiNgan = JsonConvert.DeserializeObject<GiaiNgan>(traNoBUS.GetGN(txtMaGN.Text));
            idGNTN = giaiNgan.IDGN;
            // Lấy id nguồn
            SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
            SanPhamTinDung sanPhamTinDung = JsonConvert.DeserializeObject<SanPhamTinDung>(sanPhamTinDungBUS.GetSPTDWithID(giaiNgan.IDSPTD));
            idNguonGNTN = sanPhamTinDung.IdNguon;
            if (giaiNgan != null)
            {
                // Lấy thông tin KH
                KhachHangBUS khachHangBUS = new KhachHangBUS();
                KhachHang khachHang = JsonConvert.DeserializeObject<KhachHang>(khachHangBUS.GetKHWithID(giaiNgan.IDKH));
                soTKLK = khachHang.STKLK;
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
        /// Xử lý sự kiện click button hủy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if(btnHuy.Text == "Hủy")
            {
                DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn hủy giao dịch trả nợ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogResult == DialogResult.Yes)
                {
                    Close();
                }
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
                            lblError.Text = "Số tiền trả lớn hơn tổng nợ";
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
        /// Thực hiện trả nợ
        /// </summary>
        /// <returns></returns>
        private void ThucHienTraNo()
        {
            long soTienTra = Int64.Parse(txtSoTienTra.Text.Replace(",", ""));
            long duNoGoc = Int64.Parse(txtDuNoGoc.Text.Replace(",", ""));
            long duNoLaiTrongHan = Int64.Parse(txtDuNoLaiTrongHan.Text.Replace(",", ""));
            long duNoLaiQuaHan = Int64.Parse(txtDuNoLaiQuaHan.Text.Replace(",", ""));
            long soTienTraGoc = 0;
            long soTienTraLai = 0;

            if (soTienTra <= duNoLaiQuaHan)
            {
                soTienTraLai = soTienTra;
                duNoLaiQuaHan -= soTienTra;
                soTienTra = 0;
            }
            if (soTienTra > duNoLaiQuaHan && soTienTra <= (duNoLaiQuaHan + duNoLaiTrongHan))
            {
                soTienTraLai = soTienTra;
                soTienTra -= duNoLaiQuaHan;
                duNoLaiQuaHan = 0;
                duNoLaiTrongHan -= soTienTra;
                soTienTra = 0;
            }
            if (soTienTra > (duNoLaiQuaHan + duNoLaiTrongHan) && soTienTra <= (duNoGoc + duNoLaiQuaHan + duNoLaiTrongHan))
            {
                soTienTraLai = duNoLaiQuaHan + duNoLaiTrongHan;
                soTienTra -= duNoLaiQuaHan;
                soTienTra -= duNoLaiTrongHan;
                duNoLaiQuaHan = 0;
                duNoLaiTrongHan = 0;
                duNoGoc -= soTienTra;
                soTienTraGoc = soTienTra;
                soTienTra = 0;
            }
            // Cập nhật lịch sử trả nợ
            DTO.TraNo traNo = new DTO.TraNo();
            traNo.MaTN = txtMaTN.Text;
            traNo.TenKH = txtTenKH.Text;
            traNo.SoTienTra = long.Parse(txtSoTienTra.Text.Replace(",", ""));
            traNo.SoTienTraLai = soTienTraLai;
            traNo.SoTienTraGoc = soTienTraGoc;
            traNo.NgayTraNo = DateTime.Now;
            traNo.IdGN = idGNTN;
            TraNoBUS traNoBUS = new TraNoBUS();
            bool dk1 = traNoBUS.ThemTN(JsonConvert.SerializeObject(traNo));
            // Cập nhật dư nợ cho món giải ngân
            bool dk2 = traNoBUS.CapNhatDuNo(maGNTN, duNoGoc, duNoLaiTrongHan, duNoLaiQuaHan);
            // Cập nhật lịch sử
            LichSu lichSu = new LichSu();
            lichSu.MaDT = txtMaTN.Text;
            lichSu.NoiDung = "Trả nợ";
            lichSu.ThoiGian = DateTime.Now;
            lichSu.GiaTriTruoc = "null";
            lichSu.GiaTriSau = "null";
            lichSu.TenDN = nguoiDungHeThong.tenDangNhapND;
            lichSu.SoTKLK = soTKLK;
            LichSuBUS lichSuBUS = new LichSuBUS();
            bool dk3 = lichSuBUS.ThemLichSu(JsonConvert.SerializeObject(lichSu));
            // Cập nhật số tiền cho nguồn
            NguonBUS nguonBUS = new NguonBUS();
            Nguon nguon = JsonConvert.DeserializeObject<Nguon>(nguonBUS.GetNguonWithID(idNguonGNTN));
            nguon.tienDaChoVay -= soTienTraGoc;
            nguon.tienCoTheChoVay += soTienTraGoc;
            bool dk4 = traNoBUS.CapNhatNguon(idNguonGNTN, nguon.tienDaChoVay, nguon.tienCoTheChoVay);

            if (dk1 && dk2 && dk3 && dk4)
            {
                MessageBox.Show("Trả nợ thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Cập nhật gridview
                foreach(DataGridViewRow temp in dataGridView.Rows)
                {
                    if(temp.Cells[0].Value.ToString() == maGNTN)
                    {
                        temp.Cells[1].Value = duNoGoc.ToString("#,##0");
                        temp.Cells[2].Value = duNoLaiTrongHan.ToString("#,##0");
                        temp.Cells[3].Value = duNoLaiQuaHan.ToString("#,##0");
                    }
                }
            }
            else
            {
                MessageBox.Show("Đã có lỗi sảy ra, trả nợ thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }
    }
}
