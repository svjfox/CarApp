using Microsoft.EntityFrameworkCore;
using CarApp.Core.Domain;

namespace CarApp.Data
{
    public class CarAppContext : DbContext
    {
        // Конструктор контекста базы данных
        public CarAppContext(DbContextOptions<CarAppContext> options)
            : base(options)
        {
        }

        // Таблица автомобилей
        public DbSet<Car> Cars { get; set; }

        // Настройка подключения к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("dotnet ef migrations add InitialCreate --context CarAppContext\r\ndotnet ef database update --context CarAppContext\r\n");
            }
        }
    }
}


