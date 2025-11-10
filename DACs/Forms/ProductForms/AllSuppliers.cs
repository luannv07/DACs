using DACs.Models;
using DACs.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACs.Forms.ProductForms
{
    public partial class AllSuppliers : Form
    {
        private List<NhaCungCap> suppliers = new List<NhaCungCap>();
        private readonly SupplierService supplierService = new SupplierService();
        public AllSuppliers()
        {
            InitializeComponent();
        }

        private void AllSuppliers_Load(object sender, EventArgs e)
        {
            suppliers = supplierService.GetAllSuppliers();
            dgvSupplierList.DataSource = suppliers;
            dgvSupplierList.Columns["manhacungcap"].HeaderText = "Mã nhà cung cấp";
            dgvSupplierList.Columns["manhacungcap"].Width = 30;
            dgvSupplierList.Columns["Ten"].HeaderText = "Tên";
            dgvSupplierList.Columns["Email"].HeaderText = "Email";
            dgvSupplierList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSupplierList.ReadOnly = true;
            dgvSupplierList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSupplierList.Columns["manhacungcap"].FillWeight = 30;
            dgvSupplierList.Columns["Ten"].FillWeight = 150;        
            dgvSupplierList.Columns["Email"].FillWeight = 100;
        }

        private void dgvSupplierList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ textbox
            string ten = txtSupplierName.Text.Trim();
            string email = txtSupplierEmail.Text.Trim();

            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NhaCungCap newSupplier = new NhaCungCap
            {
                Ten = ten,
                Email = email
            };

            bool isAdded = supplierService.AddSupplier(newSupplier);

            if (isAdded)
            {
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                suppliers = supplierService.GetAllSuppliers();
                dgvSupplierList.DataSource = null;
                dgvSupplierList.DataSource = suppliers;

                dgvSupplierList.Columns["manhacungcap"].HeaderText = "Mã nhà cung cấp";
                dgvSupplierList.Columns["Ten"].HeaderText = "Tên";
                dgvSupplierList.Columns["Email"].HeaderText = "Email";
                dgvSupplierList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvSupplierList.Columns["manhacungcap"].FillWeight = 30;
                dgvSupplierList.Columns["Ten"].FillWeight = 150;
                dgvSupplierList.Columns["Email"].FillWeight = 100;

                // Clear textbox
                txtSupplierName.Clear();
                txtSupplierEmail.Clear();
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
