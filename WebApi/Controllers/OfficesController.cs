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
    public class OfficesController : BaseController
    {
        private readonly IOfficeService _officeService;

        public OfficesController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet]
        public Task<IEnumerable<OfficeViewModel>> Get()
        {
            return _officeService.Get();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<OfficeViewModel> Getoffice(int id)
        {
            return await _officeService.Get(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<OfficeViewModel> Post([FromBody] OfficeViewModel office)
        {
            if (ModelState.IsValid)
            {
                var user = User.FindFirst(x => x.Type.Equals("userName"))?.Value;
                var res = await _officeService.Add(office,user);
                return res != null ? office : null;
            }
            else
                return null;
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<OfficeViewModel> Put([FromBody] OfficeViewModel office)
        {
            if (ModelState.IsValid)
            {
                var user = User.FindFirst(x => x.Type.Equals("userName"))?.Value;
                int? res = await _officeService.Update(office, user);
                return res != null ? office : null;
            }
            else
                return null;
        }
    }
}
