using Microsoft.EntityFrameworkCore;

namespace Cmf.CandidateTest.Data.Seeding;

public class SeedingDbContext : DbContext
{
    public SeedingDbContext(DbContextOptions<SeedingDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderLine> OrderLines => Set<OrderLine>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        modelBuilder.Entity<OrderLine>()
            .HasOne(ol => ol.Order)
            .WithMany(o => o.OrderLines)
            .HasForeignKey(ol => ol.OrderId);

        modelBuilder.Entity<OrderLine>()
            .HasOne(ol => ol.Product)
            .WithMany(p => p.OrderLines)
            .HasForeignKey(ol => ol.ProductId);

        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Alice Johnson", Email = "alice@example.com" },
            new User { Id = 2, Name = "Bob Smith", Email = "bob@example.com" },
            new User { Id = 3, Name = "Charlie Brown", Email = "charlie@example.com" },
            new User { Id = 4, Name = "Diana Prince", Email = "diana@example.com" }
        );

        // Seed Products
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Price = 999.99m },
            new Product { Id = 2, Name = "Mouse", Price = 29.99m },
            new Product { Id = 3, Name = "Keyboard", Price = 79.99m },
            new Product { Id = 4, Name = "Monitor", Price = 299.99m },
            new Product { Id = 5, Name = "Headphones", Price = 149.99m }
        );

        // Seed Orders (Users 1, 2, 3 have orders; User 4 has none)
        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, UserId = 1, OrderDate = new DateTime(2026, 1, 15) },
            new Order { Id = 2, UserId = 1, OrderDate = new DateTime(2026, 3, 20) },
            new Order { Id = 3, UserId = 2, OrderDate = new DateTime(2026, 2, 10) },
            new Order { Id = 4, UserId = 3, OrderDate = new DateTime(2026, 4, 5) }
        );

        // Seed OrderLines
        modelBuilder.Entity<OrderLine>().HasData(
            // Order 1 (Alice): Laptop + Mouse
            new OrderLine { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 999.99m },
            new OrderLine { Id = 2, OrderId = 1, ProductId = 2, Quantity = 2, UnitPrice = 29.99m },
            // Order 2 (Alice): Keyboard + Headphones
            new OrderLine { Id = 3, OrderId = 2, ProductId = 3, Quantity = 1, UnitPrice = 79.99m },
            new OrderLine { Id = 4, OrderId = 2, ProductId = 5, Quantity = 1, UnitPrice = 149.99m },
            // Order 3 (Bob): Monitor + Mouse + Keyboard
            new OrderLine { Id = 5, OrderId = 3, ProductId = 4, Quantity = 2, UnitPrice = 299.99m },
            new OrderLine { Id = 6, OrderId = 3, ProductId = 2, Quantity = 1, UnitPrice = 29.99m },
            new OrderLine { Id = 7, OrderId = 3, ProductId = 3, Quantity = 1, UnitPrice = 79.99m },
            // Order 4 (Charlie): Headphones
            new OrderLine { Id = 8, OrderId = 4, ProductId = 5, Quantity = 3, UnitPrice = 149.99m }
        );
    }
}
