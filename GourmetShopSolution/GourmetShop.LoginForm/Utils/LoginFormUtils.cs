using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GourmetShop.LoginForm.Utils
{
    public static class LoginFormUtils
    {
        public static string _connectionString = ConfigurationManager.ConnectionStrings["GourmetShopConnectionString"].ConnectionString;

        // TODO: Implement an email validator method
    }
}
