using Microsoft.EntityFrameworkCore;

namespace PersistenceIgnoranceImpossible;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
    }

    public DbSet<OrderInt> OrderInts { get; set; }
    public DbSet<OrderItemInt> OrderItemInts { get; set; }
    
    public DbSet<OrderGuid> OrderGuids { get; set; }
    public DbSet<OrderItemGuid> OrderItemGuids { get; set; }
}