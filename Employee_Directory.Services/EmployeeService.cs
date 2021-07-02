using EmployeeDirectory.Contracts;
using EmployeeDirectory.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PetaPoco;
using EmployeeDirectory.Models;
using AutoMapper;
using System;
using Microsoft.AspNetCore.Http;

namespace EmployeeDirectory.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly PetaPoco.Database db;

        private AutoMapper.IMapper mapper;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeService(PetaPoco.Database database, AutoMapper.IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.db = database;
            this.mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<EmployeeCard>> Get()
        {
            var data = await db.FetchAsync<EmployeeCard>(Constants.Employee.GetEmployees);
            return data;
        }

        public async Task<EmployeeViewModel> Get(int id)
        {
            var employee = await db.SingleAsync<Employee>(id);
            var emp = mapper.Map<EmployeeViewModel>(employee);
            return emp;
        }

        public Task<object> Add(EmployeeViewModel employee)
        {
            var currentUserName = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type.Equals("userName"))?.Value;
            var emp = mapper.Map<Employee>(employee);
            emp.CreatedOn = DateTime.Now;
            emp.CreatedBy = currentUserName;
            emp.ModifiedOn = DateTime.Now;
            emp.ModifiedBy = currentUserName;
            return db.InsertAsync(emp);
        }

        public Task<int> Update(EmployeeViewModel employee)
        {
            var currentUserName = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type.Equals("userName"))?.Value;
            var emp = mapper.Map<Employee>(employee);
            var empl = db.SingleAsync<Employee>(emp.Id);
            emp.CreatedOn = empl.Result.CreatedOn;
            emp.CreatedBy = empl.Result.CreatedBy;
            emp.ModifiedOn = DateTime.Now;
            emp.ModifiedBy = currentUserName;
            return db.UpdateAsync(emp);
        }

        public Task<int> Delete(int id)
        {
            return db.DeleteAsync<Employee>(id);
        }
    }
}
