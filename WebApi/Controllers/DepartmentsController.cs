using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService departmentContext;

        public DepartmentsController(IDepartmentService dc)
        {
            departmentContext = dc;
        }

        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return departmentContext.Get();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<Department> Get(int id)
        {
            return await departmentContext.Get(id);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<Department> Post([FromBody] Department department)
        {
            var res = await departmentContext.Add(department);
            return res != null ? department : null;
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<Department> Put([FromBody] Department department)
        {
            int? res = await departmentContext.Update(department);
            return res != null ? department : null;
        }
    }
}
