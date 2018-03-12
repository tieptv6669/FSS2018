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
        public ThemGN()
        {
            InitializeComponent();
        }

        private void txtSoTKLK_TextChanged(object sender, EventArgs e)
        {
            
            
        }
        
        private void cmbSPTD_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void btbXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.ForeColor = Color.Red;
                if (btbXacNhan.Text == "Xác nhận")
                {
                    NguonBUS nguonBUS = new NguonBUS();
                    string json = nguonBUS.GetNguon(txtTenNguon.Text);
                    Nguon list = JsonConvert.DeserializeObject<Nguon>(json);
                    long coTheVay = list.tienCoTheChoVay;
                    GiaiNganBUS giaiNganBUS = new GiaiNganBUS();
                    switch (giaiNganBUS.KTThongTinNhap(txtSoTKLK.Text, txtSoTienGN.Text, coTheVay))
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
                        case 4:
                            {
                                lblError.Text = "Số tiền còn lại trong nguồn ít hơn số tiền GN";
                                break;
                            }
                        case 5:
                            {
                                lblError.Text = "Bạn chưa nhập số TKLK";
                                break;
                            }
                        case 0:
                            {
                                lblError.Text = "";
                                txtSoTKLK.Enabled = false;
                                txtSoTienGN.Enabled = false;
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
                    KhachHangBUS khachHangBUS = new KhachHangBUS();
                    //KhachHang khachHang = new KhachHang();
                    string jsonKH = khachHangBUS.layMotKhachHang(txtSoTKLK.Text);
                    KhachHang listKH = JsonConvert.DeserializeObject<KhachHang>(jsonKH);
                    //khachHang = JsonConvert.DeserializeObject<KhachHang>(jsonKH);
                    int idKH = listKH.idKH;
                    
                    GiaiNgan giaiNgan = new GiaiNgan();
                    giaiNgan.MaGN = txtMaGN.Text;
                    giaiNgan.SoTienGN = int.Parse(txtSoTienGN.Text);
                    giaiNgan.DuNoGoc = int.Parse(txtSoTienGN.Text);
                    giaiNgan.NgayGN = DateTime.Now;
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
                        nguonBUS.updateSoTien(long.Parse(txtSoTienGN.Text),idNguon,coTheVay,daChoVay);
                        MessageBox.Show("Thêm khách hàng mới thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi sảy ra, thêm khách hàng mới thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (btnHuy.Text == "Hủy")
            {
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
    }
}
