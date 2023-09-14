using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ShopForPerts.Data;
using ShopForPerts.Data.Interfaces;
using ShopForPerts.Data.Mocks;
using ShopForPerts.Data.Repository;

using ShopForPerts.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ShopForPerts
{
    public class Startup
    {
        private IConfigurationRoot configurationRoot;

        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            configurationRoot = new ConfigurationBuilder().SetBasePath(hosting.ContentRootPath).AddJsonFile("dbsetting.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
         
            services.AddDbContext<AppDB>(options => options.UseSqlServer(configurationRoot.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllProduts, ProductRepository>();
            services.AddTransient<IProductsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<IUserService, UserServiceRepository>();
            services.AddTransient<IAllSeller, SellerRepository>();
            services.AddTransient<IEnd, EndOfShiftRepository>();
            services.AddTransient<IAllEndOrders, OrdersEndRepository>();
            services.AddTransient<IAllManager, ManagerRepository>();
            services.AddTransient<IAllChart, ChartWorkRepository>();

            
            services.AddHttpContextAccessor();

            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/Home/Login";
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
         
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "CategoryFilter", template: "Product/{action}/{category?}", defaults: new { Controller = "Product", action = "List" });
            });
           
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDB content = scope.ServiceProvider.GetRequiredService<AppDB>();
                DBOdjects.Initial(content);
            }
           

        }
    }
}
