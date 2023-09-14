using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Repository
{
    public class EndOfShiftRepository:IEnd
    {
        private readonly AppDB _context;

        public EndOfShiftRepository(AppDB context)
        {
            _context = context;
        }

        public void Add(EndOfShift endOFShift)
        {
            _context.EndOfShift.Add(endOFShift);
            _context.SaveChanges();
        }
    }
}
