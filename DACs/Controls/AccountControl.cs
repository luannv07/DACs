using DACs.Enums;
using DACs.Services;
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
        private readonly UserService userService = new UserService();

        public ucAccountControl()
        {
            InitializeComponent();
        }
        private void loadUserList()
        {
            DataTable dataTable = userService.GetAllUsers();

            
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
            if (string.IsNullOrWhiteSpace(txtAccountFirstName.Text) || string.IsNullOrWhiteSpace(txtAccountEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (userService.CheckEmailExists(txtAccountEmail.Text.Trim()))
            {
                MessageBox.Show("Email đã tồn tại");
                return;
            }

            string username = StringUtils.ConvertToUsername(txtAccountFirstName.Text + " " + txtAccountLastName.Text);

            userService.AddUser(
                txtAccountFirstName.Text.Trim(),
                txtAccountLastName.Text.Trim(),
                cbAccountRole.SelectedIndex > -1 ? cbAccountRole.SelectedIndex : (int)Role.Staff,
                txtAccountEmail.Text.Trim(),
                dtpAccountBirthDate.Value,
                txtAccountAddress.Text.Trim(),
                cbAccountGender.SelectedIndex > -1 ? cbAccountGender.SelectedIndex : (int)Gender.Other,
                username,
                txtAccountPassword.Text.Trim().Length < 1 ? "1" : txtAccountPassword.Text.Trim(),
                cbAccountStatus.SelectedIndex > -1 ? cbAccountStatus.SelectedIndex : (int)UserStatus.Online
            );

            loadUserList();
            resetInputFields();
            MessageBox.Show("Thêm nhân viên thành công!");
        }


        private void btnAccountEditUser_Click(object sender, EventArgs e)
        {

        }

        private void btnAccountDeleteUser_Click(object sender, EventArgs e)
        {

        }

        private void dgvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
