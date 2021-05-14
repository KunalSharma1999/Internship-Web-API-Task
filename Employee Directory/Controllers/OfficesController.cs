using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<Office> Getoffice(int id)
        {
            return await officeContext.Get(id);
        }

        [HttpPost]
        public async Task<Office> Post([FromBody] Office office)
        {
            var res = await officeContext.Add(office);
            return res != null ? office : null;
        }

        [HttpPut]
        public async Task<Office> Put([FromBody] Office office)
        {
            var res = await officeContext.Update(office);
            return res != 0 ? office : null;
        }
    }
}
