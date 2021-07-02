using AutoMapper;
using EmployeeDirectory.Contracts;
using EmployeeDirectory.DataModels;
using EmployeeDirectory.Models;
using Microsoft.AspNetCore.Http;
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

        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentService(PetaPoco.Database database, AutoMapper.IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.db = database;
            this.mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
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

        public Task<object> Add(DepartmentViewModel department)
        {
            var currentUserName = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type.Equals("userName"))?.Value;
            var dept = mapper.Map<Department>(department);
            dept.CreatedOn = DateTime.Now;
            dept.CreatedBy = currentUserName;
            dept.ModifiedOn = DateTime.Now;
            dept.ModifiedBy = currentUserName;
            return db.InsertAsync(dept);
        }

        public Task<int> Update(DepartmentViewModel department)
        {
            var currentUserName = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type.Equals("userName"))?.Value;
            var dept = mapper.Map<Department>(department);
            var deptmnt = db.SingleAsync<Department>(dept.Id);
            dept.CreatedOn = deptmnt.Result.CreatedOn;
            dept.CreatedBy = deptmnt.Result.CreatedBy;
            dept.ModifiedOn = DateTime.Now;
            dept.ModifiedBy = currentUserName;
            return db.UpdateAsync(dept);
        }
    }
}
