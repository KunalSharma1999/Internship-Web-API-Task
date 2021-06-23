using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeContext;
       
        public EmployeesController(IEmployeeService ec)
        {
            employeeContext = ec;
        }

        [HttpGet]
        public IEnumerable<EmployeeCard> Get()
        {
            return employeeContext.Get();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await employeeContext.Get(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<Employee> Post([FromBody] Employee employee)
        {
            var res = await employeeContext.Add(employee);
            return res != null ? employee : null;
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<Employee> Put([FromBody] Employee employee)
        {
            int? res = await employeeContext.Update(employee);
            return res != null ? employee : null;
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> Delete(int id)
        {
            int? res = await employeeContext.Delete(id);
            return res != null;
        }

        [HttpGet("Privacy")]
        [Authorize(Roles = "Admin")]
        public IActionResult Privacy()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();

            return Ok(claims);
        }
    }
}