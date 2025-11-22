using DACs.Models;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DACs.Services
{
    public class OrderService
    {
        public List<DonHang> getAllOrders() {
            List<DonHang> orders = new List<DonHang>();
            string query = @"select * from don_hang order by ngaydathang desc, madonhang desc";

            DataTable dt = DbUtils.ExecuteSelectQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                DonHang dh = new DonHang
                {
                    MaDonHang = Convert.ToInt32(row["MaDonHang"]),
                    MaKhachHang = Convert.ToInt32(row["MaKhachHang"]),
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                    NgayDatHang = Convert.ToDateTime(row["NgayDatHang"]),
                    TrangThai = Convert.ToByte(row["TrangThai"])
                };

                orders.Add(dh);
            }
            return orders;
        }

        public List<DonHang> search(string keyword)
        {
            List<DonHang> orders = new List<DonHang>();

            string query = @"
                SELECT m.*
                FROM DON_HANG m
                JOIN KHACH_HANG k ON k.MaKhachHang = m.MaKhachHang
                JOIN NHAN_VIEN n ON n.MaNhanVien = m.MaNhanVien
                WHERE 
                    k.TenKhachHang LIKE '%' + @kw + '%' 
                    OR n.TaiKhoan LIKE '%' + @kw + '%'
                ORDER BY m.NgayDatHang DESC, m.MaDonHang DESC;
            ";

            SqlParameter[] parameters = {
                new SqlParameter("@kw", keyword)
            };

            DataTable dt = DbUtils.ExecuteSelectQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                orders.Add(new DonHang
                {
                    MaDonHang = Convert.ToInt32(row["MaDonHang"]),
                    MaKhachHang = Convert.ToInt32(row["MaKhachHang"]),
                    MaNhanVien = Convert.ToInt32(row["MaNhanVien"]),
                    NgayDatHang = Convert.ToDateTime(row["NgayDatHang"]),
                    TrangThai = Convert.ToByte(row["TrangThai"])
                });
            }

            return orders;
        }
        public bool DeleteOrder(int maDonHang)
        {
            string query = "DELETE FROM DON_HANG WHERE MaDonHang = @MaDonHang";

            SqlParameter[] parameters = {
                new SqlParameter("@MaDonHang", maDonHang)
            };

            return DbUtils.ExecuteNonQuery(query, parameters) > 0;
        }

        public List<ChiTietDonHang> GetOrderDetails(int maDonHang)
        {
            string query = @"
                SELECT MaDonHangChiTiet, MaDonHang, MaBienThe, SoLuong, DonGia
                FROM CHI_TIET_DON_HANG
                WHERE MaDonHang = @MaDonHang
            ";

            SqlParameter[] parameters = {
                new SqlParameter("@MaDonHang", maDonHang)
            };

            DataTable dt = DbUtils.ExecuteSelectQuery(query, parameters);

            List<ChiTietDonHang> list = new List<ChiTietDonHang>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new ChiTietDonHang
                {
                    MaDonHangChiTiet = Convert.ToInt32(row["MaDonHangChiTiet"]),
                    MaDonHang = Convert.ToInt32(row["MaDonHang"]),
                    MaBienThe = Convert.ToInt32(row["MaBienThe"]),
                    SoLuong = Convert.ToInt32(row["SoLuong"]),
                    DonGia = Convert.ToDecimal(row["DonGia"])
                });
            }

            return list;
        }

        public decimal GetTotalAmount(int maDonHang)
        {
            string query = @"SELECT SUM(SoLuong * DonGia) FROM CHI_TIET_DON_HANG WHERE MaDonHang = @ma";
            SqlParameter[] pr =
            {
                new SqlParameter("@ma", maDonHang)
            };

            object result = DbUtils.ExecuteScalar(query, pr);
            return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
        }

        public int CreateOrder(DonHang dh)
        {
            string query = @"
            INSERT INTO don_hang (MaKhachHang, MaNhanVien, NgayDatHang, TrangThai)
            VALUES (@makh, @manv, @ngay, @tt);
            SELECT SCOPE_IDENTITY();
            ";

            SqlParameter[] p = {
                new SqlParameter("@makh", dh.MaKhachHang),
                new SqlParameter("@manv", dh.MaNhanVien),
                new SqlParameter("@ngay", dh.NgayDatHang),
                new SqlParameter("@tt", dh.TrangThai)
            };

            return Convert.ToInt32(DbUtils.ExecuteScalar(query, p));
        }

        public void AddOrderDetail(ChiTietDonHang ct)
        {
            string query = @"
                INSERT INTO chi_tiet_don_hang (MaDonHang, MaBienThe, SoLuong, DonGia)
                VALUES (@dh, @bt, @sl, @gia)
            ";

            SqlParameter[] p = {
                new SqlParameter("@dh", ct.MaDonHang),
                new SqlParameter("@bt", ct.MaBienThe),
                new SqlParameter("@sl", ct.SoLuong),
                new SqlParameter("@gia", ct.DonGia)
            };

            DbUtils.ExecuteNonQuery(query, p);
        }



    }
}
