using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<JobTitle> Get(int id)
        {
            return await jobTitleContext.Get(id);
        }

        [HttpPost]
        public async Task<JobTitle> Post([FromBody] JobTitle jobtitle)
        {
            var res = await jobTitleContext.Add(jobtitle);
            return res != null ? jobtitle : null;
        }

        [HttpPut]
        public async Task<JobTitle> Put([FromBody] JobTitle jobtitle)
        {
            var res = await jobTitleContext.Update(jobtitle);
            return res != 0 ? jobtitle : null;
        }
    }
}
