using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeDirectory.Data
{
    public class DepartmentHandler : IDepartmentHandler
    {
        IDbConnection _connection;
        public DepartmentHandler(IDbConnection connection)
        {
            _connection = connection;
        }
        public List<Department> GetData()
        {
            List<Department> departments = new List<Department>();
            using (SqlConnection conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "Select ID,Name from Department";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Department department = new Department()
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString()!
                        };
                        departments.Add(department);
                    }
                }
                conn.Close();
            }
            return departments;
        }
        public Department? GetDepartmentById(int id)
        {
            Department? department = null;
            using (SqlConnection conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "Select ID,Name from Department where ID=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Department dep = new Department()
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString()!
                        };
                        department = dep;
                    }
                }
                conn.Close();
                return department;
            }
        }
        public string? GetDepartmentNameById(int id)
        {
            string? departmentName = null;
            using (SqlConnection conn = _connection.GetConnection())
            {
                string query = "Select Name from Department where ID=@Id";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        departmentName = reader["Name"].ToString()!;
                    }
                }
                conn.Close();
                return departmentName;
            }
        }
    }
}
