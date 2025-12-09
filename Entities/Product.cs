using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopApi.Entities;

public class Product : BaseEntity
{
    [MaxLength(200)] 
    public required string ProductName { get; set; }

    public int Price { get; set; }

    [MaxLength(50)] 
    public required string Category { get; set; }
}