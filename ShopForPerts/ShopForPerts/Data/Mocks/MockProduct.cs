using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Mocks
{
    public class MockProduct : IAllProduts
    {

        private readonly IProductsCategory _categoryproducts = new MockCategory();
        public IEnumerable<Product> Products {
            get
            {
                return new List<Product>
                { new Product{Name="Корм",
                    ShortDes="",
                    LongDes="", 
                    price=400, 
                    isFavourite=true,
                    Available=true,  
                    image="/img/0855vhpo3p47aq8pp0vc5yv3kotlthou.png",
                    Category=_categoryproducts.AllCategories.First()},
                
                };
            }
        }
        public IEnumerable<Product> getFavProducts { get ; set; }

        public Product getObjectProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
