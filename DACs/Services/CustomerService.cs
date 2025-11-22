using DACs.Models;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DACs.Services
{
    internal class CustomerService
    {
        // ================================
        //  GET ALL CUSTOMERS
        // ================================
        public List<KhachHang> GetAllCustomers()
        {
            string query = "SELECT * FROM KHACH_HANG ORDER BY MaKhachHang DESC";

            DataTable dt = DbUtils.ExecuteSelectQuery(query);

            return ConvertToList(dt);
        }

        // ================================
        //  GET BY ID
        // ================================
        public KhachHang GetCustomerById(int id)
        {
            string query = "SELECT * FROM KHACH_HANG WHERE MaKhachHang = @ID";

            SqlParameter[] p =
            {
                new SqlParameter("@ID", id)
            };

            DataTable dt = DbUtils.ExecuteSelectQuery(query, p);

            if (dt.Rows.Count == 0)
                return null;

            return MapRow(dt.Rows[0]);
        }

        // ================================
        //  ADD
        // ================================
        public bool AddCustomer(KhachHang kh)
        {
            string query = @"
                INSERT INTO KHACH_HANG 
                (TenKhachHang, DiaChi, SoDienThoai, GioiTinh, LoaiKhachHang)
                VALUES (@Ten, @DiaChi, @SDT, @GioiTinh, @Loai)
            ";

            SqlParameter[] p =
            {
                new SqlParameter("@Ten", kh.TenKhachHang),
                new SqlParameter("@DiaChi", kh.DiaChi),
                new SqlParameter("@SDT", kh.SoDienThoai),
                new SqlParameter("@GioiTinh", kh.GioiTinh),
                new SqlParameter("@Loai", kh.LoaiKhachHang)
            };

            return DbUtils.ExecuteNonQuery(query, p) > 0;
        }

        // ================================
        //  UPDATE
        // ================================
        public bool UpdateCustomer(KhachHang kh, int loaikhachhang = 0)
        {
            string query = @"
                UPDATE KHACH_HANG SET
                    TenKhachHang = @Ten,
                    DiaChi = @DiaChi,
                    SoDienThoai = @SDT,
                    GioiTinh = @GioiTinh,
                    LoaiKhachHang = @Loai
                WHERE MaKhachHang = @ID
            ";

            SqlParameter[] p =
            {
                new SqlParameter("@Ten", kh.TenKhachHang),
                new SqlParameter("@DiaChi", kh.DiaChi),
                new SqlParameter("@SDT", kh.SoDienThoai),
                new SqlParameter("@GioiTinh", kh.GioiTinh),
                new SqlParameter("@Loai", loaikhachhang),
                new SqlParameter("@ID", kh.MaKhachHang)
            };

            return DbUtils.ExecuteNonQuery(query, p) > 0;
        }

        // ================================
        //  DELETE
        // ================================
        public bool DeleteCustomer(int id)
        {
            string query = "DELETE FROM KHACH_HANG WHERE MaKhachHang = @ID";

            SqlParameter[] p =
            {
                new SqlParameter("@ID", id)
            };

            return DbUtils.ExecuteNonQuery(query, p) > 0;
        }

        // ================================
        //  SEARCH
        // ================================
        public List<KhachHang> Search(string keyword)
        {
            string query = @"
                SELECT * FROM KHACH_HANG
                WHERE TenKhachHang LIKE @kw OR SoDienThoai LIKE @kw
            ";

            SqlParameter[] p =
            {
                new SqlParameter("@kw", "%" + keyword + "%")
            };

            DataTable dt = DbUtils.ExecuteSelectQuery(query, p);

            return ConvertToList(dt);
        }

        // ================================
        //  CHECK PHONE EXISTS
        // ================================
        public bool IsPhoneExists(string phone, int exceptId = -1)
        {
            string query = @"
                SELECT COUNT(*) FROM KHACH_HANG
                WHERE SoDienThoai = @SDT AND MaKhachHang != @ID
            ";

            SqlParameter[] p =
            {
                new SqlParameter("@SDT", phone),
                new SqlParameter("@ID", exceptId)
            };

            int count = Convert.ToInt32(DbUtils.ExecuteScalar(query, p));

            return count > 0;
        }

        // ================================
        //  HELPERS
        // ================================
        private List<KhachHang> ConvertToList(DataTable dt)
        {
            List<KhachHang> list = new List<KhachHang>();

            foreach (DataRow row in dt.Rows)
                list.Add(MapRow(row));

            return list;
        }

        private KhachHang MapRow(DataRow row)
        {
            return new KhachHang
            {
                MaKhachHang = Convert.ToInt32(row["MaKhachHang"]),
                TenKhachHang = row["TenKhachHang"].ToString(),
                DiaChi = row["DiaChi"].ToString(),
                SoDienThoai = row["SoDienThoai"].ToString(),
                GioiTinh = Convert.ToByte(row["GioiTinh"]),
                LoaiKhachHang = Convert.ToByte(row["LoaiKhachHang"])
            };
        }
    }
}
