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
    public class JobTitlesController : ControllerBase
    {
        private readonly IJobTitleService jobTitleContext;

        public JobTitlesController(IJobTitleService jc)
        {
            jobTitleContext = jc;
        }

        [HttpGet]
        public IEnumerable<JobTitle> Get()
        {
            return jobTitleContext.Get();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<JobTitle> Get(int id)
        {
            return await jobTitleContext.Get(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JobTitle> Post([FromBody] JobTitle jobtitle)
        {
            var res = await jobTitleContext.Add(jobtitle);
            return res != null ? jobtitle : null;
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<JobTitle> Put([FromBody] JobTitle jobtitle)
        {
            int? res = await jobTitleContext.Update(jobtitle);
            return res != null ? jobtitle : null;
        }
    }
}
