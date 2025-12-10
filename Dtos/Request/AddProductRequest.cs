using CoffeeShopApi.Entities;

namespace CoffeeShopApi.Dtos.Request;

public class AddProductRequest
{
    public required string ProductName { get; init; }

    public decimal Price { get; init; }

    public required Category Category { get; init; }
}