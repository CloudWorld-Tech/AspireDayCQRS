using AspireDay.Domain.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace AspireDay.Domain.Persistence;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
    {
    }

    public DbSet<BuyOrder> BuyOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BuyOrder>().ToContainer("buy-orders")
            .HasPartitionKey(x => x.OrderId)
            .HasKey(x => x.OrderId);

        base.OnModelCreating(modelBuilder);
    }
}