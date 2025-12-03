using DACs.Enums;
using DACs.Forms.OrderForms;
using DACs.Models;
using DACs.Services;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DACs.Controls
{
    public partial class ucOrderControl : UserControl
    {
        private readonly OrderService orderService = new OrderService();
        private readonly CustomerService customerService = new CustomerService();
        private readonly UserService userService = new UserService();
        private readonly LogService logService = new LogService();

        private List<DonHang> orders = new List<DonHang>();

        public readonly Dictionary<OrderStatus, string> orderMap = new Dictionary<OrderStatus, string>()
        {
            { OrderStatus.Success, "Thành công" },
            { OrderStatus.Cancel, "Đã huỷ" },
            { OrderStatus.Pending, "Đang đợi" }
        };

        public ucOrderControl()
        {
            InitializeComponent();
            dgvOrderList.DataBindingComplete += DgvOrderList_DataBindingComplete;

        }
        private void DgvOrderList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetupGrid();
        }

        // -------------------------------
        // 1. Load dữ liệu
        // -------------------------------
        private void LoadOrders()
        {
            orders = orderService.getAllOrders();

        }

        // -------------------------------
        // 2. Tạo danh sách hiển thị
        // -------------------------------
        private List<object> BuildOrderDisplayData()
        {
            var allCustomers = customerService.GetAllCustomers()
                                              .ToDictionary(c => c.MaKhachHang);

            var allUsers = userService.GetAllUsers()
                                      .ToDictionary(u => u.MaNhanVien);

            allUsers[Session.currentUser.MaNhanVien] = Session.currentUser;

            return orders.Select(o => new
            {
                o.MaDonHang,

                TenKhachHang = allCustomers.TryGetValue(o.MaKhachHang, out var kh)
                               ? kh.TenKhachHang
                               : "Không rõ",

                NhanVienXuLy = allUsers.TryGetValue(o.MaNhanVien, out var nv)
                               ? nv.TaiKhoan
                               : "Không rõ",

                NgayDatHang = o.NgayDatHang.ToString("dd/MM/yyyy HH:mm:ss"),

                TongTien = StringUtils.FormatNumber(orderService.GetTotalAmount(o.MaDonHang) * 1000) + "đ",

                TrangThai = orderMap.TryGetValue((OrderStatus)o.TrangThai, out var tt)
                            ? tt
                            : "Không xác định",
            }).ToList<object>();
        }


        // -------------------------------
        // 3. Setup DataGridView
        // -------------------------------
        private void SetupGrid()
        {
            if (dgvOrderList.Columns.Count == 0) return;
            dgvOrderList.Columns["MaDonHang"].HeaderText = "Mã đơn hàng";
            dgvOrderList.Columns["TenKhachHang"].HeaderText = "Khách hàng";
            dgvOrderList.Columns["NhanVienXuLy"].HeaderText = "Nhân viên xử lý";
            dgvOrderList.Columns["NgayDatHang"].HeaderText = "Ngày đặt hàng";
            dgvOrderList.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvOrderList.Columns["TongTien"].HeaderText = "Tổng tiền";

            dgvOrderList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderList.ReadOnly = true;
        }

        // -------------------------------
        // 4. Sự kiện load control
        // -------------------------------
        private void ucOrderControl_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        // -------------------------------
        // HÀM TÁI SỬ DỤNG
        // -------------------------------
        private void RefreshGrid()
        {
            LoadOrders();

            var data = BuildOrderDisplayData();

            dgvOrderList.DataSource = data;

            SetupGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void LoadOrderData(List<DonHang> ordersInput)
        {
            orders = ordersInput;

            var data = BuildOrderDisplayData();

            dgvOrderList.DataSource = data;

            SetupGrid();
        }


        private void btnTriggerSearching_Click(object sender, EventArgs e)
        {
            string keyword = txtSearching.Text.Trim();

            // Nếu để trống → load tất cả
            if (string.IsNullOrEmpty(keyword))
            {
                orders = orderService.getAllOrders();
                LoadOrderData(orders);
                return;
            }

            // Search theo keyword cho cả khách hàng + nhân viên
            var result = orderService.search(keyword);

            LoadOrderData(result);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvOrderList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int maDonHang = Convert.ToInt32(dgvOrderList.SelectedRows[0].Cells["MaDonHang"].Value);

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc muốn xoá đơn hàng #{maDonHang}?",
                "Xác nhận xoá",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.No)
                return;

            bool isDeleted = orderService.DeleteOrder(maDonHang);

            if (isDeleted)
            {
                logService.WriteLog(Session.currentUser.MaNhanVien, LogAction.DeleteOrder, $"Xoá thông tin đơn hàng orderID#{maDonHang}");
                MessageBox.Show("Xoá đơn hàng thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("Xoá đơn hàng thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAccountVipFeatures_Click(object sender, EventArgs e)
        {
            if (dgvOrderList.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 đơn hàng!", "Thông báo");
                return;
            }

            int maDonHang = Convert.ToInt32(
                dgvOrderList.SelectedRows[0].Cells["MaDonHang"].Value
            );

            // tìm đơn hàng trong list đang load (orders là list bạn đã bind vào grid)
            var don = orders.FirstOrDefault(x => x.MaDonHang == maDonHang);

            if (don == null)
            {
                MessageBox.Show("Không tìm thấy đơn hàng!", "Lỗi");
                return;
            }

            // lấy chi tiết đơn hàng từ DB
            var details = orderService.GetOrderDetails(maDonHang);

            if (details.Count == 0)
            {
                MessageBox.Show("Đơn này không có chi tiết sản phẩm!", "Thông báo");
                return;
            }

            // format từng dòng SP
            string detailText = string.Join("\n",
                details.Select(d =>
                    $"- CT #{d.MaDonHangChiTiet}: Biến thể {d.MaBienThe}, SL = {d.SoLuong}, Đơn giá = {StringUtils.FormatNumber(d.DonGia * 1000):n0}đ"
                )
            );

            // hiện messagebox
            MessageBox.Show(
                $"📦 ĐƠN HÀNG #{don.MaDonHang}\n" +
                $"👤 Khách: {don.MaKhachHang}\n" +
                $"🧑 Nhân viên: {don.MaNhanVien}\n" +
                $"🕒 Ngày đặt: {don.NgayDatHang:dd/MM/yyyy HH:mm}\n" +
                $"📌 Trạng thái: {orderMap[(OrderStatus)don.TrangThai]}\n\n" +
                $"------ CHI TIẾT SẢN PHẨM ------\n" +
                detailText,
                "Chi tiết đơn hàng",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            ControlUtil.LoadFormWithoutClose(Form.ActiveForm, new AddOrderLine());
        }
    }
}
