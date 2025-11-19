using DACs.Controls;
using DACs.Models;
using DACs.Services;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DACs.Forms.StoreForms
{
    public partial class CreateGRN : Form
    {
        private readonly ProductService productService = new ProductService();
        private bool isLoadingForm = true;
        private List<SanPham> products = new List<SanPham>();

        public void UpdateTotalCost()
        {
            decimal total = 0;

            foreach (Control ctrl in panel2.Controls)
            {
                if (ctrl != null && ctrl is GRNDetailsControl grn)
                {
                    total += grn.getTxtThanhTien();
                }
            }
            total *= 1000;
            txtTotalCost.Text = total.ToString("N0") + "đ";
        }
        public void ResetTotalCost()
        {
            txtTotalCost.Text = "0đ";
        }
        public CreateGRN()
        {
            InitializeComponent();

        }

        private void CreateGRN_Load(object sender, EventArgs e)
        {
            isLoadingForm = true;

            txtCurrentUser.Text = Session.CurrentUsername;

            LoadSuppliers();
            

            isLoadingForm = false;
        }

        private void LoadSuppliers()
        {
            var suppliers = productService.GetAllSuppliers();
            suppliers.Insert(0, new NhaCungCap { MaNhaCungCap = -1, Ten = "-- Chọn nhà cung cấp --" });

            cbSuppliers.DataSource = suppliers;
            cbSuppliers.DisplayMember = "Ten";
            cbSuppliers.ValueMember = "MaNhaCungCap";
            cbSuppliers.SelectedIndex = 0;
        }

        private void cbSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadingForm) return;
            if (cbSuppliers.SelectedValue == null || cbSuppliers.SelectedIndex < 0) return;
            products.Clear();
            panel2.Controls.Clear();
            int supplierId = Convert.ToInt32(cbSuppliers.SelectedValue);
            txtSupplierCode.Text = supplierId.ToString();
            products = productService.getOnlyProductNameFromSpecSupplier(Convert.ToInt32(txtSupplierCode.Text));
            GRNDetailsControl gRNDetailsControl = new GRNDetailsControl();
            gRNDetailsControl.Dock = DockStyle.Top;
            gRNDetailsControl.fillProducts(products);
            gRNDetailsControl.TongTienChanged += (s, _) => UpdateTotalCost();
            panel2.Controls.Add(gRNDetailsControl);
            VariableUtils.currentPN = 0;
            txtTotalCost.Text = "0đ";
        }

        private void btnCancel_Click(object sender, EventArgs e) { Form.ActiveForm.Close(); }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanh toán thành công (Chức năng đang phát triển)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnCancel_Click(sender, e);
        }

        private void btnCreateGRNI_Click(object sender, EventArgs e)
        {
            if (VariableUtils.currentPN > VariableUtils.maxPN)
            {
                MessageBox.Show("Bạn đã tạo số phiếu nhập tối đa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            GRNDetailsControl grnDetailsControl = new GRNDetailsControl();
            grnDetailsControl.Dock = DockStyle.Top;
            grnDetailsControl.fillProducts(products);
            grnDetailsControl.TongTienChanged += (s, _) => UpdateTotalCost();
            panel2.Controls.Add(grnDetailsControl);
            VariableUtils.currentPN++;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


    }   
}
