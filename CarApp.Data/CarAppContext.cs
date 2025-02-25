using Microsoft.EntityFrameworkCore;
using CarApp.Core.Domain;

namespace CarApp.Data
{
    public class CarAppContext : DbContext
    {
        public CarAppContext(DbContextOptions<CarAppContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<FileToDatabase> FileToDatabase { get; set; }


    }
}