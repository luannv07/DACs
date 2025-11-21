using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Models
{
    public class PhieuNhap
    {
        public int MaPhieuNhap { get; set; }
        public DateTime NgayNhap { get; set; }
        public int MaNCC { get; set; }
        public int MaNV { get; set; }
        public List<ChiTietPhieuNhap> ChiTiets { get; set; }
        public string TenNCC {  get; set; }
        public string GhiChu { get; set; }
    }
}