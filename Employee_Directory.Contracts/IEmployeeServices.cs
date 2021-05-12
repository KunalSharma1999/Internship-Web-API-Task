using Employee_Directory.Models;
using System.Collections.Generic;

namespace Employee_Directory.Contracts
{
    public interface IEmployeeServices
    {
        IEnumerable<Employee> GetEmployees();

        void Add(Employee employee);

        Employee GetEmployee(int id);
    }
}
