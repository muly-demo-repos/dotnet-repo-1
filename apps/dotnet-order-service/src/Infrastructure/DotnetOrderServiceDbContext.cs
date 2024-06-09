using DotnetOrderService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetOrderService.Infrastructure;

public class DotnetOrderServiceDbContext : DbContext
{
    public DotnetOrderServiceDbContext(DbContextOptions<DotnetOrderServiceDbContext> options)
        : base(options) { }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }
}
