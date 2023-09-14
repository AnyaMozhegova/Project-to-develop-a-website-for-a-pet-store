using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShopForPerts.Data;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Controllers
{
    public class ManagerController:Controller
    {
        private readonly IAllManager _allProduts;

        private readonly AppDB _context;

        public ManagerController(IAllManager iAllProducts, AppDB dBContent)
        {
            _allProduts = iAllProducts;

            this._context = dBContent;

        }
        // GET: Seller
        public async Task<IActionResult> Index()
        {
            return View(await _context.Manager.ToListAsync());
        }


        // GET: Seller/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Manager());
            else
                return View(_context.Manager.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AddOrEdit([Bind("Id,LastName,FirstName,MiddleName,BirthDate,Phone,Email,Password,isWork,yearWork")] Manager transaction)
        {
            if (ModelState.IsValid)
            {
                if (transaction.Id == 0)
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


        // POST: Seller/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Manager.FindAsync(id);
            _context.Manager.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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

    }
}
