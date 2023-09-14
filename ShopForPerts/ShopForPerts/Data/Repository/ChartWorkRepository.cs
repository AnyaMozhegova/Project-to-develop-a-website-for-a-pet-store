using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Models;

namespace ShopForPerts.Data.Repository
{
    public class ChartWorkRepository:IAllChart
    {
        private readonly AppDB _context;

        public void Add(ChartWork endOFShift)
        {
            _context.ChartWork.Add(endOFShift);
            _context.SaveChanges();
        }
    }
}
