using CoffeeShopApi.Database;
using CoffeeShopApi.Dtos;
using CoffeeShopApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopApi.Controllers;

public class EmployeesController : BaseController
{
    private readonly CoffeeShopDbContext _dbContext;

    public EmployeesController(CoffeeShopDbContext context)
    {
        _dbContext = context;
    }

    [HttpPost("hire")]
    public async Task<IActionResult> HireEmployee([FromBody] HireEmployeeDto hireDto)
    {
        // 1. Create new employee
        var employee = new Employee
        {
            FullName = hireDto.FullName,
            Position = hireDto.Position
        };

        // 2. Save to database
        _dbContext.Employees.Add(employee);
        await _dbContext.SaveChangesAsync();

        // 3. Returns results
        return Created($"/api/employees/{employee.Id}", new
        {
            message = "Employee hired successfully",
            employee = new
            {
                id = employee.Id,
                fullName = employee.FullName,
                position = employee.Position.ToString()
            }
        });
    }
}