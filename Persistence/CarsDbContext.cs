using cars.Models;
using Microsoft.EntityFrameworkCore;

namespace cars.Persistence
{
    public class CarsDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }

        public DbSet<Model> Models { get; set; }

        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {  
        }
    }
}