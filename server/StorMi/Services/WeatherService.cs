using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorMi.Interfaces;
using StorMi.Models;
using StorMi.Models.WeatherAPI;

namespace StorMi.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherEvaluation _weatherEvaluation;

        public WeatherService(IWeatherEvaluation weatherEvaluation)
        {
            _weatherEvaluation = weatherEvaluation;
        }

        public async Task<WeatherModelDay> DayWeatherForecast(DateTime requestedDay, string city)
        {
            var weatherModels = new List<WeatherModelDay>();

            foreach (WeatherApiHandlerModel dataHandler in Program.weatherApiAccessor.list)
            {
                if (dataHandler.IsActive)
                {
                    var weatherModel = await dataHandler.Api.GetWeatherForecastForDayAsync(requestedDay, city);

                    weatherModel.AvgHumidity *= dataHandler.Koef;
                    weatherModel.AvgTemp *= (int)dataHandler.Koef;
                    weatherModel.ChanceOfRain *= dataHandler.Koef;
                    weatherModel.ChanceOfSnow *= dataHandler.Koef;
                    weatherModel.TemperatureMax *= (int)dataHandler.Koef;
                    weatherModel.TemperatureMin *= (int)dataHandler.Koef;
                    weatherModel.WindSpeed *= dataHandler.Koef;

                    weatherModels.Add(weatherModel);
                }
            }

            var resultWeather = _weatherEvaluation.GetCalculatedWeatherModelDay(weatherModels);
            return resultWeather;
        }

        public async Task<IEnumerable<WeatherModelDay>> WeekWeatherForecast(string city)
        {
            var weatherModels = new List<WeatherModelDay>();
            int daysNumber = 7;

            // Cool code goes now. Invoking each api to get their length and
            // too choose number of the days in the final forecast
            var weatherAPIArray = new Dictionary<IApiDataHandler, List<WeatherModelDay>>();
            foreach (WeatherApiHandlerModel dataHandler in Program.weatherApiAccessor.list)
            {
                if (dataHandler.IsActive)
                {
                    weatherAPIArray.Add(dataHandler.Api, (await dataHandler.Api.GetWeatherForecastForWeekAsync(city)).ToList());
                }
            }
            
            foreach (WeatherApiHandlerModel dataHandler in Program.weatherApiAccessor.list)
            {
                //var weatherModel =
                //    await dataHandler.GetWeatherForecastForWeekAsync(city);
                var weatherModel = weatherAPIArray[dataHandler.Api];

                // If any API returns the forecast for less than 7 days
                if (daysNumber > weatherModel.ToList().Count)
                {
                    daysNumber = weatherModel.ToList().Count;
                }

                for (int i = 0; i < daysNumber; i++)
                {
                    weatherModel[i].AvgHumidity *= dataHandler.Koef;
                    weatherModel[i].AvgTemp *= (int)dataHandler.Koef;
                    weatherModel[i].ChanceOfRain *= dataHandler.Koef;
                    weatherModel[i].ChanceOfSnow *= dataHandler.Koef;
                    weatherModel[i].TemperatureMax *= (int)dataHandler.Koef;
                    weatherModel[i].TemperatureMin *= (int)dataHandler.Koef;
                    weatherModel[i].WindSpeed *= dataHandler.Koef;

                    weatherModels.Add(weatherModel[i]);
                }
            }

            var resultWeather = _weatherEvaluation.GetCalculatedWeatherModelWeek(
                weatherModels, daysNumber: daysNumber);
            return resultWeather;
        }

        public async Task<IEnumerable<WeatherModelHour>> DayHourlyWeatherForecast(string city)
        {
            var weatherModels = new List<WeatherModelHour>();
            int hoursNumber = 24;

            foreach (WeatherApiHandlerModel dataHandler in Program.weatherApiAccessor.list)
            {
                if (dataHandler.IsActive)
                {
                    var weatherModel = (await dataHandler.Api.GetWeatherForecastHourlyForDayAsync(DateTime.Today, city)).ToList();

                    for (int i = 0; i < hoursNumber; i++)
                    {
                        weatherModel[i].Humidity *= dataHandler.Koef;
                        weatherModel[i].ChanceOfRain *= dataHandler.Koef;
                        weatherModel[i].ChanceOfSnow *= dataHandler.Koef;
                        weatherModel[i].Temp *= (int)dataHandler.Koef;
                        weatherModel[i].FeelsLikeTemp *= (int)dataHandler.Koef;
                        weatherModel[i].WindSpeed *= dataHandler.Koef;
                        weatherModel[i].WindDegree *= dataHandler.Koef;

                        weatherModels.Add(weatherModel[i]);
                    }
                }
            }

            var resultWeather = 
                _weatherEvaluation.GetCalculatedWeatherModelHour(weatherModels);

            return resultWeather;
        }
    }
}