using CarApp.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarApp.Data
{
    public class CarAppContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarAppContext(DbContextOptions<CarAppContext> options) : base(options) { }
    }
}
