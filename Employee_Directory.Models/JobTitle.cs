using PetaPoco;

namespace Employee_Directory.Models
{
    [TableName("JobTitles")]
    [PrimaryKey("Id")]
    public class JobTitle
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }
    }
}
