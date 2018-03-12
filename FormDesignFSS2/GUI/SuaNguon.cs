using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using FormDesignFSS2.LichSuWS;
using DTO;
using FormDesignFSS2.NguonWS;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 26/2/2018
    /// </summary>
    public partial class SuaNguon : Form
    {
        public Nguon nguon;
        public DataGridView dataGridView;
        public NguoiDung nguoiDungHeThong;

        /// <summary>
        /// Khởi tạo form
        /// </summary>
        public SuaNguon()
        {
            nguon = new Nguon();
            InitializeComponent();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuaNguon_Load(object sender, EventArgs e)
        {
            lblError.ForeColor = Color.Red;
            txtMaNguon.Text = nguon.maNg;
            txtTenNguon.Text = nguon.tenNg;
            txtHanMuc.Text = nguon.hanMucNg.ToString("#,##0");
            txtTienDaChoVay.Text = nguon.tienDaChoVay.ToString("#,##0");
            txtTienCoTheChoVay.Text = nguon.tienCoTheChoVay.ToString("#,##0");
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
                    NguonBUS nguonBUS = new NguonBUS();
                    switch (nguonBUS.KTThongTinSuaNguon(txtHanMuc.Text, txtTienDaChoVay.Text.Replace(",", "")))
                    {
                        case 1:
                            {
                                lblError.Text = "Bạn chưa nhập hạn mức";
                                break;
                            }
                        case 2:
                            {
                                lblError.Text = "Hạn mức không hợp lệ";
                                break;
                            }
                        case 3:
                            {
                                lblError.Text = "Hạn mức phải lớn hơn số tiền đã cho vay";
                                break;
                            }
                        case 0:
                            {
                                lblError.Text = "";
                                txtMaNguon.Enabled = false;
                                txtTenNguon.Enabled = false;
                                txtHanMuc.Enabled = false;
                                txtHanMuc.Text = Int64.Parse(txtHanMuc.Text).ToString("#,##0");
                                txtTienDaChoVay.Enabled = false;
                                txtTienCoTheChoVay.Text = (Int64.Parse(txtHanMuc.Text.Replace(",","")) - Int64.Parse(txtTienDaChoVay.Text.Replace(",", ""))).ToString("#,##0");
                                txtTienCoTheChoVay.Enabled = false;
                                btnXacNhan.Text = "Lưu";
                                btnHuy.Text = "Quay lại";
                                btnHuy.Image = Properties.Resources._101;
                                break;
                            }
                    }
                }
                else
                {
                    // Sửa nguồn
                    NguonBUS nguonBUS = new NguonBUS();
                    if (nguonBUS.SuaNguon(txtMaNguon.Text, txtHanMuc.Text.Replace(",",""), txtTienCoTheChoVay.Text.Replace(",", "")))
                    {
                        // Cập nhật lại danh sách 
                        foreach (DataGridViewRow temp in dataGridView.Rows)
                        {
                            if (temp.Cells[0].Value.ToString() == txtMaNguon.Text)
                            {
                                temp.Cells[1].Value = txtTenNguon.Text;
                                temp.Cells[2].Value = txtHanMuc.Text;
                                temp.Cells[3].Value = txtTienDaChoVay.Text;
                                temp.Cells[4].Value = txtTienCoTheChoVay.Text;
                            }
                        }
                        // Ghi log
                        LichSu lichSu = new LichSu();
                        lichSu.MaDT = txtMaNguon.Text;
                        lichSu.NoiDung = "Sửa thông tin nguồn";
                        lichSu.ThoiGian = DateTime.Now;
                        lichSu.GiaTriTruoc = JsonConvert.SerializeObject(nguon);
                        Nguon nguonSau = new Nguon();
                        nguonSau.idNg = nguon.idNg;
                        nguonSau.maNg = txtMaNguon.Text;
                        nguonSau.tenNg = txtTenNguon.Text;
                        nguonSau.hanMucNg = Int64.Parse(txtHanMuc.Text.Replace(",", ""));
                        nguonSau.tienDaChoVay = Int64.Parse(txtTienDaChoVay.Text.Replace(",", ""));
                        nguonSau.tienCoTheChoVay = Int64.Parse(txtTienCoTheChoVay.Text.Replace(",", ""));
                        lichSu.GiaTriSau = JsonConvert.SerializeObject(nguonSau);
                        lichSu.TenDN = nguoiDungHeThong.tenDangNhapND;
                        lichSu.SoTKLK = "null";
                        LichSuBUS lichSuBUS = new LichSuBUS();
                        lichSuBUS.ThemLichSu(JsonConvert.SerializeObject(lichSu));

                        MessageBox.Show("Sửa thông tin nguồn thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi sảy ra, sửa thông tin nguồn thất bại", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if(btnHuy.Text == "Hủy")
            {
                Close();
            }
            else
            {
                txtMaNguon.Enabled = true;
                txtTenNguon.Enabled = true;
                txtHanMuc.Enabled = true;
                txtTienDaChoVay.Enabled = true;
                txtTienCoTheChoVay.Enabled = true;
                btnHuy.Text = "Hủy";
                btnXacNhan.Text = "Xác nhận";
                btnHuy.Image = Properties.Resources._168;
            }
        }
    }
}
