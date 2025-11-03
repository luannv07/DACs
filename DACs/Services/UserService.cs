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
            string query = "SELECT * FROM nhan_vien WHERE taikhoan = @username AND matkhau = @password";
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
                "from nhan_vien";
            DataTable dataTable = DbUtils.ExecuteSelectQuery(query, null);
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
                new SqlParameter("@ho", lastName),
                new SqlParameter("@ten", firstName),
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

    }
}
