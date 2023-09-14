using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Models;
using ShopForPerts.Data.Interfaces;


namespace ShopForPerts.Data.Mocks
{
    public class MockCategory : IProductsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                { new Category{CategoryName="Собаки"},
                new Category{CategoryName="Кошки"}
                };
            }
        }
    }
}
