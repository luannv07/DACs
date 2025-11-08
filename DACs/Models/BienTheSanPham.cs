using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Models
{
    public class BienTheSanPham
    {
        public int MaBienThe { get; set; }
        public int MaSanPham { get; set; }
        public string MauSac { get; set; }
        public string KichCo { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public byte TrangThaiBienThe { get; set; }
    }
}
