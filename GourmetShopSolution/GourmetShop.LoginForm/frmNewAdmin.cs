using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Services;
using GourmetShop.LoginForm.Utils;

namespace GourmetShop.LoginForm
{
    public partial class frmNewAdmin : Form
    {
        AuthService _authService = new AuthService(LoginFormUtils._connectionString);

        private TextBox[] newAdminTextBoxes;
        public frmNewAdmin()
        {
            InitializeComponent();

            newAdminTextBoxes = new TextBox[]
                {txtNewAdminUserName, txtNewAdminPassword, txtNewAdminConfirmPassword, txtNewAdminFirstName,
                txtNewAdminLastName, txtNewAdminCity, txtNewAdminCountry, txtNewAdminPhone };

            foreach (TextBox box in newAdminTextBoxes)
            {
                box.TextChanged += (s, e) => ValidateForm();
            }

            btnNewAdminCreateAccount.Enabled = true;
            lblAdminInvalidEmail.Visible = false;
            lblAdminPassMisMatch.Visible = false;
        }
        private void ValidateForm()
        {
            bool allFilled = newAdminTextBoxes.All
                    (box => !string.IsNullOrWhiteSpace(box.Text));

            bool isEmailValid = EmailValidator.IsValidEmail(txtNewAdminUserName.Text);

            bool passwordMatch = txtNewAdminPassword.Text == txtNewAdminConfirmPassword.Text;

            lblAdminInvalidEmail.Visible = !isEmailValid;
            lblAdminPassMisMatch.Visible = !passwordMatch;

            btnNewAdminCreateAccount.Enabled = allFilled && isEmailValid && passwordMatch;
        }

        private void picNewAdminPassword_Click(object sender, EventArgs e)
        {
            if (txtNewAdminPassword.PasswordChar == '*')
            {
                txtNewAdminPassword.PasswordChar = '\0';
                picNewAdminPassword.Image = Properties.Resources.eyeOpen;
            }
            else
            {
                txtNewAdminPassword.PasswordChar = '*';
                picNewAdminPassword.Image = Properties.Resources.eyeClosed;
            }
        }

        private void picNewAdminConfirmPassword_Click(object sender, EventArgs e)
        {
            if (txtNewAdminConfirmPassword.PasswordChar == '*')
            {
                txtNewAdminConfirmPassword.PasswordChar = '\0';
                picNewAdminConfirmPassword.Image = Properties.Resources.eyeOpen;
            }
            else
            {
                txtNewAdminConfirmPassword.PasswordChar = '*';
                picNewAdminConfirmPassword.Image = Properties.Resources.eyeClosed;
            }
        }
        private void btnAdminReturn_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void frmNewAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*frmLogin login = new frmLogin();
            login.Show();
            this.Hide();*/
        }

        private void btnNewAdminCreateAccount_Click(object sender, EventArgs e)
        {
            lblAdminAccountCreated.Visible = true;

            // CHECKME: Make sure that the admin has an email address
            User user = new User()
            {
                FirstName = txtNewAdminFirstName.Text,
                RoleId = 2,
                LastName = txtNewAdminLastName.Text,
                Phone = txtNewAdminPhone.Text,
                City = txtNewAdminCity.Text,
                Country = txtNewAdminCountry.Text
            };

            Authentication authentication = new Authentication()
            {
                Username = txtNewAdminUserName.Text,
                Password = txtNewAdminPassword.Text
            };

            _authService.Register(user, authentication);
        }
    }
}
