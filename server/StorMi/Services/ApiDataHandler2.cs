using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StorMi.Interfaces;
using StorMi.Models.WeatherAPI;
using System.Linq;

namespace StorMi.Services
{
    public class ApiDataHandler2 : IApiDataHandler
    {
        private readonly IGeoAPIHandler _geoAPIHandler;
        private readonly IApiInvoker _apiInvoker;
        private readonly string _apiSource;
        private readonly string _apiKey;

        public ApiDataHandler2(IApiInvoker apiInvoker, IGeoAPIHandler geoAPIHandler)
        {
            _apiSource = "https://api.openweathermap.org/data/2.5/onecall";
            _apiKey = "a0f92c05a3498558cf9952d561be2cf1";
            _apiInvoker = apiInvoker;
            _geoAPIHandler = geoAPIHandler;
        }

        public async Task<WeatherModelDay> GetWeatherForecastForDayAsync(DateTime requestedDay, string city)
        {
            List<double> cords = (await _geoAPIHandler.GetCityCoordsByName(city)).ToList();

            string stroka = _apiSource + $"?lat={cords[1]}&lon={cords[0]}&units=metric&appid=" + _apiKey;

            var res =
                await _apiInvoker.Invoke(stroka);

            var model = new WeatherModelDay();

            var forecastDay = res["daily"];
            var day = forecastDay[0];
            var temp = day["temp"];

            model.AvgHumidity = day["humidity"];
            model.AvgTemp = temp["day"];
            model.TemperatureMin = Convert.ToInt32(temp["min"]);
            model.TemperatureMax = Convert.ToInt32(temp["max"]);
            model.WindSpeed = day["wind_speed"];

            return model;
        }

        public async Task<IEnumerable<WeatherModelDay>> GetWeatherForecastForWeekAsync(string city)
        {
            List<double> cords = (await _geoAPIHandler.GetCityCoordsByName(city)).ToList();

            var res =
                await _apiInvoker.Invoke(_apiSource + $"?lat={cords[1]}&lon={cords[0]}&units=metric&appid=" + _apiKey);

            List<WeatherModelDay> model = new List<WeatherModelDay>();

            var forecastDay = res["daily"];

            for (int i = 0; i < 7; i++)
            {
                var node = new WeatherModelDay();
                var day = forecastDay[i];
                var temp = day["temp"];

                node.AvgHumidity = day["humidity"];
                node.AvgTemp = temp["day"];
                node.TemperatureMin = Convert.ToInt32(temp["min"]);
                node.TemperatureMax = Convert.ToInt32(temp["max"]);
                node.WindSpeed = day["wind_speed"];

                model.Add(node);
            }

            return model;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public async Task<IEnumerable<WeatherModelHour>> GetWeatherForecastHourlyForDayAsync(DateTime requestedDay, string city)
        {
            List<double> cords = (await _geoAPIHandler.GetCityCoordsByName(city)).ToList();

            var res =
                await _apiInvoker.Invoke(_apiSource + $"?lat={cords[1]}&lon={cords[0]}&units=metric&appid=" + _apiKey);

            List<WeatherModelHour> model = new List<WeatherModelHour>();

            var hourlyDay = res["hourly"];

            for (int i = 0; i < 24; i++)
            {
                var node = new WeatherModelHour();

                var hour = hourlyDay[i];

                node.Time = Convert.ToDateTime(UnixTimeStampToDateTime(Convert.ToInt32(hour["dt"])));
                node.Humidity = hour["humidity"];
                node.Temp = hour["temp"];
                node.FeelsLikeTemp = hour["feels_like"];
                node.WindSpeed = hour["wind_speed"];
                node.WindDegree = hour["wind_deg"];
                node.AvgVisibilityInKm = hour["visibility"];
                node.WindGustInKm = hour["wind_gust"];

                model.Add(node);
            }

            return model;
        }
    }
}