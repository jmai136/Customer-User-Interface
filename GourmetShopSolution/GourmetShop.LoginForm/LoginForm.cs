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
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            lblAdminPassword.Visible = chkAdmin.Checked;
            lblAdminUserName.Visible = chkAdmin.Checked;
            txtAdminPassword.Visible = chkAdmin.Checked;
            txtAdminUsername.Visible = chkAdmin.Checked;
            btnAdminLogin.Visible = chkAdmin.Checked;
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

            // TODO: Implement login functionality
            if (_authService.Login(authentication.Username, authentication.Password) != -1)
                MessageBox.Show("Login Successful");
        }
    }
}
