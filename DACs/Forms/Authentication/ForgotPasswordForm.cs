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

namespace DACs.Forms.Authentication
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ControlUtil.LoadForm(this, new LoginForm());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ControlUtil.LoadForm(this, new LoginForm());
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            // xu li gui code ve email o day
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
