using CoffeeShopApi.Entities;

namespace CoffeeShopApi.Dtos.Response;

public class AddProductResponse
{
    public required string Id { get; init; }

    public required string ProductName { get; init; }

    public decimal Price { get; init; }

    public required Category Category { get; init; }
}