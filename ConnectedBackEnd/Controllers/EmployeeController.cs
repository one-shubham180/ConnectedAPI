using ConnectedBackEnd.Data;
using ConnectedBackEnd.Models;
using ConnectedBackEnd.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectedBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;

        public EmployeeController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployee() {
            var allEmployees = dbContext.Employees.ToList();

            return Ok(allEmployees);
        }

        [HttpPost] 
        public IActionResult AddEmployee(AddEmployeeDto employee)
        {
            var emp = new Employee
            {
                Name = employee.Name,
                Email = employee.Email,
                Phone = employee.Phone,
                Salary = employee.Salary
            };

            dbContext.Employees.Add(emp);


            dbContext.SaveChanges();

            return Ok(emp);
        }


        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id) {
            var employee = dbContext.Employees.Find(id);

            if (employee is null) return NotFound();

            return Ok(employee);
        }
    }
}
