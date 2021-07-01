using PetaPoco;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeDirectory.Contracts
{
    public interface IMaintanable<T>
    {
        Task<IEnumerable<T>> Get();

        Task<T> Get(int id);

        Task<object> Add(T t, string user);

        Task<int> Update(T t, string user);
    }
}
