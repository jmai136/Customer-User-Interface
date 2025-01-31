using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GourmetShop.DataAccess.Repositories.Interfaces.CRUD_Subinterfaces;

namespace GourmetShop.DataAccess.Repositories.Classes
{
    public class ShoppingCartRepository : GourmetShopRepository, IShoppingCartRepository
    {
      
        public ShoppingCartRepository(string connectionString) : base(connectionString)
        {
        }


        public void AddToCart(int customerId, int productId, int quantity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("AddToCart", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCartItemQuantity(int cartId, int productId, int newQuantity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("UpdateCartItemQuantity", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CartID", cartId);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                cmd.Parameters.AddWithValue("@NewQuantity", newQuantity);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveFromCart(int cartId, int productId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("RemoveFromCart", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CartID", cartId);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ClearCart(int cartId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("ClearCart", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CartID", cartId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ViewCart(int cartId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("ViewCart", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CartID", cartId);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                return dt;
            }




        }



        public int PlaceOrder(int customerId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("PlaceOrder", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int orderId = Convert.ToInt32(reader["OrderId"]);
                            return orderId;
                        }
                    }
                }
            }
            return -1; // Return -1 if order creation failed
        }
    
}
}
