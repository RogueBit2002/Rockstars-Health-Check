using Microsoft.AspNetCore.Mvc;
using HealthCheck.Models;
using System.Diagnostics;
using MySqlConnector;
using HealthCheck.DAL;

namespace HealthCheck.Controllers
{
    public class HomeController : AuthController
    {
        HealthCheckje healthCheck = new HealthCheckje(new HealthCheckDAL());

        [Route("/home")]
        public IActionResult Index()
        {
            return View();
        }

        public void test()
        {
            healthCheck.GetQuestion();
        }
    }
}