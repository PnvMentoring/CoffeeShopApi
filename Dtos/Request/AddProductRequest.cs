using CoffeeShopApi.Entities;

namespace CoffeeShopApi.Dtos.Request;

public class AddProductRequest
{
    public required string Name { get; init; }

    public required decimal Price { get; init; }

    public required string CategoryId { get; init; }
}