using DACs.Models;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACs.Services
{
    internal class ProductDetailsService
    {
        public BienTheSanPham getById(int MaBienThe)
        {
            string query = @"
                select * from BIEN_THE_SAN_PHAM
                where MaBienThe = @mabienthe and XoaBienThe = 0
            ";
            var dt = DbUtils.ExecuteSelectQuery(query, new System.Data.SqlClient.SqlParameter[]
            {
                new System.Data.SqlClient.SqlParameter("@mabienthe", MaBienThe)
            });
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            var row = dt.Rows[0];
            return new BienTheSanPham
            {
                MaBienThe = Convert.ToInt32(row["MaBienThe"]),
                MaSanPham = Convert.ToInt32(row["MaSanPham"]),
                KichCo = row["KichCo"].ToString(),
                MauSac = row["MauSac"].ToString(),
            };
        }
    }
}
