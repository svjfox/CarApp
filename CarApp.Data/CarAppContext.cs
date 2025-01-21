using CarApp.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarApp.Data
{
    public class CarAppContext : DbContext
    {
        public CarAppContext(DbContextOptions<CarAppContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }

        public DbSet<FileToDatabase> fileToDatabases { get; set; }

    }
}
