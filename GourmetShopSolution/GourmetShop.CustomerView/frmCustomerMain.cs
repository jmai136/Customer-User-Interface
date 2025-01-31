using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetShop.CustomerView
{
    public partial class frmCustomerMain : Form
    {
        public frmCustomerMain()
        {
            InitializeComponent();
        }

        private void btnShoppingCart_Click(object sender, EventArgs e)
        {
            frmShoppingCart cart = new frmShoppingCart();
            cart.Show();
        }
    }
}
