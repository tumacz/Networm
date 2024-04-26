using Microsoft.AspNetCore.Mvc;
using Networm.Models;
using System.Diagnostics;

namespace Networm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var model = new AboutViewModel()
            {
                Title = "About",
                Description = "Description tekst",
                Tags = new[] { "one", "two", "three" }
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = new List<Person>()
            {
                new Person()
                {
                    FirstName = "Maciej",
                    LastName = "Ziêba"
                },
                new Person()
                {
                    FirstName = "Barbara",
                    LastName = "Patraszewska"
                }
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
