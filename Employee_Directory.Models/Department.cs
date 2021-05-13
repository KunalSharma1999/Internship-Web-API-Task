using PetaPoco;

namespace Employee_Directory.Models
{
    [TableName("Departments")]
    [PrimaryKey("Id")]
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }        
    }
}
