using IntraVisionTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IntraVisionTest.Domain
{
    public class IntraVisionContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Coin> Coins { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<OrderList> OrderLists { get; set; }

        public IntraVisionContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderList>().HasKey(x => new { x.OrderId, x.ProductId });
        }
    }
}
