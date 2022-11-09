using Microsoft.AspNetCore.Mvc;

namespace HealthCheck.Controllers
{
    public class MainController : AuthController
    {
        [Route("/")]
        public IActionResult Index()
        {
            //if (!IsLoggedIn)
                //return RedirectToLoginPage(false);

            return Redirect(AppConstants.Paths.Home);
        }
    }
}
