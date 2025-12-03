using DACs.Enums;
using DACs.Models;
using DACs.Services;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DACs.Controls
{
    public partial class ucCustomerControl : UserControl
    {
        public readonly Dictionary<Gender, string> GenderMap = new Dictionary<Gender, string>()
        {
            { Gender.Male, "Nam" },
            { Gender.Female, "Nữ" },
            { Gender.Other, "Khác" }
        };

        public readonly Dictionary<CustomerType, string> CustomerTypeMap = new Dictionary<CustomerType, string>()
        {
            { CustomerType.NON, "Thường" },
            { CustomerType.VIP, "VIP" }
        };
        private readonly CustomerService _service = new CustomerService();
        private readonly LogService logService = new LogService();
        private List<KhachHang> _currentList = new List<KhachHang>();

        public ucCustomerControl()
        {
            InitializeComponent();
            cbGioiTinh.Items.Clear();
            cbGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });

            Load += UcCustomerControl_Load;
        }

        private void UcCustomerControl_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            BindEvents();
        }

        // ================================
        // LOAD DATA
        // ================================
        private void LoadCustomers()
        {
            _currentList = _service.GetAllCustomers();

            
            SetupCustomerGridView(_currentList);


            btnAccountEditCustomer.Enabled = false;
        }

        private void SetupCustomerGridView(List<KhachHang> _currentList)
        {
            dgvCustomerList.DataSource = _currentList.Select(kh => new
            {
                MaKhachHang = kh.MaKhachHang,
                TenKhachHang = kh.TenKhachHang,
                SoDienThoai = kh.SoDienThoai,
                GioiTinh = GenderMap[(Gender)kh.GioiTinh],
                LoaiKhachHang = CustomerTypeMap[(CustomerType)kh.LoaiKhachHang],
                DiaChi = kh.DiaChi
            }).ToList();

            dgvCustomerList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvCustomerList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCustomerList.Columns["MaKhachHang"].HeaderText = "Mã khách hàng";
            dgvCustomerList.Columns["TenKhachHang"].HeaderText = "Tên khách hàng";
            dgvCustomerList.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dgvCustomerList.Columns["GioiTinh"].HeaderText = "Giới tính";
            dgvCustomerList.Columns["LoaiKhachHang"].HeaderText = "Loại khách hàng";
            dgvCustomerList.Columns["DiaChi"].HeaderText = "Địa chỉ";

            dgvCustomerList.Dock = DockStyle.Fill;
        }


        // ================================
        // EVENT SETUP
        // ================================
        private void BindEvents()
        {
            dgvCustomerList.CellClick += DgvCustomerList_CellClick;
            btnTriggerSearching.Click += BtnTriggerSearching_Click;
            btnAccountResetData.Click += BtnAccountResetData_Click;

        }

        private void DgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            btnAccountEditCustomer.Enabled = true;

            DataGridViewRow row = dgvCustomerList.Rows[e.RowIndex];

            txtMaKH.Text = row.Cells["MaKhachHang"].Value?.ToString();
            txtTenKH.Text = row.Cells["TenKhachHang"].Value?.ToString();
            txtSdtKH.Text = row.Cells["SoDienThoai"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();

            // ===== Map lại giới tính cho combobox =====
            string genderText = row.Cells["GioiTinh"].Value?.ToString();  // "Nam" / "Nữ" / "Khác"
            cbGioiTinh.SelectedItem = genderText;
        }


        // ================================
        // SEARCHING
        // ================================
        private void BtnTriggerSearching_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            string keyword = txtSearching.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                SetupCustomerGridView(_currentList);
                return;
            }

            SetupCustomerGridView(_service.Search(keyword));
        }

        // ================================
        // RESET
        // ================================
        private void BtnAccountResetData_Click(object sender, EventArgs e)
        {
            txtSearching.Text = "";
            LoadCustomers();
            panel2.Visible = false;
        }

        private void btnAccountEditCustomer_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void ucCustomerControl_Load_1(object sender, EventArgs e)
        {

        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            ClearEditForm();
            panel2.Visible = false;
        }
        private void ClearEditForm()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSdtKH.Text = "";
            txtDiaChi.Text = "";
            cbGioiTinh.SelectedIndex = -1;
        }

        private void btnAppliesEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSdtKH.Text) || txtSdtKH.Text.Length != 10 || !txtSdtKH.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Phải gồm 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbGioiTinh.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHang kh = new KhachHang
            {
                MaKhachHang = int.Parse(txtMaKH.Text),
                TenKhachHang = txtTenKH.Text.Trim(),
                SoDienThoai = txtSdtKH.Text.Trim(),
                GioiTinh = (byte)cbGioiTinh.SelectedIndex,
                DiaChi = txtDiaChi.Text.Trim()
            };

            bool updated = _service.UpdateCustomer(kh);

            if (updated)
            {
                MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCustomers();
                logService.WriteLog(Session.currentUser.MaNhanVien, LogAction.UpdateCustomer, $"Cập nhật thông tin khách hàng customerID#{kh.MaKhachHang}");
                panel2.Visible = false;
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvCustomerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
