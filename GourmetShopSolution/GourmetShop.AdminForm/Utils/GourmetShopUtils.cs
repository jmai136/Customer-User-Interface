using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GourmetShop.WinForms.Utils
{
    public static class GourmetShopUtils
    {
        // https://stackoverflow.com/questions/5573973/how-to-retrieve-the-databasename-and-the-servername-from-the-connectionstring-in 
        public static string connectionString = ConfigurationManager.ConnectionStrings["GourmetShopConnectionString"].ConnectionString;
    }

    public static class GourmetShopStringUtils
    {
        // Justification:
        // To act as a singleton and be used mainly for the frontend
        // We're going tp be va;idating as fast as possible so that by the backend, it's already good to go
        public static string ConvertToNull(string original)
        {
            if (String.IsNullOrEmpty(original))
                original = null;

            return original;
        }

        public static object ConvertToString(object var)
        {
            if (var == null)
                return "";

            return var;
        }

        // DataTable conversion for filtering and searching
        // https://stackoverflow.com/questions/564366/convert-generic-list-enumerable-to-datatable
        public static DataTable ConverListToDataTable<T>(List<T> data)
        {
            DataTable dt = new DataTable();

            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(ConvertToString(item));
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }

    public static class GourmetShopValidators
    {
        // TODO: Refactor this
        public static bool IsPhoneNumber(string phoneNum)
        {
            // https://regex101.com/r/wZ4uU6/2
            return Regex.IsMatch(phoneNum, "(?:([+]\\d{1,4})[-.\\s]?)?(?:[(](\\d{1,3})[)][-.\\s]?)?(\\d{1,4})[-.\\s]?(\\d{1,4})[-.\\s]?(\\d{1,9})");
        }

        // TODO:
        // Make a function handling try catches specifically for nullable values
        // Take two parameters, data type and value you're trying to pull from
        public static T NullableValidationHandler<T>(object dgvValue)
        {
            // Check if the input value is null
            if (dgvValue == null || string.IsNullOrEmpty(dgvValue.ToString()))
                return default; // Return null for reference types and nullable value types

            try
            {
                // Get the actual type to handle nullable types
                Type targetType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);

                // Determine the type and parse accordingly
                switch (Type.GetTypeCode(targetType))
                {
                    case TypeCode.Decimal:
                        return (T)(object)decimal.Parse(GourmetShopStringUtils.ConvertToNull(dgvValue.ToString()));
                    default:
                        return (T)(object)GourmetShopStringUtils.ConvertToNull(dgvValue.ToString());
                }
            }
            catch (ArgumentNullException ane)
            {
                //if (default(T) == null)
                    return default;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nullable validation handler error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return default;
        }
    }
}
