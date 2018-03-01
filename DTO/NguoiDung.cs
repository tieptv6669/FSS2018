using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// Viết Tiệp
    /// 24/02/2018
    /// </summary>
    public class NguoiDung
    {
        private int idNguoiDung;
        private string tenDangNhap;
        private string matKhau;
        private string hoTen;
        private string chucVu;
        private string phongBan;
        private string quyen;
        private int trangthai;

        public int idND { get; set; }
        public string tenDangNhapND { get; set; }
        public string matKhauND { get; set; }
        public string hoTenND { get; set; }
        public string chucVuND { get; set; }
        public string phongBanND { get; set; }
        public string quyenND { get; set; }
        public int trangthaiND { get; set; }
    }
}
