﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        //TODO use this button to actually log in a customer in and take them to the customer view
        private void btnCustLogin_Click(object sender, EventArgs e)
        {

            //this.Close() or this.Hide();
            //TODO enable the above when the button is hooked up.
        }
        //TODO use this button to actually log in an admin and take them to the admin view
        private void btnAdminLogin_Click(object sender, EventArgs e)
        {

            //this.Close() or this.Hide();
            //TODO enable the above when the button is hooked up.
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
