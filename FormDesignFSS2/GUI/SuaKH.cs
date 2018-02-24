using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using FormDesignFSS2.KhachHangWS;

namespace FormDesignFSS2.GUI
{
    public partial class SuaKH : Form
    {
        public KhachHang khachHang;

        public SuaKH()
        {
            InitializeComponent();
            khachHang = new KhachHang();
        }

        private void SuaKH_Load(object sender, EventArgs e)
        {

        }
    }
}
