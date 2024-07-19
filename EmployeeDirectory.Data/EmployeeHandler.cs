using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeDirectory.Data
{
    public class EmployeeHandler : IEmployeeHandler
    {
        IDbConnection _connection;
        public EmployeeHandler(IDbConnection connection)
        {
            _connection = connection;
        }
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection conn = _connection.GetConnection())
            {
                string query = $"Insert Into Employee(EmpId,FirstName,LastName,Email,Dob,PhoneNo,JoiningDate,ManagerId,ProjectId,RoleId,IsDeleted,CreatedOn,CreatedBy) " +
                    $"Values(@EmpId,@FirstName,@LastName,@Email,@Dob,@PhoneNo,@JoiningDate,@ManagerId,@ProjectId,@RoleId,@IsDeleted,@CreatedOn,@CreatedBy)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@Dob", employee.Dob);
                    cmd.Parameters.AddWithValue("@PhoneNo", employee.PhoneNo);
                    cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                    cmd.Parameters.AddWithValue("@ManagerId", employee.ManagerId);
                    cmd.Parameters.AddWithValue("@ProjectId", employee.ProjectId);
                    cmd.Parameters.AddWithValue("@RoleId", employee.RoleId);
                    cmd.Parameters.AddWithValue("@IsDeleted", employee.IsDeleted);
                    cmd.Parameters.AddWithValue("@CreatedOn", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@CreatedBy", "System");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "Select Employee.EmpId,Employee.FirstName,Employee.LastName,Employee.Email,Employee.Dob,Employee.PhoneNo,Employee.JoiningDate,Employee.RoleId,Employee.IsDeleted,Employee.ManagerId,Employee.ProjectId from Employee Where IsDeleted<>1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee emp = new Employee
                        {
                            EmpId = reader["EmpId"].ToString()!,
                            FirstName = reader["FirstName"].ToString()!,
                            LastName = reader["LastName"].ToString()!,
                            Email = reader["Email"].ToString()!,
                            Dob = (DateTime)reader["Dob"],
                            PhoneNo = reader["PhoneNo"].ToString()!,
                            JoiningDate = (DateTime)reader["JoiningDate"],
                            ManagerId = (int)reader["ManagerId"],
                            ProjectId = (int)reader["ProjectId"],
                            RoleId = (int)reader["RoleId"],
                            IsDeleted = (bool)reader["IsDeleted"]

                        };
                        employees.Add(emp);

                    }
                }
                conn.Close();

            }
            return employees;

        }
        public Employee? GetEmployeeById(string empId)
        {
            Employee? employee = null;
            using (SqlConnection conn = _connection.GetConnection())
            {
                conn.Open();
                string query = "Select Employee.EmpId,Employee.FirstName,Employee.LastName,Employee.Email,Employee.Dob,Employee.PhoneNo,Employee.JoiningDate,Employee.RoleId,Employee.IsDeleted,Employee.ManagerId,Employee.ProjectId from Employee Where Employee.EmpId=@EmpId and Employee.IsDeleted<>1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee emp = new Employee
                        {
                            EmpId = reader["EmpId"].ToString()!,
                            FirstName = reader["FirstName"].ToString()!,
                            LastName = reader["LastName"].ToString()!,
                            Email = reader["Email"].ToString()!,
                            Dob = (DateTime)reader["Dob"],
                            PhoneNo = reader["PhoneNo"].ToString()!,
                            JoiningDate = (DateTime)reader["JoiningDate"],
                            ManagerId = (int)reader["ManagerId"],
                            ProjectId = (int)reader["ProjectId"],
                            RoleId = (int)reader["RoleId"],
                            IsDeleted = (bool)reader["IsDeleted"]

                        };
                        employee = emp;
                    }
                    conn.Close();
                }
            }
            return employee;

        }
        public void Update<T>(string empId, Enum fieldName, T fieldInputData)
        {
            using (SqlConnection conn = _connection.GetConnection())
            {
                string query = $"Update Employee SET {fieldName}=@FieldInputData ,UpdatedOn=@UpdatedOn,UpdatedBy=@UpdatedBy  Where EmpId=@EmpId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UpdatedOn", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@UpdatedBy", "System");
                    cmd.Parameters.AddWithValue("@FieldInputData", fieldInputData);
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public void Delete(string empId)
        {
            using (SqlConnection conn = _connection.GetConnection())
            {
                string query = $"Update Employee SET IsDeleted='1' Where EmpId=@EmpId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}

