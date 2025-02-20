using TARgv23CarShop.Data;
using Microsoft.EntityFrameworkCore;
using TARgv23CarShop.Core.ServiceInterface;
using TARgv23CarShop.ApplicationService.Services;
using TARgv23CarShop.Core.Domain;
using CarApp.ApplicationService.Services;
using CarApp.Core.ServiceInterface;

namespace TARgv23CarShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Setting up interfaces
            builder.Services.AddScoped<ICarServices, CarServices>();
            builder.Services.AddScoped<IFileToDatabaseServices, FileToDatabaseService>();

            builder.Services.AddDbContext<TARgv23CarShopContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}