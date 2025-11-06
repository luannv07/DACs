using DACs.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACs.Controls
{
    public partial class ucProductControl : UserControl
    {
        private readonly ProductService productService = new ProductService();
        public ucProductControl()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ucProductControl_Load(object sender, EventArgs e)
        {
            dgvProductList.DataSource = productService.getAllProducts();
        }
    }
}
