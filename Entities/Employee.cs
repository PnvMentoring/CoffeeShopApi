using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Entities;

public class Employee : BaseEntity
{
    [MaxLength(100)] 
    public required string FullName { get; set; }

    [MaxLength(50)] 
    public required EmployeePosition Position { get; init; }
}

public enum EmployeePosition
{
    Barista = 0,
    Manager = 1,
    Cashier = 2,
    Chef = 3
}