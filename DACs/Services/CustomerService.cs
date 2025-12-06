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
        public List<KhachHang> GetAllCustomers()
        {
            string query = "SELECT * FROM KHACH_HANG ORDER BY MaKhachHang DESC";

            DataTable dt = DbUtils.ExecuteSelectQuery(query);

            return ConvertToList(dt);
        }

        public List<dynamic> GetTopCustomers()
        {
            string query = @"select top 5 k.makhachhang, k.tenkhachhang, count(o.madonhang) as tongdonhang from khach_hang k
            join DON_HANG o on o.MaKhachHang = k.MaKhachHang
            group by k.TenKhachHang, k.makhachhang
            order by tongdonhang desc";

            DataTable dt = DbUtils.ExecuteSelectQuery(query);

            List<dynamic> data = new List<dynamic>();

            foreach (DataRow row in dt.Rows)
                data.Add(new
                {
                    MaKhachHang = row["MaKhachHang"].ToString(),
                    TenKhachHang = row["TenKhachHang"].ToString(),
                    TongDon = row["tongdonhang"].ToString()
                });
            return data;
        }

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

        public int AddCustomer(KhachHang kh)
        {
            string query = @"
                INSERT INTO khach_hang (TenKhachHang, DiaChi, SoDienThoai, GioiTinh, LoaiKhachHang)
                VALUES (@ten, @dc, @sdt, @gt, @loai);
                SELECT SCOPE_IDENTITY();
            ";

            SqlParameter[] p = {
                new SqlParameter("@ten", kh.TenKhachHang),
                new SqlParameter("@dc", kh.DiaChi),
                new SqlParameter("@sdt", kh.SoDienThoai),
                new SqlParameter("@gt", kh.GioiTinh),
                new SqlParameter("@loai", kh.LoaiKhachHang)
            };

            return Convert.ToInt32(DbUtils.ExecuteScalar(query, p));
        }


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
        public bool DeleteCustomer(int id)
        {
            string query = "DELETE FROM KHACH_HANG WHERE MaKhachHang = @ID";

            SqlParameter[] p =
            {
                new SqlParameter("@ID", id)
            };

            return DbUtils.ExecuteNonQuery(query, p) > 0;
        }
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
        public KhachHang GetByPhone(string sdt)
        {
            string query = @"SELECT * FROM khach_hang WHERE SoDienThoai = @sdt";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@sdt", sdt)
            };

            var re = DbUtils.ExecuteSelectQuery(query, parameters);

            if (re.Rows.Count == 0)
                return null;   // Không tìm thấy khách hàng

            DataRow row = re.Rows[0];

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
