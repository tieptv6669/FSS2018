using System;

namespace DTO
{
    public class GN_SPTD_NGUON
    {
        private string soTKLK;
        private string maGN;
        private string tenSPTD;
        private int laiSuat;
        private int laiSuatQuaHan;
        private int kyHan;
        private long duNoGoc;
        private long duNoLaiTH;
        private long duNoLaiNH;
        private string tenKH;
        private long soTienGN;
        private string trangThai;
        private string tenNguon;
        private DateTime ngayGN;
        private DateTime ngayDH;
        private string ghichu;

        public string SoTKLK { get; set; }
        public string MaGN { get; set; }
        public string TenSPTD { get; set; }
        public int LaiSuat { get; set; }
        public int LaiSuatQuaHan { get; set; }
        public int KyHan { get; set; }
        public long DuNoGoc { get; set; }
        public long DuNoLaiTH { get; set; }
        public long DuNoLaiNH { get; set; }
        public string TenKH { get; set; }
        public long SoTienGN { get; set; }
        public string TrangThai { get; set; }
        public string TenNguon { get; set; }
        public DateTime NgayGN { get; set; }
        public DateTime NgayDH { get; set; }
        public string GhiChu { get; set; }
    }
}
