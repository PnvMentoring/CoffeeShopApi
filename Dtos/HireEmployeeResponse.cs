using System.ComponentModel.DataAnnotations;
using CoffeeShopApi.Entities;

namespace CoffeeShopApi.Dtos;

public class HireEmployeeResponse
{
    [MaxLength(100)] 
    public required string FullName { get; init; }
    
    public required EmployeePosition Position { get; init; }
}