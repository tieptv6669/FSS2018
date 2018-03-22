using System;

namespace DTO
{
    /// <summary>
    /// Viết Tiệp
    /// 11/3/2018
    /// </summary>
    public class TraNo
    {
        private int idTN;
        private string maTN;
        private string tenKH;
        private long soTienTra;
        private long soTienTraGoc;
        private long soTienTraLai;
        private DateTime ngayTraNo;
        private int idGN;

        public int IdTN { get; set; }
        public string MaTN { get; set; }
        public string TenKH;
        public long SoTienTra { get; set; }
        public long SoTienTraGoc { get; set; }
        public long SoTienTraLai { get; set; }
        public DateTime NgayTraNo { get; set; }
        public int IdGN { get; set; }
    }
}
