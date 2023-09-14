using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Repository
{
    public class SellerRepository: IAllSeller
    {
        private readonly AppDB _context;

        public SellerRepository(AppDB context)
        {
            _context = context;
        }

        public void AddUser(Seller seller)
        {
            _context.Seller.Add(seller);
            _context.SaveChanges();
        }

        public bool IsEmailExists(string email)
        {
            return _context.Seller.Any(u => u.Email == email);
        }

       
    }
}
