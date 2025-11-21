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

        public bool addPhieuNhap(PhieuNhap phieuNhap, List<ChiTietPhieuNhap> chiTietPhieuNhap)
        {
            string query = @"insert into phieu_nhap (ngaynhap, mancc, manv, ghichu) values (getdate(), @mancc, @manv, @ghichu)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@mancc", phieuNhap.MaNCC),
                new SqlParameter("@manv", phieuNhap.MaNV),
                new SqlParameter("@ghichu", phieuNhap.GhiChu)
            };
            int rowAffected = DbUtils.ExecuteNonQuery(query, parameters);

            if (rowAffected <= 0)
            {
                MessageBox.Show("Thêm phiếu nhập thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var firstRow = DbUtils.ExecuteSelectQuery(@"select top 1 maphieunhap from phieu_nhap order by maphieunhap desc");

            int maPhieuNhap = Convert.ToInt32(firstRow.Rows[0]["maphieunhap"]);

            foreach (var chiTiet in chiTietPhieuNhap)
            {
                string detailQuery = @"insert into chi_tiet_phieu_nhap (maphieunhap, mabienthe, soluong, dongia) 
                                       values (@maphieunhap, @mabienthe, @soluong, @dongia)";
                SqlParameter[] detailParameters = new SqlParameter[]
                {
                    new SqlParameter("@maphieunhap", maPhieuNhap),
                    new SqlParameter("@mabienthe", chiTiet.MaBienThe),
                    new SqlParameter("@soluong", chiTiet.SoLuong),
                    new SqlParameter("@dongia", chiTiet.DonGia)
                };
                int detailRowAffected = DbUtils.ExecuteNonQuery(detailQuery, detailParameters);
                if (detailRowAffected <= 0)
                {
                    MessageBox.Show("Thêm chi tiết phiếu nhập thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        public PhieuNhap getById(int MaPhieuNhap)
        {
            string query = @"
                select 
                    p.MaPhieuNhap, p.NgayNhap, p.MaNCC, p.MaNV, 
                    n.Ten, p.GhiChu,
                    pd.mabienthe, pd.soluong, pd.dongia
                from PHIEU_NHAP as p
                join NHA_CUNG_CAP as n on n.MaNhaCungCap = p.MaNCC
                join CHI_TIET_PHIEU_NHAP as pd on pd.MaPhieuNhap = p.MaPhieuNhap
                where xoaPhieunhap = 0 and p.MaPhieuNhap = @maphieunhap
            ";

            DataTable dt = DbUtils.ExecuteSelectQuery(query, new SqlParameter[]
            {
                new SqlParameter("@maphieunhap", MaPhieuNhap)
            });

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            DataRow first = dt.Rows[0];

            PhieuNhap phieuNhap = new PhieuNhap
            {
                MaPhieuNhap = Convert.ToInt32(first["MaPhieuNhap"]),
                NgayNhap = Convert.ToDateTime(first["NgayNhap"]),
                MaNCC = Convert.ToInt32(first["MaNCC"]),
                MaNV = Convert.ToInt32(first["MaNV"]),
                TenNCC = first["Ten"].ToString(),
                GhiChu = first["GhiChu"].ToString(),
                ChiTiets = new List<ChiTietPhieuNhap>()
            };

            foreach (DataRow row in dt.Rows)
            {
                ChiTietPhieuNhap ct = new ChiTietPhieuNhap
                {
                    MaPhieuNhap = phieuNhap.MaPhieuNhap,
                    MaBienThe = Convert.ToInt32(row["mabienthe"]),
                    SoLuong = Convert.ToInt32(row["soluong"]),
                    DonGia = Convert.ToDecimal(row["dongia"])
                };

                phieuNhap.ChiTiets.Add(ct);
            }

            return phieuNhap;
        }

    }
}
