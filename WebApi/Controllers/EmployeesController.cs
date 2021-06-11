using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeContext;
       
        public EmployeesController(IEmployeeService ec)
        {
            employeeContext = ec;
        }

        [Authorize]
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
        public async Task<Employee> Post([FromBody] Employee employee)
        {
            var res = await employeeContext.Add(employee);
            return res != null ? employee : null;
        }

        [HttpPut]
        public async Task<Employee> Put([FromBody] Employee employee)
        {
            int? res = await employeeContext.Update(employee);
            return res != null ? employee : null;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> Delete(int id)
        {
            int? res = await employeeContext.Delete(id);
            return res != null;
        }
    }
}