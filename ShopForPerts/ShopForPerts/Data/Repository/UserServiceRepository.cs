using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Repository
{
    public class UserServiceRepository : IUserService
    {

        private readonly AppDB _context;

        public UserServiceRepository(AppDB context)
        {
            _context = context;
        }

        public void AddUser(DataForUser user)
        {
            _context.DataForUsers.Add(user);
            _context.SaveChanges();
        }

        public bool IsEmailExists(string email)
        {
            return _context.DataForUsers.Any(u => u.Email == email);
        }
    }
}
