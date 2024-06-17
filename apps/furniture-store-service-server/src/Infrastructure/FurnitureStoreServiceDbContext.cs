using FurnitureStoreService.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStoreService.Infrastructure;

public class FurnitureStoreServiceDbContext : IdentityDbContext<IdentityUser>
{
    public FurnitureStoreServiceDbContext(DbContextOptions<FurnitureStoreServiceDbContext> options)
        : base(options) { }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Supplier> Suppliers { get; set; }

    public DbSet<Order> Orders { get; set; }
}
