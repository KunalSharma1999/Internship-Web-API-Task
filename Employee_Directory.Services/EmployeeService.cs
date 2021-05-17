﻿using Employee_Directory.Contracts;
using Employee_Directory.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Directory.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly PetaPoco.Database db;

        public EmployeeService(PetaPoco.Database database)
        {
            this.db = database;
        }

        public object Get()
        {
            return db.Query<object>(Constants.Employee.GetEmployees).ToList();
        }

        public async Task<Employee> Get(int id)
        {
            return await db.SingleAsync<Employee>(id);
        }

        public async Task<object> Add(Employee employee)
        {
            return await db.InsertAsync(employee);
            
        }

        public async Task<int> Update(Employee employee)
        {
              return await db.UpdateAsync(employee);
        }

        public async Task<int> Delete(int id)
        {
            return await db.DeleteAsync<Employee>(id);
        }
    }
}
