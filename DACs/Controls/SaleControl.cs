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
    public partial class ucSaleControl : UserControl
    {
        public ucSaleControl()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ucSaleControl_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            FormAddSale formAddSale = new FormAddSale();
            formAddSale.ShowDialog();
        }
    }
}
