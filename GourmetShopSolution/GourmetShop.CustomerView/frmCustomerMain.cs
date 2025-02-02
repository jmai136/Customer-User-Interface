using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        private SupplierRepository supplierRepository = new SupplierRepository(connectionString);
        public frmCustomerMain()
        {
            InitializeComponent();
            LoadProducts();
            dgvCustViewProducts.DataBindingComplete += dgvCustViewProducts_DataBindingComplete;
            SupplierList();
            cboCustSuppliers.SelectedIndex = 0;
        }


        private void cboCustSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboCustSuppliers.SelectedIndex == 0)
                {
                    LoadProducts();
                }
                else if (cboCustSuppliers.SelectedItem is Supplier selectedSupplier)
                {
                    string supplierName = selectedSupplier.CompanyName;
                    LoadProductsBySupplierName(supplierName);
                }


            } catch (Exception ex) 
            {
                MessageBox.Show($"Unable to load suppliers or products: {ex.Message}");
            }
            
        }
        private void LoadProducts()
        {
            try
            {
                List<Product> availableProducts = (List<Product>)productRepository.GetAvailableProductsForCust();
                dgvCustViewProducts.DataSource = availableProducts;
                //Hide columns that aren't pertinant to the customer
                //https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-hide-columns-in-the-windows-forms-datagridview-control?view=netframeworkdesktop-4.8
                dgvCustViewProducts.Columns["SupplierID"].Visible = false;
                dgvCustViewProducts.Columns["Package"].Visible = false;
            }catch (Exception ex)
            {
                MessageBox.Show($"Unable to load Products: {ex.Message}");
            }
            
            
            
        }

        private void btnShoppingCart_Click(object sender, EventArgs e)
        {
            frmShoppingCart cart = new frmShoppingCart();
            cart.Show();
        }


        //ChatGpt Suggested this event handler to hide the IsDiscontinued Column. Couldn't find a good answer anywhere else.
        //This column is not pertinant to customers as we already filter out discontinued.
        private void dgvCustViewProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (dgvCustViewProducts.Columns.Contains("IsDisContinued"))
                {
                    dgvCustViewProducts.Columns["IsDiscontinued"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The event handler is not behaving: {ex.Message}");
            }

        }

        private void SupplierList()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["GourmetShopConnectionString"].ConnectionString;
                var supplierRepository = new SupplierRepository(connectionString);
                var suppliers = supplierRepository.GetAll().ToList();

                suppliers.Insert(0, new Supplier { Id = -1, CompanyName = "-- Select a Supplier --" });

                cboCustSuppliers.DataSource = suppliers;
                cboCustSuppliers.DisplayMember = "CompanyName";
                cboCustSuppliers.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load Suppliers: {ex.Message}");
            }

        }

        private void LoadProductsBySupplierName(string supplierName)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["GourmetShopConnectionString"].ConnectionString;
                var productRepository = new ProductRepository(connectionString);

                List<Product> filteredProds = productRepository.GetSupplierByName(supplierName);
                dgvCustViewProducts.DataSource = filteredProds;

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Unable to filter products by suppliers: {ex.Message}");
            }
        }
        //TODO
        //Someone smarter than me double check this!!!!
        private void AddToCart(int customerId, int productId, int quantity)
        {
            //_ = SessionData.CurrentCustomerId;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("AddToCart", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            }catch(Exception ex){
                lblAddToCart.Text = "Failed to add to cart because: " + ex.Message;
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if(dgvCustViewProducts.SelectedRows.Count == 0)
            {
                lblAddToCart.Text = "Select a product to add to cart";
                return;
            }

            if(SessionData.CurrentCustomerId <= 0)
            {
                lblAddToCart.Text = "Your session has expired. You will need to log in";
                return;
            }

            int productId = Convert.ToInt32(dgvCustViewProducts.SelectedRows[0].Cells["Id"].Value);
            int customerId = SessionData.CurrentCustomerId;
            int quantiy = (int)nudQuantity.Value;

            if(nudQuantity.Value < 1)
            {
                lblAddToCart.Text = "Select a quantity";
                return;
            }

            AddToCart(customerId, productId, quantiy);
        }
    }
}
