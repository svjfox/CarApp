using Microsoft.EntityFrameworkCore;
using CarApp.Data;
using CarApp.Core;
using CarApp.ApplicationServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;

namespace CarApp
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddScored<ICorsService, CarService>();



        }
    }
}