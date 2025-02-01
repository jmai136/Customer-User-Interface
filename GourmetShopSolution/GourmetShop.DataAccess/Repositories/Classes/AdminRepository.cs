using GourmetShop.DataAccess.Entities;
using GourmetShop.DataAccess.Repositories.Interfaces;
using GourmetShop.DataAccess.Repositories.Interfaces.CRUD_Subinterfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GourmetShop.DataAccess.Repositories.Classes
{

    //CHECKME
    public class AdminRepository : GourmetShopRepository, IAdmin
    {

        public AdminRepository(string connectionString) : base(connectionString)
        {
        }

        public (int TotalUnitsSold, decimal TotalSalesAmount) GetProductSales(int productId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand("GetProductSales", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductID", productId);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int totalUnitsSold = reader.GetInt32(reader.GetOrdinal("TotalUnitsSold"));
                            decimal totalSalesAmount = reader.GetDecimal(reader.GetOrdinal("TotalSalesAmount"));
                            return (totalUnitsSold, totalSalesAmount);
                        }
                    }
                }
            }
            catch (SqlException ex) // Catches SQL-specific errors
            {
                Console.WriteLine($"Database error: {ex.Message}");
            }
            catch (Exception ex) // Catches any other unexpected errors
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return (0, 0); // Return default values in case of failure
        }

    }
}
