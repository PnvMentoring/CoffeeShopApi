using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Entities;

public class Employee : BaseEntity
{
    [MaxLength(100)]
    public required string FullName { get; set; }
    
    [MaxLength(50)]
    public required string Position { get; set; }
}