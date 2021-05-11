using Employee_Directory.Models;
using System.Collections.Generic;

namespace Employee_Directory.Contracts
{
    public interface IOfficeServices
    {
        IEnumerable<Office> GetAllOffices();
        void AddOffice(Office office);
        void UpdateOffice(int id, Office office);
        Office GetOfficeById(int id);
    }
}
