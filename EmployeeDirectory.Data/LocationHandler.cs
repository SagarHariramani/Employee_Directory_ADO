using EmployeeDirectory.Data.Contract;
using EmployeeDirectory.Models;
using Microsoft.Data.SqlClient;

namespace EmployeeDirectory.Data
{
    public class LocationHandler : ILocationHandler
    {
        IDbConnection Connection;
        public LocationHandler(IDbConnection connection)
        {
            Connection = connection;
        }
        public List<Location> GetData()
        {
            List<Location> locations = new List<Location>();
            using (SqlConnection conn = Connection.GetConnection())
            {
                conn.Open();
                string query = "Select ID,Name from Location";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Location location = new Location()
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString()!
                        };
                        locations.Add(location);
                    }
                }
                conn.Close();
            }
            return locations;
        }
        public string? GetLocationNameById(int id)
        {
            string? locationName = null;
            using (SqlConnection conn = Connection.GetConnection())
            {
                string query = "Select Name from Location where ID=@Id";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        locationName = reader["Name"].ToString()!;
                    }
                }
                conn.Close();
                return locationName;
            }
        }
    }
}
