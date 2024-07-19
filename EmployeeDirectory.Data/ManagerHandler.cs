using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeDirectory.Data
{
    public class ManagerHandler : IManagerHandler
    {
        IDbConnection Connection;

        public ManagerHandler(IDbConnection connection)
        {
            Connection = connection;
        }

        public List<Manager> GetManagers()
        {
            List<Manager> managers = new List<Manager>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "select Manager.Id,FirstName+' '+LastName as Name from Manager Inner Join Employee on Manager.EmployeeId=Employee.Id;";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Manager manager = new Manager()
                        {
                            ID = (int)reader["Id"],
                            Name = reader["Name"].ToString()!
                        };
                        managers.Add(manager);
                    }
                }
                conn.Close();
            }
            return managers;
        }

        public string? GetMangerNameById(int id)
        {
            string? managerName = null;
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "select FirstName+' '+LastName as Name from Manager Inner Join Employee on Manager.EmployeeId=Employee.Id where Manager.ID=@Id";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        managerName = reader["Name"].ToString()!;
                    }
                }
                conn.Close();
                return managerName;
            }
        }
    }
}
