using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopForPerts.Data.Models;


namespace ShopForPerts.Data
{
    public class AppDB : DbContext
    {

        public AppDB(DbContextOptions<AppDB> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<ShopCartItem> ShopCartItem { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

        public DbSet<DataForUser> DataForUsers { get; set; }

        public DbSet<Seller> Seller { get; set; }

        public DbSet<EndOfShift> EndOfShift { get; set; }

        public DbSet<OrderEnd> OrderEnd { get; set; }

        public DbSet<Manager> Manager { get; set; }

        public DbSet<ChartWork> ChartWork { get; set; }



    }
}
