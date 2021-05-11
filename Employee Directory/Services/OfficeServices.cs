using Employee_Directory.Contracts;
using Employee_Directory.Models;
using System;
using System.Collections.Generic;

namespace Employee_Directory.Services
{
    public class OfficeServices: IOfficeServices
    {
        PetaPoco.Database db = new PetaPoco.Database("Data Source=localhost;Initial Catalog=EmployeeDB;Integrated Security=True", "System.Data.SqlClient");


        public IEnumerable<Office> GetAllOffices()
        {
            try
            {
                return db.Query<Office>("Select * from Offices");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddOffice(Office office)
        {
            try
            {
                db.Insert("Offices", office);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateOffice(int id, Office office)
        {
            try
            {
                office.Id = id;
                db.Update("Offices", "Id", office);
            }
            catch
            {
                throw;
            }
        }

        public Office GetOfficeById(int id)
        {
            try
            {
                return db.SingleOrDefault<Office>("SELECT * FROM Offices WHERE Id=@0", id);
            }
            catch
            {
                throw;
            }
        }
    }
}
