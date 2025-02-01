using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;
using GourmetShop.DataAccess.Repositories.Classes;
using GourmetShop.WinForms.Forms;
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

namespace GourmetShop.WinForms
{
    public partial class MainForm : Form
    {

        public static string connectionString = ConfigurationManager.ConnectionStrings["GourmetShopConnectionString"].ConnectionString;
        private AdminRepository _adminRepository = new AdminRepository(connectionString);
        private ProductRepository productRepository = new ProductRepository(connectionString);
        public MainForm()
        {
            InitializeComponent();
            LoadAvailableProducts();
            dgvAvailableProducts.SelectionChanged += dgvAvailableProducts_SelectionChanged;
        }

        private void vts_mi_ViewProducts_Click(object sender, EventArgs e)
        {
            using (var frmProducts = new frmProducts())
            {
                frmProducts.ShowDialog();
            }
        }

        private void vts_mi_ViewSuppliers_Click(object sender, EventArgs e)
        {
            using (var frmSuppliers = new frmSuppliers())
            {
                frmSuppliers.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadAvailableProducts()
        {
            List<Product> availableProducts = productRepository.GetAvailableProductsForAdmin();
            dgvAvailableProducts.DataSource = availableProducts;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvAvailableProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAvailableProducts.SelectedRows.Count > 0)
            {
                // Get selected product ID
                int productId = Convert.ToInt32(dgvAvailableProducts.SelectedRows[0].Cells["ProductID"].Value);

                // Call repository method to fetch sales data
                var (totalUnitsSold, totalSalesAmount) = _adminRepository.GetProductSales(productId);

                // Update labels with the retrieved values
                lblTotalUnitsSold.Text = $"Total Units Sold: {totalUnitsSold}";
                lblTotalSalesAmount.Text = $"Total Sales: ${totalSalesAmount:F2}";
            }
        }
    }
}
