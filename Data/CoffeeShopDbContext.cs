using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Data;

public class CoffeeShopDbContext : DbContext
{
    public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
        : base(options)
    {
    }
    
}