using System;
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
        }

        //I'm throwing this together really quick so ya'll can get started.
        //When I have more time, I am going to put these in array so that 
        //both fields have to be filled in for the button to be enabled.
        
        //TODO: Change to an array so both fields have to be filled in to enable the login button
        private void txtCustUserName_TextChanged(object sender, EventArgs e)
        {
            btnCustLogin.Enabled = true;
        }
        //TODO consider an event/handler or whatever it's called to put dots/starts when the password is typed.
        //TODO see if there can be a show password option if it changes to dots when typed
        private void txtCustPassword_TextChanged(object sender, EventArgs e)
        {
            btnCustLogin.Enabled = true;
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
            
        }

        //TODO 
        //Put these in an array so both have to be filled in for the button to be enabled
        private void txtAdminUsername_TextChanged(object sender, EventArgs e)
        {
            btnAdminLogin.Enabled = true;
        }
        //TODO consider an event/handler or whatever it's called to put dots/starts when the password is typed.
        //TODO see if there can be a show password option if it changes to dots when typed
        private void txtAdminPassword_TextChanged(object sender, EventArgs e)
        {
            btnAdminLogin.Enabled=true;
        }
    }
}
