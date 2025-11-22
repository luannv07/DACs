using DACs.Enums;
using DACs.Models;
using DACs.Services;
using DACs.Utils;
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
    public partial class AddProduct : Form
    {
        private readonly ProductService productService = new ProductService();

        private readonly Dictionary<string, string> productMap = new Dictionary<string, string>
        {
            { ProductStatus.Active.ToString(), "Đang bán" },
            { ProductStatus.Inactive.ToString(), "Ngừng bán" }
        };
        public AddProduct()
        {
            InitializeComponent();
        }
        private void handleRadioBtnChange(object sender, EventArgs e)
        {
            
            if (rbAddProduct.Checked)
            {
                cbTenSp.Enabled = false;
                panel2.Enabled = true;
                //nmrSoLuong.Enabled = true;
                //nmrSoLuong.Minimum = 1;
                //nmrSoLuong.Value = 1;
                ResetProductFields();
                cbTenSp.SelectedIndex = -1;
            }
            else if (rbAddProductDetails.Checked)
            {
                cbTenSp.Enabled = true;
                panel2.Enabled = false;
                //nmrSoLuong.Enabled = false;
                //nmrSoLuong.Minimum = 0;
                //nmrSoLuong.Value = 0;
                ResetVariantFields();
            }
            txtGiamGia.Text = "0";
            cbTrangThai.SelectedItem = productMap[ProductStatus.Active.ToString()];
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }
        private void getDistinctProduct()
        {
            var allProducts = productService.GetAllProducts(true);

            var distinctProducts = allProducts
                                    .GroupBy(p => p.MaSanPham)
                                    .Select(g => g.First())
                                    .ToList();
            cbTenSp.DataSource = distinctProducts;
            cbTenSp.DisplayMember = "TenSanPham";
            cbTenSp.ValueMember = "MaSanPham";
            cbTenSp.SelectedIndex = -1;
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            cbNCC.DataSource = productService.GetAllSuppliers();
            cbNCC.DisplayMember = "Ten";
            cbNCC.ValueMember = "MaNhaCungCap";
            cbNCC.SelectedIndex = -1;
            txtNCCTU.Text = "";

            cbMauSac.DataSource = ProductPropsUtils.CommonColors;
            cbMauSac.SelectedIndex = -1;
            cbKichCo.DataSource = ProductPropsUtils.CommonSizes;
            cbKichCo.SelectedIndex = -1;

            getDistinctProduct();


            txtGiamGia.Text = "0";
            cbTrangThai.SelectedItem = productMap[ProductStatus.Active.ToString()];
        }

        private void cbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNCC.SelectedIndex == -1)
            {
                txtNCCTU.Text = "";
                return;
            }
            txtNCCTU.Text = cbNCC.SelectedValue.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ResetProductFields()
        {
            // Reset lại các trường nhập liệu khi chọn "Thêm sản phẩm mới"
            txtTenSp.Clear();
            cbNCC.SelectedIndex = -1;
            txtNCCTU.Clear();
            dtpNgayThem.Value = DateTime.Now;
        }

        private void ResetVariantFields()
        {
            // Reset lại các trường nhập liệu khi chọn "Thêm biến thể sản phẩm"
            cbTenSp.SelectedIndex = -1;
            cbMauSac.SelectedIndex = -1;
            cbKichCo.SelectedIndex = -1;
            txtDonGia.Clear();
            txtGiamGia.Clear();
            cbTrangThai.SelectedIndex = -1;
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            // Nếu người dùng chọn "Thêm sản phẩm mới"
            if (rbAddProduct.Checked)
            {
                // Validate cho sản phẩm mới
                if (string.IsNullOrEmpty(txtTenSp.Text))
                {
                    MessageBox.Show("Hãy nhập tên sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbNCC.SelectedIndex == -1)
                {
                    MessageBox.Show("Hãy chọn nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtNCCTU.Text))
                {
                    MessageBox.Show("Mã nhà cung cấp không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate ngày thêm (Ngày phải là ngày hợp lệ)
                if (dtpNgayThem.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show("Ngày thêm không thể là ngày trong tương lai.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbMauSac.SelectedIndex == -1)
                {
                    MessageBox.Show("Hãy chọn màu sắc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbKichCo.SelectedIndex == -1)
                {
                    MessageBox.Show("Hãy chọn kích cỡ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtDonGia.Text) || !decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia <= 0)
                {
                    MessageBox.Show("Hãy nhập đơn giá hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtGiamGia.Text, out decimal giamgia) || giamgia < 0 || giamgia >= 100)
                {
                    MessageBox.Show("Giảm giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Lưu sản phẩm mới
                SaveNewProduct();
            }
            // Nếu người dùng chọn "Thêm biến thể sản phẩm"
            else if (rbAddProductDetails.Checked)
            {
                // Validate cho biến thể sản phẩm
                if (cbTenSp.SelectedIndex == -1)
                {
                    MessageBox.Show("Hãy chọn sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbMauSac.SelectedIndex == -1)
                {
                    MessageBox.Show("Hãy chọn màu sắc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbKichCo.SelectedIndex == -1)
                {
                    MessageBox.Show("Hãy chọn kích cỡ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(txtDonGia.Text) || !decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia <= 0)
                {
                    MessageBox.Show("Hãy nhập đơn giá hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtGiamGia.Text, out decimal giamgia) || giamgia < 0 || giamgia >= 100)
                {
                    MessageBox.Show("Giảm giá không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Lưu biến thể sản phẩm
                SaveProductVariant();
                }

                ResetVariantFields();
                ResetProductFields();

               getDistinctProduct();
            }

        private void SaveNewProduct()
        {
            // Lấy thông tin từ giao diện
            string tenSanPham = txtTenSp.Text;
            int maNCC = Convert.ToInt32(txtNCCTU.Text);
            byte trangThai = (byte)(cbTrangThai.SelectedItem.ToString() == productMap[ProductStatus.Active.ToString()] ? 1 : 0);

            // Tạo sản phẩm mới
            SanPham sanPham = new SanPham
            {
                TenSanPham = tenSanPham,
                MaNCC = maNCC,
                NgayTao = DateTime.Now
            };

            // Tạo biến thể mặc định với số lượng = 0
            BienTheSanPham bienThe = new BienTheSanPham
            {
                MauSac = cbMauSac.SelectedItem.ToString(),
                KichCo = cbKichCo.SelectedItem.ToString(),
                SoLuong = 0,
                DonGia = decimal.Parse(txtDonGia.Text),
                GiamGia = decimal.Parse(txtGiamGia.Text),
                TrangThaiBienThe = trangThai
            };

            // Sử dụng service để thêm sản phẩm và biến thể
            bool isAdded = productService.AddNewProductWithVariant(sanPham, bienThe);

            if (isAdded)
            {
                MessageBox.Show("Thêm sản phẩm mới thành công!" + cbTrangThai.SelectedItem, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void SaveProductVariant()
        {
            BienTheSanPham bienThe = new BienTheSanPham
            {
                MaSanPham = (int)cbTenSp.SelectedValue,
                MauSac = cbMauSac.SelectedItem.ToString(),
                KichCo = cbKichCo.SelectedItem.ToString(),
                SoLuong = 0,
                DonGia = decimal.Parse(txtDonGia.Text.Trim()),
                GiamGia = decimal.Parse(txtGiamGia.Text.Trim()),
                TrangThaiBienThe = (byte)(cbTrangThai.SelectedItem.ToString() == productMap[ProductStatus.Active.ToString()] ? 1 : 0)
            };

            bool ok = productService.AddProductVariantForNewProduct(bienThe.MaSanPham, bienThe);

            if (ok)
                MessageBox.Show("Thêm biến thể thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
