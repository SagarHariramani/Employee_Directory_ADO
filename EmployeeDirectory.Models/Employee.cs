namespace EmployeeDirectory.Models
{

    public class Employee
    {
        public string EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public string PhoneNo { get; set; }
        public DateTime JoiningDate { get; set; }
        public int ManagerId { get; set; }
        public int? ProjectId { get; set; }
        public bool IsDeleted { get; set; }
        public int RoleId { get; set; }

    }
}
