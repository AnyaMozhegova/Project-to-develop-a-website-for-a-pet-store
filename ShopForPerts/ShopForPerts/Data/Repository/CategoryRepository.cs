using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Models;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Repository
{
    public class CategoryRepository : IProductsCategory
    {

        private readonly AppDB dBContent;
        public CategoryRepository(AppDB dBContent)
        {
            this.dBContent = dBContent;
        }

        public IEnumerable<Category> AllCategories => dBContent.Categories;
    }
}
