using HealthCheck.Data;
using HealthCheck.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace HealthCheck.Controllers
{
    public class LoginController : AuthController
    {
        private const string FailedAttemptKey = "failed-login-attempt";
        
        [Route("/login")]
        public IActionResult Index(string redirect)
        {
            LoginModel model = new LoginModel(
                HttpContext.Session.Keys.Contains(FailedAttemptKey),
                redirect);

            HttpContext.Session.Remove(FailedAttemptKey);

            return View(model);
        }

        [Route("/logout")]
        public new IActionResult Logout()
        {
            base.Logout();

            return Redirect(AppConstants.Paths.Login);
        }


        [Route("/login/try")]
        public IActionResult Try(IFormCollection collection)
        {
            string email = collection["email"];
            string password = collection["password"];
            string redirect = collection["redirect"];

            bool success = TryLogin(email, password, out uint id);
            //Test code used until database is implemented
            if(!success)
            {
                //Just setting so we can use Keys.Contains later
                HttpContext.Session.Set(FailedAttemptKey, new byte[] { });
                return RedirectToLoginPage(redirect);
            }

            ManagerID = id;

            HttpContext.Session.Remove(FailedAttemptKey);

            return Redirect(string.IsNullOrEmpty(redirect) ? AppConstants.Paths.Home : redirect);
        }


        private bool TryLogin(string email, string password, out uint id)
        {
            id = 0;
            string query = "SELECT * FROM `manager` WHERE `email`=@email LIMIT 1;";

            MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.Connection);
            command.Parameters.AddWithValue("email", email);

            MySqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                reader.Close();
                return false;
            }
                

            id = reader.GetUInt32("id");
            string pw = reader.GetString("password");

            reader.Close();
            return pw == password;
        }
    }
}
