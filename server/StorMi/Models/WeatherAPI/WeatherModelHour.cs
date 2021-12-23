using System.ComponentModel.DataAnnotations;
using System;

namespace StorMi.Models.WeatherAPI
{
    public class WeatherModelHour
    {
        public string City { get; set; }

        public string Country { get; set; }

        public DateTime Time { get; set; }

        public float Humidity { get; set; }

        public int Temp { get; set; }

        public int FeelsLikeTemp { get; set; }

        public float ChanceOfRain { get; set; }

        public float ChanceOfSnow { get; set; }

        public float WindSpeed { get; set; }

        public float WindDegree { get; set; }

        public string WindDirection { get; set; }

        public string AvgVisibilityInKm { get; set; }

        public string WindGustInKm { get; set; }

        public string Condition { get; set; }
    }
}