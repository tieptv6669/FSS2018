﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DTO;
using FormDesignFSS2.GiaiNganWS;
using FormDesignFSS2.KhachHang_SPTD_WS;
using Newtonsoft.Json;
using FormDesignFSS2.SanPhamTinDungWS;
using FormDesignFSS2.NguonWS;
using FormDesignFSS2.KhachHangWS;
using FormDesignFSS2.XuLyCuoiNgayWS;
using FormDesignFSS2.LichSuWS;

namespace FormDesignFSS2.GUI
{
    public partial class SuaGN : Form
    {
        public GN_SPTD_NGUON giaiNgan;
        public DataGridView dataGridView;
        public NguoiDung nguoiDungHeThong;
        public string gioHT;

        public SuaGN()
        {
            InitializeComponent();
            giaiNgan = new GN_SPTD_NGUON();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuaGN_Load(object sender, EventArgs e)
        {
            try
            {
                lblError.ForeColor = Color.Red;
                txtSoTKLK.Text = giaiNgan.SoTKLK;
                txtMaGN.Text = giaiNgan.MaGN;
                txtSoTienGN.Text = giaiNgan.SoTienGN.ToString("#,##0");
                txtNguon.Text = giaiNgan.TenNguon;
                txtKyHan.Text = giaiNgan.KyHan.ToString();
                txtLaiSuat.Text = giaiNgan.LaiSuat.ToString();
                txtLaiSuatQH.Text = giaiNgan.LaiSuatQuaHan.ToString();
                dateNgayGN.Value = giaiNgan.NgayGN;
                dateNgayDH.Value = giaiNgan.NgayDH;
                txtGhiChu.Text = giaiNgan.GhiChu;
                // Lấy danh sách sptd
                KhachHang_SPTD_BUS hang_SPTD_BUS = new KhachHang_SPTD_BUS();
                KhachHang kh = new KhachHang();
                string jsonData = hang_SPTD_BUS.LayDSKH_SPTD_SD(txtSoTKLK.Text);
                List<KhachHang_SPTD> list = JsonConvert.DeserializeObject<List<KhachHang_SPTD>>(jsonData);
                // Hiển thị danh sách SPTD lên combobox
                cmbSPTD.Refresh();
                cmbSPTD.DataSource = list;
                cmbSPTD.DisplayMember = "tenSPTD";
                int i = 0;
                foreach (var temp in list)
                {
                    if (temp.TenSPTD == giaiNgan.TenSPTD)
                    {
                        cmbSPTD.SelectedIndex = i;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý dự kiện chọn SPTD khác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbSPTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                KhachHang_SPTD sptd = (KhachHang_SPTD)cmbSPTD.SelectedItem;
                SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
                string jsonData = sanPhamTinDungBUS.TimKiemSPTD(sptd.TenSPTD, sptd.MaSPTD, sptd.TenNguon);
                List<SanPhamTinDung> list = JsonConvert.DeserializeObject<List<SanPhamTinDung>>(jsonData);

                foreach (var temp in list)
                {
                    txtKyHan.Text = temp.ThoiHanVay.ToString();
                    txtLaiSuat.Text = temp.LaiSuat.ToString();
                    txtLaiSuatQH.Text = temp.LaiSuatQuaHan.ToString();
                    txtNguon.Text = temp.TenNguon.ToString();

                    dateNgayDH.Value = dateNgayGN.Value.AddMonths(int.Parse(txtKyHan.Text));
                    // Lấy danh sách ngày lễ
                    XuLyCuoiNgayBUS xuLyCuoiNgayBUS = new XuLyCuoiNgayBUS();
                    List<DateTime> listNgayLe = JsonConvert.DeserializeObject<List<DateTime>>(xuLyCuoiNgayBUS.GetListNgayNghi());
                    List<string> listNgayLeStr = new List<string>();
                    foreach (DateTime dateTime in listNgayLe)
                    {
                        listNgayLeStr.Add(dateTime.ToShortDateString());
                    }
                    // Lùi ngày đáo hạn về trước nếu là ngày lễ hoặc thứ 7 chủ nhật
                    while (listNgayLeStr.Contains(dateNgayDH.Value.ToShortDateString()) || dateNgayDH.Value.DayOfWeek.ToString() == "Saturday" || dateNgayDH.Value.DayOfWeek.ToString() == "Sunday")
                    {
                        dateNgayDH.Value = dateNgayDH.Value.AddDays(-1);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button xác nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnXacNhan.Text == "Xác nhận")
                {
                    KhachHangBUS khachHangBUS = new KhachHangBUS();
                    string jsonKH = khachHangBUS.layMotKhachHang(txtSoTKLK.Text);
                    KhachHang listKH = JsonConvert.DeserializeObject<KhachHang>(jsonKH);

                    //Lấy ra số tiền có thể cho vay trong danh sách nguồn
                    NguonBUS nguonBUS = new NguonBUS();
                    string json = nguonBUS.GetNguon(txtNguon.Text);
                    Nguon list = JsonConvert.DeserializeObject<Nguon>(json);
                    long coTheVay = list.tienCoTheChoVay;
                    //Check lỗi
                    GiaiNganBUS giaiNganBUS = new GiaiNganBUS();
                    switch (giaiNganBUS.KTTTSuaGN(txtSoTKLK.Text, dateNgayGN.Value,txtSoTienGN.Text,coTheVay, listKH.loai, txtGhiChu.Text))
                    {
                        case 1:
                            {
                                lblError.Text = "Bạn không thể sửa giải ngân";
                                break;
                            }
                        case 2:
                            {
                                lblError.Text = "Số tiền không hợp lệ";
                                break;
                            }
                        case 3:
                            {
                                lblError.Text = "Số tiền nhiều hơn nguồn có";
                                break;
                            }
                        case 4:
                            {
                                lblError.Text = "Số tiền vượt quá hạn mức loại KH";
                                break;
                            }
                        case 5:
                            {
                                lblError.Text = "Vượt quá độ dài trường thông tin";
                                break;
                            }
                        case 6:
                            {
                                lblError.Text = "Bạn chưa nhập số tiền";
                                break;
                            }
                        case 0:
                            {
                                lblError.Text = "";
                                btnXacNhan.Text = "Lưu";
                                btnHuy.Text = "Quay lại";
                                btnHuy.Image = Properties.Resources._101;
                                if (txtGhiChu.Text.Length == 0)
                                {
                                    txtGhiChu.Text = " ";
                                }
                                txtSoTKLK.Enabled = false;
                                txtSoTienGN.Enabled = false;
                                txtSoTienGN.Text = Int64.Parse(txtSoTienGN.Text).ToString("#,##0");
                                cmbSPTD.Enabled = false;
                                txtGhiChu.Enabled = false;
                                break;
                            }
                    }
                }
                else
                {
                    KhachHang_SPTD khachHang_SPTD = (KhachHang_SPTD)cmbSPTD.SelectedItem;
                    if (giaiNgan.SoTienGN == long.Parse(txtSoTienGN.Text.Replace(",","")) && giaiNgan.TenSPTD == khachHang_SPTD.TenSPTD &&
                          giaiNgan.GhiChu == txtGhiChu.Text)
                    {
                        MessageBox.Show("Thao tác lỗi. Bạn chưa thay đổi thông tin nào của giải ngân", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        GiaiNganBUS giaiNganBUS = new GiaiNganBUS();
                        KhachHang_SPTD sptd = (KhachHang_SPTD)cmbSPTD.SelectedItem;
                        SanPhamTinDungBUS sanPhamTinDungBUS = new SanPhamTinDungBUS();
                        string jsonData = sanPhamTinDungBUS.TimKiemSPTD(sptd.TenSPTD, sptd.MaSPTD, sptd.TenNguon);
                        List<SanPhamTinDung> list = JsonConvert.DeserializeObject<List<SanPhamTinDung>>(jsonData);
                        int idSPTD = 0;
                        foreach (var temp in list)
                        {
                            idSPTD = temp.IdSPTD;
                        }
                        string nguonCu = giaiNgan.TenNguon;
                        long stgn = giaiNgan.SoTienGN;
                        if (giaiNganBUS.SuaGN(giaiNgan.MaGN, long.Parse(txtSoTienGN.Text.Replace(",", "")), idSPTD, txtGhiChu.Text))
                        {
                            //Trả lại tiền cho nguồn cũ
                            NguonBUS nguonBUS = new NguonBUS();
                            string json = nguonBUS.GetNguon(nguonCu);
                            Nguon listt = JsonConvert.DeserializeObject<Nguon>(json);
                            long coTheVay = listt.tienCoTheChoVay;
                            long daChoVay = listt.tienDaChoVay;
                            int idNguon = listt.idNg;
                            nguonBUS.updateSoTienSua(stgn, idNguon, coTheVay, daChoVay);

                            //Trừ tiền cho nguồn mới
                            string jsons = nguonBUS.GetNguon(txtNguon.Text);
                            Nguon lists = JsonConvert.DeserializeObject<Nguon>(jsons);
                            long coTheVayms = lists.tienCoTheChoVay;
                            long daChoVayms = lists.tienDaChoVay;
                            int idNguonms = lists.idNg;
                            nguonBUS.updateSoTien(long.Parse(txtSoTienGN.Text.Replace(",", "")), idNguonms, coTheVayms, daChoVayms);

                            // Ghi log
                            LichSu lichSu = new LichSu();
                            lichSu.MaDT = giaiNgan.MaGN;
                            lichSu.NoiDung = "Sửa thông tin giải ngân";
                            lichSu.ThoiGian = DateTime.Parse(gioHT);
                            lichSu.GiaTriTruoc = JsonConvert.SerializeObject(giaiNgan);
                            giaiNgan.SoTienGN = long.Parse(txtSoTienGN.Text.Replace(",", ""));
                            giaiNgan.DuNoGoc = long.Parse(txtSoTienGN.Text.Replace(",", ""));
                            giaiNgan.TenSPTD = khachHang_SPTD.TenSPTD;
                            giaiNgan.LaiSuat = Int32.Parse(txtLaiSuat.Text);
                            giaiNgan.LaiSuatQuaHan = Int32.Parse(txtLaiSuatQH.Text);
                            giaiNgan.KyHan = Int32.Parse(txtKyHan.Text);
                            giaiNgan.TenNguon = txtNguon.Text;
                            giaiNgan.GhiChu = txtGhiChu.Text;
                            lichSu.GiaTriSau = JsonConvert.SerializeObject(giaiNgan);
                            lichSu.TenDN = nguoiDungHeThong.tenDangNhapND;
                            lichSu.SoTKLK = txtSoTKLK.Text;
                            LichSuBUS lichSuBUS = new LichSuBUS();
                            lichSuBUS.ThemLichSu(JsonConvert.SerializeObject(lichSu));

                            MessageBox.Show("Sửa thông tin giải ngân thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Đã có lỗi sảy ra, sửa thông tin giải ngân thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
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
                Close();
            }
            else
            {
                txtSoTKLK.Enabled = true;
                txtSoTienGN.Enabled = true;
                cmbSPTD.Enabled = true;
                txtGhiChu.Enabled = true;
                btnXacNhan.Text = "Xác nhận";
                btnHuy.Text = "Hủy";
                btnHuy.Image = Properties.Resources._168;
            }
        }
    }
}
