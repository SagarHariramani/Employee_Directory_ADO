namespace EmployeeDirectory.Models
{

    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }


    }

}
