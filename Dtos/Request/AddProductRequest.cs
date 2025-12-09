namespace CoffeeShopApi.Dtos.Request;

public class AddProductRequest
{
    public required string ProductName { get; init; }

    public int Price { get; init; }

    public required string Category { get; init; }
}