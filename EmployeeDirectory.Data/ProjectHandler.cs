using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeDirectory.Data
{
    public class ProjectHandler : IProjectHandler
    {
        IDbConnection Connection;

        public ProjectHandler(IDbConnection connection)
        {
            Connection = connection;
        }

        public List<Project> GetData()
        {
            List<Project> Projects = new List<Project>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "Select Id,Name from Project";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Project project = new Project()
                        {
                            ID = (int)reader["Id"],
                            Name = reader["Name"].ToString()!
                        };
                        Projects.Add(project);
                    }
                }
                conn.Close();
            }
            return Projects;
        }
        public string? GetProjectNameById(int? id)
        {
            string? projectName = null;
            if (id == null)
            {
                return null;
            }
            else
            {
                using (SqlConnection conn = Connection.GetConnection())
                {
                    string query = "Select Name from Project Where ID=@Id";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            projectName = reader["Name"].ToString();

                        }
                    }
                    conn.Close();
                    return projectName;
                }
            }
           

        }
    }
}
