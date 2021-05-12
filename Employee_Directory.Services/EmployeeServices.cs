using Employee_Directory.Contracts;
using Employee_Directory.Models;
using System;
using System.Collections.Generic;

namespace Employee_Directory.Services
{
    public class EmployeeServices: IEmployeeServices
    { 
        readonly PetaPoco.Database db = new PetaPoco.Database("Data Source = localhost; Initial Catalog = EmployeeDB; Integrated Security = True", "System.Data.SqlClient");

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return db.Query<Employee>(Constants.Employee.GetEmployees);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(Employee employee)
        {
            try
            {
                if(employee != null)
                {
                    if(employee.Id != default(int))
                    {
                        db.Update(Constants.Employee.TableName, Constants.Employee.PrimaryKeyName, employee);
                    }
                    else
                    {
                        db.Insert(Constants.Employee.TableName, employee);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                return db.SingleOrDefault<Employee>(Constants.Employee.GetEmployee, id);
            }
            catch
            {
                throw;
            }
        }
    }
}
