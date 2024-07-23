using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using applicationPool.Models;
using Microsoft.AspNetCore.Authorization;

namespace applicationPool.Controllers;

public class HomeController : Controller
{
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var apps = new List<AppModel>
            {
                new AppModel { Id = 1, Name = "To Do App", Description = "Go to App" ,Image="work-order.png",Url = "/Home/TodoList" },
                new AppModel { Id = 2, Name = "BMI Calculator", Description = "Go to App",Image="calculator.png" ,Url = "/Home/BMICalculator"},
                new AppModel { Id = 3, Name = "Random Qutoes", Description = "Go to App" ,Image="quotes.png",Url="/Home/RandomQuote"},
                new AppModel { Id = 4, Name = "Weather App", Description = "Go to App" ,Image="season.png",Url = "/Weather/Index" }
            };

            return View(apps);
        }

        [HttpPost]
        public JsonResult CalculateBMI(float boy, float kilo)
        {
            var model = new BMIModel
            {
                Boy = boy,
                Kilo = kilo,
                VücutKitleEndeksi = kilo / ((boy / 100) * (boy / 100))
            };

            if (model.VücutKitleEndeksi < 18.5)
            {
                model.Sonuc = "Zayıf";
            }
            else if (model.VücutKitleEndeksi < 24.9)
            {
                model.Sonuc = "Normal kilolu";
            }
            else if (model.VücutKitleEndeksi < 29.9)
            {
                model.Sonuc = "Fazla kilolu";
            }
            else
            {
                model.Sonuc = "Obez";
            }

            return Json(model);
        }

        public IActionResult TodoList() => View();
        public IActionResult BMICalculator() => View();
        public IActionResult Weather() => View();
        public IActionResult RandomQuote() => View();

    [Authorize]
    public IActionResult Secure()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

