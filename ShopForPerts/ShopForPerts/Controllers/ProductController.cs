using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopForPerts.Data;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;
using ShopForPerts.ViewModels;

namespace ShopForPerts.Controllers
{
    public class ProductController: Controller
    {
        private readonly IAllProduts _allProduts;
        private readonly IProductsCategory _allCategory;
        private readonly AppDB _context;
        public ProductController(IAllProduts iAllProducts, IProductsCategory iProductsCat, AppDB dBContent)
        {
            _allProduts = iAllProducts;
            _allCategory = iProductsCat;
            this._context = dBContent;

        }
        

        [Route("Product/List")]
        [Route("Product/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            var products = _context.Products.ToList();

            
            string _currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                products = _context.Products.OrderBy(i => i.id).ToList();
            }
            else if (string.Equals("Cat", category, StringComparison.OrdinalIgnoreCase))
            {
                products = _context.Products.Where(i => i.Category.CategoryName.Equals("Кошки")).OrderBy(i => i.id).ToList();
                ViewBag.Title = "Категория: Кошки";
            }
            else if (string.Equals("Dog", category, StringComparison.OrdinalIgnoreCase))
            {
                products = _context.Products.Where(i => i.Category.CategoryName.Equals("Собаки")).OrderBy(i => i.id).ToList();
                ViewBag.Title = "Категория: Собаки";
            }

            var productObj = new ProductListViewModel
            {
                getAllProducts = products,
                currCategory = ViewBag.Title
            };

            return View(productObj);
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }


        // GET: Transaction/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Product());
            else
                return View(_context.Products.Find(id));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("id,Name,ShortDes,LongDes,Manufacturer,image,price,isFavourite,Available,CategoryId")] Product transaction)
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


        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartItems = await _context.ShopCartItem.ToListAsync();
            _context.ShopCartItem.RemoveRange(cartItems);

            // Удаление записи из таблицы Products
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
