using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GourmetShop.DataAccess.Entities
{
    public class SessionData
    {

        public static int CurrentCustomerId { get; set; } = -1; //(starts with no customer)

        public static int CurrentAdminId { get; set; } = 1; //starts with no admin

        public static int CurrentCartId { get; set; } = -1; // Track the cart ID
    }
}
