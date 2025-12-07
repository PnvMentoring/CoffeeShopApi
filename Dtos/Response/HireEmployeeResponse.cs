using System.ComponentModel.DataAnnotations;
using CoffeeShopApi.Entities;

namespace CoffeeShopApi.Dtos;

public class HireEmployeeResponse
{
    public required string Id { get; init; }
    
    public required string FullName { get; init; }
    
    public required EmployeePosition Position { get; init; }
}