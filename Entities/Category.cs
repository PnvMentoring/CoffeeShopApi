using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Entities;

public class Category : BaseEntity
{
    
    [MaxLength(50)]
    public required string Name { get; init; }
}