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
    public partial class ChayQuaNgay : Form
    {
        private int progressBarStatus;
        public ChayQuaNgay()
        {
            progressBarStatus = 0;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
   
            btnBatDau.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
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

        private void ChayQuaNgay_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

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
    }
}
