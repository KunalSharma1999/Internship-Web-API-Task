using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Directory.Contracts
{
    public interface IContract<T>
    {
        IEnumerable<T> Get();

        Task<T> Get(int id);

        Task<object> Add(T t);

        Task<int> Update(T t);
    }
}
