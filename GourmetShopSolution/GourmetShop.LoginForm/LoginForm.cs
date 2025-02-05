using GourmetShop.CustomerView;
using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;
using GourmetShop.DataAccess.Repositories.Interfaces.CRUD_Subinterfaces;
using GourmetShop.DataAccess.Services;
using GourmetShop.LoginForm.Utils;
using GourmetShop.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GourmetShop.LoginForm
{
    public partial class frmLogin : Form
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["GourmetShopConnectionString"].ConnectionString;
        AuthService _authService = new AuthService(LoginFormUtils._connectionString);
        private CustomerRepository customerRepository = new CustomerRepository(connectionString);
        private ShoppingCartRepository shoppingcartRepository = new ShoppingCartRepository(connectionString);


        public frmLogin()
        {
            InitializeComponent();
            picCustPassword.Image = Properties.Resources.eyeClosed;//images from creative commons on google

        }
       
        
        private void txtCustUserName_TextChanged(object sender, EventArgs e)
        {
            btnCustLogin.Enabled = !string.IsNullOrWhiteSpace(txtCustUserName.Text) &&
                                   !string.IsNullOrWhiteSpace(txtCustPassword.Text);
        }
        
        private void txtCustPassword_TextChanged(object sender, EventArgs e)
        {
            btnCustLogin.Enabled = !string.IsNullOrWhiteSpace(txtCustUserName.Text) &&
                                    !string.IsNullOrWhiteSpace(txtCustPassword.Text);
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmNewUser newCustomer = new frmNewUser();
            newCustomer.Owner = this;
            newCustomer.Show();
        }

       

       private void picCustPassword_Click(object sender, EventArgs e)
        {
            if (txtCustPassword.PasswordChar == '*')
            {
                txtCustPassword.PasswordChar = '\0';
                picCustPassword.Image = Properties.Resources.eyeOpen;
            }
            else
            {
                txtCustPassword.PasswordChar = '*';
                picCustPassword.Image = Properties.Resources.eyeClosed;
            }
        }

        

        private void btnCustLogin_Click(object sender, EventArgs e)
        {
            Authentication authentication = new Authentication()
            {
                Username = txtCustUserName.Text,
                Password = txtCustPassword.Text
            };


            try
            {
                int userId = _authService.Login(authentication.Username, authentication.Password);

                //retrievs customer id and sets it as current session data

                Customer customer = customerRepository.GetByUserId(userId);
                SessionData.CurrentCustomerId = customer.Id;

                //checks if customer has an existing cart that has products in it.
                int cartId = shoppingcartRepository.GetCartIdForCustomer(userId);
                if (cartId > 0)
                {
                    SessionData.CurrentCartId = cartId; // Apply existing cart to session
                }

                this.Hide();
                frmCustomerMain customerMain = new frmCustomerMain(userId);
                customerMain.FormClosed += (s, args) => this.Close();
                customerMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login Failed: {ex.Message}");
            }
        }

       
        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            Authentication authentication = new Authentication()
            {
                Username = txtAdminUsername.Text,
                Password = txtAdminPassword.Text
            };

            try
            {
                int userId = _authService.Login(authentication.Username, authentication.Password);

                frmAdminMain adminMain = new frmAdminMain(userId);

                this.Hide();
                adminMain.FormClosed += (s, args) => this.Close();
                adminMain.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login Failed: {ex.Message}");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtAdminUsername_TextChanged(object sender, EventArgs e)
        {
            btnAdminLogin.Enabled = !string.IsNullOrWhiteSpace(txtAdminUsername.Text) &&
                                   !string.IsNullOrWhiteSpace(txtAdminPassword.Text);
        }

        private void txtAdminPassword_TextChanged(object sender, EventArgs e)
        {
            btnAdminLogin.Enabled = !string.IsNullOrWhiteSpace(txtAdminUsername.Text) &&
                                   !string.IsNullOrWhiteSpace(txtAdminPassword.Text);
        }

        private void picAdminPassword_Click(object sender, EventArgs e)
        {
            if(txtCustPassword.PasswordChar == '*')
            {
                txtAdminPassword.PasswordChar = '\0';
                picAdminPassword.Image = Properties.Resources.eyeOpen;
            }
            else
            {
                txtAdminPassword.PasswordChar = '*';
                picAdminPassword.Image = Properties.Resources.eyeClosed;
            }
        }
    }
}
