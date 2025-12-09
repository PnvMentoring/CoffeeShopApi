namespace CoffeeShopApi.Dtos.Response;

public class AddProductResponse
{
    public required string Id { get; init; }

    public required string ProductName { get; init; }

    public int Price { get; init; }

    public required string Category { get; init; }
}