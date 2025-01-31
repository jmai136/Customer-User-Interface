using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Services;
using GourmetShop.LoginForm.Utils;
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

namespace GourmetShop.LoginForm
{
    public partial class frmNewCustomer : Form
    {
        AuthService _authService = new AuthService(LoginFormUtils._connectionString);

        public frmNewCustomer()
        {
            InitializeComponent();
        }

        private void picNewCustPassword_Click(object sender, EventArgs e)
        {
            if (txtNewCustPassword.PasswordChar == '*')
            {
                txtNewCustPassword.PasswordChar = '\0';
                picNewCustPassword.Image = Properties.Resources.eyeOpen;
            }
            else
            {
                txtNewCustPassword.PasswordChar = '*';
                picNewCustPassword.Image = Properties.Resources.eyeClosed;
            }
        }

        private void picNewCustConfirmPassword_Click(object sender, EventArgs e)
        {

        }

        // CHECKME: It will throw an error a second time if you try to register the same user information for phone number, first name, and last name
        private void btnNewCustCreateAccount_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                FirstName = txtNewCustFirstName.Text,
                RoleId = 1,
                LastName = txtNewCustLastName.Text,
                Phone = txtNewCustPhone.Text,
                City = txtNewCustCity.Text,
                Country = txtNewCustCountry.Text
            };

            Authentication authentication = new Authentication()
            {
                Username = txtNewCustUserName.Text,
                Password = txtNewCustPassword.Text
            };

            _authService.Register(user, authentication);
        }
    }
}
