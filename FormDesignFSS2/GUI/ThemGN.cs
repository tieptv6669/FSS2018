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
using FormDesignFSS2.GiaiNganWS;
using FormDesignFSS2.KhachHang_SPTD_WS;
using DTO;
using FormDesignFSS2.SanPhamTinDungWS;
using FormDesignFSS2.LichSuWS;
using FormDesignFSS2.KhachHangWS;
using FormDesignFSS2.NguonWS;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Thùy Linh
    /// 7/3/2018
    /// </summary>
    public partial class ThemGN : Form
    {
        public string gioHT;
        public NguoiDung nguoiDungHeThong;

        public ThemGN()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Xử lý sự kiện chọn SPTD khác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSPTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lấy ds sptd của KH
            KhachHang_SPTD sptd = (KhachHang_SPTD)cmbSPTD.SelectedItem;
            SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
            string jsonData = sanPhamTinDungBUS.TimKiemSPTD(sptd.TenSPTD, sptd.MaSPTD, sptd.TenNguon);
            List<SanPhamTinDung> list = JsonConvert.DeserializeObject<List<SanPhamTinDung>>(jsonData);
            //DateTime date = DateTime.Now;
            
            foreach(var temp in list)
            {
                txtKyHan.Text = temp.ThoiHanVay.ToString();
                txtLaiSuat.Text = temp.LaiSuat.ToString();
                txtLaiSuatQH.Text = temp.LaiSuatQuaHan.ToString();
                txtTenNguon.Text = temp.TenNguon.ToString();
                //Kiểm tra ngày đáo hạn
                dateNgayDH.Value = dateNgayGN.Value.AddMonths(int.Parse(txtKyHan.Text));
                if(dateNgayDH.Value.DayOfWeek.ToString() == "Saturday")
                {
                    dateNgayDH.Value = dateNgayDH.Value.AddDays(-1);
                }
                if (dateNgayDH.Value.DayOfWeek.ToString() == "Sunday")
                {
                    dateNgayDH.Value = dateNgayDH.Value.AddDays(-2);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button xác nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btbXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHangBUS khachHangBUS = new KhachHangBUS();
                string jsonKH = khachHangBUS.layMotKhachHang(txtSoTKLK.Text);
                KhachHang listKH = JsonConvert.DeserializeObject<KhachHang>(jsonKH);

                lblError.ForeColor = Color.Red;
                if (btbXacNhan.Text == "Xác nhận")
                {
                    NguonBUS nguonBUS = new NguonBUS();
                    string json = nguonBUS.GetNguon(txtTenNguon.Text);
                    Nguon list = JsonConvert.DeserializeObject<Nguon>(json);
                    long coTheVay = list.tienCoTheChoVay;
                    GiaiNganBUS giaiNganBUS = new GiaiNganBUS();
                    switch (giaiNganBUS.KTThongTinNhap(txtSoTKLK.Text, txtSoTienGN.Text, coTheVay, listKH.loai))
                    {
                        case 1:
                            {
                                lblError.Text = "Số TKLK sai";
                                break;
                            }
                        case 2:
                            {
                                lblError.Text = "Bạn chưa nhập số tiền";
                                break;
                            }
                        case 3:
                            {
                                lblError.Text = "Số tiền không hợp lệ";
                                break;
                            }
                        case 7:
                            {
                                lblError.Text = "Vượt quá độ dài trường thông tin";
                                break;
                            }
                        case 4:
                            {
                                lblError.Text = "Số tiền nhiều hơn nguồn có";
                                break;
                            }
                        case 5:
                            {
                                lblError.Text = "Bạn chưa nhập số TKLK";
                                break;
                            }
                        case 6:
                            {
                                lblError.Text = "Số tiền vượt quá hạn mức loại KH";
                                break;
                            }
                        case 0:
                            {
                                lblError.Text = "";
                                txtSoTKLK.Enabled = false;
                                txtSoTienGN.Enabled = false;
                                txtSoTienGN.Text = Int64.Parse(txtSoTienGN.Text).ToString("#,##0");
                                cmbSPTD.Enabled = false;
                                txtGhiChu.Enabled = false;
                                btbXacNhan.Text = "Lưu";
                                btnHuy.Text = "Quay lại";
                                btnHuy.Image = Properties.Resources._101;
                                break;
                            }
                    }
                }
                else
                {
                    KhachHang_SPTD sptd = (KhachHang_SPTD)cmbSPTD.SelectedItem;
                    SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
                    string jsonSPTD = sanPhamTinDungBUS.TimKiemSPTD(sptd.TenSPTD, "","");
                    List<SanPhamTinDung> listSPTD = JsonConvert.DeserializeObject<List<SanPhamTinDung>>(jsonSPTD);
                    int idSPTD = 0;
                    foreach (SanPhamTinDung temp in listSPTD)
                    {
                        idSPTD = temp.IdSPTD;
                    }
                    
                    int idKH = listKH.idKH;
                    
                    GiaiNgan giaiNgan = new GiaiNgan();
                    giaiNgan.MaGN = txtMaGN.Text;
                    giaiNgan.SoTienGN = Int64.Parse(txtSoTienGN.Text.Replace(",", ""));
                    giaiNgan.DuNoGoc = Int64.Parse(txtSoTienGN.Text.Replace(",", ""));
                    giaiNgan.NgayGN = dateNgayGN.Value;
                    giaiNgan.NgayDaoHan = dateNgayDH.Value;
                    giaiNgan.IDSPTD = idSPTD;
                    giaiNgan.IDKH = idKH;
                    giaiNgan.DuNoLaiNgoaiHan = 0;
                    giaiNgan.DuNoLaiTrongHan = 0;
                    giaiNgan.TrangThai = "Còn nợ";
                    if (txtGhiChu.Text.Length == 0)
                    {
                        giaiNgan.GhiChu = " ";
                    }
                    else
                    {
                        giaiNgan.GhiChu = txtGhiChu.Text;
                    }

                    string jsonData = JsonConvert.SerializeObject(giaiNgan);
                    GiaiNganBUS giaiNganBUS = new GiaiNganBUS();
                    if (giaiNganBUS.themGiaiNgan(jsonData))
                    {
                        NguonBUS nguonBUS = new NguonBUS();
                        string json = nguonBUS.GetNguon(txtTenNguon.Text);
                        Nguon list = JsonConvert.DeserializeObject<Nguon>(json);
                        long coTheVay = list.tienCoTheChoVay;
                        long daChoVay = list.tienDaChoVay;
                        int idNguon = list.idNg;
                        nguonBUS.updateSoTien(long.Parse(txtSoTienGN.Text.Replace(",", "")), idNguon, coTheVay, daChoVay);
                        // Ghi log
                        LichSu lichSu = new LichSu();
                        lichSu.MaDT = giaiNgan.MaGN;
                        lichSu.NoiDung = "Thêm giải ngân mới";
                        lichSu.ThoiGian = DateTime.Parse(gioHT);
                        lichSu.GiaTriTruoc = "null";
                        lichSu.GiaTriSau = "null";
                        lichSu.TenDN = nguoiDungHeThong.tenDangNhapND;
                        lichSu.SoTKLK = txtSoTKLK.Text;
                        LichSuBUS lichSuBUS = new LichSuBUS();
                        lichSuBUS.ThemLichSu(JsonConvert.SerializeObject(lichSu));

                        MessageBox.Show("Thêm giải ngân mới thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi sảy ra, thêm giải ngân mới thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button hủy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (btnHuy.Text == "Hủy")
            {
                lblError.Text = "";
                Close();
            }
            else
            {
                txtSoTKLK.Enabled = true;
                txtSoTienGN.Enabled = true;
                cmbSPTD.Enabled = true;
                txtGhiChu.Enabled = true;
                btbXacNhan.Text = "Xác nhận";
                btnHuy.Text = "Hủy";
                btnHuy.Image = Properties.Resources._168;
            }
        }

        /// <summary>
        /// Xử lý sự kiện nhấn tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSoTKLK_Leave(object sender, EventArgs e)
        {
            try
            {
                lblError.ForeColor = Color.Red;
                if (txtSoTKLK.Text.Length == 10)
                {
                    KhachHangBUS khachHangBUS = new KhachHangBUS();
                    KhachHang kh = new KhachHang();
                    string json = khachHangBUS.layMotKhachHang(txtSoTKLK.Text);
                    kh = JsonConvert.DeserializeObject<KhachHang>(json);
                    if (kh != null)
                    {
                        lblError.Text = "";

                        // Lấy danh sách sptd
                        KhachHang_SPTD_BUS hang_SPTD_BUS = new KhachHang_SPTD_BUS();
                        string jsonData = hang_SPTD_BUS.LayDSKH_SPTD_SD(txtSoTKLK.Text);
                        List<KhachHang_SPTD> list = JsonConvert.DeserializeObject<List<KhachHang_SPTD>>(jsonData);
                        // Hiển thị danh sách SPTD lên combobox
                        if (list != null && list.Count > 0)
                        {
                            cmbSPTD.Refresh();
                            cmbSPTD.DataSource = list;
                            cmbSPTD.DisplayMember = "TenSPTD";
                            // Đặt giá trị mặc định cho cmbSPTD GN
                            cmbSPTD.SelectedIndex = 0;
                            // Sinh mã GN
                            GiaiNganBUS gnbus = new GiaiNganBUS();
                            txtMaGN.Text = gnbus.taoMaGN(txtSoTKLK.Text);
                        }
                        else
                        {
                            lblError.Text = "Không có SPTD nào để chọn";
                        }
                    }
                    else
                    {
                        lblError.Text = "Số TKLK sai";
                    }
                }
                else
                {
                    lblError.Text = "Số TKLK sai";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemGN_Load(object sender, EventArgs e)
        {
            dateNgayGN.Value = DateTime.Parse(gioHT);
            dateNgayDH.Value = DateTime.Parse(gioHT);
        }
    }
}
