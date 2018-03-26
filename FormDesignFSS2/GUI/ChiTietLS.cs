using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDesignFSS2.GUI
{
    public partial class ChiTietLS : Form
    {
        // Dòng được chọn
        public DataGridViewRow dataGridViewRow;

        public ChiTietLS()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Xử lý sự kiện click button đóng form 
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
        private void ChiTietLS_Load(object sender, EventArgs e)
        {
            txtTDN.Text = dataGridViewRow.Cells[0].Value.ToString();
            txtSoTKLK.Text = dataGridViewRow.Cells[1].Value.ToString();
            txtMaDT.Text = dataGridViewRow.Cells[2].Value.ToString();
            txtGiaTriCu.Text = dataGridViewRow.Cells[3].Value.ToString();
            txtGiaTriMoi.Text = dataGridViewRow.Cells[4].Value.ToString();
            txtNoiDung.Text = dataGridViewRow.Cells[5].Value.ToString();
            txtThoiGian.Text = DateTime.Parse(dataGridViewRow.Cells[6].Value.ToString()).ToShortDateString();
        }
    }
}
