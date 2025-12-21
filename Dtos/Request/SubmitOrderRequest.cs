using FluentValidation;

namespace CoffeeShopApi.Dtos.Request;

public class SubmitOrderRequest
{
    public required CustomerInfo CustomerInfo { get; init; }
    public required string EmployeeId { get; init; }
    public required string PaymentMethod { get; init; }
    public OrderItemRequest[] Items { get; init; } = Array.Empty<OrderItemRequest>();
}

public class CustomerInfo
{
    public required string Name { get; init; }
    public string? Note { get; init; }
}

public class OrderItemRequest
{
    public required string ProductId { get; init; }
    public int Quantity { get; init; }
}

public class SubmitOrderRequestValidation : AbstractValidator<SubmitOrderRequest>
{
    public SubmitOrderRequestValidation()
    {
        RuleFor(x => x.CustomerInfo)
            .NotNull();

        RuleFor(x => x.CustomerInfo.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.EmployeeId)
            .NotEmpty();

        RuleFor(x => x.PaymentMethod)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Items)
            .NotEmpty();

        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.ProductId)
                .NotEmpty();

            item.RuleFor(i => i.Quantity)
                .GreaterThan(0)
                .LessThanOrEqualTo(100);
        });
    }
}