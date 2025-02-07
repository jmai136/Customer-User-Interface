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
        private UserRepository userRepository = new UserRepository(connectionString);
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
            customer = _customerRepository.GetByUserId(userId);
            User user = userRepository.GetByUserId(userId);

            // FIXED: Show the customer name instead of the ID
            MessageBox.Show($"Welcome, {user.FirstName} {user.LastName}!");
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

            this.Hide();

            frmShoppingCart cart = new frmShoppingCart();
            cart.Owner = this;
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

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvCustViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if quantity is 0 //added by yareni
           int  quantity = (int)nudQuantity.Value;
            if (quantity == 0)
            {
                MessageBox.Show("Quantity cannot be 0. Please select a valid quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SessionData.CurrentCustomerId <= 0)
            {
                MessageBox.Show("Invalid Customer ID. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int customerId = SessionData.CurrentCustomerId;
            int productId = Convert.ToInt32(dgvCustViewProducts.SelectedRows[0].Cells["Id"].Value);
          
            try
            {
                _shoppingcartRepository.AddToCart(customerId, productId, quantity);

                // Fetch and store the cart ID in the session
                int cartId = _shoppingcartRepository.GetCartIdForCustomer(customerId);
                if (cartId > 0)
                {
                    SessionData.CurrentCartId = cartId;
                }

                MessageBox.Show("Added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the product to the cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
