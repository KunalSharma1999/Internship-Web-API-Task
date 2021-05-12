using Employee_Directory.Contracts;
using Employee_Directory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeServices officeContext;

        public OfficesController(IOfficeServices oc)
        {
            officeContext = oc;
        }

        [HttpGet]
        [Route("offices")]
        public IEnumerable<Office> Get()
        {
            return officeContext.GetOffices();
        }

        [HttpGet]
        [Route("getoffice/{id}")]
        public Office Getoffice(int id)
        {
            return officeContext.GetOffice(id);
        }

        [HttpPost]
        [Route("saveoffice")]
        public void Post([FromBody] Office office)
        {
            officeContext.Add(office);
        }

        [HttpPut]
        [Route("saveoffice")]
        public void Put([FromBody] Office office)
        {
            officeContext.Add(office);
        }
    }
}
