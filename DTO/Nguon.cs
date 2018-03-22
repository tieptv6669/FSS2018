
namespace DTO
{
    /// <summary>
    /// Viết Tiệp
    /// 24/02/2018
    /// </summary>
    public class Nguon
    {
        private int idNguon;
        private string maNguon;
        private string tenNguon;
        private long hanMuc;
        private long soTienDaChoVay;
        private long soTienCoTheChoVay;

        public int idNg { get; set; }
        public string maNg { get; set; }
        public string tenNg { get; set; }
        public long hanMucNg { get; set; }
        public long tienDaChoVay { get; set; }
        public long tienCoTheChoVay { get; set; }
    }
}
