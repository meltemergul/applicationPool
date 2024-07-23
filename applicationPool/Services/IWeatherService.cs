using System;
using applicationPool.Models;

namespace applicationPool.Services
{
    public interface IWeatherService
    {
        Task<WeatherModel.Root> GetWeatherAsync(string cityName);

    }
}

