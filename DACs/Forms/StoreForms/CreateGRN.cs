using DACs.Controls;
using DACs.Enums;
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
        private readonly StoreService storeService = new StoreService();
        private readonly LogService logService = new LogService();
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
            // 1. Tạo phiếu nhập
            var phieuNhap = new PhieuNhap
            {
                MaNCC = Convert.ToInt32(cbSuppliers.SelectedValue),
                MaNV = Session.currentUser.MaNhanVien,
                GhiChu = txtNote.Text.Trim(),
            };

            // 2. Thu thập CHI TIẾT từ tất cả GRNDetailsControl
            List<ChiTietPhieuNhap> chiTietPhieuNhaps = new List<ChiTietPhieuNhap>();

            foreach (Control ctrl in panel2.Controls)
            {
                if (ctrl is GRNDetailsControl row)
                {
                    var chiTiet = row.GetChiTiet();

                    // Bỏ các dòng rỗng (user chưa chọn gì)
                    if (chiTiet.MaBienThe == 0 || chiTiet.SoLuong <= 0)
                        continue;

                    chiTietPhieuNhaps.Add(chiTiet);
                }
            }

            // 3. Validate: phải có ít nhất 1 chi tiết
            if (chiTietPhieuNhaps.Count == 0)
            {
                MessageBox.Show("Phiếu nhập phải có ít nhất 1 dòng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Gọi service để lưu vào DB
            bool success = storeService.addPhieuNhap(phieuNhap, chiTietPhieuNhaps);

            if (success)
            {
                MessageBox.Show("Thanh toán thành công!", "Thông báo");
                btnCancel_Click(sender, e);
                MessageBox.Show("Bạn đã tạo thành công phiếu nhập! Vui lòng tải lại để xem phiếu mới nhất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                logService.WriteLog(Session.currentUser.MaNhanVien, LogAction.CreateProduct, $"user#{Session.currentUser.MaNhanVien} vừa tạo phiếu nhập mới từ NCC: {cbSuppliers.SelectedValue}");
                productService.UpdateProductVariantQuantity(chiTietPhieuNhaps);

            }
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


    }   
}
