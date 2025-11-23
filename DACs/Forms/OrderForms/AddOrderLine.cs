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

namespace DACs.Forms.OrderForms
{
    public partial class AddOrderLine : Form
    {
        private readonly ProductService productService = new ProductService();
        private List<SanPham> products = new List<SanPham>();
        private List<dynamic> productSummary = new List<dynamic>();
        private List<dynamic> filteredProducts = new List<dynamic>();
        private List<BienTheSanPham> currentVariants = new List<BienTheSanPham>();
        private List<BienTheSanPham> allVariants = new List<BienTheSanPham>();
        private List<ChiTietDonHang> cart = new List<ChiTietDonHang>();
        private readonly CustomerService customerService = new CustomerService();
        private readonly OrderService orderService = new OrderService();
        private readonly UserService userService = new UserService();
        private readonly LogService logService = new LogService();

        private readonly Dictionary<string, string> genderMap = new Dictionary<string, string>
        {
            { Gender.Male.ToString(), "Nam" },
            { Gender.Female.ToString(), "Nữ" },
            { Gender.Other.ToString(), "Khác" }
        };
        public AddOrderLine()
        {
            InitializeComponent();
        }

        private void AddOrderLine_Load(object sender, EventArgs e)
        {
            products = productService.GetProductVariantsSummary();
            allVariants = productService.GetAllVariantsFlat();

            dgvProductList.BorderStyle = BorderStyle.None;
            dgvProductList.ReadOnly = true;
            dgvProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductList.MultiSelect = false;
            dgvProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var distinctProductsByName = products
            .GroupBy(p => new { p.MaSanPham, p.TenSanPham })
            .Select(g => new
            {
                MaSanPham = g.Key.MaSanPham,
                TenSanPham = g.Key.TenSanPham,
                TongTon = g.SelectMany(p => p.BienThes).Sum(bt => bt.SoLuong),
                GiaTrungBinh = (g.SelectMany(p => p.BienThes).Min(bt => bt.DonGia) + g.SelectMany(p => p.BienThes).Max(bt => bt.DonGia)) / 2
            })
            .ToList();

            foreach (var item in distinctProductsByName)
            {
                productSummary.Add(new
                {
                    MaSanPham = item.MaSanPham,
                    TenSanPham = item.TenSanPham,
                    GiaTrungBinh = StringUtils.FormatNumber(item.GiaTrungBinh * 1000) + "đ",
                    TongTon = item.TongTon,
                });
            }

            dgvProductList.DataSource = productSummary;
            filteredProducts = productSummary;
            setupDGvProductList();


            cbByField.Items.Clear();
            cbByField.DataSource = new BindingSource(VariableUtils.filterProductSearch, null);
            cbByField.DisplayMember = "Value";
            cbByField.ValueMember = "Key";
            cbByField.SelectedIndex = 0;
        }
        private void setupDGvProductList()
        {
            if (dgvProductList.RowCount <= 0) return;

            dgvProductList.Columns["MaSanPham"].HeaderText = "Mã SP";
            dgvProductList.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvProductList.Columns["TongTon"].HeaderText = "Tổng tồn kho";
            dgvProductList.Columns["GiaTrungBinh"].HeaderText = "Giá trung bình";
            dgvProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void txtSearching_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearching.Text.Trim().ToLower();

            filteredProducts = productSummary
                .Where(p => p.TenSanPham.ToLower().Contains(keyword))
                .ToList();
            ApplyFilterAndSort();
        }

        private void cbByPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilterAndSort();
        }

        private void ApplyFilterAndSort()
        {
            if (cbByField.SelectedIndex == -1)
            {
                dgvProductList.DataSource = filteredProducts;
                setupDGvProductList();
                return;
            }

            var selectedPair = (KeyValuePair<int, string>)cbByField.SelectedItem;
            int filterId = selectedPair.Key;

            List<dynamic> sorted = filteredProducts;

            switch (filterId)
            {
                case 0: // không sắp xếp
                    sorted = filteredProducts;
                    break;

                case 1: // giá tăng dần
                    sorted = filteredProducts.OrderBy(p => p.GiaTrungBinh).ToList();
                    break;

                case 2: // giá giảm dần
                    sorted = filteredProducts.OrderByDescending(p => p.GiaTrungBinh).ToList();
                    break;

                case 3: // tồn kho cao -> thấp
                    sorted = filteredProducts.OrderByDescending(p => p.TongTon).ToList();
                    break;

                case 4: // tồn kho thấp -> cao
                    sorted = filteredProducts.OrderBy(p => p.TongTon).ToList();
                    break;
            }

            dgvProductList.DataSource = sorted;
            setupDGvProductList();
        }


        private void cbMauSac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMauSac.SelectedIndex == -1) return;

            string selectedColor = cbMauSac.SelectedItem.ToString();

            // Lấy size theo màu đã chọn
            var sizes = currentVariants
                .Where(v => v.MauSac == selectedColor)
                .Select(v => v.KichCo)
                .Distinct()
                .ToList();

            cbKichCo.DataSource = sizes;
            cbKichCo.SelectedIndex = -1;

            txtSLToiDa.Text = "";
            txtDonGia.Text = "";
        }

        private void cbKichCo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMauSac.SelectedIndex == -1 || cbKichCo.SelectedIndex == -1) return;

            string color = cbMauSac.SelectedItem.ToString();
            string size = cbKichCo.SelectedItem.ToString();

            var variant = currentVariants
                .FirstOrDefault(v => v.MauSac == color && v.KichCo == size);

            if (variant != null)
            {
                txtSLToiDa.Text = "/" + variant.SoLuong.ToString();
                txtDonGia.Text = StringUtils.FormatNumber(variant.DonGia * 1000) + "đ";
                nmrSL.Maximum = variant.SoLuong;
            }
        }

        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int maSP = Convert.ToInt32(dgvProductList.Rows[e.RowIndex].Cells["MaSanPham"].Value);

            var product = products.FirstOrDefault(p => p.MaSanPham == maSP);
            if (product == null) return;
            


            currentVariants = product.BienThes;

            var colors = currentVariants
                .Select(v => v.MauSac)
                .Distinct()
                .ToList();

            cbMauSac.DataSource = colors;
            cbMauSac.SelectedIndex = -1;

            cbKichCo.DataSource = null;
            txtSLToiDa.Text = "";
            txtDonGia.Text = "";
        }

        private void dgvCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProductList.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!");
                return;
            }

            if (cbMauSac.SelectedIndex == -1 || cbKichCo.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn màu sắc và kích cỡ!");
                return;
            }

            if (!int.TryParse(nmrSL.Value.ToString(), out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            int maSP = Convert.ToInt32(dgvProductList.CurrentRow.Cells["MaSanPham"].Value);
            string color = cbMauSac.SelectedItem.ToString();
            string size = cbKichCo.SelectedItem.ToString();

            // tìm sản phẩm gốc
            var sanPham = products.FirstOrDefault(p => p.MaSanPham == maSP);
            if (sanPham == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!");
                return;
            }

            // tìm biến thể tương ứng
            var bienThe = sanPham.BienThes.FirstOrDefault(bt =>
                bt.MauSac == color &&
                bt.KichCo == size
            );

            if (bienThe == null)
            {
                MessageBox.Show("Không tìm thấy biến thể sản phẩm!");
                return;
            }

            // kiểm tra tồn kho
            if (soLuong > bienThe.SoLuong)
            {
                MessageBox.Show("Số lượng vượt quá tồn kho!");
                return;
            }

            // kiểm tra nếu biến thể đã có trong giỏ → tăng số lượng
            var exist = cart.FirstOrDefault(x => x.MaBienThe == bienThe.MaBienThe);

            if (exist != null)
            {
                // kiểm tra tồn kho sau khi cộng dồn
                if (exist.SoLuong + soLuong > bienThe.SoLuong)
                {
                    MessageBox.Show("Không đủ tồn kho cho số lượng cộng thêm!");
                    return;
                }

                exist.SoLuong += soLuong;
            }
            else
            {
                // thêm mới vào giỏ
                cart.Add(new ChiTietDonHang
                {
                    MaBienThe = bienThe.MaBienThe,
                    SoLuong = soLuong,
                    DonGia = bienThe.DonGia,
                    MaDonHang = 0 // chưa tạo đơn nên để 0
                });
            }

            LoadCartToGrid();
        }
        private void LoadCartToGrid()
        {
            dgvCart.DataSource = null;

            decimal tongSauGiam = 0; // tổng tiền sau giảm giá từng biến thể

            var data = cart.Select(c =>
            {
                var variant = allVariants.First(v => v.MaBienThe == c.MaBienThe);

                decimal donGia = variant.DonGia * 1000;
                decimal giam = variant.GiamGia;     // %
                decimal donGiaSauGiam = donGia * (100 - giam) / 100;

                decimal thanhTienSauGiam = c.SoLuong * donGiaSauGiam;

                tongSauGiam += thanhTienSauGiam;

                return new
                {
                    MaBienThe = c.MaBienThe,
                    SoLuong = c.SoLuong,
                    DonGia = StringUtils.FormatNumber(donGia),
                    GiamGia = giam + "%",
                    ThanhTien = StringUtils.FormatNumber(c.SoLuong * donGia) + "đ",
                    ThanhTienSauGiam = StringUtils.FormatNumber(thanhTienSauGiam) + "đ"
                };
            }).ToList();

            dgvCart.DataSource = data;

            dgvCart.Columns["MaBienThe"].HeaderText = "Mã BT";
            dgvCart.Columns["SoLuong"].HeaderText = "SL";
            dgvCart.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvCart.Columns["GiamGia"].HeaderText = "Giảm";
            dgvCart.Columns["ThanhTien"].HeaderText = "Tổng gốc";
            dgvCart.Columns["ThanhTienSauGiam"].HeaderText = "Sau giảm";

            // gán tổng trước khi áp dụng VIP
            txtBeforeSale.Text = StringUtils.FormatNumber(tongSauGiam) + "đ";

            UpdateTotalCost();
        }

        private void txtSDTKH_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSDTKH.Text))
            {
                txtTenKH.Text = "";
                txtDiaChiKH.Text = "";
                cbGioiTinh.SelectedIndex = -1;
                txtSalePercent.Text = "0";
                txtTotalCost.Text = txtBeforeSale.Text;
                return;
            }

            string phone = txtSDTKH.Text.Trim();

            // Check độ dài SDT
            if (phone.Length < 9 || phone.Length > 11)
            {
                txtTenKH.Text = "";
                txtDiaChiKH.Text = "";
                cbGioiTinh.SelectedIndex = -1;
                txtSalePercent.Text = "0";
                txtTotalCost.Text = txtBeforeSale.Text;
                return;
            }

            KhachHang kh = customerService.GetByPhone(phone);

            if (kh == null)
            {
                txtTenKH.Text = "";
                txtDiaChiKH.Text = "";
                cbGioiTinh.SelectedIndex = -1;
                txtSalePercent.Text = "0";
                txtTotalCost.Text = txtBeforeSale.Text;
                return;
            }

            txtTenKH.Text = kh.TenKhachHang;
            txtDiaChiKH.Text = kh.DiaChi;
            txtSDTKH.Text = kh.SoDienThoai;

            Gender g = (Gender)kh.GioiTinh;

            string display = genderMap[g.ToString()];

            cbGioiTinh.SelectedIndex = cbGioiTinh.Items.IndexOf(display);

            if (kh.LoaiKhachHang == (byte)CustomerType.VIP)
            {
                txtSalePercent.Text = VariableUtils.VIP_PERCENTAGE.ToString();
            }
            else
            {
                txtSalePercent.Text = "0";
            }
            UpdateTotalCost();
        }

        private void UpdateTotalCost()
        {
            decimal tongSauGiam = 0;

            foreach (var c in cart)
            {
                var variant = allVariants.First(v => v.MaBienThe == c.MaBienThe);

                decimal donGia = variant.DonGia * 1000;
                decimal giam = variant.GiamGia;
                decimal donGiaSauGiam = donGia * (100 - giam) / 100;

                tongSauGiam += donGiaSauGiam * c.SoLuong;
            }

            txtBeforeSale.Text = StringUtils.FormatNumber(tongSauGiam) + "đ";

            // --- VIP ---
            decimal vipPercent = 0;

            string raw = txtSalePercent.Text.Replace("%", "").Trim();

            if (!string.IsNullOrWhiteSpace(raw))
                decimal.TryParse(raw, out vipPercent);

            decimal tongSauVIP = tongSauGiam * (100 - vipPercent) / 100;

            txtTotalCost.Text = StringUtils.FormatNumber(tongSauVIP) + "đ";
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            
            // 1. Giỏ hàng rỗng
            if (cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!");
                return;
            }

            // 2. Kiểm tra thông tin khách
            string phone = txtSDTKH.Text.Trim();
            string name = txtTenKH.Text.Trim();
            string address = txtDiaChiKH.Text.Trim();
            byte gender = (byte)cbGioiTinh.SelectedIndex; // 0-Nam,1-Nữ,2-Khác

            if (phone.Length != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ! (phải đủ 10 số)");
                return;
            }
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
                return;
            }
            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ khách hàng!");
                return;
            }
            if (cbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return;
            }

            // 3. Kiểm tra khách hàng
            KhachHang kh = customerService.GetByPhone(phone);
            KhachHang newKH;
            int maKH = 0;
            string sdt = "";

            if (kh != null)
            {
                maKH = kh.MaKhachHang;
                sdt = kh.SoDienThoai;
            }
            else
            {
                // 4. Tạo khách hàng mới
                newKH = new KhachHang
                {
                    TenKhachHang = name,
                    DiaChi = address,
                    SoDienThoai = phone,
                    GioiTinh = gender,
                    LoaiKhachHang = 0 // mặc định thường
                };
                sdt = phone;

                maKH = customerService.AddCustomer(newKH);

                if (maKH <= 0)
                {
                    MessageBox.Show("Lỗi tạo khách hàng!");
                    return;
                }

                logService.WriteLog(Session.currentUser.MaNhanVien, LogAction.CreateCustomer,
                    $"Tạo khách hàng mới: {newKH.TenKhachHang} ({newKH.SoDienThoai})");

            }


            // ---- 5. Tạo đơn hàng ----
            DonHang dh = new DonHang
            {
                MaKhachHang = maKH,
                MaNhanVien = Session.currentUser.MaNhanVien,
                NgayDatHang = DateTime.Now,
                TrangThai = 0
            };



            int maDH = orderService.CreateOrder(dh);

            if (maDH <= 0)
            {
                MessageBox.Show("Lỗi tạo đơn hàng!");
                return;
            }

            // ---- 6. Insert chi tiết đơn hàng ----
            foreach (var c in cart)
            {
                // lấy biến thể từ allVariants
                var variant = allVariants.First(v => v.MaBienThe == c.MaBienThe);

                decimal donGia = variant.DonGia;
                decimal giam = variant.GiamGia;

                decimal donGiaSauGiam = donGia * (100 - giam) / 100;

                ChiTietDonHang ct = new ChiTietDonHang
                {
                    MaDonHang = maDH,
                    MaBienThe = c.MaBienThe,
                    SoLuong = c.SoLuong,
                    DonGia = donGiaSauGiam
                };

                orderService.AddOrderDetail(ct);

                // ---- 7. Trừ tồn kho ----
                productService.UpdateVariantStock(c.MaBienThe, -c.SoLuong);
            }
            logService.WriteLog(Session.currentUser.MaNhanVien, LogAction.CreateOrder, $"Tạo đơn hàng cho khách hàng có SĐT: {sdt} bởi user#{Session.currentUser.MaNhanVien}");
            MessageBox.Show("Tạo đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

    }
}
