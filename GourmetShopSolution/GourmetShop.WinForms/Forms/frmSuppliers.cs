using GourmetShop.DataAccess.Repositories;
using GourmetShop.WinForms.Utils;
using GourmetShop.WinForms.Forms.Subforms.Suppliers;

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
using System.Runtime.Remoting.Messaging;

namespace GourmetShop.WinForms.Forms
{
    public partial class frmSuppliers : Form
    {
        private readonly SupplierRepository _supplierRepository;

        // TO BE REFACTORED
        List<Supplier> suppliersUpdate = new List<Supplier>()
        {
        };

        // TO BE REFACTORED
        private int supplierIdDelete = -1;

        public frmSuppliers()
        {
            InitializeComponent();

            _supplierRepository = new SupplierRepository(GourmetShopUtils.connectionString);
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            RefreshSuppliers();
        }

        private void RefreshSuppliers()
        {
            try
            {
                var suppliers = _supplierRepository.GetAll();
                dgvSuppliers.DataSource = suppliers.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Get all suppliers error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            using (var frmAddSupplier = new frmAddSupplier(_supplierRepository))
            {
                frmAddSupplier.FormClosed += AddSupplier_FormClosed;
                frmAddSupplier.ShowDialog();
            }
        }

        private void AddSupplier_FormClosed(Object sender, FormClosedEventArgs e)
        {
            RefreshSuppliers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/22328392/cannot-perform-like-operation-on-system-int32-and-system-string-datagridview
            // Quick on the fly, specifically for searching by columns
            try
            {
                DataTable dt = (DataTable)(dgvSuppliers.DataSource.GetType() != typeof(DataTable) ? GourmetShopStringUtils.ConverListToDataTable(dgvSuppliers.DataSource as List<Supplier>) : dgvSuppliers.DataSource);
                dt.DefaultView.RowFilter = string.Format("CONVERT(CompanyName, System.String) LIKE '%{0}%' OR CONVERT(ContactName, System.String) LIKE '%{0}%' OR CONVERT(ContactTitle, System.String) LIKE '%{0}%' OR CONVERT(City, System.String) LIKE '%{0}%' OR CONVERT(Country, System.String) LIKE '%{0}%' OR CONVERT(Phone, System.String) LIKE '%{0}%' OR CONVERT(Fax, System.String) LIKE '%{0}%'", txtSearch.Text.Trim());

                dgvSuppliers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSuppliers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];

                if (BatchUpdateSuppliers(row))
                    return;

                AddSupplierToBatchUpdate(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Cell value changed error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddSupplierToBatchUpdate(DataGridViewRow row)
        {
            Supplier updatedSupplier = new Supplier();

            try
            {
                updatedSupplier.Id = Int32.Parse(row.Cells["Id"].Value.ToString());
                updatedSupplier.CompanyName = row.Cells["CompanyName"].Value.ToString();
                updatedSupplier.ContactName = GourmetShopValidators.NullableValidationHandler<string?>(row.Cells["ContactName"].Value);
                updatedSupplier.ContactTitle = GourmetShopValidators.NullableValidationHandler<string?>(row.Cells["ContactTitle"].Value);
                updatedSupplier.City = GourmetShopValidators.NullableValidationHandler<string?>(row.Cells["City"].Value);
                updatedSupplier.Country = GourmetShopValidators.NullableValidationHandler<string?>(row.Cells["Country"].Value);
                updatedSupplier.Phone = GourmetShopValidators.NullableValidationHandler<string?>(row.Cells["Phone"].Value);
                updatedSupplier.Fax = GourmetShopValidators.NullableValidationHandler<string?>(row.Cells["Fax"].Value);

                suppliersUpdate.Add(updatedSupplier);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Add supplier to batch updates error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool BatchUpdateSuppliers(DataGridViewRow row)
        {
            foreach (Supplier supplier in suppliersUpdate)
            {
                if (supplier.Id == Int32.Parse(row.Cells["Id"].Value.ToString()))
                {
                    try
                    {
                        supplier.CompanyName = row.Cells["CompanyName"].Value.ToString();
                        supplier.ContactName = GourmetShopValidators.NullableValidationHandler<string?>(row.Cells["ContactName"].Value);
                        supplier.ContactTitle = GourmetShopValidators.NullableValidationHandler<string?>(row.Cells["ContactTitle"].Value);
                        supplier.City = GourmetShopValidators.NullableValidationHandler<string?>(row.Cells["City"].Value);
                        supplier.Country = GourmetShopValidators.NullableValidationHandler<string?>(row.Cells["Country"].Value);
                        supplier.Phone = GourmetShopValidators.NullableValidationHandler<string?>(row.Cells["Phone"].Value);
                        supplier.Fax = GourmetShopValidators.NullableValidationHandler<string?>(row.Cells["Fax"].Value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Batch update suppliers error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return true;
                }
            }

            return false;
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Supplier supplier in suppliersUpdate)
                    _supplierRepository.Update(supplier);

                RefreshSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update supplier  error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSuppliers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];

                supplierIdDelete = Int32.Parse(row.Cells["Id"].Value?.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Row enter changed error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                _supplierRepository.Delete(supplierIdDelete);
                supplierIdDelete = -1;

                RefreshSuppliers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Delete supplier error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
