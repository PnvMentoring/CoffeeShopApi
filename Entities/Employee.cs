using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Entities;

public class Employee : BaseEntity
{
    [MaxLength(100)] public required string FullName { get; init; }

    [MaxLength(50)] public required EmployeePosition Position { get; init; }
}