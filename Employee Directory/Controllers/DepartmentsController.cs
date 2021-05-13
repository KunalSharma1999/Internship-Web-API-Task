﻿using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<Department> Get(int id)
        {
            return await departmentContext.Get(id);
        }

        [HttpPost]
        public Department Post([FromBody] Department department)
        {
            var res = departmentContext.Add(department);
            return res != null ? department : null;
        }

        [HttpPut]
        public Department Put([FromBody] Department department)
        {
            var res = departmentContext.Update(department);
            return res != null ? department : null;
        }
    }
}
