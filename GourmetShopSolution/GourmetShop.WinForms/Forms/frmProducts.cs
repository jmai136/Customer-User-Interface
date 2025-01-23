using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;
using GourmetShop.WinForms.Forms.Subforms.Products;
using GourmetShop.WinForms.Utils;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetShop.WinForms.Forms
{
    public partial class frmProducts : Form
    {
        private readonly ProductRepository _productRepository;

        private object[] cmbSupplierIdValues;

        // TO BE REFACTORED
        List<Product> productsUpdate = new List<Product>()
        {
        };

        // TO BE REFACTORED
        private int productIdDelete = -1;

        public frmProducts()
        {
            InitializeComponent();
            _productRepository = new ProductRepository(GourmetShopUtils.connectionString);
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            RefreshProducts();
        }

        private void RefreshProducts()
        {
            try
            {
                var products = _productRepository.GetAll();
                dgvProducts.DataSource = products.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Get all products error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
              cmbSupplierIdValues = dgvProducts.Rows
                    .Cast<DataGridViewRow>()
                    .Select(r => r.Cells[2].Value)
                    .Distinct()
                    .OrderBy(num => num)
                    .ToArray();

            using (var frmAddProduct = new frmAddProduct(_productRepository, cmbSupplierIdValues))
            {
                frmAddProduct.FormClosed += AddProduct_FormClosed;
                frmAddProduct.ShowDialog();
            }
        }

        private void AddProduct_FormClosed(Object sender, FormClosedEventArgs e)
        {
            RefreshProducts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/22328392/cannot-perform-like-operation-on-system-int32-and-system-string-datagridview
            // Quick on the fly, specifically for searching by columns
            try
            {
                DataTable dt = (DataTable)(dgvProducts.DataSource.GetType() != typeof(DataTable) ? GourmetShopStringUtils.ConverListToDataTable(dgvProducts.DataSource as List<Product>) : dgvProducts.DataSource);
                dt.DefaultView.RowFilter = string.Format("CONVERT(ProductName, System.String) LIKE '%{0}%' OR CONVERT(UnitPrice, System.String) LIKE '%{0}%' OR CONVERT(Package, System.String) LIKE '%{0}%'", txtSearch.Text.Trim());

                dgvProducts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            // When the cells change, the row to an array, and once updated, loop through that array and pass in the values of that cells
            try
            {
                foreach (Product product in productsUpdate)
                    _productRepository.Update(product);

                RefreshProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update product error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            string unitPriceValue = "", packageValue = "";

            // Split these try catch statements into three
            try
            {
                row = dgvProducts.Rows[e.RowIndex];

                unitPriceValue = row.Cells["UnitPrice"].Value?.ToString() ?? String.Empty;
                packageValue = row.Cells["Package"].Value?.ToString() ?? String.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cell value changed error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (BatchUpdateProducts(row, unitPriceValue, packageValue))
                return;

            AddProductToBatchUpdate(row, unitPriceValue, packageValue);
        }

        private bool BatchUpdateProducts(DataGridViewRow row, string unitPriceValue, string packageValue)
        {
            // MODIFY, PASS IN PRODUCT INSTEAD
            foreach (Product product in productsUpdate)
            {
                if (product.Id == Int32.Parse(row.Cells["Id"].Value.ToString()))
                {
                    try
                    {
                        product.ProductName = row.Cells["ProductName"].Value.ToString();
                        product.SupplierId = Int32.Parse(row.Cells["SupplierId"].Value.ToString());
                        product.UnitPrice = GourmetShopValidators.NullableValidationHandler<decimal?>(unitPriceValue);
                        product.Package = GourmetShopValidators.NullableValidationHandler<string>(packageValue);
                        product.IsDiscontinued = Convert.ToBoolean(row.Cells["IsDiscontinued"].Value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Batch update products error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    /*try
                    {
                        product.UnitPrice = decimal.Parse(GourmetShopStringUtils.ConvertToNull(unitPriceValue));
                    }
                    // Argument null exception should be ignored because you should be able to add null values in the database
                    catch (ArgumentNullException ane)
                    {
                        product.UnitPrice = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Batch update products error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }*/

                    /*try
                    {
                        product.Package = GourmetShopStringUtils.ConvertToNull(packageValue);
                    }
                    // Argument null exception should be ignored because you should be able to add null values in the database
                    catch (ArgumentNullException ane)
                    {
                        product.Package = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Batch update products error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }*/

                    return true;
                }
            }

            return false;
        }

        private void AddProductToBatchUpdate(DataGridViewRow row, string unitPriceValue, string packageValue)
        {
            Product updatedProduct = new Product();

            /*// ALLOW NULLS
            try
            {
                updatedProduct.UnitPrice = decimal.Parse(GourmetShopStringUtils.ConvertToNull(unitPriceValue));
            }
            // Argument null exception should be ignored because you should be able to add null values in the database
            catch (ArgumentNullException ane)
            {
                updatedProduct.UnitPrice = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add product to batch updates error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                updatedProduct.Package = GourmetShopStringUtils.ConvertToNull(packageValue);
            }
            // Argument null exception should be ignored because you should be able to add null values in the database
            catch (ArgumentNullException ane)
            {
                updatedProduct.Package = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add product to batch updates error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            try
            {
                updatedProduct.Id = Int32.Parse(row.Cells["Id"].Value.ToString());
                updatedProduct.ProductName = row.Cells["ProductName"].Value.ToString();
                updatedProduct.SupplierId = Int32.Parse(row.Cells["SupplierId"].Value.ToString());
                updatedProduct.UnitPrice = GourmetShopValidators.NullableValidationHandler<decimal?>(unitPriceValue);
                updatedProduct.Package = GourmetShopValidators.NullableValidationHandler<string>(packageValue);
                updatedProduct.IsDiscontinued = Convert.ToBoolean(row.Cells["IsDiscontinued"].Value);

                productsUpdate.Add(updatedProduct);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Add product to batch updates error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProducts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

                productIdDelete = Int32.Parse(row.Cells["Id"].Value?.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Row enter changed error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _productRepository.Delete(productIdDelete);
                productIdDelete = -1;

                RefreshProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete product error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
 }
