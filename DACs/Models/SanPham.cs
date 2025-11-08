using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Models
{
    public class SanPham
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int MaNCC { get; set; }
        public decimal GiamGia { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
