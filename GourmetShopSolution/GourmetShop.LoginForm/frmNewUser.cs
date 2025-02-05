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
                {txtNewCustUserName, txtNewCustPassword, txtNewCustConfirmPassword, txtNewCustFirstName,
                txtNewCustLastName, txtNewCustCity, txtNewCustCountry, txtNewCustPhone };

            //subscribing to all the textBoxes at once
            //using the => so I don't have to write a seperate function
            foreach (TextBox box in newCustTextBoxes)
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
            lblPassMisMatch.Visible = !passwordMatch;
            lblInvalidPhoneNumber.Visible = !isPhoneNumberValid;

            btnNewCustCreateAccount.Enabled = allFilled && isEmailValid && passwordMatch && isPhoneNumberValid;
            btnNewAdmin.Enabled = allFilled && isEmailValid && passwordMatch && !isPhoneNumberValid && cboAdmin.Checked;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        
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


            

            try
            {
                //TODO I can't quite get this to work for this section, But I did get it to work for admin
                //will not let you create an account if there is already a user with names and phone number
                //in the database
                //var userRepo = new CustomerRepository(LoginFormUtils._connectionString);
                //if (userRepo.UserExists(user.FirstName, user.LastName, user.Phone))
                //{
                //    lblAccountCreated.Visible = true;
                //    lblAccountCreated.Text = "Account already exists";
                //    btnNewCustCreateAccount.Enabled = false;
                //}
                
                    int newCustomerId = _authService.Register(user, authentication);
                    SessionData.CurrentCustomerId = newCustomerId;
                
               
                
                
                
               
                    
                

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to create account: {ex.Message}");
            }
        }

        private void cboAdmin_CheckedChanged(object sender, EventArgs e)
        {
            btnNewCustCreateAccount.Enabled = false;
            btnNewCustCreateAccount.Visible = false;
            btnNewAdmin.Visible = true;
            btnNewAdmin.Enabled = true;
        }

        private void btnNewAdmin_Click(object sender, EventArgs e)
        {

            User AdminUser = new User()
            {
                FirstName = txtNewCustFirstName.Text,
                RoleId = 2,
                LastName = txtNewCustLastName.Text,
                Phone = txtNewCustPhone.Text,
                City = txtNewCustCity.Text,
                Country = txtNewCustCountry.Text
            };

            

            Authentication authenticationAdmin = new Authentication()
            {
                
                Username = txtNewCustUserName.Text,
                Password = txtNewCustPassword.Text
            };
            try
            {
                int newCustomerId = _authService.Register(AdminUser, authenticationAdmin);
                lblAccountCreated.Visible = true;

                //will not let you create an account if there is already a user with names and phone number
                //in the database
                var userRepo = new CustomerRepository(LoginFormUtils._connectionString);
                if (userRepo.UserExists(AdminUser.FirstName, AdminUser.LastName, AdminUser.Phone))
                {
                    lblAccountCreated.Visible = true;
                    lblAccountCreated.Text = "Account already exists";
                    btnNewAdmin.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"Unable to create account: {ex.Message}");
            }

            
        }
       
        


        // Save the new customer ID in session so they can place an order immediately


    }

        
}
   

