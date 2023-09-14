using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopForPerts.Data;
using ShopForPerts.Data.Interfaces;

using ShopForPerts.Data.Models;

namespace ShopForPerts.Controllers
{
    public class OrderController:Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        private readonly AppDB _context;

        public OrderController(IAllOrders allOrders, ShopCart shopCart, AppDB dBContent)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
            this._context = dBContent;
        }

        public IActionResult Checkout()
        { if (HttpContext.Session.GetString("UserId") != null)
            { 
                return View();
            }
        else
            {
                return View("Index", "Home");
            }
            
          
        }
        
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                shopCart.shopCartItems = shopCart.getShopItems();

                if (shopCart.shopCartItems.Count == 0)
                {
                    ModelState.AddModelError("", "У Вас должны быть товары");
                }
                if (ModelState.IsValid)
                {
                    allOrders.createOrder(order);
                    return RedirectToAction("Complete");
                }
                return View(order);
            }
            else
            {
                return View("Index", "Home");
            }
        }
        
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ поступил на обработку";
            return View();
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order.ToListAsync());
        }



        // GET: Transaction/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Order());
            else
                return View(_context.Order.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("id,name,surname,adress,phone,email,orderTime")] Order transaction)
        {
            if (ModelState.IsValid)
            {
                if (transaction.id == 0)
                {

                    _context.Add(transaction);
                }
                else
                    _context.Update(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }


        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = _context.Order.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            // Создаем новую запись в таблице OrderEnd
            var orderEnd = new OrderEnd
            {
               
                name = order.name,
                surname = order.surname,
                adress = order.adress,
                phone = order.phone,
                email = order.email,
                orderTime = order.orderTime
            };
            _context.OrderEnd.Add(orderEnd);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

            
        }
    }
}
