using Microsoft.AspNetCore.Mvc;
using HealthCheck.Models;
using System.Diagnostics;
using HealthCheck.Data;
using MySqlConnector;

namespace HealthCheck.Controllers
{
    public class HomeController : AuthController
    {
        [Route("/home")]
        public IActionResult Index()
        {
            /*if (!IsLoggedIn)
                return RedirectToLoginPage();*/
            
            HomeModel model = new HomeModel();



            model.time = DateTime.Now;// GetLastVisit();

            //LogVisit();
            return View(model);
        }

        private DateTime GetLastVisit()
        {
            string query = "SELECT MAX(`time`) from `visit` WHERE `manager_id`=@id";

            MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.Connection);
            command.Parameters.AddWithValue("id", ManagerID);

            MySqlDataReader reader = command.ExecuteReader();

            if (!reader.Read())
            {
                reader.Close();
                return DateTime.Now;
            }
                

            int ordinal = reader.GetOrdinal("MAX(`time`)");

            if (reader.IsDBNull(ordinal))
            {
                reader.Close();
                return DateTime.Now;
            }
                

            DateTime r = reader.GetDateTime(ordinal);
            reader.Close();

            return r;
        }

        private void LogVisit()
        {
            string query = "INSERT INTO `visit` (`manager_id`) VALUES (@id)";

            MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.Connection);
            command.Parameters.AddWithValue("id", ManagerID);

            command.ExecuteNonQuery();

        }
    }
}