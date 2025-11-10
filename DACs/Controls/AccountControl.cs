using DACs.Enums;
using DACs.Models;
using DACs.Services;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DACs.Controls
{
    public partial class ucAccountControl : UserControl
    {
        private readonly UserService userService = new UserService();
        private List<NhanVien> users = new List<NhanVien>();

        private readonly Dictionary<string, string> genderMap = new Dictionary<string, string>
        {
            { Gender.Male.ToString(), "Nam" },
            { Gender.Female.ToString(), "Nữ" },
            { Gender.Other.ToString(), "Khác" }
        };

        private readonly Dictionary<string, string> roleMap = new Dictionary<string, string>
        {
            { Role.Admin.ToString(), "Quản trị" },
            { Role.StoreStaff.ToString(), "Kiểm kho" },
            { Role.Staff.ToString(), "Nhân viên" }
        };

        private readonly Dictionary<string, string> statusMap = new Dictionary<string, string>
        {
            { UserStatus.Online.ToString(), "Hoạt động" },
            { UserStatus.Offline.ToString(), "Đã nghỉ" }
        };

        public ucAccountControl()
        {
            InitializeComponent();
        }

        private void ucAccountControl_Load(object sender, EventArgs e)
        {
            LoadUserList();
        }

        private void LoadUserList()
        {
            users = userService.GetAllUsers();

            dgvUserList.DataSource = users
                .Select(u => new
                {
                    u.MaNhanVien,
                    u.Ho,
                    u.Ten,
                    u.Email,
                    NgaySinh = u.NgaySinh.ToString("dd/MM/yyyy"),
                    u.DiaChi,
                    GioiTinh = genderMap.ContainsKey(u.GioiTinh) ? genderMap[u.GioiTinh] : "Khác",
                    u.TaiKhoan,
                    u.MatKhau,
                    VaiTro = roleMap.ContainsKey(u.VaiTro) ? roleMap[u.VaiTro] : "Nhân viên",
                    TrangThai = statusMap.ContainsKey(u.TrangThai) ? statusMap[u.TrangThai] : "Đã nghỉ",
                    NgayTao = u.NgayTao.ToString("dd/MM/yyyy")
                })
                .ToList();

            // Header
            dgvUserList.Columns["MaNhanVien"].HeaderText = "Mã NV";
            dgvUserList.Columns["Ho"].HeaderText = "Họ";
            dgvUserList.Columns["Ten"].HeaderText = "Tên";
            dgvUserList.Columns["Email"].HeaderText = "Email";
            dgvUserList.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dgvUserList.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvUserList.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvUserList.Columns["TaiKhoan"].HeaderText = "Tài khoản";
            dgvUserList.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dgvUserList.Columns["VaiTro"].HeaderText = "Vai trò";
            dgvUserList.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvUserList.Columns["NgayTao"].HeaderText = "Ngày tạo";

            dgvUserList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUserList.ReadOnly = true;
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
            if (!dgvUserList.Columns.Contains("MaNhanVien")) return;

            object idObj = dgvUserList.Rows[e.RowIndex].Cells["MaNhanVien"].Value;
            if (idObj == null) return;

            int id = Convert.ToInt32(idObj);
            var selectedUser = users.FirstOrDefault(u => u.MaNhanVien == id);
            if (selectedUser == null) return;

            txtAccountCode.Text = selectedUser.MaNhanVien.ToString();
            txtAccountFirstName.Text = selectedUser.Ho;
            txtAccountLastName.Text = selectedUser.Ten;
            txtAccountEmail.Text = selectedUser.Email;
            txtAccountAddress.Text = selectedUser.DiaChi;
            txtAccountUsername.Text = selectedUser.TaiKhoan;
            txtAccountPassword.Text = selectedUser.MatKhau;
            dtpAccountBirthDate.Value = selectedUser.NgaySinh;

            cbAccountGender.SelectedItem = genderMap.ContainsKey(selectedUser.GioiTinh) ? genderMap[selectedUser.GioiTinh] : "Khác";
            cbAccountRole.SelectedItem = roleMap.ContainsKey(selectedUser.VaiTro) ? roleMap[selectedUser.VaiTro] : "Nhân viên";
            cbAccountStatus.SelectedItem = statusMap.ContainsKey(selectedUser.TrangThai) ? statusMap[selectedUser.TrangThai] : "Đã nghỉ";

            btnAccountAddUser.Enabled = false;
            btnAccountEditUser.Enabled = true;
            btnAccountDeleteUser.Enabled = true;
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

            NhanVien newUser = new NhanVien
            {
                Ho = txtAccountFirstName.Text.Trim(),
                Ten = txtAccountLastName.Text.Trim(),
                Email = txtAccountEmail.Text.Trim(),
                NgaySinh = dtpAccountBirthDate.Value,
                DiaChi = txtAccountAddress.Text.Trim(),
                GioiTinh = genderMap.FirstOrDefault(x => x.Value == cbAccountGender.SelectedItem?.ToString()).Key ?? Gender.Other.ToString(),
                TaiKhoan = username,
                MatKhau = string.IsNullOrWhiteSpace(txtAccountPassword.Text) ? "1" : txtAccountPassword.Text.Trim(),
                VaiTro = roleMap.FirstOrDefault(x => x.Value == cbAccountRole.SelectedItem?.ToString()).Key ?? Role.Staff.ToString(),
                TrangThai = statusMap.FirstOrDefault(x => x.Value == cbAccountStatus.SelectedItem?.ToString()).Key ?? UserStatus.Online.ToString()
            };

            userService.AddUser(newUser);
            LoadUserList();
            resetInputFields();
            MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAccountEditUser_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtAccountCode.Text, out int id))
            {
                MessageBox.Show("Bạn quên chưa chọn người cần sửa thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NhanVien updatedUser = new NhanVien
            {
                MaNhanVien = id,
                Ho = txtAccountFirstName.Text.Trim(),
                Ten = txtAccountLastName.Text.Trim(),
                Email = txtAccountEmail.Text.Trim(),
                NgaySinh = dtpAccountBirthDate.Value,
                DiaChi = txtAccountAddress.Text.Trim(),
                GioiTinh = genderMap.FirstOrDefault(x => x.Value == cbAccountGender.SelectedItem?.ToString()).Key ?? Gender.Other.ToString(),
                TaiKhoan = txtAccountUsername.Text.Trim(),
                MatKhau = txtAccountPassword.Text.Trim(),
                VaiTro = roleMap.FirstOrDefault(x => x.Value == cbAccountRole.SelectedItem?.ToString()).Key ?? Role.Staff.ToString(),
                TrangThai = statusMap.FirstOrDefault(x => x.Value == cbAccountStatus.SelectedItem?.ToString()).Key ?? UserStatus.Online.ToString()
            };

            userService.UpdateUser(updatedUser);
            LoadUserList();
            resetInputFields();
            btnAccountAddUser.Enabled = true;
            btnAccountEditUser.Enabled = false;
            btnAccountDeleteUser.Enabled = false;
            MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAccountDeleteUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAccountUsername.Text))
            {
                MessageBox.Show("Bạn quên chưa chọn người xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            userService.DeleteUser(txtAccountUsername.Text.Trim());
            LoadUserList();
            resetInputFields();
            btnAccountAddUser.Enabled = true;
            btnAccountEditUser.Enabled = false;
            btnAccountDeleteUser.Enabled = false;
            MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAccountResetData_Click(object sender, EventArgs e)
        {
            LoadUserList();
            MessageBox.Show("Làm mới danh sách nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAccountResetFields_Click(object sender, EventArgs e)
        {
            resetInputFields();
            btnAccountAddUser.Enabled = true;
            btnAccountEditUser.Enabled = false;
            btnAccountDeleteUser.Enabled = false;
        }

        private void dgvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnTriggerSearching_Click(object sender, EventArgs e)
        {
            string keyword = txtSearching.Text.Trim();

            List<NhanVien> searchResult = userService.GetUserByCodeOrName(keyword);

            dgvUserList.DataSource = searchResult
                .Select(u => new
                {
                    u.MaNhanVien,
                    u.Ho,
                    u.Ten,
                    u.Email,
                    NgaySinh = u.NgaySinh.ToString("dd/MM/yyyy"),
                    u.DiaChi,
                    GioiTinh = genderMap.ContainsKey(u.GioiTinh) ? genderMap[u.GioiTinh] : "Khác",
                    u.TaiKhoan,
                    u.MatKhau,
                    VaiTro = roleMap.ContainsKey(u.VaiTro) ? roleMap[u.VaiTro] : "Nhân viên",
                    TrangThai = statusMap.ContainsKey(u.TrangThai) ? statusMap[u.TrangThai] : "Đã nghỉ",
                    NgayTao = u.NgayTao.ToString("dd/MM/yyyy")
                })
                .ToList();
        }

        private void dtpAccountBirthDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtAccountFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
