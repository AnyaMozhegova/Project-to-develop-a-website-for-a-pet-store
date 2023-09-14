using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ShopForPerts.Data.Models
{
    public class ShopCart
    {
        private readonly AppDB dBContent;
        public ShopCart(AppDB dBContent)
        {
            this.dBContent = dBContent;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> shopCartItems { get; set; }


        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDB>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);


            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Product product)
        {
           dBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                product = product,
                price = product.price,
               
            });
            dBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return dBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.product).ToList();
        }
    }
}
