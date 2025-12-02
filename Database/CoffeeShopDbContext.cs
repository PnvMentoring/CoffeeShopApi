using CoffeeShopApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Database;

public class CoffeeShopDbContext : DbContext
{
    public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
        : base(options)
    {
    }
    
}