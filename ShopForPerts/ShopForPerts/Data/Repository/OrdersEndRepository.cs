using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Interfaces;

using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Repository
{
    public class OrdersEndRepository : IAllEndOrders
    {

        private readonly AppDB appDB;
        private readonly ShopCart shopCart;

        public OrdersEndRepository(AppDB appDB, ShopCart shopCart)
        {
            this.appDB = appDB;
            this.shopCart = shopCart;
        }
        public void createOrder(OrderEnd order)
        {
            

            appDB.OrderEnd.Add(order);
            appDB.SaveChanges();

            var items = shopCart.shopCartItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    productid = el.product.id,
                    orderID = order.id,
                    price = el.product.price
                };
                appDB.OrderDetail.Add(orderDetail);


            }
            appDB.SaveChanges();
        }
    }
}
