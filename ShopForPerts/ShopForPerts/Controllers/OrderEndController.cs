using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopForPerts.Data;
using ShopForPerts.Data.Interfaces;

using ShopForPerts.Data.Models;

namespace ShopForPerts.Controllers
{
    public class OrderEndController:Controller
    {
        private readonly IAllEndOrders allOrders;
        private readonly ShopCart shopCart;
        private readonly AppDB _context;

        public OrderEndController(IAllEndOrders allOrders, ShopCart shopCart, AppDB dBContent)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
            this._context = dBContent;
        }

     


        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderEnd.ToListAsync());
        }


    }
}
