using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Interfaces
{
   public interface IAllProduts
    {

        IEnumerable<Product> Products { get; }
        IEnumerable<Product> getFavProducts { get; }

        Product getObjectProduct(int productId);
    }
}
