using EmployeeDirectory.Contracts;
using EmployeeDirectory.DataModels;
using EmployeeDirectory.Models;
using EmployeeDirectory.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class DepartmentsController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public Task<IEnumerable<DepartmentViewModel>> Get()
        {
            return _departmentService.Get();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<DepartmentViewModel> Get(int id)
        {
            return await _departmentService.Get(id);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<DepartmentViewModel> Post([FromBody] DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                var res = await _departmentService.Add(department);
                return res != null ? department : null;
            }
            else
                return null;
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<DepartmentViewModel> Put([FromBody] DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                int? res = await _departmentService.Update(department);
                return res != null ? department : null;
            }
            else
                return null;
        }
    }
}
