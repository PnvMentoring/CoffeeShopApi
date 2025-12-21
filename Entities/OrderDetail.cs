using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Entities;

public class OrderDetail : BaseEntity
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; init; }

    [MaxLength(36)] 
    public required string OrderId { get; set; }
    [MaxLength(36)] 
    public required string ProductId { get; set; }

    public required Order Order { get; init; }
    public required Product Product { get; init; }
}