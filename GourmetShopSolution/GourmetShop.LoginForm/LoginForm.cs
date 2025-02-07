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
            picPassword.Image = Properties.Resources.eyeClosed;//images from creative commons on google

        }
        
        private void txtCustUserName_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = !string.IsNullOrWhiteSpace(txtUserName.Text) &&
                                   !string.IsNullOrWhiteSpace(txtPassword.Text);
        }
        
        private void txtCustPassword_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = !string.IsNullOrWhiteSpace(txtUserName.Text) &&
                                    !string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmNewUser newCustomer = new frmNewUser();
            newCustomer.Owner = this;
            newCustomer.Show();
        }

       private void picPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
                picPassword.Image = Properties.Resources.eyeOpen;
            }
            else
            {
                txtPassword.PasswordChar = '*';
                picPassword.Image = Properties.Resources.eyeClosed;
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Authentication authentication = new Authentication()
            {
                Username = txtUserName.Text,
                Password = txtPassword.Text
            };

            try
            {
                int userId = _authService.Login(authentication.Username, authentication.Password);


                UserRepository userRepository = new UserRepository(connectionString);
                User user = userRepository.GetByUserId(userId);

                if (user.RoleId == 1)
                {
                    Customer customer = customerRepository.GetByUserId(userId);
                    SessionData.CurrentCustomerId = customer.Id;

                    //checks if customer has an existing cart that has products in it.
                    int cartId = shoppingcartRepository.GetCartIdForCustomer(userId);
                    if (cartId > 0)
                    {
                        SessionData.CurrentCartId = cartId; // Apply existing cart to session
                    }

                    frmCustomerMain customerMain = new frmCustomerMain(userId);
                    this.Hide();
                    customerMain.FormClosed += (s, args) => this.Close();
                    customerMain.Show();
                }
                else if (user.RoleId == 2)
                {
                    frmAdminMain adminMain = new frmAdminMain(userId);

                    this.Hide();
                    adminMain.FormClosed += (s, args) => this.Close();
                    adminMain.Show();
                }
                else
                {
                    throw new Exception("Invalid user type");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login Failed: {ex.Message}");
            }
        }
    }
}
