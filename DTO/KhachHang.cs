using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// Thùy Linh
    /// 24/2/2018
    /// </summary>
    public class KhachHang
    {
        private int idKhachHang;
        private string soTKLK;
        private string hoTen;
        private DateTime ngayMoTK;
        private DateTime ngaySinh;
        private string ngheNghiep;
        private string soCMNN;
        private string email;
        private string gioiTinh;
        private string loaiKH;
        private string diaChi;
        private string SDT;
        private string ghiChu;

        public int idKH { get; set; }
        public string STKLK { get; set; }
        public string hoTenKH { get; set; }
        public DateTime ngayMoTKKH { get; set; }
        public DateTime ngaySinhKH { get; set; }
        public string ngheNghiepKH { get; set; }
        public string soCMNNKH { get; set; }
        public string emailKH { get; set; }
        public string gioiTinhKH { get; set; }
        public string loai { get; set; }
        public string diaChiKH { get; set; }
        public string SDTKH { get; set; }
        public string ghiChuKH { get; set; }

    }
}
