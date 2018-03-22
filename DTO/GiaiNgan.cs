using System;

namespace DTO
{
    public class GiaiNgan
    {
        private int idGN;
        private string maGN;
        private long soTienGN;
        private long duNoGoc;
        private long duNoLaiTrongHan;
        private long duNoLaiNgoaiHan;
        private DateTime ngayGN;
        private DateTime ngayDaoHan;
        private int idKH;
        private int idSPTD;
        private string trangThai;
        private string ghiChu;

        public int IDGN { get; set; }
        public string MaGN { get; set; }
        public long SoTienGN { get; set; }
        public long DuNoGoc { get; set; }
        public long DuNoLaiTrongHan { get; set; }
        public long DuNoLaiNgoaiHan { get; set; }
        public DateTime NgayGN { get; set; }
        public DateTime NgayDaoHan { get; set; }
        public int IDKH { get; set; }
        public int IDSPTD { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
    }
}
