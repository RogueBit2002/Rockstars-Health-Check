using Microsoft.AspNetCore.Mvc;

namespace HealthCheck.Controllers
{
    public class HealthCheckController : AuthController
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
