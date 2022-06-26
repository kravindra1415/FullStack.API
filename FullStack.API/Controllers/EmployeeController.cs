using FullStack.API.Data;
using FullStack.API.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Employee employee)
        {
            employee.Id = Guid.NewGuid();

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var employeeToFind = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employeeToFind == null)
            {
                return NotFound();
            }
            return Ok(employeeToFind);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id,Employee employee)
        {
            var employeeToUpdate=await _context.Employees.FindAsync(id);

            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            employeeToUpdate.Name=employee.Name;
            employeeToUpdate.Email = employee.Email;
            employeeToUpdate.Phone = employee.Phone;
            employeeToUpdate.Salary = employee.Salary;
            employeeToUpdate.Department = employee.Department;

            await _context.SaveChangesAsync();

            return Ok(employeeToUpdate);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var employeeToDelete = await _context.Employees.FindAsync(id);

            if(employeeToDelete == null){
                return NotFound();
            }

            _context.Employees.Remove(employeeToDelete);
            await _context.SaveChangesAsync();

            return Ok(employeeToDelete);
        }
    }
}
