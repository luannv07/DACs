using DACs.Forms.StoreForms;
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

namespace DACs.Controls
{
    public partial class GRNDetailsControl : UserControl
    {
        private readonly ProductService productService = new ProductService();
        public GRNDetailsControl()
        {
            InitializeComponent();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (selectedProductId.HasValue
                && !string.IsNullOrEmpty(selectedColor)
                && !string.IsNullOrEmpty(selectedSize))
            {
                RemoveCombination(selectedProductId.Value, selectedColor, selectedSize);
            }

            VariableUtils.currentPN--;

            var ctrl = (sender as Control);
            while (ctrl != null && !(ctrl is GRNDetailsControl))
                ctrl = ctrl.Parent;

            if (ctrl == null) return;

            var row = ctrl as GRNDetailsControl;
            var parent = row.Parent;

            parent.Controls.Remove(row);
            row.Dispose();

            var parentForm = this.FindForm() as CreateGRN;
            parentForm?.UpdateTotalCost();
        }


        private bool isLoading = false;

        public void fillProducts(List<SanPham> products)
        {
            isLoading = true;
            cbSP.DataSource = null;
            cbSP.Items.Clear();

            if (products == null || products.Count == 0)
            {
                cbSP.Items.Add("-- Không có sản phẩm --");
                cbSP.SelectedIndex = 0;
                return;
            }

            var listWithDefault = new List<SanPham>();
            listWithDefault.Add(new SanPham { MaSanPham = -1, TenSanPham = "-- Chọn sản phẩm --" });
            listWithDefault.AddRange(products);

            cbSP.DataSource = listWithDefault;
            cbSP.DisplayMember = "TenSanPham";
            cbSP.ValueMember = "MaSanPham";
            isLoading = false;
        }

        private void GRNDetailsControl_Load(object sender, EventArgs e)
        {

        }

        private void fillColors(List<string> colors)
        {
            cbMauSac.Items.Clear();
            cbMauSac.Items.AddRange(colors.ToArray());
        }

        private void resetFields()
        {
            cbKichCo.Items.Clear();
            cbMauSac.Items.Clear();
            txtDonGia.Text = null;
            txtThanhTien.Text = null;
        }

        private void fillSizes(List<string> sizes)
        {
            cbKichCo.Items.Clear();
            cbKichCo.Items.AddRange(sizes.ToArray());
        }

        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            RemoveOldCombinationIfExists();
            if (cbSP == null || cbSP.SelectedValue == null) return;
            resetFields();
            Control ctrl = (Control)sender;

            while (ctrl != null && !(ctrl is GRNDetailsControl))
            {
                ctrl = ctrl.Parent;
            }
            if (ctrl == null) return;

            var row = ctrl as GRNDetailsControl;
            var panel = row.Parent;
            if (panel == null) return;

            var parentForm = this.FindForm() as CreateGRN;
            parentForm?.UpdateTotalCost();

            List<string> colors = productService.GetAllColorByProductId(Convert.ToInt32(cbSP.SelectedValue));
            fillColors(colors);


        }

        private void cbKichCo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            RemoveOldCombinationIfExists();
            if (cbSP == null || cbSP.SelectedValue == null) return;
            if (cbMauSac == null || string.IsNullOrEmpty(cbMauSac.Text)) return;
            if (cbKichCo == null || string.IsNullOrEmpty(cbKichCo.Text)) return;

            int productId = Convert.ToInt32(cbSP.SelectedValue);
            string color = cbMauSac.Text;
            string size = cbKichCo.Text;

            txtDonGia.Text = productService.getPriceByProductIdAndColorAndSize(productId, color, size).ToString();
            updateThanhTien();

        }

        private void cbMauSac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
            RemoveOldCombinationIfExists();
            if (cbSP == null || cbSP.SelectedValue == null) return;
            if (cbMauSac == null || string.IsNullOrEmpty(cbMauSac.Text)) return;

            int productId = Convert.ToInt32(cbSP.SelectedValue);
            string color = cbMauSac.Text;

            List<string> sizes = productService.GetAllSizeByProductIdAndColor(productId, color);
            fillSizes(sizes);

        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }
        public event EventHandler TongTienChanged;

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            updateThanhTien();

        }
        private int? selectedProductId = null;
        private string selectedColor = null;
        private string selectedSize = null;
        private void RemoveOldCombinationIfExists()
        {
            if (selectedProductId.HasValue
                && !string.IsNullOrEmpty(selectedColor)
                && !string.IsNullOrEmpty(selectedSize))
            {
                RemoveCombination(selectedProductId.Value, selectedColor, selectedSize);
            }

            selectedProductId = null;
            selectedColor = null;
            selectedSize = null;
        }


        private void updateThanhTien()
        {
            if (isLoading) return;
            if (cbSP.SelectedValue == null || string.IsNullOrEmpty(cbMauSac.Text)
                || string.IsNullOrEmpty(cbKichCo.Text)
                || string.IsNullOrEmpty(txtDonGia.Text))
                return;

            int productId = Convert.ToInt32(cbSP.SelectedValue);
            string color = cbMauSac.Text;
            string size = cbKichCo.Text;

            if (selectedProductId != productId || selectedColor != color || selectedSize != size)
            {
                if (!AddCombination(productId, color, size))
                {
                    MessageBox.Show("Biến thể sản phẩm này đã được thêm rồi!", "Lỗi");

                    cbSP.SelectedIndex = 0;
                    cbMauSac.SelectedItem = null;
                    cbKichCo.SelectedItem = null;
                    txtDonGia.Text = "";
                    return;
                }

                selectedProductId = productId;
                selectedColor = color;
                selectedSize = size;
            }
            txtThanhTien.Text = (Convert.ToDecimal(txtDonGia.Text) * nudSoLuong.Value).ToString();
            TongTienChanged?.Invoke(this, EventArgs.Empty);
        }


        public decimal getTxtThanhTien()
        {
            if (string.IsNullOrEmpty(txtThanhTien.Text)) return Convert.ToDecimal(0);
            return Convert.ToDecimal(txtThanhTien.Text);
        }

        private bool AddCombination(int ProductId, string Color, string Size)
        {
            if (VariableUtils.SelectedCombinations.Any(c => c.ProductId == ProductId && c.Color == Color && c.Size == Size))
            {
                return false;
            }
            VariableUtils.SelectedCombinations.Add(new ProductCombination(ProductId, Color, Size));
            return true;
        }

        private bool RemoveCombination(int ProductId, string Color, string Size)
        {
            var combination = VariableUtils.SelectedCombinations.FirstOrDefault(c => c.ProductId == ProductId && c.Color == Color && c.Size == Size);
            if (combination != default)
            {
                VariableUtils.SelectedCombinations.Remove(combination);
                return true;
            }
            return false;

        }

        public ChiTietPhieuNhap GetChiTiet()
        {
            int productId = 0;
            if (cbSP.SelectedValue != null && int.TryParse(cbSP.SelectedValue.ToString(), out int pid))
                productId = pid;

            if (productId <= 0)
                return new ChiTietPhieuNhap { MaBienThe = 0, SoLuong = 0, DonGia = 0 };

            string color = string.IsNullOrWhiteSpace(cbMauSac.Text) ? null : cbMauSac.Text;
            string size = string.IsNullOrWhiteSpace(cbKichCo.Text) ? null : cbKichCo.Text;

            if (color == null || size == null)
                return new ChiTietPhieuNhap { MaBienThe = 0, SoLuong = 0, DonGia = 0 };

            int maBienThe =
                productService.GetBienTheSanPhamByUniqueFieldsGroup(productId, color, size)?.MaBienThe ?? 0;

            decimal donGia = 0;
            if (!string.IsNullOrWhiteSpace(txtDonGia.Text))
                decimal.TryParse(txtDonGia.Text, out donGia);

            int soLuong = Convert.ToInt32(nudSoLuong.Value);

            return new ChiTietPhieuNhap
            {
                MaBienThe = maBienThe,
                SoLuong = soLuong,
                DonGia = donGia
            };
        }

    }
}
