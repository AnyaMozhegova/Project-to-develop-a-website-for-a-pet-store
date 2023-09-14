using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopForPerts.Data;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
        private readonly AppDB _context;

        public AccountController(IUserService userService, AppDB dBContent)
        {
            _userService = userService;
            this._context = dBContent;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(DataForUser user)
        {
            if (ModelState.IsValid)
            {
                if (_userService.IsEmailExists(user.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                }
                else
                {
                    _userService.AddUser(user);
                    return RedirectToAction( "Home");
                }
            }

            return View(user);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.DataForUsers.ToListAsync());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new DataForUser());
            else
                return View(_context.DataForUsers.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,LastName,FirstName,MiddleName,BirthDate,Phone,Email,Password")] DataForUser transaction)
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
            var transaction = await _context.DataForUsers.FindAsync(id);
            _context.DataForUsers.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
       
    }
}
