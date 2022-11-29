using Microsoft.EntityFrameworkCore;

namespace Akhil_API.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasMany(a => a.products)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoyId);

            builder.Seed();
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

    }
}
