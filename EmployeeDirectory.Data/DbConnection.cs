﻿using EmployeeDirectory.Data.Contract;
using Microsoft.Data.SqlClient;

namespace EmployeeDirectory.Data
{
    public class DbConnection(string connectionString) : IDbConnection
    {
        private readonly string connectionString = connectionString;


        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection = new SqlConnection(connectionString);
                return connection;
            }
            catch (Exception)
            {
                throw new Exception("Error establishing connection");
            }
        }
    }


}