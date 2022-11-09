using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace HealthCheck.Data
{
    public static class DatabaseConnectionProvider
    {
        private static MySqlConnection? connection;
        public static MySqlConnection Connection
        {
            get
            {
                EnsureConnection();

                return connection;
            }
        }

        private static void EnsureConnection()
        {
            bool closed = connection?.State == ConnectionState.Closed;
            bool broken = connection?.State == ConnectionState.Broken;

            if (closed || broken || connection == null)
            {
                connection?.Close();
                connection = new MySqlConnection(GetConnectionString());
                connection.Open();
            }
        }

        private static string GetConnectionString()
        {
            string host = "localhost";
            string username = "rhc-admin";
            string password = "r00t";
            string database = "rockstars_health_check";

            string cs = $"server={host};userid={username};password={password};database={database}";

            return cs;
        }
    }
}
