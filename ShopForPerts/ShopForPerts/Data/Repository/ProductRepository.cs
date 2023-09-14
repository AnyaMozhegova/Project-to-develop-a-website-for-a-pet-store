using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Repository
{
    public class ProductRepository : IAllProduts


       
    {
        private readonly AppDB dBContent;
        public ProductRepository(AppDB dBContent)
        {
            this.dBContent = dBContent;
        }

        public IEnumerable<Product> Products => dBContent.Products.Include(c => c.Category);

        public IEnumerable<Product> getFavProducts => dBContent.Products.Where(p => p.isFavourite==true).Include(c => c.Category);


        public Product getObjectProduct(int productId) => dBContent.Products.FirstOrDefault(p => p.id == productId);


    }
}
