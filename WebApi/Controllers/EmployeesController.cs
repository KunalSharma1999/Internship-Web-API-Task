using EmployeeDirectory.Contracts;
using EmployeeDirectory.DataModels;
using EmployeeDirectory.Models;
using EmployeeDirectory.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeService _employeeService;
       
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public Task<IEnumerable<EmployeeCard>> Get()
        {
            return _employeeService.Get();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<EmployeeViewModel> Get(int id)
        {
            return await _employeeService.Get(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<EmployeeViewModel> Post([FromBody] EmployeeViewModel employee)
        {
            if(ModelState.IsValid)
            {
                var res = await _employeeService.Add(employee);
                return res != null ? employee : null;
            }
            else
                return null;
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<EmployeeViewModel> Put([FromBody] EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                int? res = await _employeeService.Update(employee);
                return res != null ? employee : null;
            }
            else
                return null;
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> Delete(int id)
        {
            int? res = await _employeeService.Delete(id);
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