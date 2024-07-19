using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeDirectory.Data
{
    public class RoleHandler : IRoleHandler
    {
        IDbConnection Connection;
        public RoleHandler(IDbConnection connection)
        {
            Connection = connection;
        }
        public void AddRole(Role role)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = $"Insert Into Role (Name,Description,LocationId,DepartmentId) values(@Name,@Description,@LocationId,@DepartmentId) ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", role.Name);
                    cmd.Parameters.AddWithValue("@Description", role.Description);
                    cmd.Parameters.AddWithValue("@LocationId", role.LocationId);
                    cmd.Parameters.AddWithValue("@DepartmentId", role.DepartmentId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "Select ID,Name,LocationId,DepartmentId,Description from Role";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Role role = new Role
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString()!,
                            Description = reader["Description"].ToString()!,
                            LocationId = (int)reader["LocationId"],
                            DepartmentId = (int)reader["DepartmentId"]
                        };
                        roles.Add(role);
                    }
                    conn.Close();
                }
            }
            return roles;
        }
        public void Update(string roleId, string fieldName, string fieldInputData)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = $"Update Role SET @fieldName=@fieldInputData Where Id= @roleId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fieldName", fieldName);
                    cmd.Parameters.AddWithValue("@fieldInputData", fieldInputData);
                    cmd.Parameters.AddWithValue("@roleId", roleId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public int GetRoleCount()
        {
            int count = 0;
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "Select count(*) as RoleCount from Role";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int roleCount = (int)reader["RoleCount"];
                        count = roleCount;
                    }
                    conn.Close();

                }
            }
            return count;
        }
        public Role? GetRoleById(int roleId)
        {
            Role? roleDetail = null;
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "Select Role.ID,Name,LocationId,DepartmentId,Description from Role Where Role.ID=@RoleId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@RoleId", roleId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Role role = new Role
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString()!,
                            Description = reader["Description"].ToString()!,
                            LocationId = (int)reader["LocationId"],
                            DepartmentId = (int)reader["DepartmentId"]
                        };
                        roleDetail = role;
                    }
                    conn.Close();
                }
                return roleDetail;
            }
        }
        public int GetRoleId(string roleName, int location, int department)
        {
            int roleId = 0;
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "Select ID from Role Where Name=@RoleName and LocationId=@LocationId and DepartmentId=@DepartmentId ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@RoleName", roleName);
                    cmd.Parameters.AddWithValue("@LocationId", location);
                    cmd.Parameters.AddWithValue("@DepartmentId", department);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        roleId = (int)reader["ID"];
                    }
                    conn.Close();
                }
                return roleId;
            }

        }
        public void Delete(int roleId)
        {
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = $"Update Role SET IsDeleted='1' Where Id=@roleId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@roleId", roleId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }

}
