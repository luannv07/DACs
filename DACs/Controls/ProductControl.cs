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
        private readonly LogService logService = new LogService();
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
            cbKichCo.Items.AddRange(ProductPropsUtils.CommonSizes);
            cbMauSac.Items.AddRange(ProductPropsUtils.CommonColors);

            var suppliers = productService.GetAllSuppliers();
            cbNCC.DataSource = suppliers;
            cbNCC.DisplayMember = "TenNhaCungCap";
            cbNCC.ValueMember = "MaNhaCungCap";
            cbNCC.SelectedIndex = -1;

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
            btnThem.Enabled = false;
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
                    logService.WriteLog(Session.currentUser.MaNhanVien, LogAction.DeleteProduct, $"Xoá biến thể sản phẩm productDetails#{maBt} bởi user#{Session.currentUser.MaNhanVien}");
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
            var suppliers = productService.GetAllSuppliers();
            cbNCC.DataSource = suppliers;
            cbNCC.DisplayMember = "TenNhaCungCap";
            cbNCC.ValueMember = "MaNhaCungCap";
            cbNCC.SelectedIndex = -1;

            ResetProductFields();
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
            bienthe.MauSac = cbMauSac.Text.Trim();
            bienthe.KichCo = cbKichCo.Text.Trim();

            bool isUpdated = productService.UpdateProductVariant(maBt, sanpham.TenSanPham, bienthe.TrangThaiBienThe, bienthe.DonGia, bienthe.GiamGia, bienthe.MauSac, bienthe.KichCo);
            if (isUpdated)
            {
                MessageBox.Show("Cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                logService.WriteLog(Session.currentUser.MaNhanVien, LogAction.UpdateProduct, $"Sửa thông tin biến thể sản phẩm productDetails#{maBt} bởi user#{Session.currentUser.MaNhanVien}");
                LoadProductList(productService.GetAllProducts());
                ResetProductFields();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ControlUtil.LoadFormWithoutClose(Form.ActiveForm, new AddProduct());
        }
        private void btnThem_Click1()
        {
            SanPham sanPham = new SanPham();
            BienTheSanPham bienThe = new BienTheSanPham();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(txtTenSp.Text))
            {
                MessageBox.Show("Hãy nhập tên sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sanPham.TenSanPham = txtTenSp.Text.Trim();

            if (string.IsNullOrEmpty(cbNCC.Text) || cbNCC.Text == "-1")
            {
                MessageBox.Show("Hãy chọn Nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sanPham.MaNCC = int.Parse(cbNCC.Text.Trim());

            if (string.IsNullOrEmpty(cbMauSac.Text))
            {
                MessageBox.Show("Hãy chọn Màu sắc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bienThe.MauSac = cbMauSac.Text.Trim();

            if (string.IsNullOrEmpty(cbKichCo.Text))
            {
                MessageBox.Show("Hãy chọn Kích cỡ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bienThe.KichCo = cbKichCo.Text.Trim();
            bienThe.SoLuong = 0;  // default value
            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Hãy nhập Đơn giá hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                bienThe.DonGia = decimal.Parse(txtDonGia.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đơn giá không hợp lệ. Vui lòng nhập số hợp lệ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Handle Giảm giá
            if (string.IsNullOrEmpty(txtGiamGia.Text))
            {
                MessageBox.Show("Hãy nhập Giảm giá hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                bienThe.GiamGia = decimal.Parse(txtGiamGia.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giá trị giảm giá sai. Vui lòng nhập số hợp lệ: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Handle Trạng thái
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

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbMauSac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
