using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentServices departmentContext;

        public DepartmentsController(IDepartmentServices dc)
        {
            departmentContext = dc;
        }

        [HttpGet]
        [Route("departments")]
        public IEnumerable<Department> Get()
        {
            return departmentContext.GetDepartments();
        }

        [HttpGet]
        [Route("getdepartment/{id}")]
        public Department GetDepartment(int id)
        {
            return departmentContext.GetDepartment(id);
        }

        [HttpPost]
        [Route("savedepartment")]
        public void Post([FromBody] Department department)
        {
            departmentContext.Add(department);
        }

        [HttpPut]
        [Route("saveedepartment")]
        public void Put([FromBody] Department department)
        {
            departmentContext.Add(department);
        }
    }
}
