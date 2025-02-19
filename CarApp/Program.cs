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

            // Добавление сервисов в контейнер зависимостей
            builder.Services.AddControllersWithViews();

            // Регистрация сервисов для приложения CarApp
            builder.Services.AddScoped<ICarService, CarService>();

            // Настройка контекста базы данных


            builder.Services.AddDbContext<CarAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Настройка Identity (если нужно для пользователей)
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 6;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddEntityFrameworkStores<CarAppContext>()
            .AddDefaultTokenProviders();

            // Настройка сессий
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Время жизни сессии
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Настройка HTTP конвейера запросов
            if (!app.Environment.IsDevelopment())
            {
                // Использование обработчика исключений для продакшн-окружения
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // Включение HSTS для повышения безопасности
            }
            else
            {
                // Для режима разработки отображение подробных ошибок
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); // Редирект HTTP на HTTPS
            app.UseStaticFiles(); // Использование статических файлов

            // Настройка для дополнительных статических файлов
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "uploads")),
                RequestPath = "/uploads"
            });

            app.UseSession(); // Подключение сессий

            app.UseRouting(); // Включение маршрутизации

            app.UseAuthentication(); // Включение аутентификации

            app.UseAuthorization(); // Включение авторизации

            // Настройка маршрутов
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Cars}/{action=Index}/{id?}");

            // Запуск приложения
            app.Run();
        }
    }
}
