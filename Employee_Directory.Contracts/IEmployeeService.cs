using Employee_Directory.Models;
using System.Threading.Tasks;

namespace Employee_Directory.Contracts
{
    public interface IEmployeeService: IContract<Employee>
    {
        Task<int> Delete(int id);
    }
}
