using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitlesController : ControllerBase
    {
        private readonly IJobTitleServices jobTitleContext;

        public JobTitlesController(IJobTitleServices jc)
        {
            jobTitleContext = jc;
        }

        [HttpGet]
        [Route("jobtitles")]
        public IEnumerable<JobTitle> Get()
        {
            return jobTitleContext.GetJobTitles();
        }

        [HttpGet]
        [Route("getjobtitle/{id}")]
        public JobTitle GetJobTitle(int id)
        {
            return jobTitleContext.GetJobTitle(id);
        }

        [HttpPost]
        [Route("savejobtitle")]
        public void Post([FromBody] JobTitle jobtitle)
        {
            jobTitleContext.Add(jobtitle);
        }

        [HttpPut]
        [Route("savejobtitle")]
        public void Put([FromBody] JobTitle jobtitle)
        {
            jobTitleContext.Add(jobtitle);
        }
    }
}
