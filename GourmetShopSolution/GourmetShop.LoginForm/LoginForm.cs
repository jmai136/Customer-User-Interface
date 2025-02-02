using GourmetShop.CustomerView;
using GourmetShop.DataAccess.Entities;
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

namespace GourmetShop.LoginForm
{
    public partial class frmLogin : Form
    {
        AuthService _authService = new AuthService(LoginFormUtils._connectionString);

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
            frmNewCustomer newCustomer = new frmNewCustomer();
            newCustomer.Show();
            this.Hide();
        }

        private void btnNewAdmin_Click(object sender, EventArgs e)
        {
            frmNewAdmin newAdmin = new frmNewAdmin();
            newAdmin.Show();
            this.Hide();
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            lblAdminPassword.Visible = chkAdmin.Checked;
            lblAdminUserName.Visible = chkAdmin.Checked;
            txtAdminPassword.Visible = chkAdmin.Checked;
            txtAdminUsername.Visible = chkAdmin.Checked;
            btnAdminLogin.Visible = chkAdmin.Checked;
            btnNewAdmin.Visible = chkAdmin.Checked;
            picAdminPassword.Visible = chkAdmin.Checked;
            picAdminPassword.Image = Properties.Resources.eyeClosed;

        }

        
        private void txtAdminUsername_TextChanged(object sender, EventArgs e)
        {
            btnAdminLogin.Enabled = btnCustLogin.Enabled = !string.IsNullOrWhiteSpace(txtAdminUsername.Text) &&
                                   !string.IsNullOrWhiteSpace(txtAdminPassword.Text);
        }
        
        private void txtAdminPassword_TextChanged(object sender, EventArgs e)
        {
            btnAdminLogin.Enabled = !string.IsNullOrWhiteSpace(txtAdminUsername.Text) &&
                                   !string.IsNullOrWhiteSpace(txtAdminPassword.Text);
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

        private void picAdminPassword_Click(object sender, EventArgs e)
        {
            if (txtAdminPassword.PasswordChar == '*')
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

        private void btnCustLogin_Click(object sender, EventArgs e)
        {
            Authentication authentication = new Authentication()
            {
                Username = txtCustUserName.Text,
                Password = txtCustPassword.Text
            };

            // TODO: Implement login functionality, so grab the customer ID from the database based on the user ID
            int userId = _authService.Login(authentication.Username, authentication.Password);

            if (userId == -1)
            {
                MessageBox.Show("Login Failed");
                return;
            }

            frmCustomerMain customerMain = new frmCustomerMain(userId);
            customerMain.Show();

            // FIXME: Need to be able to clsoe the login form otherwise process will keep running in background even when you're done with the app
            // Probably going to have to close this form, assign a handler to the FormClosing, open the other forms from there, then actually implement application exit when they're done
            this.Hide();
        }

        //TODO use this button to actually log in an admin and take them to the admin view
        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            Authentication authentication = new Authentication()
            {
                Username = txtAdminUsername.Text,
                Password = txtAdminPassword.Text
            };

            int userId = _authService.Login(authentication.Username, authentication.Password);

            if (userId == -1)
            {
                MessageBox.Show("Login Failed");
                return;
            }

            frmAdminMain adminMain = new frmAdminMain(userId);
            adminMain.Show();

            // FIXME: Need to be able to clsoe the login form otherwise process will keep running in background even when you're done with the app
            // Probably going to have to close this form, assign a handler to the FormClosing, open the other forms from there, then actually implement application exit when they're done
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
