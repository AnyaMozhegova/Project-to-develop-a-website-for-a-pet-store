using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShopForPerts.Data;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Controllers
{
    public class EndOfShiftController:Controller
    {
      
        private readonly AppDB _context;
        private readonly IEnd _userService;

        public EndOfShiftController(IEnd Service, AppDB dBContent)
        {
            this._userService = Service;
            this._context = dBContent;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        

        public async Task<IActionResult> Index()
        {
            return View(await _context.EndOfShift.ToListAsync());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new EndOfShift());
            else
                return View(_context.EndOfShift.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("id,collection,cashless,cash,banknote5000,bankote1000,bankote500,bankote100,bankote50,bankoteSmall,refund,seller1,seller2,day")] EndOfShift transaction)
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
            var transaction = await _context.EndOfShift.FindAsync(id);
            _context.EndOfShift.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public IActionResult RefundDays(uint refundAmount)
        {
            var data = _context.EndOfShift
                .Where(e => e.refund > refundAmount)
                .Select(e => e.day)
                .Distinct()
                .ToList();

            return View(data);
        }


    }
}

