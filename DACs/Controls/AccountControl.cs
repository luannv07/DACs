using DACs.Enums;
using DACs.Services;
using DACs.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            MessageBox.Show("Làm mới danh sách nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadUserList();
        }

        private void btnAccountResetFields_Click(object sender, EventArgs e)
        {
            btnAccountEditUser.Enabled = false;
            btnAccountDeleteUser.Enabled = false;
            btnAccountAddUser.Enabled = true;
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
            btnAccountAddUser.Enabled = false;
            btnAccountEditUser.Enabled = true;
            btnAccountDeleteUser.Enabled = true;
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvUserList.Rows[e.RowIndex];

            txtAccountCode.Text = row.Cells["manhanvien"].Value?.ToString();
            txtAccountLastName.Text = row.Cells["ten"].Value?.ToString();
            txtAccountFirstName.Text = row.Cells["ho"].Value?.ToString();
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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (userService.CheckEmailExists(txtAccountEmail.Text.Trim()))
            {
                MessageBox.Show("Email đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnAccountEditUser_Click(object sender, EventArgs e)
        {
            int rows = 0;
            if (string.IsNullOrWhiteSpace(txtAccountCode.Text))
            {
                MessageBox.Show("Bạn quên chưa chọn người cần sửa thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            rows = userService.UpdateUser(
                txtAccountFirstName.Text.Trim(),
                txtAccountLastName.Text.Trim(),
                cbAccountRole.SelectedIndex > -1 ? cbAccountRole.SelectedIndex : (int)Role.Staff,
                txtAccountEmail.Text.Trim(),
                dtpAccountBirthDate.Value,
                txtAccountAddress.Text.Trim(),
                cbAccountGender.SelectedIndex > -1 ? cbAccountGender.SelectedIndex : (int)Gender.Other,
                txtAccountUsername.Text.Trim(),
                txtAccountPassword.Text.Trim(),
                cbAccountStatus.SelectedIndex > -1 ? cbAccountStatus.SelectedIndex : (int)UserStatus.Online
                );
            if (rows == -1)
            {
                MessageBox.Show("Cập nhật thông tin nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else
            {
                btnAccountAddUser.Enabled = true;
                btnAccountDeleteUser.Enabled = false;
                btnAccountEditUser.Enabled = false;
                loadUserList();
                resetInputFields();
                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnAccountDeleteUser_Click(object sender, EventArgs e)
        {
            int rows = 0;
            if (string.IsNullOrWhiteSpace(txtAccountCode.Text))
            {
                MessageBox.Show("Bạn quên chưa chọn người xoáaa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            rows = userService.DeleteUser(txtAccountUsername.Text.Trim());
            if (rows == 0)
            {
                MessageBox.Show("WithMG, Xoá không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadUserList(); resetInputFields();
                btnAccountAddUser.Enabled = true;
                btnAccountDeleteUser.Enabled = false;
                btnAccountEditUser.Enabled = false;
            }

        }

        private void dgvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void txtAccountFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbAccountRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
