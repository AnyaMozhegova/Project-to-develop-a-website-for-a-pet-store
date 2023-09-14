using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.Decompiler.CSharp.Syntax;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShopForPerts.Data;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.ViewModels;


namespace ShopForPerts.Controllers
{
    
    public class HomeController:Controller
    {
  
        private readonly IAllProduts _productRep;
        private readonly AppDB _context;

        public HomeController(IAllProduts productRep, AppDB dBContent)
        {
            _productRep = productRep;
            this._context = dBContent;
            
        }

        public ViewResult Index()
        {
           
           
            


            var homeProduct = new HomeViewModel
            {
                favProduct = _productRep.getFavProducts
            };
            return View(homeProduct);
        }

        public ViewResult IndexSeller()
        {

            var homeProduct = new HomeViewModel
            {
                favProduct = _productRep.getFavProducts
            };
            return View(homeProduct);
        }

        public ViewResult IndexManager()
        {

            var homeProduct = new HomeViewModel
            {
                favProduct = _productRep.getFavProducts
            };
            return View(homeProduct);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _context.DataForUsers.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            var seller = await _context.Seller.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            var manager = await _context.Manager.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            if (user != null)
            {

                // сохраняем информацию о пользователе в сессии
               
                HttpContext.Session.SetString("UserId", user.Id.ToString());
               
                return RedirectToAction("Index", "Home");

            }
            if (seller != null)
            {
                // сохраняем информацию о пользователе в сессии
                HttpContext.Session.SetString("SellerId", seller.Id.ToString());
                ViewBag.Email = seller.Email;
                return RedirectToAction("IndexSeller", "Home");
            }
            if (manager != null)
            {
                HttpContext.Session.SetString("ManagerId", manager.Id.ToString());
                ViewBag.Email = manager.Email;
                return RedirectToAction("IndexManager", "Home");
            }

                ModelState.AddModelError("", "Invalid email or password");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookies");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult ExportToCsv()
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true";
            var query = "SELECT id, collection, cashless, cash, banknote5000, bankote1000, bankote500, bankote100, bankote50, bankoteSmall, refund, seller1, seller2, day FROM EndOfShift";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var csv = new StringBuilder();

                        // добавьте заголовки столбцов
                        csv.AppendLine("id,collection,cashless,cash,banknote5000,bankote1000,bankote500,bankote100,bankote50,bankoteSmall,refund,seller1,seller2,day");

                        // добавьте данные в формате CSV
                        while (reader.Read())
                        {
                            csv.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
                                reader["id"], reader["collection"], reader["cashless"], reader["cash"], reader["banknote5000"], reader["bankote1000"], reader["bankote500"], reader["bankote100"], reader["bankote50"], reader["bankoteSmall"], reader["refund"], reader["seller1"], reader["seller2"], reader["day"]));
                        }

                        // верните данные в формате CSV
                        return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "data.csv");
                    }
                }
            }
        }
        public ActionResult ExportToCsvSeller()
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Shop;Trusted_Connection=True;MultipleActiveResultSets=true";
            var query = "SELECT id, LastName, FirstName, MiddleName, BirthDate, Phone, Email, Password, isWork, yearWork FROM Seller";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var csv = new StringBuilder();

                        // добавьте заголовки столбцов
                        csv.AppendLine("id,collection,cashless,cash,banknote5000,bankote1000,bankote500,bankote100,bankote50,bankoteSmall,refund,seller1,seller2,day");

                        // добавьте данные в формате CSV
                        while (reader.Read())
                        {
                            csv.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                                reader["id"], reader["LastName"], reader["FirstName"], reader["MiddleName"], reader["BirthDate"], reader["Phone"], reader["Email"], reader["Password"], reader["isWork"], reader["yearWork"]));
                        }

                        // верните данные в формате CSV
                        return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "data.csv");
                    }
                }
            }
           
        }


    }
}
