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

namespace DACs.Forms.Authentication
{
    public partial class LoginForm : Form
    {
        private readonly UserService userService = new UserService();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản trị viên để lấy lại mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            DataTable dataTable = userService.AuthenticateUser(txtUsername.Text, txtPassword.Text);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng! Hoặc tài khoản đã bị xoá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Đăng nhập thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Session.CurrentRole = dataTable.Rows[0]["vaitro"].ToString() == "0" ? Role.Staff :
                                  dataTable.Rows[0]["vaitro"].ToString() == "1" ? Role.StoreStaff :
                                  Role.Admin;
            Session.CurrentUsername = dataTable.Rows[0]["taikhoan"].ToString();
            ControlUtil.LoadForm(this, new MainForm());

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

                DataTable dataTable = userService.AuthenticateUser(txtUsername.Text, txtPassword.Text);
                if (dataTable.Rows.Count > 0)
                {
                    Session.CurrentRole = dataTable.Rows[0]["vaitro"].ToString() == "0" ? Role.Staff :
                                          dataTable.Rows[0]["vaitro"].ToString() == "1" ? Role.StoreStaff :
                                          Role.Admin;
                    Session.CurrentUsername = dataTable.Rows[0]["taikhoan"].ToString();
                }
            }
        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
