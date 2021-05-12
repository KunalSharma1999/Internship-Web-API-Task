using Employee_Directory.Models;
using System.Collections.Generic;

namespace Employee_Directory.Contracts
{
    public interface IOfficeServices
    {
        IEnumerable<Office> GetOffices();

        void Add(Office office);

        Office GetOffice(int id);
    }
}
