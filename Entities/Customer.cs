using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Entities;

public class Customer : BaseEntity
{
    [MaxLength(100)] 
    public required string Name { get; set; }

    [MaxLength(500)] 
    public string? Note { get; set; }
}