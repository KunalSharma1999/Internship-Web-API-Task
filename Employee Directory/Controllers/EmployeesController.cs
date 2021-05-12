using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeServices employeeContext;
       
        public EmployeesController(IEmployeeServices ec)
        {
            employeeContext = ec;
        }

        [HttpGet]
        [Route("employees")]
        public IEnumerable<Employee> Get()
        {
            return employeeContext.GetEmployees();
        }

        [HttpGet]
        [Route("getemployee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            Employee employee = employeeContext.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        [Route("saveemployee")]
        public void Post([FromBody] Employee employee)
        {
            employeeContext.Add(employee);
        }

        [HttpPut]
        [Route("saveemployee")]
        public void Put([FromBody] Employee employee)
        {
            employeeContext.Add(employee);
        }
    }
}