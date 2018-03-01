using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// Viết Tiệp
    /// 28/2/2018
    /// </summary>
    public class KhachHangReport
    {
        private string soTKLK;
        private string hoTen;
        private DateTime ngaySinh;
        private string CMND;

        public string soTKLKKH { get; set; }
        public string hoTenKH { get; set; }
        public DateTime ngaySinhKH { get; set; }
        public string cmndKH { get; set; }
    }
}
