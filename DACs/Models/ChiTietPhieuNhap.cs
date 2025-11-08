using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Models
{
    public class ChiTietPhieuNhap
    {
        public int IdChiTiet { get; set; }
        public int MaPhieuNhap { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}
