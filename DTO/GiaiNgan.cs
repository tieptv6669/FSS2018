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
<<<<<<< HEAD
        private int duNoGoc;
        private int duNoLaiTrongHan;
        private int duNoLaiNgoaiHan;
=======
        private long duNoGoc;
        private long duNoLaiTrongHan;
        private long duNoLaiNgoaiHan;
>>>>>>> f58958ded318da7368db100d4de77587da95b3df
        private DateTime ngayGN;
        private DateTime ngayDaoHan;
        private int idKH;
        private int idSPTD;
        private string trangThai;
        private string ghiChu;

        public int IDGN { get; set; }
        public string MaGN { get; set; }
        public long SoTienGN { get; set; }
<<<<<<< HEAD
        public int DuNoGoc { get; set; }
        public int DuNoLaiTrongHan { get; set; }
        public int DuNoLaiNgoaiHan { get; set; }
=======
        public long DuNoGoc { get; set; }
        public long DuNoLaiTrongHan { get; set; }
        public long DuNoLaiNgoaiHan { get; set; }
>>>>>>> f58958ded318da7368db100d4de77587da95b3df
        public DateTime NgayGN { get; set; }
        public DateTime NgayDaoHan { get; set; }
        public int IDKH { get; set; }
        public int IDSPTD { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
    }
}
