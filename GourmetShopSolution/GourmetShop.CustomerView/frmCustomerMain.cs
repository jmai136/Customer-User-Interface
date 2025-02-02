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
using GourmetShop.DataAccess.Repositories.Classes;
using GourmetShop.DataAccess.Repositories.Interfaces.CRUD_Subinterfaces;

namespace GourmetShop.CustomerView
{
    public partial class frmCustomerMain : Form
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["GourmetShopConnectionString"].ConnectionString;

        private ProductRepository productRepository = new ProductRepository(connectionString);
        private SupplierRepository supplierRepository = new SupplierRepository(connectionString);
        private CustomerRepository _customerRepository = new CustomerRepository(connectionString);
        private ShoppingCartRepository _shoppingcartRepository = new ShoppingCartRepository(connectionString);

        Customer customer = new Customer();
        public frmCustomerMain()
        {
            InitializeComponent();
            LoadProducts();
            dgvCustViewProducts.DataBindingComplete += dgvCustViewProducts_DataBindingComplete;
            SupplierList();
            cboCustSuppliers.SelectedIndex = 0;
        }

        public frmCustomerMain(int userId) : this()
        {
            // TODO: Use the customer's ID to fetch the customer's data which you can then do stuff with it
            customer = _customerRepository.GetByUserId(userId);

            MessageBox.Show($"Welcome, {customer.Id}!");
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
            // CHECKME: Assigning current customer ID in session data to customer ID
            SessionData.CurrentCustomerId = customer.Id;

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
        //private void AddToCart(int customerId, int productId, int quantity)
        //{
        //    //_ = SessionData.CurrentCustomerId;
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        using (SqlCommand cmd = new SqlCommand("AddToCart", conn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@CustomerID", customerId);
        //            cmd.Parameters.AddWithValue("@ProductID", productId);
        //            cmd.Parameters.AddWithValue("@Quantity", quantity);
                    
        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //        }

        //    }catch(Exception ex){
        //        lblAddToCart.Text = "Failed to add to cart because: " + ex.Message;
        //    }
        //}

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvCustViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Debugging: Check if the Customer ID is valid
            MessageBox.Show($"Current Customer ID: {SessionData.CurrentCustomerId}");

            if (SessionData.CurrentCustomerId <= 0)
            {
                MessageBox.Show("Invalid Customer ID. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int customerId = SessionData.CurrentCustomerId;
            int productId = Convert.ToInt32(dgvCustViewProducts.SelectedRows[0].Cells["Id"].Value);
            int quantity = (int)nudQuantity.Value;

            try
            {
                _shoppingcartRepository.AddToCart(customerId, productId, quantity);
                MessageBox.Show("Added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
