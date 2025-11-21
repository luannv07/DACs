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

namespace DACs.Forms.StoreForms
{
    public partial class ViewGRN : Form
    {
        private readonly StoreService storeService = new StoreService();
        private readonly UserService userService = new UserService();
        private readonly ProductDetailsService productDetailsService = new ProductDetailsService();
        private readonly ProductService productService = new ProductService();
        private readonly string GRNId;
        public ViewGRN(string text)
        {
            InitializeComponent();
            GRNId = text;
        }

        private void ViewGRN_Load(object sender, EventArgs e)
        {
            PhieuNhap grn = storeService.getById(Convert.ToInt32(GRNId));

            if (grn == null)
            {
                MessageBox.Show("Không tìm thấy phiếu nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            txtSupplierCode.Text = grn.MaNCC.ToString();
            cbSuppliers.Items.Clear();
            cbSuppliers.Items.Add(grn.TenNCC);
            cbSuppliers.SelectedIndex = 0;
            txtCurrentUser.Text = userService.getById(Convert.ToInt32(grn.MaNV.ToString())).TaiKhoan;
            txtNote.Text = grn.GhiChu;
            label1.Text = "Phiếu Nhập Hàng #" + grn.MaPhieuNhap.ToString();
            
            dgvGRNDetails.DataSource = grn.ChiTiets.Select(ct =>
            {
                BienTheSanPham bienthe = productDetailsService.getById(ct.MaBienThe);
                SanPham sanpham = productService.GetProductByPDId(ct.MaBienThe);
                return new
                {

                    MaBienThe = sanpham.TenSanPham + " (" + ct.MaBienThe + ")",
                    KichCo = bienthe.KichCo,
                    MauSac = bienthe.MauSac,
                    DonGia = string.Format("{0:N0} đ", ct.DonGia * 1000),
                    SoLuong = ct.SoLuong,
                    ThanhTien = string.Format("{0:N0} đ", ct.SoLuong * ct.DonGia * 1000),
                    NgayNhap = grn.NgayNhap,
                };
            }).ToList();

            txtTotalCost.Text = string.Format("{0:N0} đ",
                grn.ChiTiets.Sum(ct => ct.SoLuong * ct.DonGia * 1000)
            );

            dgvGRNDetails.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvGRNDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvGRNDetails.Columns["MaBienThe"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvGRNDetails.Columns["NgayNhap"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
            dgvGRNDetails.Columns["MaBienThe"].HeaderText = "Tên SP chi tiết";
            dgvGRNDetails.Columns["KichCo"].HeaderText = "Kích cỡ";
            dgvGRNDetails.Columns["MauSac"].HeaderText = "Màu sắc";
            dgvGRNDetails.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvGRNDetails.Columns["SoLuong"].HeaderText = "Số lượng";
            dgvGRNDetails.Columns["ThanhTien"].HeaderText = "Thành tiền (đ)";
            dgvGRNDetails.Columns["NgayNhap"].HeaderText = "Ngày nhập";

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
