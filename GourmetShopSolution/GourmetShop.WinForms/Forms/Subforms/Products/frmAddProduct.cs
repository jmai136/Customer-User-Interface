using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;
using GourmetShop.WinForms.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetShop.WinForms.Forms.Subforms.Products
{
    public partial class frmAddProduct : Form
    {
        private ProductRepository _productRepository;

        // TO-DO:
        // Get supplier IDs, so inside of the data grid view, parse through the rows of it
        // Then somehow paass those in in the add product form and then make them values in the combobox
        public frmAddProduct(ProductRepository productRepository, object[] cmbSupplierIdValues)
        {
            _productRepository = productRepository;

            InitializeComponent();

            cmbSupplierId.Items.Clear();
            cmbSupplierId.Items.AddRange(cmbSupplierIdValues);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // Doesn't matter what we pass in for Id because it'll always be overriden
                Product product = new Product
                {
                    Id = -1,
                    ProductName = txtProductName.Text,
                    SupplierId = (int)cmbSupplierId.SelectedItem,
                    UnitPrice = (txtUnitPrice.Text.Length != 0) ? decimal.Parse(txtUnitPrice.Text, CultureInfo.InvariantCulture) : null,
                    Package = GourmetShopStringUtils.ConvertToNull(txtPackage.Text),
                    IsDiscontinued = cbIsDiscontinued.Checked
                };

                _productRepository.Add(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add product error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
        }
    }
}
