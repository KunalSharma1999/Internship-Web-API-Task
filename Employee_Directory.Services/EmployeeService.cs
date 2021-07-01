using EmployeeDirectory.Contracts;
using EmployeeDirectory.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PetaPoco;
using EmployeeDirectory.Models;
using AutoMapper;
using System;

namespace EmployeeDirectory.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly PetaPoco.Database db;

        private AutoMapper.IMapper mapper;

        public EmployeeService(PetaPoco.Database database, AutoMapper.IMapper mapper)
        {
            this.db = database;
            this.mapper = mapper;
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

        public Task<object> Add(EmployeeViewModel employee, string user)
        {
            // Convert viewmodel to DataModel
            var emp = mapper.Map<Employee>(employee);
            emp.CreatedOn = DateTime.Now;
            emp.CreatedBy = user;
            emp.ModifiedOn = DateTime.Now;
            emp.ModifiedBy = user;
            return db.InsertAsync(emp);
        }

        public Task<int> Update(EmployeeViewModel employee, string user)
        {
            var emp = mapper.Map<Employee>(employee);
            var empl = db.SingleAsync<Employee>(emp.Id);
            emp.CreatedOn = empl.Result.CreatedOn;
            emp.CreatedBy = empl.Result.CreatedBy;
            emp.ModifiedOn = DateTime.Now;
            emp.ModifiedBy = user;
            return db.UpdateAsync(emp);
        }

        public Task<int> Delete(int id)
        {
            return db.DeleteAsync<Employee>(id);
        }
    }
}
