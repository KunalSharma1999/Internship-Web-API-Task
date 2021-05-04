using Employee_Directory.Models;
using System.Collections.Generic;

namespace Employee_Directory.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);
        void UpdateEmployee(int id, Employee employee);
        Employee GetEmployeeData(int id);
    }
}
