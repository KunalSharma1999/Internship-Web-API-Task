﻿using PetaPoco;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.DataModels
{
    [TableName("Employees")]
    [PrimaryKey("Id")]
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PreferredName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string SkypeId { get; set; }

        public int DepartmentId { get; set; }

        public int OfficeId { get; set; }

        public int JobTitleId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }
    }
}
