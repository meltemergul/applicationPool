using System;
namespace applicationPool.Models
{
    public class WeatherModel {
    public class Main
    {
        public float Temp { get; set; }
        public float Feels_Like { get; set; }
        public float Temp_Min { get; set; }
        public float Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

    public class Weather
    {
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Sys
    {
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }

    public class Root
    {
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Sys Sys { get; set; }
        public string Name { get; set; }
    }
}
}

