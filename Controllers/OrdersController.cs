using CoffeeShopApi.Database;
using CoffeeShopApi.Dtos.Request;
using CoffeeShopApi.Dtos.Response;
using CoffeeShopApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly CoffeeShopDbContext _db;

    public OrdersController(CoffeeShopDbContext db)
    {
        _db = db;
    }

    [HttpPost("submit")]
    public async Task<IActionResult> SubmitOrder([FromBody] SubmitOrderRequest request)
    {
        var customer = new Customer
        {
            Name = request.CustomerInfo.Name,
            Note = request.CustomerInfo.Note
        };

        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();

        var employee = await _db.Employees
            .FirstOrDefaultAsync(e => e.Id == request.EmployeeId);

        if (employee == null)
        {
            return BadRequest(new
            {
                message = $"Employee with ID '{request.EmployeeId}' not found"
            });
        }

        var productIds = request.Items.Select(i => i.ProductId).ToList();

        var products = await _db.Products
            .Where(p => productIds.Contains(p.Id))
            .ToDictionaryAsync(p => p.Id, p => p);

        foreach (var item in request.Items)
        {
            if (!products.TryGetValue(item.ProductId, out var product))
            {
                return BadRequest(new
                {
                    message = $"Product with ID '{item.ProductId}' not found"
                });
            }
        }

        var order = new Order
        {
            OrderDate = DateTime.UtcNow,
            PaymentMethod = request.PaymentMethod,
            Customer = customer,
            Employee = employee,
            OrderDetails = new List<OrderDetail>()
        };

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();

        foreach (var item in request.Items)
        {
            var product = products[item.ProductId];

            var orderDetail = new OrderDetail
            {
                OrderId = order.Id,
                ProductId = product.Id,
                Order = order,
                Product = product,
                Quantity = item.Quantity,
                UnitPrice = product.Price
            };

            _db.OrderDetails.Add(orderDetail);
        }

        await _db.SaveChangesAsync();

        return Created($"/api/orders/{order.Id}", new SubmitOrderResponse
        {
            OrderId = order.Id,
            CustomerName = customer.Name,
            EmployeeName = employee.FullName,
            Items = request.Items.Select(item =>
            {
                var product = products[item.ProductId];
                return new OrderItemResponse
                {
                    ProductName = product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,
                    Subtotal = item.Quantity * product.Price
                };
            }).ToList()
        });
    }
}