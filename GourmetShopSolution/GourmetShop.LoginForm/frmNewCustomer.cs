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

        private TextBox[] newCustTextBoxes;

        public frmNewCustomer()
        {
            InitializeComponent();

            newCustTextBoxes = new TextBox[]
                {txtNewCustUserName, txtNewCustPassword, txtNewCustConfirmPassword, txtNewCustFirstName,
                txtNewCustLastName, txtNewCustCity, txtNewCustCountry, txtNewCustPhone };

            //subscribing to all the textBoxes at once
            //using the => so I don't have to write a seperate function
            foreach(TextBox box in newCustTextBoxes)
            {
                box.TextChanged += (s, e) => ValidateForm();
            }

            btnNewCustCreateAccount.Enabled = true;
            lblinvalidEmail.Visible = false;
            lblPassMisMatch.Visible = false;
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
            if (txtNewCustConfirmPassword.PasswordChar == '*')
            {
                txtNewCustConfirmPassword.PasswordChar = '\0';
                picNewCustConfirmPassword.Image = Properties.Resources.eyeOpen;
            }
            else
            {
                txtNewCustConfirmPassword.PasswordChar = '*';
                picNewCustConfirmPassword.Image = Properties.Resources.eyeClosed;
            }
        }

        private void ValidateForm()
        {
            bool allFilled = newCustTextBoxes.All
                    (box => !string.IsNullOrWhiteSpace(box.Text));

            bool isEmailValid = EmailValidator.IsValidEmail(txtNewCustUserName.Text);

            bool passwordMatch = txtNewCustPassword.Text == txtNewCustConfirmPassword.Text;

            bool isPhoneNumberValid = PhoneNumberValidator.IsValidPhoneNumber(txtNewCustPhone.Text);

            lblinvalidEmail.Visible = !isEmailValid;
            lblPassMisMatch.Visible= !passwordMatch;

            btnNewCustCreateAccount.Enabled = allFilled && isEmailValid && passwordMatch && isPhoneNumberValid;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        //TODO Actually put in logic to verify account was created and then have the label show up.
        private void btnNewCustCreateAccount_Click(object sender, EventArgs e)
        {
            lblAccountCreated.Visible = true;

            // CHECKME: It will throw an error a second time if you try to register the same user information for phone number, first name, and last name
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

            // Save the new customer ID in session so they can place an order immediately

            try
            {
                int newCustomerId = _authService.Register(user, authentication);

                SessionData.CurrentCustomerId = newCustomerId;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to create account: {ex.Message}");
            }
        }
    }
}
