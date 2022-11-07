using Microsoft.AspNetCore.Mvc;
using MyFirstMVCApplication.Models;

namespace MyFirstMVCApplication.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TeachingAssistants()
        {
            List<TA> tas = new List<TA>()
            {
                new TA()
                {
                    Name = "Matt"
                },
                new TA()
                {
                    Name = "Connor"
                },
                new TA()
                {
                    Name = "Jenna"
                }
            };

            return View(tas);
        }
    }
}
