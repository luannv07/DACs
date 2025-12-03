using DACs.Enums;
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
    public partial class ucStoreControl : UserControl
    {
        private readonly StoreService storeService = new StoreService();
        private readonly UserService userService = new UserService();
        private readonly LogService logService = new LogService();

        private List<PhieuNhap> phieuNhap = new List<PhieuNhap>(); 

        public ucStoreControl()
        {
            InitializeComponent();
        }

        public void LoadPhieuNhap()
        {
            phieuNhap = storeService.getAllPhieuNhap();
            if (phieuNhap == null || phieuNhap.Count <= 0) return;
            dgvPhieuNhap.DataSource = phieuNhap
                .Select(u => new
                {
                    u.MaPhieuNhap,
                    u.MaNCC,
                    MaNV = userService.getById(u.MaNV)?.TaiKhoan,
                    NgayNhap = u.NgayNhap.ToString("dd/MM/yyyy HH:mm:ss"),
                    u.TenNCC,
                    u.GhiChu,
                    u.ChiTiets
                })
                .ToList();
            dgvPhieuNhap.Columns["MaPhieuNhap"].HeaderText = "Mã phiếu";
            dgvPhieuNhap.Columns["MaPhieuNhap"].Width = 100;

            dgvPhieuNhap.Columns["NgayNhap"].HeaderText = "Ngày nhập";
            dgvPhieuNhap.Columns["MaNCC"].HeaderText = "Mã NCC";
            dgvPhieuNhap.Columns["MaNCC"].Width = 80;
            dgvPhieuNhap.Columns["MaNV"].HeaderText = "Người thực hiện";
            dgvPhieuNhap.Columns["TenNCC"].HeaderText = "Tên Nhà cung cấp";
            dgvPhieuNhap.Columns["GhiChu"].HeaderText = "Ghi chú";

            dgvPhieuNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieuNhap.ReadOnly = true;
        }

        private void ucStoreControl_Load(object sender, EventArgs e)
        {
            LoadPhieuNhap();   
        }

        private void btnStoreAdd_Click(object sender, EventArgs e)
        {
            ControlUtil.LoadFormWithoutClose(Form.ActiveForm, new CreateGRN());
            VariableUtils.SelectedCombinations.Clear();
        }

        private void btnStoreDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPNDisabled.Text))
            {
                MessageBox.Show("Vui lòng chọn đúng hàng cần xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá phiếu này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            bool executed = storeService.deleteById(Convert.ToInt32(txtMaPNDisabled.Text));
            if (executed)
            {
                logService.WriteLog(Session.currentUser.MaNhanVien, LogAction.DeleteGRN, $"Xoá phiếu nhập GRN_ID#{txtMaPNDisabled.Text}");
                MessageBox.Show("Xoá thành công phiếu nhập có mã: " + txtMaPNDisabled.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show("Xoá thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadPhieuNhap();
            ToggleButton(false);
        }

        private void btnStoreDetails_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(txtMaPNDisabled.Text);
            ControlUtil.LoadFormWithoutClose(Form.ActiveForm, new ViewGRN(txtMaPNDisabled.Text));
        }

        private void dgvPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            if (!dgvPhieuNhap.Columns.Contains("MaPhieuNhap")) return;

            var cellValue = dgvPhieuNhap.Rows[e.RowIndex].Cells["MaPhieuNhap"].Value;
            if (cellValue == null) return;

            txtMaPNDisabled.Text = cellValue.ToString();

            ToggleButton(true);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tải lại thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadPhieuNhap();
            ToggleButton(false);
        }
        private void ToggleButton(bool isCellClicked)
        {
            btnStoreAdd.Enabled = !isCellClicked;
            btnStoreDetails.Enabled = isCellClicked;
            btnStoreDelete.Enabled = isCellClicked;
        }
    }
}
