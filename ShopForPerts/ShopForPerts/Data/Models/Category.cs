using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopForPerts.Data.Models
{
    public class Category
    {
        public int id { set; get; }
        public string CategoryName { set; get; }
        public string Desc { set; get; }

        public List<Product> Products { set; get; }
    }
}
