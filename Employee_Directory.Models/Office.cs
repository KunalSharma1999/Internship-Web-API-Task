using PetaPoco;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.DataModels
{
    [TableName("Offices")]
    [PrimaryKey("Id")]
    public class Office
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }
    }
}
