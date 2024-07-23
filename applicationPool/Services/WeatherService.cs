
using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using applicationPool.Models;

namespace applicationPool.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherModel.Root> GetWeatherAsync(string cityName)
        {
            var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid=96140583fbe1e693ef155b47c8714d74&lang=tr&units=metric");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<WeatherModel.Root>(content);
        }
    }
}

