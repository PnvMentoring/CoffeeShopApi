using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopApi.Entities;

public class Product : BaseEntity
{
    [MaxLength(200)] 
    public required string Name { get; set; }
    
    public required decimal Price { get; set; }

    public required Category Category { get; set; }
}