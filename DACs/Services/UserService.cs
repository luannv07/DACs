using DACs.Enums;
using DACs.Models;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DACs.Services
{
    public class UserService
    {
        // Lấy 1 user theo username/password
        public NhanVien AuthenticateUser(string username, string password)
        {
            string query = "SELECT * FROM nhan_vien WHERE taikhoan = @username AND matkhau = @password AND xoataikhoan = 0";
            SqlParameter[] parameters = {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            DataTable dt = DbUtils.ExecuteSelectQuery(query, parameters);
            if (dt.Rows.Count == 0) return null;

            return MapNhanVien(dt.Rows[0]);
        }

        // Lấy tất cả user
        public List<NhanVien> GetAllUsers()
        {
            string query = "SELECT * FROM nhan_vien WHERE xoataikhoan = 0 AND taikhoan != @username";
            SqlParameter[] parameters = { new SqlParameter("@username", Session.CurrentUsername) };

            DataTable dt = DbUtils.ExecuteSelectQuery(query, parameters);

            List<NhanVien> users = new List<NhanVien>();
            foreach (DataRow row in dt.Rows)
            {
                users.Add(MapNhanVien(row));
            }

            return users;
        }

        // Kiểm tra email tồn tại
        public bool CheckEmailExists(string email)
        {
            string query = "SELECT COUNT(email) FROM nhan_vien WHERE email = @email";
            SqlParameter[] param = { new SqlParameter("@email", email) };
            DataTable dt = DbUtils.ExecuteSelectQuery(query, param);
            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // Thêm user
        public void AddUser(NhanVien user)
        {
            string query = @"INSERT INTO nhan_vien 
                             (ho, ten, vaitro, email, ngaysinh, diachi, gioitinh, taikhoan, matkhau, trangthai, ngaytao) 
                             VALUES 
                             (@ho, @ten, @vaitro, @email, @ngaysinh, @diachi, @gioitinh, @taikhoan, @matkhau, @trangthai, @ngaytao)";

            SqlParameter[] parameters = {
                new SqlParameter("@ho", user.Ho),
                new SqlParameter("@ten", user.Ten),
                new SqlParameter("@vaitro", RoleToInt(user.VaiTro)),
                new SqlParameter("@email", user.Email),
                new SqlParameter("@ngaysinh", user.NgaySinh),
                new SqlParameter("@diachi", user.DiaChi),
                new SqlParameter("@gioitinh", GenderToInt(user.GioiTinh)),
                new SqlParameter("@taikhoan", user.TaiKhoan),
                new SqlParameter("@matkhau", user.MatKhau),
                new SqlParameter("@trangthai", UserStatusToInt(user.TrangThai)),
                new SqlParameter("@ngaytao", DateTime.Now)
            };

            DbUtils.ExecuteNonQuery(query, parameters);
        }

        // Cập nhật user
        public void UpdateUser(NhanVien user)
        {
            string query = @"UPDATE nhan_vien SET 
                             ho = @ho, 
                             ten = @ten, 
                             vaitro = @vaitro, 
                             email = @email, 
                             ngaysinh = @ngaysinh, 
                             diachi = @diachi, 
                             gioitinh = @gioitinh, 
                             matkhau = @matkhau, 
                             trangthai = @trangthai
                             WHERE taikhoan = @taikhoan";

            SqlParameter[] parameters = {
                new SqlParameter("@ho", user.Ho),
                new SqlParameter("@ten", user.Ten),
                new SqlParameter("@vaitro", RoleToInt(user.VaiTro)),
                new SqlParameter("@email", user.Email),
                new SqlParameter("@ngaysinh", user.NgaySinh),
                new SqlParameter("@diachi", user.DiaChi),
                new SqlParameter("@gioitinh", GenderToInt(user.GioiTinh)),
                new SqlParameter("@taikhoan", user.TaiKhoan),
                new SqlParameter("@matkhau", user.MatKhau),
                new SqlParameter("@trangthai", UserStatusToInt(user.TrangThai))
            };

            DbUtils.ExecuteNonQuery(query, parameters);
        }

        // Xóa user
        public void DeleteUser(string username)
        {
            string query = "UPDATE nhan_vien SET xoaTaiKhoan = 1 WHERE taikhoan = @taikhoan";
            SqlParameter[] parameters = { new SqlParameter("@taikhoan", username) };
            DbUtils.ExecuteNonQuery(query, parameters);
        }

        private NhanVien MapNhanVien(DataRow row)
        {
            return new NhanVien
            {
                MaNhanVien = Convert.ToInt32(row["manhanvien"]),
                Ho = row["ho"].ToString(),
                Ten = row["ten"].ToString(),
                VaiTro = ParseRole(Convert.ToInt32(row["vaitro"])).ToString(),
                Email = row["email"].ToString(),
                NgaySinh = Convert.ToDateTime(row["ngaysinh"]),
                DiaChi = row["diachi"].ToString(),
                GioiTinh = ParseGender(Convert.ToInt32(row["gioitinh"])).ToString(),
                TaiKhoan = row["taikhoan"].ToString(),
                MatKhau = row["matkhau"].ToString(),
                TrangThai = ParseUserStatus(Convert.ToInt32(row["trangthai"])).ToString(),
                NgayTao = Convert.ToDateTime(row["ngaytao"])
            };
        }


        private Role ParseRole(int value)
        {
            if (value == 0) return Role.Staff;
            else if (value == 1) return Role.StoreStaff;
            else if (value == 2) return Role.Admin;
            return Role.Staff;
        }

        private Gender ParseGender(int value)
        {
            if (value == 0) return Gender.Male;
            else if (value == 1) return Gender.Female;
            return Gender.Other;
        }

        private UserStatus ParseUserStatus(int value)
        {
            if (value == 0) return UserStatus.Offline;
            else if (value == 1) return UserStatus.Online;
            return UserStatus.Offline;
        }

        private int RoleToInt(string value)
        {
            if (value == Role.Admin.ToString()) return 2;
            if (value == Role.StoreStaff.ToString()) return 1;
            return 0;
        }

        private int GenderToInt(string value)
        {
            if (value == Gender.Male.ToString()) return 0;
            if (value == Gender.Female.ToString()) return 1;
            return 2;
        }

        private int UserStatusToInt(string value)
        {
            if (value == UserStatus.Offline.ToString()) return 0;
            return 1;
        }
    }
}
