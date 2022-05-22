using Microsoft.AspNetCore.Mvc;
using pyli.Models;
using System.Diagnostics;
using Cs.AlphaLibrary;

namespace pyli.Controllers
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

            AgeViewModel age = new AgeViewModel
            { 
                Age = Base.GetAge(new DateTime(2000, 01, 01)),
                Day = 1,
                Mounth = 1,
                Year = 2000
            };
            return View(age);
        }

        public IActionResult GetAge(AgeViewModel ageViewModel)
        {
            if (ModelState.IsValid)
            {
                var isDate = DateTime.TryParse($"{ageViewModel.Year}-{ageViewModel.Mounth}-{ageViewModel.Day}", out DateTime dateOfBirth);
                if (isDate)
                {
                    ageViewModel.DateOfBirth = dateOfBirth;
                    var age = Base.GetAge(ageViewModel.DateOfBirth);
                    ageViewModel.Age = age;
                }
                else
                {
                    ageViewModel.ErrorMessage = ($"{ageViewModel.Day}-{ageViewModel.Mounth}-{ageViewModel.Year} is not a valid date. (dd-mm-yyyy)");
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View("index", ageViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}