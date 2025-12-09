using CoffeeShopApi.Database;
using CoffeeShopApi.Dtos.Request;
using CoffeeShopApi.Dtos.Response;
using CoffeeShopApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopApi.Controllers;

public class ProductsController(CoffeeShopDbContext dbContext) : BaseController
{
    [HttpPost("addproduct")]
    public async Task<ActionResult<AddProductResponse>> AddProduct(
        [FromBody] AddProductRequest request)
    {
        var product = new Product
        {
            ProductName = request.ProductName,
            Price = request.Price,
            Category = request.Category
        };

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();

        return Created($"/api/products/{product.Id}",
            new AddProductResponse
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Category = product.Category
            });
    }
}