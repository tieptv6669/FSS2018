using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GN_KH
    {
        private string soTKLK;
        private string tenKH;
        private string maGN;
        private int soTienGN;
        private string trangThai;
        private int duNoGoc;
        private int duNoLaiTrongHan;
        private int duNoLaiQuaHan;

        public string SoTKLK { get; set; }
        public string TenKH { get; set; }
        public string MaGN { get; set; }
        public int SoTienGN { get; set; }
        public string TrangThai { get; set; }
        public int DuNoGoc { get; set; }
        public int DuNoLaiTrongHan { get; set; }
        public int DuNoLaiQuaHan { get; set; }
    }
}
