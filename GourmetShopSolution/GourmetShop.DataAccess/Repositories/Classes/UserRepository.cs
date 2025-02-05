using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GourmetShop.DataAccess.Entities;

namespace GourmetShop.DataAccess.Repositories
{
    public class UserRepository: GourmetShopRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public bool UserExists(string firstName, string lastName, string phone)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("CheckUserExists", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Phone", phone);

                        int count = (int)cmd.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
            catch (SqlException ex) // Catches SQL-specific errors
            {
                throw; // Rethrow the exception to the calling code
            }
            catch (Exception ex) // Catches any other unexpected errors
            {
                throw; // Rethrow the exception to the calling code
            }
        }

        public void GetAllCustomers()
        {
        }
        
    }
}
