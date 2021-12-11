using System.ComponentModel.DataAnnotations;

namespace StoMi.ViewModels
{
    public class WeatherModel
    {
        public string Name { get; set; }

        public int Temperature { get; set; }

        public int TemperatureMin { get; set; }

        public int TemperatureMax { get; set; }

        public float WindSpeed { get; set; }

        public float WindDeg { get; set; }

        public string WindGust { get; set; }

        public string Rain { get; set; }

        public string Snow { get; set; }

        public int CloundsAll { get; set; }

    }
}