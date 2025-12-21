namespace CoffeeShopApi.Dtos.Response;

public class SubmitOrderResponse
{
    public required string OrderId { get; init; }
    public required string CustomerName { get; init; }
    public required string EmployeeName { get; init; }
    public required List<OrderItemResponse> Items { get; init; }
}

public class OrderItemResponse
{
    public required string ProductName { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
    public decimal Subtotal { get; init; }
}