using Microsoft.Data.SqlClient;

namespace EmployeeDirectory.Data.Contract
{
    public interface IDbConnection
    {
        SqlConnection GetConnection();
    }
}