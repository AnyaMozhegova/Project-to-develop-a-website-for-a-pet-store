using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;
using ShopForPerts.Data.Repository;
using ShopForPerts.ViewModels;

namespace ShopForPerts.Controllers
{
    public class ShopCartController: Controller
    {

        private readonly IAllProduts _productRep;

        private readonly ShopCart _shopCart;

        public ShopCartController(IAllProduts productRep, ShopCart shopCart)
        {
            _productRep = productRep;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.shopCartItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart( int id)
        {
            var item = _productRep.Products.FirstOrDefault(i=>i.id==id);
            if(item!=null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
