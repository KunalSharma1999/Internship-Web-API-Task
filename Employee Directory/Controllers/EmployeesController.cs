using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Directory.Controllers
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

        [HttpGet]
        public IEnumerable<Employee> Get()
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
        public Employee Post([FromBody] Employee employee)
        {
            var res = employeeContext.Add(employee);
            return res!=null ? employee : null;
        }

        [HttpPut]
        public Employee Put([FromBody] Employee employee)
        {
            var res = employeeContext.Update(employee);
            return res != null ? employee : null;
        }
    }
}