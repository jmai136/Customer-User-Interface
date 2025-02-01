using GourmetShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GourmetShop.DataAccess.Repositories.Interfaces
{
    //CHECKME
    public interface IAdmin : IGourmetShopRepository<Admin>
    {
        (int TotalUnitsSold, decimal TotalSalesAmount) GetProductSales(int productId);
    }
}
