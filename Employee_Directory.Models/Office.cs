using PetaPoco;

namespace Employee_Directory.Models
{
    [TableName("Offices")]
    [PrimaryKey("Id")]
    public class Office
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
