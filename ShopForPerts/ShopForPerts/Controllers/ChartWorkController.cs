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
    public class ChartWorkController:Controller
    {
        private readonly AppDB _context;
        private readonly IAllChart _userService;

        public ChartWorkController(IAllChart Service, AppDB dBContent)
        {
            this._userService = Service;
            this._context = dBContent;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }



        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.ChartWork.ToListAsync());
        //}

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new ChartWork());
            else
                return View(_context.ChartWork.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,LastNameSeller1,FirstNameSeller1,MiddleNameSeller1,LastNameSeller2,FirstNameSeller2,MiddleNameSeller2,Desc,day")] ChartWork transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);
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
            var transaction = await _context.ChartWork.FindAsync(id);
            _context.ChartWork.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Index()
        {
            var model = _context.ChartWork.ToList();
            return View(model);
        }

    }
}
