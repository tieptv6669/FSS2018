using System;

namespace DTO
{
    /// <summary>
    /// Viết Tiệp
    /// 8/3/2018
    /// </summary>
    public class LichSu
    {
        private int idLichSu;
        private string maDoiTuong;
        private string noiDung;
        private DateTime thoiGian;
        private string giaTriTruoc;
        private string giaTriSau;
        private string tenDangNhap;
        private string soTKLK;

        public int IdLS { get; set; }
        public string MaDT { get; set; }
        public string NoiDung { get; set; }
        public DateTime ThoiGian { get; set; }
        public string GiaTriTruoc { get; set; }
        public string GiaTriSau { get; set; }
        public string TenDN { get; set; }
        public string SoTKLK { get; set; }
    }
}
