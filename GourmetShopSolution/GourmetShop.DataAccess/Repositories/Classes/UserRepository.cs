﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
