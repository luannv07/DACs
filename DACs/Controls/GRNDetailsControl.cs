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
            VariableUtils.currentPN--;
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

            panel.Controls.Remove(row);
            row.Dispose();

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
            cbKichCo.Items.AddRange(sizes.ToArray());
        }

        private void cbSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading) return;
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
        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("pass");
            //TongTienChanged?.Invoke(this, EventArgs.Empty);
        }

        private void nudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            updateThanhTien();
            
        }

        
        private void updateThanhTien()
        {
            if (isLoading) return;
            if (cbSP == null || cbSP.SelectedValue == null) return;
            if (cbMauSac == null || string.IsNullOrEmpty(cbMauSac.Text)) return;
            if (cbKichCo == null || string.IsNullOrEmpty(cbKichCo.Text)) return;
            if (string.IsNullOrEmpty(txtDonGia.Text)) return;
            txtThanhTien.Text = (Convert.ToDecimal(txtDonGia.Text) * nudSoLuong.Value).ToString();
            TongTienChanged?.Invoke(this, EventArgs.Empty);
        }

        public decimal getTxtThanhTien()
        {
            if (string.IsNullOrEmpty(txtThanhTien.Text)) return Convert.ToDecimal(0);
            return Convert.ToDecimal(txtThanhTien.Text);
        }
    }
}
