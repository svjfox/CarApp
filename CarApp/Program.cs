using CarApp.Data;
using CarApp.ApplicationServices.Services;
using CarApp.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CarApp.Core.Domain;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CarApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ���������� �������� � ��������� ������������
            builder.Services.AddControllersWithViews();

            // ��������� ��������� ���� ������
            builder.Services.AddDbContext<CarAppContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("CarApp.Data") // ��������� ������ ��� ��������
                ));

            // ����������� �������� ��� ���������� CarApp
            builder.Services.AddScoped<ICarService, CarService>();

            // ��������� Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false; // ���������� ������������� ��������
                options.Password.RequiredLength = 6; // ����������� ����� ������
                options.Password.RequireNonAlphanumeric = false; // �� ��������� �����������
                options.Password.RequireUppercase = false; // �� ��������� ��������� �����
                options.Password.RequireLowercase = false; // �� ��������� �������� �����
                options.Lockout.MaxFailedAccessAttempts = 5; // �������� ������� �����
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // ����� ����������
            })
            .AddEntityFrameworkStores<CarAppContext>()
            .AddDefaultTokenProviders();

            // ��������� ������
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // ��������� FluentValidation
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            var app = builder.Build();

            // ��������� HTTP ��������� ��������
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication(); // ��������� ��������������
            app.UseAuthorization();  // ��������� �����������

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Cars}/{action=Index}/{id?}");

            app.Run();
        }
    }
}