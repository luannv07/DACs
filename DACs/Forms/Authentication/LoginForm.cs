using DACs.Enums;
using DACs.Models;
using DACs.Services;
using DACs.Utils;
using System;
using System.Windows.Forms;

namespace DACs.Forms.Authentication
{
    public partial class LoginForm : Form
    {
        private readonly UserService userService = new UserService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!DbUtils.TestConnection())
            {
                MessageBox.Show("Không thể kết nối tới database. Vui lòng kiểm tra server.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NhanVien user = userService.AuthenticateUser(txtUsername.Text, txtPassword.Text);

            if (user == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng! Hoặc tài khoản đã bị xoá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Lưu thông tin session
            Session.CurrentRole = ParseRole(user.VaiTro);
            Session.CurrentUsername = user.TaiKhoan;

            ControlUtil.LoadForm(this, new MainForm());

            // Remember me
            if (chkRememberMe.Checked)
            {
                Properties.Settings.Default.username = txtUsername.Text;
                Properties.Settings.Default.password = txtPassword.Text;
                Properties.Settings.Default.rememberme = true;
            }
            else
            {
                Properties.Settings.Default.username = "";
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.rememberme = false;
            }
            Properties.Settings.Default.Save();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.rememberme)
            {
                txtUsername.Text = Properties.Settings.Default.username;
                txtPassword.Text = Properties.Settings.Default.password;
                chkRememberMe.Checked = true;

                NhanVien user = userService.AuthenticateUser(txtUsername.Text, txtPassword.Text);
                if (user != null)
                {
                    Session.CurrentRole = ParseRole(user.VaiTro);
                    Session.CurrentUsername = user.TaiKhoan;
                }
            }
        }

        private Role ParseRole(string vaiTro)
        {
            if (vaiTro == Enums.Role.Admin.ToString()) return Enums.Role.Admin;
            if (vaiTro == Enums.Role.StoreStaff.ToString()) return Enums.Role.StoreStaff;
            return Enums.Role.Staff;
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản trị viên!");
        }
    }
}
