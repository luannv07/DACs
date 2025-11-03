using DACs.Enums;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACs.Controls
{
    public partial class ucAccountControl : UserControl
    {
        public ucAccountControl()
        {
            InitializeComponent();
        }
        private void loadUserList()
        {
            //string query =
            //"select manhanvien as 'Mã NV', ho as 'Họ', ten as 'Tên', Email, Ngaysinh as 'Ngày sinh', Diachi as 'Địa chỉ', gioitinh as 'Giới tính', Taikhoan as 'Tài khoản', matkhau as 'Mật khẩu', vaitro as 'Vai trò', trangthai as 'Trạng thái', ngaytao as 'Ngày tạo' from nhan_vien";
            string query = "select " +
                "manhanvien, ho, ten, vaitro, email, ngaysinh, diachi, gioitinh, taikhoan, matkhau, trangthai, ngaytao " +
                "from nhan_vien";

            DataTable dataTable = DbUtils.executeSelectQuery(query, null);

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
            dgvUserList.DataSource = dataTable;
            dgvUserList.Columns["gioitinh"].Visible = false;
            dgvUserList.Columns["trangthai"].Visible = false;
            dgvUserList.Columns["vaitro"].Visible = false;

            dgvUserList.Columns["manhanvien"].HeaderText = "Mã NV";
            dgvUserList.Columns["ho"].HeaderText = "Họ";
            dgvUserList.Columns["ten"].HeaderText = "Tên";
            dgvUserList.Columns["Email"].HeaderText = "Email";
            dgvUserList.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvUserList.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvUserList.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvUserList.Columns["TaiKhoan"].HeaderText = "Tài khoản";
            dgvUserList.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dgvUserList.Columns["NgayTao"].HeaderText = "Ngày tạo";

            dgvUserList.Columns["gioitinh_text"].HeaderText = "Giới tính";
            dgvUserList.Columns["trangthai_text"].HeaderText = "Trạng thái";
            dgvUserList.Columns["vaitro_text"].HeaderText = "Vai trò";

            dgvUserList.Columns["vaitro_text"].DisplayIndex = 3;
        }
        private void ucAccountControl_Load(object sender, EventArgs e)
        {
            loadUserList();
        }

        private void btnAccountResetData_Click(object sender, EventArgs e)
        {
            loadUserList();
        }

        private void btnAccountResetFields_Click(object sender, EventArgs e)
        {
            resetInputFields();
        }
        private void resetInputFields()
        {
            txtAccountCode.Clear();
            txtAccountAddress.Clear();
            txtAccountEmail.Clear();
            txtAccountFirstName.Clear();
            txtAccountLastName.Clear();
            txtAccountPassword.Clear();
            txtAccountUsername.Clear();
            dtpAccountBirthDate.Value = DateTime.Now;
            cbAccountGender.SelectedIndex = -1;
            cbAccountRole.SelectedIndex = -1;
            cbAccountStatus.SelectedIndex = -1;
        }
        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvUserList.Rows[e.RowIndex];

            txtAccountCode.Text = row.Cells["manhanvien"].Value?.ToString();
            txtAccountLastName.Text = row.Cells["ho"].Value?.ToString();
            txtAccountFirstName.Text = row.Cells["ten"].Value?.ToString();
            txtAccountEmail.Text = row.Cells["email"].Value?.ToString();
            txtAccountAddress.Text = row.Cells["diachi"].Value?.ToString();
            txtAccountUsername.Text = row.Cells["taikhoan"].Value?.ToString();
            txtAccountPassword.Text = row.Cells["matkhau"].Value?.ToString();

            if (DateTime.TryParse(row.Cells["ngaysinh"].Value?.ToString(), out DateTime dob))
                dtpAccountBirthDate.Value = dob;

            string gender = row.Cells["gioitinh_text"].Value?.ToString();
            if (!string.IsNullOrEmpty(gender))
                cbAccountGender.SelectedItem = gender;

            string role = row.Cells["vaitro_text"].Value?.ToString();
            if (!string.IsNullOrEmpty(role))
                cbAccountRole.SelectedItem = role;

            string status = row.Cells["trangthai_text"].Value?.ToString();
            if (!string.IsNullOrEmpty(status))
                cbAccountStatus.SelectedItem = status;
        }

        private void btnAccountAddUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAccountCode.Text))
            {
                MessageBox.Show("Bạn đang chọn một nhân viên, không thể thêm mới!", "Thông báo");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAccountFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtAccountLastName.Text) ||
                string.IsNullOrWhiteSpace(txtAccountEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ, tên và email!", "Cảnh báo");
                return;
            }

            string query = "insert into nhan_vien (ho, ten, vaitro, email, ngaysinh, diachi, gioitinh, taikhoan, matkhau, trangthai, ngaytao) " +
                "values (@ho, @ten, @vaitro, @email, @ngaysinh, @diachi, @gioitinh, @taikhoan, @matkhau, @trangthai, @ngaytao)";
            txtAccountUsername.Text = StringUtils.ConvertToUsername(txtAccountFirstName.Text + " " + txtAccountLastName.Text);
            // check email exists
            string checkExistEmailQuery = "select count(email) from nhan_vien where email = @email";
            SqlParameter[] sqlParameters = new SqlParameter[] { new SqlParameter("@email", txtAccountEmail.Text.Trim()) };
            DataTable dataTable = DbUtils.executeSelectQuery(checkExistEmailQuery, sqlParameters);

            if (dataTable.Columns.Count > 0 && Convert.ToInt32(dataTable.Rows[0][0]) > 0)
            {
                MessageBox.Show("Email đã tồn tại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ho", txtAccountLastName.Text.Trim()),
                new SqlParameter("@ten", txtAccountFirstName.Text.Trim()),
                new SqlParameter("@vaitro", cbAccountRole.SelectedIndex > -1 ? cbAccountRole.SelectedIndex : (int)Role.Staff),
                new SqlParameter("@email", txtAccountEmail.Text.Trim()),
                new SqlParameter("@ngaysinh", dtpAccountBirthDate.Value),
                new SqlParameter("@diachi", txtAccountAddress.Text.Trim()),
                new SqlParameter("@gioitinh", cbAccountGender.SelectedIndex > -1 ? cbAccountGender.SelectedIndex : (int)Gender.Other),
                new SqlParameter("@taikhoan", txtAccountUsername.Text.Trim()),
                new SqlParameter("@matkhau", txtAccountPassword.Text.Trim()),
                new SqlParameter("@trangthai", cbAccountStatus.SelectedIndex > -1 ? cbAccountStatus.SelectedIndex : (int)UserStatus.Online),
                new SqlParameter("@ngaytao", DateTime.Now)
            };
            DbUtils.executeNonDataQuery(query, parameters);
            loadUserList();
            resetInputFields();
            MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAccountEditUser_Click(object sender, EventArgs e)
        {

        }

        private void btnAccountDeleteUser_Click(object sender, EventArgs e)
        {

        }
    }
}
