using EmployeeDirectory.Contracts;
using EmployeeDirectory.DataModels;
using EmployeeDirectory.Models;
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

        public OfficeService(PetaPoco.Database database, AutoMapper.IMapper mapper)
        {
            this.db = database;
            this.mapper = mapper;
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

        public Task<object> Add(OfficeViewModel office, string user)
        {
            var offc = mapper.Map<Office>(office);
            offc.CreatedOn = DateTime.Now;
            offc.CreatedBy = user;
            offc.ModifiedOn = DateTime.Now;
            offc.ModifiedBy = user;
            return db.InsertAsync(offc);

        }

        public Task<int> Update(OfficeViewModel office, string user)
        {
            var offc = mapper.Map<Office>(office);
            var ofc = db.SingleAsync<Office>(offc.Id);
            offc.CreatedOn = ofc.Result.CreatedOn;
            offc.CreatedBy = ofc.Result.CreatedBy;
            offc.ModifiedOn = DateTime.Now;
            offc.ModifiedBy = user;
            return db.UpdateAsync(offc);
        }
    }
}
