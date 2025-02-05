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

        public void GetAllCustomers()
        {
        }
        
    }
}
