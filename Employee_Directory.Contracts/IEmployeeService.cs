using EmployeeDirectory.DataModels;
using EmployeeDirectory.Models;
using PetaPoco;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeDirectory.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeCard>> Get();

        Task<EmployeeViewModel> Get(int id);

        Task<object> Add(EmployeeViewModel employee);

        Task<int> Update(EmployeeViewModel employee);

        Task<int> Delete(int id);
    }
}
