using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// Viết Tiệp
    /// 11/3/2018
    /// </summary>
    public class GN_KH
    {
        private string soTKLK;
        private string tenKH;
        private string maGN;
        private long soTienGN;
        private string trangThai;
        private int duNoGoc;
        private int duNoLaiTrongHan;
        private int duNoLaiQuaHan;

        public string SoTKLK { get; set; }
        public string TenKH { get; set; }
        public string MaGN { get; set; }
        public long SoTienGN { get; set; }
        public string TrangThai { get; set; }
        public int DuNoGoc { get; set; }
        public int DuNoLaiTrongHan { get; set; }
        public int DuNoLaiQuaHan { get; set; }
    }
}
