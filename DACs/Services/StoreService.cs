using DACs.Models;
using DACs.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACs.Services
{
    internal class StoreService
    {
        public bool deleteById(int MaPhieuNhap)
        {
            string query = @"
                update phieu_nhap
                set xoaPhieuNhap = 1
                where xoaphieunhap = 0 and maphieunhap = @maphieunhap
            ";
            int rowAffected = DbUtils.ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@maphieunhap", MaPhieuNhap)
            });

            return rowAffected > 0;
        }
        public List<PhieuNhap> getAllPhieuNhap()
        {
            string query = @"
                select p.MaPhieuNhap, p.NgayNhap, p.MaNCC, p.MaNV, n.Ten, p.GhiChu from PHIEU_NHAP as p
                join NHA_CUNG_CAP as n on n.MaNhaCungCap = p.MaNCC
                where xoaPhieunhap = 0 
                order by p.ngaynhap desc
            ";
            DataTable dt = DbUtils.ExecuteSelectQuery(query, null);
            List<PhieuNhap> phieuNhap = new List<PhieuNhap>();
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có phiếu nhập nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            foreach (DataRow row in dt.Rows)
            {
                phieuNhap.Add(new PhieuNhap
                {
                    MaPhieuNhap = Convert.ToInt32(row["MaPhieuNhap"]),
                    ChiTiets = new List<ChiTietPhieuNhap>(),
                    NgayNhap = Convert.ToDateTime(row["NgayNhap"]),
                    MaNCC = Convert.ToInt32(row["MaNCC"]),
                    MaNV = Convert.ToInt32(row["MaNV"]),
                    TenNCC = row["Ten"].ToString(),
                    GhiChu = row["GhiChu"].ToString()
                });
            }
            return phieuNhap;
        }
    }
}
