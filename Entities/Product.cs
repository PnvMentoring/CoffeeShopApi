using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopApi.Entities;

public class Product : BaseEntity
{
    [MaxLength(200)] 
    public required string Name { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    public required Category Category { get; set; }
}