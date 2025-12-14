using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Dtos.Response;

public class AddCategoryResponse
{
    public required string Id { get; init; }
    
    public required string Name { get; init; }
}