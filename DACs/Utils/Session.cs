using DACs.Enums;
using DACs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Utils
{
    public static class Session
    {
        public static Role CurrentRole { get; set; }
        public static string CurrentUsername { get; set; } = "Anonymous";

        public static NhanVien currentUser { get; set; } = new NhanVien
        {
            MaNhanVien = 1,
            Ho = "Anonymous",
            Ten = "User",
        };
    }
}
