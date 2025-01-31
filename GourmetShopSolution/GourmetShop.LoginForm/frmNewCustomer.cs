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
    public partial class frmNewCustomer : Form
    {
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
    }
}
