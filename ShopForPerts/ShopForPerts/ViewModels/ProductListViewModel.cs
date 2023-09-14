using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Models;


namespace ShopForPerts.ViewModels
{
    public class ProductListViewModel
    {

        public IEnumerable<Product> getAllProducts { get; set; }

        public string currCategory { get; set; }
    }
}
