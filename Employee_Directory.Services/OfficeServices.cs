using Employee_Directory.Contracts;
using Employee_Directory.Models;
using System;
using System.Collections.Generic;

namespace Employee_Directory.Services
{
    public class OfficeServices: IOfficeServices
    {
        readonly PetaPoco.Database db = new PetaPoco.Database("Data Source=localhost;Initial Catalog=EmployeeDB;Integrated Security=True", "System.Data.SqlClient");

        public IEnumerable<Office> GetOffices()
        {
            try
            {
                return db.Query<Office>(Constants.Office.GetOffices);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(Office office)
        {
            try
            {
                if(office != null)
                {
                    if(office.Id != default(int))
                    {
                        db.Update(Constants.Office.TableName, Constants.Office.PrimaryKeyName, office);
                    }
                    else
                    {
                        db.Insert(Constants.Office.TableName, office);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public Office GetOffice(int id)
        {
            try
            {
                return db.SingleOrDefault<Office>(Constants.Office.GetOffice, id);
            }
            catch
            {
                throw;
            }
        }
    }
}
