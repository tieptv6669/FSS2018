using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamTinDung
    {
        private int idSPTD;
        private string maSPTD;
        private string tenSPTD;
        private int thoiHanVay;
        private int laiSuat;
        private int laiSuatQuaHan;
        private string trangThai;
        private int idNguon;
        private string tenNguon;

        public int IdSPTD { get; set; }
        public string MaSPTD { get; set; }
        public string TenSPTD { get; set; }
        public int ThoiHanVay { get; set; }
        public int LaiSuat { get; set; }
        public int LaiSuatQuaHan { get; set; }
        public string TrangThai { get; set; }
        public int IdNguon { get; set; }
        public string TenNguon { get; set; }
    }
}
