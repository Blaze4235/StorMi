using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StorMi.Interfaces;
using StorMi.Models.WeatherAPI;

namespace StorMi.Services
{
    public class ApiDataHandler1 : IApiDataHandler
    {
        private readonly IApiInvoker _apiInvoker;
        private readonly string _apiSource;

        public ApiDataHandler1(IApiInvoker apiInvoker)
        {
            _apiSource = "https://api.weatherapi.com/v1/forecast.json?key=2f3b18240aca47f9a5e131759211112";
            _apiInvoker = apiInvoker;
        }
        
        public async Task<WeatherModelDay> GetWeatherForecastForDayAsync(DateTime requestedDay, string city)
        {
            var res =
                await _apiInvoker.Invoke(_apiSource + $"&q={city}&days=1&aqi=no&alerts=no");

            var model = new WeatherModelDay();
            
            var location = res["location"];
            var forecast = res["forecast"];
            var forecastDay = forecast["forecastday"];
            var day = forecastDay[0];
            var weatherParams = day["day"];

            model.City = location["name"];
            model.Country = location["country"];
            model.AvgHumidity = weatherParams["avghumidity"];
            model.AvgTemp = weatherParams["avgtemp_c"];
            model.ChanceOfRain = weatherParams["daily_chance_of_rain"];
            model.ChanceOfSnow = weatherParams["daily_chance_of_snow"];
            model.TemperatureMin = Convert.ToInt32(weatherParams["mintemp_c"]);
            model.TemperatureMax = Convert.ToInt32(weatherParams["maxtemp_c"]);
            model.WindSpeed = weatherParams["maxwind_kph"];
            model.OverallCondition = weatherParams["condition"]?["text"];

            return model;
        }

        public async Task<IEnumerable<WeatherModelDay>> GetWeatherForecastForWeekAsync(string city)
        {
            var res = 
                await _apiInvoker.Invoke(_apiSource + $"&q={city}&days=7&aqi=no&alerts=no");

            List<WeatherModelDay> model = new List<WeatherModelDay>();

            var location = res["location"];
            var forecast = res["forecast"];
            var forecastDay = forecast["forecastday"];

            for (int i = 0; i < forecastDay.Count; i++)
            {
                var node = new WeatherModelDay();
                var day = forecastDay[i];
                var weatherParams = day["day"];

                node.City = location["name"];
                node.Country = location["country"];
                node.AvgHumidity = weatherParams["avghumidity"];
                node.AvgTemp = weatherParams["avgtemp_c"];
                node.ChanceOfRain = weatherParams["daily_chance_of_rain"];
                node.ChanceOfSnow = weatherParams["daily_chance_of_snow"];
                node.TemperatureMin = Convert.ToInt32(weatherParams["mintemp_c"]);
                node.TemperatureMax = Convert.ToInt32(weatherParams["maxtemp_c"]);
                node.WindSpeed = weatherParams["maxwind_kph"];
                node.OverallCondition = weatherParams["condition"]?["text"];

                model.Add(node);
            }

            return model;
        }

        public async Task<IEnumerable<WeatherModelHour>> GetWeatherForecastHourlyForDayAsync(DateTime requestedDay, string city)
        {
            var res = await _apiInvoker.Invoke(_apiSource + $"&q={city}&days=10&aqi=no&alerts=no");
            List<WeatherModelHour> model = new List<WeatherModelHour>();

            var location = res["location"];
            var forecast = res["forecast"];
            var forecastDay = forecast["forecastday"];
            for (int i = 0; i < forecastDay.Count; i++)
            {
                var currentDay = forecastDay[i];
                var date = currentDay["date"];

                string searchDay = requestedDay.ToString("yyyy-MM-dd");

                if (searchDay == date.Value)
                {

                    for (int j = 0; j < currentDay["hour"].Count; j++)
                    {
                        var node = new WeatherModelHour();
                        var hour = currentDay["hour"][j];
                        node.City = location["name"];
                        node.Country = location["country"];
                        node.Time = Convert.ToDateTime(hour["time"]);
                        node.Humidity = hour["humidity"];
                        node.Temp = hour["temp_c"];
                        node.FeelsLikeTemp = hour["feelslike_c"];
                        node.ChanceOfRain = hour["chance_of_rain"];
                        node.ChanceOfSnow = hour["chance_of_snow"];
                        node.WindSpeed = hour["wind_kph"];
                        node.WindDegree = hour["wind_degree"];
                        node.WindDirection = hour["wind_dir"];
                        node.AvgVisibilityInKm = hour["vis_km"];
                        node.WindGustInKm = hour["vis_km"];
                        node.Condition = hour["condition"]?["text"];

                        model.Add(node);
                    }
                }
            }

            return model;
        }
    }
}