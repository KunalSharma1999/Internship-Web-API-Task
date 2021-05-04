using Employee_Directory.Models;
using Employee_Directory.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository employeeContext;
        public EmployeesController(IEmployeeRepository ec)
        {
            employeeContext = ec;
        }

        [HttpGet]
        [Route("AllEmployeeDetails")]
        public IEnumerable<Employee> Get()
        {
            return employeeContext.GetAllEmployees();
        }

        [HttpGet]
        [Route("GetEmployeeDetailsById/{employeeId}")]
        public Employee GetEmployeeById(int employeeId)
        {
            return employeeContext.GetEmployeeData(employeeId);
        }

        [HttpPost]
        [Route("InsertEmployeeDetails")]
        public void PostEmployee([FromBody] Employee employee)
        {
            employeeContext.AddEmployee(employee);
        }

        [HttpPut]
        [Route("UpdateEmployeeDetails/{id}")]
        public void PutEmployee(int id, [FromBody] Employee employee)
        {
            employeeContext.UpdateEmployee(id, employee);
        }
    }
}