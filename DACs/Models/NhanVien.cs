using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Models
{
    public class NhanVien
    {
        public int MaNhanVien { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }   
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }   
        public string TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
        public bool XoaTaiKhoan { get; set; }
    }
}
