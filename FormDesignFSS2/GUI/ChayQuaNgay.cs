using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormDesignFSS2.XuLyCuoiNgayWS;
using FormDesignFSS2.LichSuWS;
using DTO;
using Newtonsoft.Json;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 6/3/2018
    /// </summary>
    public partial class ChayQuaNgay : Form
    {
        private int progressBarStatus;
        public NguoiDung nguoiDungHeThong;
        public Label labelNgayHeThong;

        /// <summary>
        /// Khởi tạo form
        /// </summary>
        public ChayQuaNgay()
        {
            progressBarStatus = 0;
            InitializeComponent();
        }
      
        /// <summary>
        /// Đếm thời gian
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerXuLyCuoiNgay_Tick(object sender, EventArgs e)
        {
            progressBar.Increment(1);
            progressBarStatus++;
            if(progressBarStatus <= 99)
            {
                processPercent.Text = progressBarStatus.ToString() + "%";
            }
            else
            {
                processPercent.Text = "Đã xong!";
            }
        }

        /// <summary>
        /// Xử lý sự kiện đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChayQuaNgay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (progressBarStatus > 0 && progressBarStatus <= 99)
            {
                MessageBox.Show("Tiến trình đang chạy không thể thoát", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button thoát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (progressBarStatus > 0 && progressBarStatus <= 99)
            {
                MessageBox.Show("Tiến trình đang chạy không thể thoát", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button bắt đầu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            try
            {
                XuLyCuoiNgayBUS xuLyCuoiNgayBUS = new XuLyCuoiNgayBUS();
                switch (xuLyCuoiNgayBUS.KTThongTinChayQuaNgay(txtNgayLVHienTai.Text, dateTPNgayLamViecTiepTheo.Text)){
                    case 1:
                        {
                            lblError.Text = "Ngày làm việc tiếp theo không phải thứ 7 hoặc chủ nhật";
                            break;
                        }
                    case 2:
                        {
                            lblError.Text = "Thời gian nghỉ quá lớn";
                            break;
                        }
                    case 3:
                        {
                            lblError.Text = "Ngày làm việc tiếp theo không hợp lệ";
                            break;
                        }
                    case 0:
                        {
                            lblError.Text = "";
                            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn thực hiện xử lý cuối ngày?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if(dialogResult == DialogResult.Yes)
                            {
                                // Xử lý cuối ngày
                                btnBatDau.Enabled = false;
                                dateTPNgayLamViecTiepTheo.Enabled = false;

                                string ngayHienTai = txtNgayLVHienTai.Text;
                                string ngayTiepTheo = dateTPNgayLamViecTiepTheo.Value.ToShortDateString();

                                xuLyCuoiNgayBUS.XuLyCuoiNgay(ngayHienTai, ngayTiepTheo);
                                // Ghi log
                                LichSu lichSu = new LichSu();
                                lichSu.MaDT = "null";
                                lichSu.NoiDung = "Xử lý cuối ngày";
                                lichSu.ThoiGian = DateTime.Parse(labelNgayHeThong.Text);
                                lichSu.GiaTriTruoc = "null";
                                lichSu.GiaTriSau = "null";
                                lichSu.TenDN = nguoiDungHeThong.tenDangNhapND;
                                lichSu.SoTKLK = "null";
                                LichSuBUS lichSuBUS = new LichSuBUS();
                                lichSuBUS.ThemLichSu(JsonConvert.SerializeObject(lichSu));
                                // Hiển thị lại ngày hệ thống
                                labelNgayHeThong.Text = ngayTiepTheo;
                                

                                timerXuLyCuoiNgay.Start();
                            }
                            break;
                        }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChayQuaNgay_Load(object sender, EventArgs e)
        {
            lblError.ForeColor = Color.Red;
            // Lấy ngày làm việc hiện tại
            XuLyCuoiNgayBUS xuLyCuoiNgayBUS = new XuLyCuoiNgayBUS();
            txtNgayLVHienTai.Text = xuLyCuoiNgayBUS.LayNgayLamViecHienTai();
        }
    }
}
