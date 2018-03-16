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
using FormDesignFSS2.TraNoWS;
using DTO;

namespace FormDesignFSS2.GUI
{
    /// <summary>
    /// Viết Tiệp
    /// 5/3/2018
    /// </summary>
    public partial class LichSuTraNo : Form
    {
        // Mã giải ngân
        public string maGN;
        // ID giải ngân
        public int idGN;

        public LichSuTraNo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý sự kiện click button đóng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Tải form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LichSuTraNo_Load(object sender, EventArgs e)
        {
            txtMaGN.Text = maGN;
            // Lấy danh sách các lần trả nợ cho món giải ngân
            TraNoBUS traNoBUS = new TraNoBUS();
            List<DTO.TraNo> list = JsonConvert.DeserializeObject<List<DTO.TraNo>>(traNoBUS.GetListTN(idGN));
            // Hiển thị lên grid view
            foreach(DTO.TraNo temp in list)
            {
                gridLSTN.Rows.Add(temp.MaTN, temp.TenKH, temp.SoTienTra, temp.SoTienTraGoc, temp.SoTienTraLai, temp.NgayTraNo);
            }
            gridLSTN.Refresh();
        }
    }
}
