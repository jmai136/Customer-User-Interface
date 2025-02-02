using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories.Classes;
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

namespace GourmetShop.CustomerView
{
    //CHECKME
    public partial class frmShoppingCart : Form
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["GourmetShopConnectionString"].ConnectionString;
        private ShoppingCartRepository shoppingCartRepository = new ShoppingCartRepository(connectionString);

        public frmShoppingCart()
        {
            InitializeComponent();
            LoadShoppingCart();

            // Set all columns as read-only first
            foreach (DataGridViewColumn col in dgvShoppingCartView.Columns)
            {
                col.ReadOnly = true;
            }

            // Allow only the "Quantity" column to be editable
            // FIXME: System.NullReferenceException: 'Object reference not set to an instance of an object.'
            dgvShoppingCartView.Columns["Quantity"].ReadOnly = false;





        }

        private void LoadShoppingCart()
        {
            int cartId = SessionData.CurrentCartId; // Retrieve cart ID from session

            if (cartId > 0)
            {
             
                DataTable cartData = shoppingCartRepository.ViewCart(cartId); // Fetch cart items


               

                dgvShoppingCartView.DataSource = cartData; // Bind to DataGridView

                decimal totalAmount = 0;


                foreach (DataRow row in cartData.Rows)
                {
                    decimal price = Convert.ToDecimal(row["Price"]);
                    int quantity = Convert.ToInt32(row["Quantity"]);

                    // Add price * quantity to the total amount
                    totalAmount += price * quantity;
                }

                // Update the label **after** calculating total
                lblTotalAmountDue.Text = $"Total Amount Due: ${totalAmount:F2}";
            }
            else
            {
                MessageBox.Show("Your cart is empty. Please add products first.", "Cart Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTotalAmountDue.Text = "Total Amount Due: $0.00"; // Ensure label is reset when the cart is empty
            }
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvShoppingCartView.SelectedRows.Count > 0)
            {
                // Get CartID and ProductID from the selected row
                int cartId = Convert.ToInt32(dgvShoppingCartView.SelectedRows[0].Cells["CartID"].Value);  // Make sure column name matches
                int productId = Convert.ToInt32(dgvShoppingCartView.SelectedRows[0].Cells["ProductID"].Value); // Make sure column name matches

                // Call the method to remove product from cart

                RemoveProductFromCart(cartId, productId);

                // Refresh the cart items to reflect the changes
                LoadShoppingCart();
            }
            else
            {
                // Display a message if no row is selected
                MessageBox.Show("Please select a row to delete.");
            }

        }

        private void btnReturnHome_Click(object sender, EventArgs e)
        {
            frmCustomerMain  customerview= new frmCustomerMain();
            customerview.Show();
            this.Close();
            
        }

        private void lblPlaceOrder_Click(object sender, EventArgs e)
        {
            bool isCartEmpty = true;
            foreach (DataGridViewRow row in dgvShoppingCartView.Rows)
            {
                // Skip the row if it's a new empty row or does not have a ProductID (assuming ProductID is required)
                if (row.IsNewRow) continue;

                if (row.Cells["ProductID"].Value != null && Convert.ToInt32(row.Cells["Quantity"].Value) > 0)
                {
                    isCartEmpty = false;
                    break;
                }
            }

            if (isCartEmpty)
            {
                MessageBox.Show("Your shopping cart is empty. Please add products before placing an order.",
                                "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop execution, don't place an order
            }

            int customerId = SessionData.CurrentCustomerId; // Retrieve customer ID from session or wherever it's stored

            try
            {
                // Call PlaceOrder and catch any exceptions if something goes wrong
                shoppingCartRepository.PlaceOrder(customerId);
                ClearCart();
                // If we reach here, the order was placed successfully
                MessageBox.Show("Your order has been successfully placed!", "Order Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                // Open the Customer View form with the product list
                frmCustomerMain customerView = new frmCustomerMain();
                customerView.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                // If an error occurs, show the error message
                MessageBox.Show($"There was an issue placing your order: {ex.Message}", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void ClearCart()
        {
            // Reset cart in session and clear DataGridView
            SessionData.CurrentCartId = -1; // Reset cart ID in session
            dgvShoppingCartView.DataSource = null; // Clear DataGridView
            lblTotalAmountDue.Text = "Total Amount Due: $0.00";
        }
        private void frmShoppingCart_Load(object sender, EventArgs e)
        {
            
        }



        private void RemoveProductFromCart(int cartId, int productId)
        {
            try
            {
                // Call the RemoveFromCart stored procedure using the ShoppingCartRepository
                shoppingCartRepository.RemoveFromCart(cartId, productId);

                // Optionally, display a confirmation message
                MessageBox.Show("Product removed from the cart.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvShoppingCartView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvShoppingCartView.Columns[e.ColumnIndex].Name == "Quantity")
            {
                // Get the updated quantity value from the DataGridView
                int newQuantity = Convert.ToInt32(dgvShoppingCartView.Rows[e.RowIndex].Cells["Quantity"].Value);

              

                // Get the ProductID and CartID from the corresponding row
                int productId = Convert.ToInt32(dgvShoppingCartView.Rows[e.RowIndex].Cells["ProductId"].Value);
                int cartId = SessionData.CurrentCartId;


                if (newQuantity <= 0)
                {
                    DialogResult result = MessageBox.Show("Quantity is set to 0. Do you want to remove this item from the cart?",
                                                          "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Call repository method to remove the item from the database
                        shoppingCartRepository.RemoveFromCart(cartId, productId);

                        // Remove the row from the DataGridView
                        dgvShoppingCartView.Rows.RemoveAt(e.RowIndex);

                        // Refresh total amount
                        LoadShoppingCart();
                    }
                    else
                    {
                        // Reset the quantity back to 1 if the user cancels
                        dgvShoppingCartView.Rows[e.RowIndex].Cells["Quantity"].Value = 1;
                    }

                    return;
                }



                // Call the method to update the quantity
                shoppingCartRepository.UpdateCartItemQuantity(cartId, productId, newQuantity);

                LoadShoppingCart();
            }
        }
    }
}
