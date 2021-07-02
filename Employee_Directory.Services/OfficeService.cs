using EmployeeDirectory.Contracts;
using EmployeeDirectory.DataModels;
using EmployeeDirectory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services
{
    public class OfficeService: IOfficeService
    {
        private readonly PetaPoco.Database db;

        private AutoMapper.IMapper mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public OfficeService(PetaPoco.Database database, AutoMapper.IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.db = database;
            this.mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<OfficeViewModel>> Get()
        {
            var offices = await db.FetchAsync<Office>();
            var offcs = mapper.Map<IEnumerable<OfficeViewModel>>(offices);
            return offcs;
        }

        public async Task<OfficeViewModel> Get(int id)
        {
            var office = await db.SingleAsync<Office>(id);
            var offc = mapper.Map<OfficeViewModel>(office);
            return offc;
        }

        public Task<object> Add(OfficeViewModel office)
        {
            var currentUserName = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type.Equals("userName"))?.Value;
            var offc = mapper.Map<Office>(office);
            offc.CreatedOn = DateTime.Now;
            offc.CreatedBy = currentUserName;
            offc.ModifiedOn = DateTime.Now;
            offc.ModifiedBy = currentUserName;
            return db.InsertAsync(offc);

        }

        public Task<int> Update(OfficeViewModel office)
        {
            var currentUserName = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type.Equals("userName"))?.Value;
            var offc = mapper.Map<Office>(office);
            var ofc = db.SingleAsync<Office>(offc.Id);
            offc.CreatedOn = ofc.Result.CreatedOn;
            offc.CreatedBy = ofc.Result.CreatedBy;
            offc.ModifiedOn = DateTime.Now;
            offc.ModifiedBy = currentUserName;
            return db.UpdateAsync(offc);
        }
    }
}
