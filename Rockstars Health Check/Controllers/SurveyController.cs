using HealthCheck.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheck.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Survey()
        {
            List<string> questions = new List<string>();
            questions.Add("question 1");
            questions.Add("question 2");
            questions.Add("question 3");
            Survey survey = new Survey(questions, "test", true);
            return View(survey);
        }
    }
}
