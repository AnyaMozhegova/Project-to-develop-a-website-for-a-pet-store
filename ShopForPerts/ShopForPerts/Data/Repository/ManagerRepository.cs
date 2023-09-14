using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Repository
{
    public class ManagerRepository:IAllManager
    {
        private readonly AppDB _context;

        public ManagerRepository(AppDB context)
        {
            _context = context;
        }

        public void AddUser(Manager manager)
        {
            _context.Manager.Add(manager);
            _context.SaveChanges();
        }

        public bool IsEmailExists(string email)
        {
            return _context.Manager.Any(u => u.Email == email);
        }
    }
}
