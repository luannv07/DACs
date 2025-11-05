using DACs.Controls;
using DACs.Enums;
using DACs.Forms.Authentication;
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

namespace DACs
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void txtHelloUser_Click(object sender, EventArgs e)
        {

        }

        private void btnMenuHome_Click(object sender, EventArgs e)
        {
            activateButton(btnMenuHome);
            ControlUtil.LoadContentControl(new ucHomeControl(), panelContent);
        }
        
        private Button currentButton = null;
        private void activateButton(Button btn)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.LightYellow;
            }
            currentButton = btn;
            currentButton.BackColor = Color.Yellow;
        }

        private void btnMenuSale_Click(object sender, EventArgs e)
        {
            activateButton(btnMenuSale);
            ControlUtil.LoadContentControl(new ucSaleControl(), panelContent);
        }

        private void btnMenuProduct_Click(object sender, EventArgs e)
        {
            activateButton(btnMenuProduct);
        }

        private void btnMenuCustomer_Click(object sender, EventArgs e)
        {
            activateButton(btnMenuStore);
        }

        private void btnMenuSupplier_Click(object sender, EventArgs e)
        {
            activateButton(btnMenuSupplier);
            ControlUtil.LoadContentControl(new ucStoreControl(), panelContent);
        }

        private void btnMenuReport_Click(object sender, EventArgs e)
        {
            activateButton(btnMenuReport);
        }

        private void btnMenuAccount_Click(object sender, EventArgs e)
        {
            // how can i get currentUser role here???

            activateButton(btnMenuAccount);
            ControlUtil.LoadContentControl(new ucAccountControl(), panelContent);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RoleUtil.ApplyRole(Session.CurrentRole, panelMenu);
            txtHelloUser.Text = "Xin chào, " + Session.CurrentUsername;
            activateButton(btnMenuHome);
            ControlUtil.LoadContentControl(new ucHomeControl(), panelContent);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // bằng 1 cách thần kì nếu như có ai đó
            // dùg shortcut để maximize cửa sổ thì sẽ
            // hiện thông báo và trả về trạng thái bình thường :D
            if (this.WindowState == FormWindowState.Maximized)
            {
                MessageBox.Show("Tính năng này đã bị chặn rui cuoc doi oi.");
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ControlUtil.LoadForm(this, new LoginForm());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
