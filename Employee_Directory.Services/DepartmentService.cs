using AutoMapper;
using EmployeeDirectory.Contracts;
using EmployeeDirectory.DataModels;
using EmployeeDirectory.Models;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly PetaPoco.Database db;

        private AutoMapper.IMapper mapper;

        public DepartmentService(PetaPoco.Database database, AutoMapper.IMapper mapper)
        {
            this.db = database;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentViewModel>> Get()
        {
            var departments = await db.FetchAsync<Department>();
            var depts = mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            return depts;
        }

        public async Task<DepartmentViewModel> Get(int id)
        {
            var department = await db.SingleAsync<Department>(id);
            var dept = mapper.Map<DepartmentViewModel>(department);
            return dept;
        }

        public Task<object> Add(DepartmentViewModel department, string user)
        {
            var dept = mapper.Map<Department>(department);
            dept.CreatedOn = DateTime.Now;
            dept.CreatedBy = user;
            dept.ModifiedOn = DateTime.Now;
            dept.ModifiedBy = user;
            return db.InsertAsync(dept);
        }

        public Task<int> Update(DepartmentViewModel department, string user)
        {
            var dept = mapper.Map<Department>(department);
            var deptmnt = db.SingleAsync<Department>(dept.Id);
            dept.CreatedOn = deptmnt.Result.CreatedOn;
            dept.CreatedBy = deptmnt.Result.CreatedBy;
            dept.ModifiedOn = DateTime.Now;
            dept.ModifiedBy = user;
            return db.UpdateAsync(dept);
        }
    }
}
