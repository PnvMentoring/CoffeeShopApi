using System.ComponentModel.DataAnnotations;
using CoffeeShopApi.Entities;

namespace CoffeeShopApi.Dtos;

public class HireEmployeeDto : BaseEntity
{
    [MaxLength(100)] public required string FullName { get; init; }

    public required EmployeePosition Position { get; init; }

    public HireEmployeeDto(string fullName, EmployeePosition position)
    {
        FullName = fullName;
        Position = position;
    }
}