using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;

namespace GourmetShop.CustomerView
{
    public partial class frmCustomerMain : Form
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["GourmetShopConnectionString"].ConnectionString;
        private ProductRepository productRepository = new ProductRepository(connectionString);
        public frmCustomerMain()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            List<Product> availableProducts = (List<Product>)productRepository.GetAvailableProductsForAdmin();
            dgvCustViewProducts.DataSource = availableProducts;
        }

        private void btnShoppingCart_Click(object sender, EventArgs e)
        {
            frmShoppingCart cart = new frmShoppingCart();
            cart.Show();
        }
    }
}
