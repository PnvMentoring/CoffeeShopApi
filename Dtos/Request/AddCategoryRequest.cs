using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Dtos.Request;

public class AddCategoryRequest
{
    [MaxLength(50)]
    public required string Name { get; init; }
}