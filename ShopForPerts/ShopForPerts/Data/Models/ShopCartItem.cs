using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForPerts.Data.Models
{
    public class ShopCartItem
    {

        public int id { get; set; }
        public Product product { get; set; }
        public int price { get; set; }

        public string ShopCartId { get; set; }

       

    }
}
