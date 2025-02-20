using CarApp.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarApp.Data
{
    public class CarAppContext : DbContext
    {
        public CarAppContext(DbContextOptions<CarAppContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } // Примерная таблица

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("dotnet ef migrations add InitialCreate --context CarAppContext\r\ndotnet ef database update --context CarAppContext\r\n",
                    b => b.MigrationsAssembly("CarApp"));
            }
        }
    }
}
