using System.ComponentModel.DataAnnotations;
using CoffeeShopApi.Entities;

namespace CoffeeShopApi.Dtos;

public class HireEmployee : BaseEntity
{
    
    [MaxLength(100)]
    public required string FullName { get; set; }
    
    [MaxLength(50)]
    public required string Position { get; set; }
    
    public HireEmployee(string fullName, string position)
    {
        FullName = fullName;
        Position = position;
    }

}