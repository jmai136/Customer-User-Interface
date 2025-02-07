using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;
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
    public partial class frmNewUser : Form
    {
        AuthService _authService = new AuthService(LoginFormUtils._connectionString);

        private TextBox[] newCustTextBoxes;

        public frmNewUser()
        {
            InitializeComponent();

            newCustTextBoxes = new TextBox[]
                {txtNewUserName, txtNewPassword, txtNewConfirmPassword, txtNewFirstName,
                txtNewtLastName, txtNewCity, txtNewCountry, txtNewPhone };

            //subscribing to all the textBoxes at once
            //using the => so I don't have to write a seperate function
            foreach (TextBox box in newCustTextBoxes)
            {
                box.TextChanged += (s, e) => ValidateForm();
            }

            lblinvalidEmail.Visible = false;
            lblPassMisMatch.Visible = false;
            btnCreateUser.Enabled = false;
            lblAccountCreated.Visible = false;
        }

        private void picNewCustPassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.PasswordChar == '*')
            {
                txtNewPassword.PasswordChar = '\0';
                picNewCustPassword.Image = Properties.Resources.eyeOpen;
            }
            else
            {
                txtNewPassword.PasswordChar = '*';
                picNewCustPassword.Image = Properties.Resources.eyeClosed;
            }
        }

        private void picNewCustConfirmPassword_Click(object sender, EventArgs e)
        {
            if (txtNewConfirmPassword.PasswordChar == '*')
            {
                txtNewConfirmPassword.PasswordChar = '\0';
                picNewCustConfirmPassword.Image = Properties.Resources.eyeOpen;
            }
            else
            {
                txtNewConfirmPassword.PasswordChar = '*';
                picNewCustConfirmPassword.Image = Properties.Resources.eyeClosed;
            }
        }

        private void ValidateForm()
        {
            bool allFilled = newCustTextBoxes.All
                    (box => !string.IsNullOrWhiteSpace(box.Text));

            bool isEmailValid = EmailValidator.IsValidEmail(txtNewUserName.Text);

            bool passwordMatch = txtNewPassword.Text == txtNewConfirmPassword.Text;

            bool isPhoneNumberValid = PhoneNumberValidator.IsValidPhoneNumber(txtNewPhone.Text);

            lblinvalidEmail.Visible = !isEmailValid;
            lblPassMisMatch.Visible = !passwordMatch;
            lblInvalidPhoneNumber.Visible = !isPhoneNumberValid;

            // TODO: Refactor this function to be in the UserRepository, not UserRepository
            var userRepo = new UserRepository(LoginFormUtils._connectionString);
            
            if (allFilled && isEmailValid && passwordMatch && isPhoneNumberValid && !userRepo.UserExists(txtNewFirstName.Text, txtNewtLastName.Text, txtNewPhone.Text))
            {
                btnCreateUser.Enabled = true;
                lblAccountCreated.Visible = false;
            }
            else if(allFilled && isEmailValid && passwordMatch && isPhoneNumberValid && userRepo.UserExists(txtNewFirstName.Text, txtNewtLastName.Text, txtNewPhone.Text))
            {
                btnCreateUser.Enabled = false;
                lblAccountCreated.Visible = true;
                lblAccountCreated.Text = "Account already exists";
            }
            else
            {
                btnCreateUser.Enabled = false;
                lblAccountCreated.Visible = false;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboAdmin_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                FirstName = txtNewFirstName.Text,
                RoleId = (cboAdmin.Checked) ? 2 : 1,
                LastName = txtNewtLastName.Text,
                Phone = txtNewPhone.Text,
                City = txtNewCity.Text,
                Country = txtNewCountry.Text
            };

            Authentication authenticationAdmin = new Authentication()
            {
                Username = txtNewUserName.Text,
                Password = txtNewPassword.Text
            };

            try
            {
                int userId = _authService.Register(user, authenticationAdmin);

                if (userId <= 0)
                {
                    throw new Exception("User account could not be created. Please try again.");
                }
                lblAccountCreated.Text = "Account successfully created! Return to login";
                lblAccountCreated.Visible = true;
                // CHECKME: Should be unnecessary because customer Id's assigned when the customer form's created
                /*
                if (userId != 1)
                    return;

                SessionData.CurrentCustomerId = userId;
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to create account: {ex.Message}");
            }
        }

        private void frmNewUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Show();
        }




        // Save the new customer ID in session so they can place an order immediately


    }

        
}
   

