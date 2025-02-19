using CarApp.Data;
using CarApp.ApplicationServices.Services;
using CarApp.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Identity;
using CarApp.Core.Domain;
using Fluent.Infrastructure.FluentModel;

namespace CarApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ���������� �������� � ��������� ������������
            builder.Services.AddControllersWithViews();

            // ����������� �������� ��� ���������� CarApp
            builder.Services.AddScoped<ICarService, CarService>();

            // ��������� ��������� ���� ������


            builder.Services.AddDbContext<CarAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // ��������� Identity (���� ����� ��� �������������)
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 6;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddEntityFrameworkStores<CarAppContext>()
            .AddDefaultTokenProviders();

            // ��������� ������
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // ����� ����� ������
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // ��������� HTTP ��������� ��������
            if (!app.Environment.IsDevelopment())
            {
                // ������������� ����������� ���������� ��� ��������-���������
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // ��������� HSTS ��� ��������� ������������
            }
            else
            {
                // ��� ������ ���������� ����������� ��������� ������
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); // �������� HTTP �� HTTPS
            app.UseStaticFiles(); // ������������� ����������� ������

            // ��������� ��� �������������� ����������� ������
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "uploads")),
                RequestPath = "/uploads"
            });

            app.UseSession(); // ����������� ������

            app.UseRouting(); // ��������� �������������

            app.UseAuthentication(); // ��������� ��������������

            app.UseAuthorization(); // ��������� �����������

            // ��������� ���������
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Cars}/{action=Index}/{id?}");

            // ������ ����������
            app.Run();
        }
    }
}
