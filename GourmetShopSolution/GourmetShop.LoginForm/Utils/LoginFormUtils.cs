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
    }

    public static class EmailValidator
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            int atIndex = email.IndexOf("@");
            int dotIndex = email.LastIndexOf('.');

            if (atIndex < 1)
            {
                return false;
            }

            if (dotIndex < atIndex + 2)
            {
                return false;
            }

            if (dotIndex == email.Length - 1)
            {
                return false;
            }

            string userName = email.Substring(0, atIndex);
            string domain = email.Substring(atIndex + 1);

            if (userName.Length < 1)
            {
                return false;
            }

            if (userName.Length > 100)
            {
                return false;
            }

            if (domain.Length < 3)
            {
                return false;
            }
            //I'm really not clear on international email addresses
            //the gourmet shop goes to other countries, and this assignment
            //if I remember correctly was for U.S. addresses 
            if (domain.Length > 253)
            {
                return false;
            }

            if (!IsValidUserName(userName))
            {
                return false;
            }

            if (!IsValidDomain(domain))
            {
                return false;
            }
            return true;
        }
        //trying to make sure we don't end up with charachters that should not be there
        //but allow some characters that may be there
        public static bool IsValidUserName(string userName)
        {
            foreach (char c in userName)
            {
                if (!(char.IsLetterOrDigit(c) || c == '.' || c == '_' || c == '-'))
                {
                    return false;
                }

            }
            return true;
        }

        public static bool IsValidDomain(string domain)
        {
            foreach (char c in domain)
            {
                if (!(char.IsLetterOrDigit(c) || c == '.' || c == '-'))
                {
                    return false;
                }

                if (domain.StartsWith("-") || domain.EndsWith("-"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
