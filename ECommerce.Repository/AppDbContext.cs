using ECommerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repository
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Product> Products { get; set; }
    }
}
