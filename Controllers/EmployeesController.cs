using CoffeeShopApi.Database;
using CoffeeShopApi.Dtos;
using CoffeeShopApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopApi.Controllers;

public class EmployeesController : BaseController
{
    private readonly CoffeeShopDbContext _dbDbContext;

    public EmployeesController(CoffeeShopDbContext dbContext)
    {
        _dbDbContext = dbContext;
    }

    [HttpPost("hire")]
    public async Task<ActionResult<HireEmployeeResponse>> HireEmployee([FromBody] HireEmployeeRequest hireRequest)
    {
        // 1. Create new employee
        var employee = new Employee
        {
            FullName = hireRequest.FullName,
            Position = hireRequest.Position
        };
   
        // 2. Save to database
        _dbDbContext.Employees.Add(employee);
        await _dbDbContext.SaveChangesAsync();

        var response = new HireEmployeeResponse
        {
            FullName = employee.FullName,
            Position = employee.Position,
        };

        // 3. Returns results
        return Created($"/api/employees/{employee.Id}", new
        {
            message = "Employee hired successfully",
            employee = response
        });
    }
}