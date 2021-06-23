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
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeService officeContext;

        public OfficesController(IOfficeService oc)
        {
            officeContext = oc;
        }

        [HttpGet]
        public IEnumerable<Office> Get()
        {
            return officeContext.Get();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<Office> Getoffice(int id)
        {
            return await officeContext.Get(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<Office> Post([FromBody] Office office)
        {
            var res = await officeContext.Add(office);
            return res != null ? office : null;
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<Office> Put([FromBody] Office office)
        {
            int? res = await officeContext.Update(office);
            return res != null ? office : null;
        }
    }
}
