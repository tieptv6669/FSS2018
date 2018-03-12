using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiaiNgan
    {
        private int idGN;
        private string maGN;
        private long soTienGN;
        private int duNoGoc;
        private int duNoLaiTrongHan;
        private int duNoLaiNgoaiHan;
        private DateTime ngayGN;
        private DateTime ngayDaoHan;
        private int idKH;
        private int idSPTD;
        private string trangThai;
        private string ghiChu;

        public int IDGN { get; set; }
        public string MaGN { get; set; }
        public long SoTienGN { get; set; }
        public int DuNoGoc { get; set; }
        public int DuNoLaiTrongHan { get; set; }
        public int DuNoLaiNgoaiHan { get; set; }
        public DateTime NgayGN { get; set; }
        public DateTime NgayDaoHan { get; set; }
        public int IDKH { get; set; }
        public int IDSPTD { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
    }
}
