using DACs.Enums;
using DACs.Models;
using DACs.Services;
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
            cbNCC.Items.AddRange(productService.GetAllSuppliers().Select(ncc => ncc.MaNhaCungCap.ToString()).ToArray());
            LoadProductList(products);
            // LoadAvailableProductIds(); // nạp cbMaSp
        }

        //private void LoadAvailableProductIds()
        //{
        //    if (int.TryParse(cbNCC.Text, out int supplierId))
        //    {
        //        var availableIds = productService.GetAvailableProductIds(supplierId);
        //        cbMaSp.Items.Clear();
        //        cbMaSp.Items.AddRange(availableIds.Select(id => id.ToString()).ToArray());
        //        cbMaSp.SelectedIndex = -1;
        //    }
        //}

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
                        sp.MaNCC,
                        sp.GiamGia,
                        sp.NgayTao,
                        bt.MauSac,
                        bt.KichCo,
                        bt.SoLuong,
                        bt.DonGia,
                        TrangThai = productMap.TryGetValue(((ProductStatus)bt.TrangThaiBienThe).ToString(), out var statusStr)
                            ? statusStr
                            : "Không xác định"
                    });
                }
            }

            dgvProductList.DataSource = flatList;

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
        }

        private void btnAccountResetFields_Click(object sender, EventArgs e)
        {
            ResetProductFields();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            
        }

        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbMaSp.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            if (e.RowIndex < 0 || e.RowIndex >= products.Count)
                return;

            var selectedProduct = products[e.RowIndex];
            var firstVariant = selectedProduct.BienThes.FirstOrDefault();

            cbMaSp.Text = selectedProduct.MaSanPham.ToString();
            txtTenSp.Text = selectedProduct.TenSanPham;
            cbNCC.Text = selectedProduct.MaNCC.ToString();
            txtGiamGia.Text = selectedProduct.GiamGia.ToString("0.##");
            dtpNgayThem.Value = selectedProduct.NgayTao;
            txtMaBt.Text = selectedProduct.BienThes.FirstOrDefault().MaBienThe.ToString();

            if (firstVariant != null)
            {
                cbMauSac.Text = firstVariant.MauSac;
                cbKichCo.Text = firstVariant.KichCo;
                txtSoLuong.Text = firstVariant.SoLuong.ToString();
                txtDonGia.Text = firstVariant.DonGia.ToString("0.##");

                cbTrangThai.Text = firstVariant.TrangThaiBienThe == 1 ? "Đang bán"
                                   : firstVariant.TrangThaiBienThe == 0 ? "Ngừng bán"
                                   : "Không xác định";
            }
            else
            {
                cbMauSac.Text = "";
                cbKichCo.Text = "";
                txtSoLuong.Text = "";
                txtDonGia.Text = "";
                cbTrangThai.Text = "";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // TODO: sử dụng cbMaSp.SelectedItem
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvProductList.CurrentRow == null)
                return;

            DataGridViewRow row = dgvProductList.CurrentRow;

            SanPham product = new SanPham
            {
                MaSanPham = Convert.ToInt32(row.Cells["MaSanPham"].Value),
                TenSanPham = txtTenSp.Text.Trim(),
                MaNCC = cbNCC.SelectedValue != null
                ? Convert.ToInt32(cbNCC.SelectedValue)
                : 0,
                GiamGia = decimal.Parse(txtGiamGia.Text.Trim()),
                NgayTao = dtpNgayThem.Value,
                BienThes = new List<BienTheSanPham>()
                {
                    new BienTheSanPham
                    {
                        MaBienThe = int.Parse(txtMaBt.Text),
                        MauSac = cbMauSac.Text.Trim(),
                        KichCo = cbKichCo.Text.Trim(),
                        SoLuong = int.Parse(txtSoLuong.Text.Trim()),
                        DonGia = decimal.Parse(txtDonGia.Text.Trim()),
                        TrangThaiBienThe = (byte)(cbTrangThai.Text == "Đang bán" ? 1 : 0)
                    }
                }
            };
            if (product.GiamGia < 0 || product.GiamGia > 100)
            {
                MessageBox.Show("Giảm giá phải từ 0 đến 100%", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            productService.UpdateProduct(product);
            LoadProductList(productService.GetAllProducts());

            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (re == DialogResult.Yes)
            {
                productService.DeleteProduct(int.Parse(txtMaBt.Text));
                LoadProductList(productService.GetAllProducts());
            }
        }
        private void btnReloadDb_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã tải lại dữ liệu từ database.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProductList(productService.GetAllProducts());
            //LoadAvailableProductIds();
        }

        private void ResetProductFields()
        {
            cbMaSp.Enabled = true;
            cbMaSp.SelectedIndex = -1;
            txtTenSp.Clear();
            cbNCC.SelectedIndex = -1;
            txtGiamGia.Clear();
            cbMaSp.SelectedIndex = -1;
            txtMaBt.Text = "";
            dtpNgayThem.Value = DateTime.Now;

            cbMauSac.SelectedIndex = -1;
            cbKichCo.SelectedIndex = -1;
            txtSoLuong.Clear();
            txtDonGia.Clear();
            cbTrangThai.SelectedIndex = -1;

            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnTriggerSearching_Click(object sender, EventArgs e)
        {
            List<SanPham> filteredProducts = productService.FindByName(txtSearching.Text.Trim());

            if (filteredProducts.Count == 0)
            {
                dgvProductList.DataSource = new List<SanPham>();
                MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadProductList(filteredProducts);
        }


    }
}
