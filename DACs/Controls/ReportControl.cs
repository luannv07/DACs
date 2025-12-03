using DACs.Services;
using DACs.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DACs.Controls
{
    public partial class ucReportControl : UserControl
    {
        private readonly CustomerService customerService = new CustomerService();
        private readonly OrderService orderService = new OrderService();
        private readonly ProductService productService = new ProductService();
        private readonly LogService logService = new LogService();

        public ucReportControl()
        {
            InitializeComponent();
        }

        private void ucReportControl_Load(object sender, EventArgs e)
        {
            LoadFilterData();
            txtTotalCost.Text = StringUtils.FormatNumber(orderService.GetTotalRevenue() * 1000) + "đ";
            txtTotalCustomer.Text = customerService.GetAllCustomers().Count().ToString() + " khách hàng";
            txtTotalOrder.Text = orderService.getAllOrders().Count().ToString() + " đơn hàng";

            dgvBestCustomers.Rows.Clear();
            dgvBestSell.Rows.Clear();

            dgvBestCustomers.DataSource = customerService.GetTopCustomers();
            
            dgvBestCustomers.Columns["MaKhachHang"].HeaderText = "Mã KH";
            dgvBestCustomers.Columns["TenKhachHang"].HeaderText = "Tên KH";
            dgvBestCustomers.Columns["TongDon"].HeaderText = "Số đơn";
            dgvBestCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBestCustomers.Columns["MaKhachHang"].FillWeight = 20;
            dgvBestCustomers.Columns["TenKhachHang"].FillWeight = 60;
            dgvBestCustomers.Columns["TongDon"].FillWeight = 20;


            dgvBestSell.DataSource = productService.GetBestSell();
            dgvBestSell.Columns["MaSanPham"].HeaderText = "Mã SP";
            dgvBestSell.Columns["TenSanPham"].HeaderText = "Tên SP";
            dgvBestSell.Columns["SoLuong"].HeaderText = "Đã bán";
            dgvBestSell.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBestSell.Columns["MaSanPham"].FillWeight = 20;
            dgvBestSell.Columns["TenSanPham"].FillWeight = 60;
            dgvBestSell.Columns["SoLuong"].FillWeight = 20;

        }
        private void LoadFilterData()
        {
            cbFilterBy.Items.Clear();

            cbFilterBy.Items.Add("7 ngày gần nhất");
            cbFilterBy.Items.Add("Tháng này");
            cbFilterBy.Items.Add("Năm nay");
            cbFilterBy.Items.Add("Toàn thời gian");

            cbFilterBy.SelectedIndex = 0;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbFilterBy.SelectedItem.ToString();
            DateTime fromDate;

            switch (selected)
            {
                case "7 ngày gần nhất":
                    fromDate = DateTime.Today.AddDays(-7);
                    break;

                case "Tháng này":
                    fromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    break;

                case "Năm nay":
                    fromDate = new DateTime(DateTime.Today.Year, 1, 1);
                    break;

                default:
                    fromDate = orderService.GetFirstOrderDate();
                    break;
            }

            LoadRevenueChart(fromDate);
        }
        private void LoadRevenueChart(DateTime fromDate)
        {
            var data = orderService.GetRevenueByDate(fromDate);

            chartReporter.Series.Clear();
            var area = chartReporter.ChartAreas[0];

            area.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -45;

            area.AxisY.LabelStyle.Format = "#,##0";

            area.AxisY.Title = "Đơn vị: Nghìn đồng";

            Series s = new Series("Doanh thu");
            double totalDays = (DateTime.Today - fromDate).TotalDays;

            if (totalDays <= 7)
            {
                s.ChartType = SeriesChartType.Line;
                s.BorderWidth = 3;
                s.IsValueShownAsLabel = true;
            }
            else
            {
                s.ChartType = SeriesChartType.Column;
                s.IsValueShownAsLabel = false;
                s["PointWidth"] = "0.6";
                s.BorderWidth = 0;
            }

            foreach (var item in data)
            {
                s.Points.AddXY(item.Ngay.ToString("dd/MM"), item.DoanhThu);
            }

            chartReporter.AntiAliasing = AntiAliasingStyles.All;
            chartReporter.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            chartReporter.Series.Add(s);
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            string folderPath = Path.Combine(
                Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName,
                "DemoExportCSV"
            );

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string uuid = Guid.NewGuid().ToString();
            string filePath = Path.Combine(folderPath,
                $"BaoCaoDoanhThu_{uuid}.csv");

            ExportRevenueToCSV(filePath);

            MessageBox.Show("Đã xuất CSV tại:\n" + filePath,
                "Xuất CSV Thành côngggg!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            logService.WriteLog(Session.currentUser?.MaNhanVien, Enums.LogAction.ExportCSV, "Xuất báo cáo doanh thu ra file CSV.");
        }
        private void ExportRevenueToCSV(string filePath)
        {
            string selected = cbFilterBy.SelectedItem.ToString();
            DateTime fromDate;

            switch (selected)
            {
                case "7 ngày gần nhất":
                    fromDate = DateTime.Today.AddDays(-7);
                    break;

                case "Tháng này":
                    fromDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    break;

                case "Năm nay":
                    fromDate = new DateTime(DateTime.Today.Year, 1, 1);
                    break;

                default:    // Toàn thời gian
                    fromDate = orderService.GetFirstOrderDate();
                    break;
            }

            var data = orderService.GetRevenueByDate(fromDate);

            List<string> lines = new List<string>();
            lines.Add("Ngay,DoanhThu");
            //lines.Add($"{DateTime.Today.ToString("dd-MM-yyyy")},TuiNhoBan");
            foreach (var item in data)
            {
                string line = $"{item.Ngay:dd-MM-yyyy},{item.DoanhThu}";
                lines.Add(line);
            }

            File.WriteAllLines(filePath, lines);
        }

    }
}
