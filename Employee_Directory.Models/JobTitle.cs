using PetaPoco;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.DataModels
{
    [TableName("JobTitles")]
    [PrimaryKey("Id")]
    public class JobTitle
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }
    }
}
