using AspNetCodeReact.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCodeReact.Data
{
    public sealed class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options)
        : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } = null!;

        public DbSet<Brand> Brands { get; set; } = null!;

        public DbSet<BodyType> BodyTypes { get; set; } = null!;
    }
}