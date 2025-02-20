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

            // Добавление сервисов в контейнер зависимостей
            builder.Services.AddControllersWithViews();

            // Настройка контекста базы данных
            builder.Services.AddDbContext<CarAppContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("CarApp.Data") // Указываем сборку для миграций
                ));

            // Регистрация сервисов для приложения CarApp
            builder.Services.AddScoped<ICarService, CarService>();

            // Настройка Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false; // Отключение подтверждения аккаунта
                options.Password.RequiredLength = 6; // Минимальная длина пароля
                options.Password.RequireNonAlphanumeric = false; // Не требовать спецсимволы
                options.Password.RequireUppercase = false; // Не требовать заглавные буквы
                options.Password.RequireLowercase = false; // Не требовать строчные буквы
                options.Lockout.MaxFailedAccessAttempts = 5; // Максимум попыток входа
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Время блокировки
            })
            .AddEntityFrameworkStores<CarAppContext>()
            .AddDefaultTokenProviders();

            // Настройка сессий
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Настройка FluentValidation
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<Program>();

            var app = builder.Build();

            // Настройка HTTP конвейера запросов
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

            app.UseAuthentication(); // Включение аутентификации
            app.UseAuthorization();  // Включение авторизации

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Cars}/{action=Index}/{id?}");

            app.Run();
        }
    }
}