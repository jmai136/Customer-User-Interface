using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories;
using GourmetShop.WinForms.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetShop.WinForms.Forms.Subforms.Suppliers
{
    public partial class frmAddSupplier : Form
    {
        private SupplierRepository _supplierRepository;

        public frmAddSupplier(SupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;

            InitializeComponent();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                // Doesn't matter what we pass in for Id because it'll always be overriden
                Supplier supplier = new Supplier
                {
                    Id = -1,
                    CompanyName = GourmetShopStringUtils.ConvertToNull(txtCompanyName.Text),
                    ContactName = GourmetShopStringUtils.ConvertToNull(txtContactName.Text),
                    ContactTitle = GourmetShopStringUtils.ConvertToNull(txtContactTitle.Text),
                    City = GourmetShopStringUtils.ConvertToNull(txtCity.Text),
                    Phone = GourmetShopStringUtils.ConvertToNull(txtPhone.Text),
                    Fax = GourmetShopStringUtils.ConvertToNull(txtFax.Text)
                };

                try
                {
                    // Essentially if the phone number has a string, it's gonna have to check also whether it's a phone number
                    if (supplier.Phone != null && !GourmetShopValidators.IsPhoneNumber(supplier.Phone))
                    {
                        throw new NotImplementedException("Invalid phone number");
                    }
                }
                catch (NotImplementedException ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }

                _supplierRepository.Add(supplier);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add product error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
        }
    }
}
