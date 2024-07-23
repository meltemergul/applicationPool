using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using applicationPool.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace applicationPool.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(string cityName)
        {
            var weather = await _weatherService.GetWeatherAsync(cityName);
            return Json(weather);
        }
    }
}

