using DACs.Enums;
using DACs.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DACs.Services
{
    internal class UserService
    {
        public DataTable AuthenticateUser(string username, string password)
        {
            string query = "SELECT * FROM nhan_vien WHERE taikhoan = @username AND matkhau = @password and xoataikhoan = 0";
            SqlParameter[] parameters = {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };
            return DbUtils.ExecuteSelectQuery(query, parameters);
        }
        public DataTable GetAllUsers()
        {
            string query = "select " +
                "manhanvien, ho, ten, vaitro, email, ngaysinh, diachi, gioitinh, taikhoan, matkhau, trangthai, ngaytao " +
                "from nhan_vien where xoataikhoan = 0 and taikhoan != @username";
            DataTable dataTable = DbUtils.ExecuteSelectQuery(query, new SqlParameter[] { new SqlParameter("@username", Session.CurrentUsername) });
            dataTable.Columns.Add("gioitinh_text", typeof(string));
            dataTable.Columns.Add("trangthai_text", typeof(string));
            dataTable.Columns.Add("vaitro_text", typeof(string));

            foreach (DataRow row in dataTable.Rows)
            {
                try
                {
                    row["gioitinh_text"] =
                        Convert.ToInt32(row["gioitinh"]) == (int)Gender.Male ? "Nam" :
                        Convert.ToInt32(row["gioitinh"]) == (int)Gender.Female ? "Nữ" :
                        "Khác";
                    row["trangthai_text"] =
                        Convert.ToInt32(row["trangthai"]) == (int)UserStatus.Online ? "Hoạt động" :
                        "Đã nghỉ";
                    row["vaitro_text"] =
                        Convert.ToInt32(row["vaitro"]) == (int)Role.Staff ? "Nhân viên" :
                        Convert.ToInt32(row["vaitro"]) == (int)Role.StoreStaff ? "Kiểm kho" :
                        "Quản trị";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dataTable;
        }

        public bool CheckEmailExists(string email)
        {
            string query = "SELECT COUNT(email) FROM nhan_vien WHERE email = @email";
            SqlParameter[] param = { new SqlParameter("@email", email) };
            DataTable dt = DbUtils.ExecuteSelectQuery(query, param);
            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        public void AddUser(string firstName, string lastName, int role, string email, DateTime dob,
                            string address, int gender, string username, string password, int status)
        {
            string query = @"INSERT INTO nhan_vien 
                             (ho, ten, vaitro, email, ngaysinh, diachi, gioitinh, taikhoan, matkhau, trangthai, ngaytao) 
                             VALUES 
                             (@ho, @ten, @vaitro, @email, @ngaysinh, @diachi, @gioitinh, @taikhoan, @matkhau, @trangthai, @ngaytao)";

            SqlParameter[] parameters = {
                new SqlParameter("@ho", firstName),
                new SqlParameter("@ten", lastName),
                new SqlParameter("@vaitro", role),
                new SqlParameter("@email", email),
                new SqlParameter("@ngaysinh", dob),
                new SqlParameter("@diachi", address),
                new SqlParameter("@gioitinh", gender),
                new SqlParameter("@taikhoan", username),
                new SqlParameter("@matkhau", password),
                new SqlParameter("@trangthai", status),
                new SqlParameter("@ngaytao", DateTime.Now)
            };

            DbUtils.ExecuteNonQuery(query, parameters);
        }
        public int UpdateUser(string firstName, string lastName, int role, string email, DateTime dob,
                            string address, int gender, string username, string password, int status)
        {
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Có 1 vài trường bạn để trống kìaaaa!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            DataTable oldEmail = DbUtils.ExecuteSelectQuery("select email from nhan_vien where taikhoan = @taikhoan", 
                   new SqlParameter[] { new SqlParameter("@taikhoan", username) });
            if (oldEmail.Rows.Count > 0 && !oldEmail.Rows[0]["email"].ToString().Equals(email))
            {
                if (this.CheckEmailExists(email))
                {
                    MessageBox.Show("Bạn cập nhật email trùng rồiii!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return -1;
                }
            }

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
                new SqlParameter("@ho", firstName),
                new SqlParameter("@ten", lastName),
                new SqlParameter("@vaitro", role),
                new SqlParameter("@email", email),
                new SqlParameter("@ngaysinh", dob),
                new SqlParameter("@diachi", address),
                new SqlParameter("@gioitinh", gender),
                new SqlParameter("@taikhoan", username),
                new SqlParameter("@matkhau", password),
                new SqlParameter("@trangthai", status)
                };
            return DbUtils.ExecuteNonQuery(query, parameters);
        }
        public int DeleteUser(string username)
        {
            string query = "Update nhan_vien set xoaTaiKhoan = 1 where taikhoan = @taikhoan";
            SqlParameter[] parameters = {
                new SqlParameter("@taikhoan", username)
            };
            return DbUtils.ExecuteNonQuery(query, parameters);
        }
    }
}
