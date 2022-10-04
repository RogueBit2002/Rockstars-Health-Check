using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HealthCheck.Data
{
    public class DB
    {
        static string ConnectionString = "Server=tcp:shc-rockstarsdb.database.windows.net,1433;Initial Catalog=RockstarsDB_HBG;Persist Security Info=False;User ID=shcAdmin;Password=Prirvrimmat8;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection MyConnection = new SqlConnection(ConnectionString);
        DateTime LastTime = DateTime.Today;
        DateTime CurrentTime = DateTime.Now;

        public string DBTime;

        public DB()
        {
            GetTime();
        }

        public string GetTime()
        {
            try
            {
                MyConnection.Open();
                Console.Write("connected");
                string Query1 = "Select TOP (1) * FROM times ORDER BY CAST(lastTime as DateTime) desc\r\n";

                using (SqlCommand comm = new SqlCommand(Query1, MyConnection))
                {
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        LastTime = reader.GetDateTime(0);
                    }
                }
                MyConnection.Close();
                MyConnection.Open();
                string Query2 = "INSERT INTO times (lastTime) VALUES ('" + CurrentTime + "')";
                using (SqlCommand comm = new SqlCommand(Query2, MyConnection))
                {
                    Console.WriteLine(comm.CommandText);
                    comm.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
                throw;
            }
            finally
            {
                MyConnection.Close();
                Console.WriteLine("closed");
            }
            return LastTime.ToString();
        }
    }
}
