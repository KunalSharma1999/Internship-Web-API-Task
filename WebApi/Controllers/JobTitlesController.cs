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
    public class JobTitlesController : BaseController
    {
        private readonly IJobTitleService _jobTitleService;

        public JobTitlesController(IJobTitleService jobTitleService)
        {
            _jobTitleService = jobTitleService;
        }

        [HttpGet]
        public Task<IEnumerable<JobTitleViewModel>> Get()
        {
            return _jobTitleService.Get();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<JobTitleViewModel> Get(int id)
        {
            return await _jobTitleService.Get(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JobTitleViewModel> Post([FromBody] JobTitleViewModel jobtitle)
        {
            if (ModelState.IsValid)
            {
                var res = await _jobTitleService.Add(jobtitle);
                return res != null ? jobtitle : null;
            }
            else
                return null;
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<JobTitleViewModel> Put([FromBody] JobTitleViewModel jobtitle)
        {
            if (ModelState.IsValid)
            {
                int? res = await _jobTitleService.Update(jobtitle);
                return res != null ? jobtitle : null;
            }
            else
                return null;
        }
    }
}
