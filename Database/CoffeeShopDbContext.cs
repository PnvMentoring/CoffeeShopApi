using CoffeeShopApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Database;

public class CoffeeShopDbContext : DbContext
{
    public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
        : base(options)
    {
    }

    public required DbSet<Employee> Employees { get; init; }
    public required DbSet<Product> Products { get; init; }
    public DbSet<Category> Categories { get; init; } 
    public DbSet<Customer> Customers { get; init; } 
    public DbSet<Order> Orders { get; init; } 
    public DbSet<OrderDetail> OrderDetails { get; init; }
}