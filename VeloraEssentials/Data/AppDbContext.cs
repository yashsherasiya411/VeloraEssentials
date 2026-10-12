using Microsoft.EntityFrameworkCore;
using VeloraEssentials.Models;

namespace VeloraEssentials.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
