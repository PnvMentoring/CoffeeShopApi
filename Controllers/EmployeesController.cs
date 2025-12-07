using CoffeeShopApi.Database;
using CoffeeShopApi.Dtos;
using CoffeeShopApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopApi.Controllers;

public class EmployeesController : BaseController
{
    private readonly CoffeeShopDbContext _context;
    public EmployeesController(CoffeeShopDbContext context)
    {
        _context = context;
    }
    [HttpPost("hire")]
    public async Task<IActionResult> HireEmployee([FromBody] HireEmployee hireDto)
    {
        // 1. Tạo nhân viên mới
        var employee = new Employee
        {
            FullName = hireDto.FullName,
            Position = hireDto.Position
        };

        // 2. Lưu vào database
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        // 3. Trả về kết quả
        return Ok(new
        {
            message = "Employee hired successfully",
            employee = new
            {
                id = employee.Id,
                fullName = employee.FullName,
                position = employee.Position
            }
        });
    }
}