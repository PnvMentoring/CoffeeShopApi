using CoffeeShopApi.Database;
using CoffeeShopApi.Dtos.Request;
using CoffeeShopApi.Dtos.Response;
using CoffeeShopApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Controllers;

public class ProductsController(CoffeeShopDbContext dbContext) : BaseController
{
    [HttpPost("add")]
    public async Task<ActionResult<AddProductResponse>> AddProduct(
        [FromBody] AddProductRequest request)
    {
        var category = await dbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == request.CategoryId);

        if (category == null)
        {
            return BadRequest(new { message = "Category not found" });
        }

        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Category = category
        };

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync();

        return Created("",
            new
            {
                message = "Add Product successfully",
                employee = new AddProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Category = product.Category
                }
            });
    }
}