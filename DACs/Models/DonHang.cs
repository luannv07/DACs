using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Models
{
    public class DonHang
    {
        public int MaDonHang { get; set; }
        public DateTime NgayDatHang { get; set; }
        public int MaKhachHang { get; set; }
        public byte TrangThai { get; set; }
    }
}
