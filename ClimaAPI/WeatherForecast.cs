using System;

namespace ClimaAPI
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        public int ProbLluvia { get; set; }
        public int Humedad { get; set; }
        public int Viento { get; set; }
    }
}
