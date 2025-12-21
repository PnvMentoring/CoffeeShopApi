using System.ComponentModel.DataAnnotations;

namespace CoffeeShopApi.Entities;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; init; }

    [MaxLength(50)] 
    public required string PaymentMethod { get; init; }
    public required Customer Customer { get; init; }
    public required Employee Employee { get; init; }
    public ICollection<OrderDetail> OrderDetails { get; init; } = new List<OrderDetail>();
}