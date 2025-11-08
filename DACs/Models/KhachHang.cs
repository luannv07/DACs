using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Models
{
    public class KhachHang
    {
        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public byte GioiTinh { get; set; }
        public byte LoaiKhachHang { get; set; }
    }
}
