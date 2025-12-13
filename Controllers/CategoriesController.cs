// CategoriesController.cs

using CoffeeShopApi.Database;
using CoffeeShopApi.Dtos.Request;
using CoffeeShopApi.Dtos.Response;
using CoffeeShopApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopApi.Controllers;

public class CategoriesController(CoffeeShopDbContext dbContext) : BaseController
{
    [HttpPost]
    public async Task<ActionResult<AddCategoryResponse>> AddCategory(
        [FromBody] AddCategoryRequest request)
    {
        var existingCategory = await dbContext.Categories
            .FirstOrDefaultAsync(c => c.Name == request.Name);

        if (existingCategory != null)
        {
            return BadRequest(new { message = "Category name already exists" });
        }

        var category = new Category
        {
            Name = request.Name
        };

        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync();

        return Created("",
            new
            {
                message = "Add Category successfully",
                category = new AddCategoryResponse
                {
                    Id = category.Id,
                    Name = category.Name
                }
            });
    }
}