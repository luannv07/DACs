using DACs.Enums;
using DACs.Forms.OrderForms;
using DACs.Forms.ProductForms;
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
    public partial class ucHomeControl : UserControl
    {
        private readonly OrderService orderService = new OrderService();
        private readonly LogService logService = new LogService();

        private readonly Dictionary<string, string> roleMap = new Dictionary<string, string>
        {
            { Role.Admin.ToString(), "Quản trị" },
            { Role.StoreStaff.ToString(), "Kiểm kho" },
            { Role.Staff.ToString(), "Nhân viên" }
        };
        public ucHomeControl()
        {
            InitializeComponent();
        }
        private void setDynamicData()
        {
            var result = orderService.GetTodayOrdersAndRevenue();

            txtTodayOrder.Text = result.soDonMoi.ToString();
            txtTodayCost.Text = StringUtils.FormatNumber(result.tongDoanhThu * 1000) + " đ";
            txtTodayOrder.TextAlign = ContentAlignment.MiddleCenter;
            txtTodayCost.TextAlign = ContentAlignment.MiddleCenter;
            //txtTodayOrder.Dock = DockStyle.Fill;
            //txtTodayCost.Dock= DockStyle.Fill;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ucHomeControl_Load(object sender, EventArgs e)
        {
            LoadRecentLogs();


            timer1.Start();
            label1.Text = "Chào mừng: " + Session.currentUser.Ten + " (" + roleMap[Session.currentUser.VaiTro] + ")";
            setDynamicData();

            if (Session.currentUser.VaiTro == Role.Admin.ToString())
            {
                btnAddGRN.Enabled = true;
                btnAddProduct.Enabled = true;
                btnCreateOrder.Enabled = true;
            }
            else if (Session.currentUser.VaiTro == Role.Staff.ToString())
            {
                btnAddGRN.Enabled = false;
                btnAddProduct.Enabled = true;
                btnCreateOrder.Enabled = true;
            }
            else if (Session.currentUser.VaiTro == Role.StoreStaff.ToString())
            {
                btnAddGRN.Enabled = true;
                btnAddProduct.Enabled = true;
                btnCreateOrder.Enabled = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Thời gian hiện tại: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            ControlUtil.LoadFormWithoutClose(Form.ActiveForm, new AddOrderLine());
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ControlUtil.LoadFormWithoutClose(Form.ActiveForm, new AddProduct());
        }

        private void btnAddGRN_Click(object sender, EventArgs e)
        {
            ControlUtil.LoadFormWithoutClose(Form.ActiveForm, new CreateGRN());
        }
        private void LoadRecentLogs()
        {
            rtbRecentActivities.Clear();

            List<LogHeThong> logs = logService.GetLogs(VariableUtils.MAX_LOGS_COUNT);
            if (logs == null || logs.Count == 0)
            {
                rtbRecentActivities.AppendText("Chưa có hoạt động gần đây.");
                return;
            }
            foreach (var log in logs)
            {
                AppendLogColored(log);
            }
        }

        private void AppendLogColored(LogHeThong log)
        {
            Color color;

            switch (log.HanhDong)
            {
                case "CreateOrder":
                case "CreateProduct":
                case "CreateCustomer":
                    color = Color.Green;
                    break;

                case "UpdateProduct":
                case "UpdateCustomer":
                    color = Color.Orange;
                    break;

                case "DeleteOrder":
                case "DeleteProduct":
                    color = Color.Red;
                    break;

                case "ImportStock":
                    color = Color.Blue;
                    break;

                default:
                    color = Color.Black;
                    break;
            }

            rtbRecentActivities.SelectionColor = color;
            rtbRecentActivities.AppendText(StringUtils.FormatLog(log) + "\n");

            rtbRecentActivities.SelectionColor = Color.Black;
        }

    }
}
