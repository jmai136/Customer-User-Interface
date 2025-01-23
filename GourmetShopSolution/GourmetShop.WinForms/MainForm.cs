using GourmetShop.WinForms.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetShop.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void vts_mi_ViewProducts_Click(object sender, EventArgs e)
        {
            using (var frmProducts = new frmProducts())
            {
                frmProducts.ShowDialog();
            }
        }

        private void vts_mi_ViewSuppliers_Click(object sender, EventArgs e)
        {
            using (var frmSuppliers = new frmSuppliers())
            {
                frmSuppliers.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
