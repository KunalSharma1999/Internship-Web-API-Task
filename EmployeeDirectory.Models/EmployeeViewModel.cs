using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PreferredName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$")]
        public string PhoneNumber { get; set; }

        [Required]
        public string SkypeId { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int OfficeId { get; set; }

        public int JobTitleId { get; set; }

    }
}
