using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using applicationPool.Models;

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
            new AppModel { Id = 1, Name = "To Do App", Description = "Go to App" ,Image="work-order.png"},
            new AppModel { Id = 2, Name = "BMI Calculator", Description = "Go to App",Image="calculator.png" },
            new AppModel { Id = 3, Name = "Random Qutoes", Description = "Go to App" ,Image="quotes.png"},
            new AppModel { Id = 4, Name = "Weather App", Description = "Go to App" ,Image="season.png"}
           
        };

        return View(apps);
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

