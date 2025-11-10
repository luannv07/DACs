using DACs.Enums;
using DACs.Forms.ProductForms;
using DACs.Models;
using DACs.Services;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DACs.Controls
{
    public partial class ucProductControl : UserControl
    {
        private readonly ProductService productService = new ProductService();
        private List<SanPham> products = new List<SanPham>();

        private readonly Dictionary<string, string> productMap = new Dictionary<string, string>
        {
            { ProductStatus.Active.ToString(), "Đang bán" },
            { ProductStatus.Inactive.ToString(), "Ngừng bán" }
        };

        public ucProductControl()
        {
            InitializeComponent();
        }

        private void ucProductControl_Load(object sender, EventArgs e)
        {
            products = productService.GetAllProducts();
            cbKichCo.Items.AddRange(productService.GetAllSizes().ToArray());
            cbMauSac.Items.AddRange(productService.GetAllColors().ToArray());
            cbNCC.Items.Clear();
            cbNCC.Items.AddRange(productService.GetAllSuppliers().Select(ncc => ncc.MaNhaCungCap.ToString()).ToArray());
            LoadProductList(products);
        }

        private void LoadProductList(List<SanPham> products)
        {
            var flatList = new List<dynamic>();
            foreach (var sp in products)
            {
                foreach (var bt in sp.BienThes)
                {
                    flatList.Add(new
                    {
                        bt.MaBienThe,
                        sp.MaSanPham,
                        sp.TenSanPham,
                        bt.MauSac,
                        bt.KichCo,
                        bt.GiamGia,
                        sp.NgayTao,
                        bt.SoLuong,
                        bt.DonGia,
                        sp.MaNCC,
                        TrangThai = productMap.TryGetValue(((ProductStatus)bt.TrangThaiBienThe).ToString(), out var statusStr)
                            ? statusStr
                            : "Không xác định"
                    });
                }
            }

            dgvProductList.DataSource = flatList;
            if (dgvProductList.Rows.Count != 0)
            {
                if (dgvProductList.Columns["MaSanPham"] != null)
                    dgvProductList.Columns["MaSanPham"].Width = 50;
                if (dgvProductList.Columns["MaBienThe"] != null)
                    dgvProductList.Columns["MaBienThe"].Width = 50;

                dgvProductList.Columns["MaSanPham"].HeaderText = "MSP";
                dgvProductList.Columns["MaBienThe"].HeaderText = "MBT";
                dgvProductList.Columns["TenSanPham"].HeaderText = "Tên SP";
                dgvProductList.Columns["MaNCC"].HeaderText = "Mã NCC";
                dgvProductList.Columns["GiamGia"].HeaderText = "Giảm giá";
                dgvProductList.Columns["NgayTao"].HeaderText = "Ngày tạo";
                dgvProductList.Columns["MauSac"].HeaderText = "Màu sắc";
                dgvProductList.Columns["KichCo"].HeaderText = "Kích cỡ";
                dgvProductList.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvProductList.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvProductList.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            } else
            {
                MessageBox.Show("Không có sản phẩm nào trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAccountResetFields_Click(object sender, EventArgs e)
        {
            ResetProductFields();
        }

        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            cbMaSp.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            cbNCC.Enabled = false;

            if (!dgvProductList.Columns.Contains("MaSanPham")) return;

            var cellValue = dgvProductList.Rows[e.RowIndex].Cells["MaBienThe"].Value;
            if (cellValue == null) return;
            int maBt = Convert.ToInt32(cellValue);

            SanPham selectedProduct = productService.GetProductByPDId(maBt);
            if (selectedProduct == null) return;

            BienTheSanPham firstVariant = selectedProduct.BienThes.FirstOrDefault();

            cbMaSp.Text = selectedProduct.MaSanPham.ToString();
            txtTenSp.Text = selectedProduct.TenSanPham;
            cbNCC.Text = selectedProduct.MaNCC.ToString();
            dtpNgayThem.Value = selectedProduct.NgayTao;

            if (firstVariant != null)
            {
                txtMaBt.Text = firstVariant.MaBienThe.ToString();
                cbMauSac.Text = firstVariant.MauSac;
                cbKichCo.Text = firstVariant.KichCo;
                txtGiamGia.Text = firstVariant.GiamGia.ToString("0.##");
                txtSoLuong.Text = firstVariant.SoLuong.ToString();
                txtDonGia.Text = firstVariant.DonGia.ToString("0.##");
                cbTrangThai.Text = firstVariant.TrangThaiBienThe == 1 ? productMap[ProductStatus.Active.ToString()] 
                                   : firstVariant.TrangThaiBienThe == 0 ? productMap[ProductStatus.Inactive.ToString()] 
                                   : "Không xác định";
            }
            else
            {
                txtMaBt.Clear();
                cbMauSac.Text = "";
                cbKichCo.Text = "";
                txtSoLuong.Clear();
                txtDonGia.Clear();
                cbTrangThai.Text = "";
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (re == DialogResult.Yes)
            {
                int maBt = int.Parse(txtMaBt.Text.Trim());
                bool isDeleted = productService.DeleteProductVariant(maBt);
                if (isDeleted)
                {
                    MessageBox.Show("Xóa sản phẩm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProductList(productService.GetAllProducts());
                    ResetProductFields();
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnReloadDb_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã tải lại dữ liệu từ database.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProductList(productService.GetAllProducts());
            cbKichCo.Items.AddRange(productService.GetAllSizes().ToArray());
            cbMauSac.Items.AddRange(productService.GetAllColors().ToArray());
            cbNCC.Items.Clear();
            cbNCC.Items.AddRange(productService.GetAllSuppliers().Select(ncc => ncc.MaNhaCungCap.ToString()).ToArray());
        }

        private void ResetProductFields()
        {
            cbNCC.Enabled = true;
            cbMaSp.SelectedIndex = -1;
            cbMaSp.Text = "";
            txtTenSp.Clear();
            cbNCC.SelectedIndex = -1;
            txtGiamGia.Clear();
            txtMaBt.Text = "";

            cbMauSac.SelectedIndex = -1;
            cbKichCo.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtSoLuong.Text = "0";
            txtDonGia.Clear();
            cbTrangThai.SelectedIndex = -1;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true; 
        }

        private void btnTriggerSearching_Click(object sender, EventArgs e)
        {
            List<SanPham> filteredProducts = productService.FindByName(txtSearching.Text.Trim());

            if (filteredProducts.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProductList(products);
                return;
            }

            LoadProductList(filteredProducts);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maBt = int.Parse(txtMaBt.Text.Trim());
            SanPham sanpham = new SanPham();
            sanpham.TenSanPham = txtTenSp.Text.Trim();

            BienTheSanPham bienthe = new BienTheSanPham();

            bienthe.TrangThaiBienThe = (byte)(cbTrangThai.Text.Trim() == productMap[ProductStatus.Active.ToString()] ? 1 : 0);
            bienthe.DonGia = decimal.Parse(txtDonGia.Text.Trim());
            bienthe.GiamGia = decimal.Parse(txtGiamGia.Text.Trim());

            bool isUpdated = productService.UpdateProductVariant(maBt, sanpham.TenSanPham, bienthe.TrangThaiBienThe, bienthe.DonGia, bienthe.GiamGia);
            if (isUpdated)
            {
                MessageBox.Show("Cập nhật sản phẩm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProductList(productService.GetAllProducts());
                ResetProductFields();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SanPham sanPham = new SanPham();

            sanPham.TenSanPham = txtTenSp.Text.Trim();
            sanPham.MaNCC = int.Parse(cbNCC.Text.Trim());
            BienTheSanPham bienThe = new BienTheSanPham();
            bienThe.MauSac = "-1";
            bienThe.KichCo = "-1";
            bienThe.SoLuong = 0;
            bienThe.DonGia = decimal.Parse(txtDonGia.Text.Trim());
            bienThe.GiamGia = decimal.Parse(txtGiamGia.Text.Trim());
            bienThe.TrangThaiBienThe = (byte)(cbTrangThai.Text.Trim() == productMap[ProductStatus.Active.ToString()] ? 1 : 0);
            bool isAdded = productService.AddNewProductWithVariant(sanPham, bienThe);
            if (isAdded)
            {
                MessageBox.Show("Thêm sản phẩm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProductList(productService.GetAllProducts());
                ResetProductFields();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnOpenSuppilers_Click(object sender, EventArgs e)
        {
            Form currentForm = Form.ActiveForm;
            Form supplierForm = new AllSuppliers();
            supplierForm.Show();
        }

        private void dgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
