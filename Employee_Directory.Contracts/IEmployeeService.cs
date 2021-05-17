using Employee_Directory.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Directory.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeCard> Get();

        Task<Employee> Get(int id);

        Task<object> Add(Employee employee);

        Task<int> Update(Employee employee);

        Task<int> Delete(int id);
    }
}
