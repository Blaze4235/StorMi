using System.ComponentModel.DataAnnotations;

namespace StorMi.Models.WeatherAPI
{
    public class WeatherModelDay
    {
        public string City { get; set; }

        public string Country { get; set; }

        public float AvgHumidity { get; set; }

        public int AvgTemp { get; set; }

        public float ChanceOfRain { get; set; }

        public float ChanceOfSnow { get; set; }

        public int TemperatureMin { get; set; }

        public int TemperatureMax { get; set; }

        public float WindSpeed { get; set; }

        public string OverallCondition { get; set; }
    }
}