using Microsoft.EntityFrameworkCore;
using CarApp.Core.Entities;

namespace CarApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
    }
}

