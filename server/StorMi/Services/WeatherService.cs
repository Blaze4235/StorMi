using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorMi.Interfaces;
using StorMi.Models.WeatherAPI;

namespace StorMi.Services
{
    public class WeatherService : IWeatherService
    {
        private Dictionary<IApiDataHandler, float> _dataHandlers;
        private readonly IWeatherEvaluation _weatherEvaluation;

        public WeatherService(IWeatherEvaluation weatherEvaluation)
        {
            _dataHandlers = new Dictionary<IApiDataHandler, float>();
            _weatherEvaluation = weatherEvaluation;
        }

        public void SetDefault()
        {
            _dataHandlers.TryAdd(new ApiDataHandler1(new ApiInvoker()), 1);
            _dataHandlers.TryAdd(new ApiDataHandler2(new ApiInvoker(), new GeoAPIHandler(new ApiInvoker())), 1);
        }

        public void AddWeatherDataSource(IApiDataHandler apiDataHandler, float coef)
        {
            _dataHandlers.TryAdd(apiDataHandler, coef);
        }

        public void RemoveWeatherDataSource(IApiDataHandler apiDataHandler, float coef)
        {
            _dataHandlers.Remove(apiDataHandler);
        }

        public async Task<WeatherModelDay> DayWeatherForecast(DateTime requestedDay, string city)
        {
            // If currently no api isn't set up by admin
            if (_dataHandlers.Count == 0)
            {
                SetDefault();
            }

            var weatherModels = new List<WeatherModelDay>();

            foreach (var dataHandler in _dataHandlers.Keys)
            {
                var weatherModel = 
                    await dataHandler.GetWeatherForecastForDayAsync(requestedDay, city);

                weatherModel.AvgHumidity *= _dataHandlers[dataHandler];
                weatherModel.AvgTemp *= (int)_dataHandlers[dataHandler];
                weatherModel.ChanceOfRain *= _dataHandlers[dataHandler];
                weatherModel.ChanceOfSnow *= _dataHandlers[dataHandler];
                weatherModel.TemperatureMax *= (int)_dataHandlers[dataHandler];
                weatherModel.TemperatureMin *= (int)_dataHandlers[dataHandler];
                weatherModel.WindSpeed *= _dataHandlers[dataHandler];

                weatherModels.Add(weatherModel);
            }

            var resultWeather = _weatherEvaluation.GetCalculatedWeatherModelDay(weatherModels);

            return resultWeather;
        }

        public async Task<IEnumerable<WeatherModelDay>> WeekWeatherForecast(string city)
        {
            // If currently no api isn't set up by admin
            if (_dataHandlers.Count == 0)
            {
                SetDefault();
            }

            var weatherModels = new List<WeatherModelDay>();
            int daysNumber = 7;

            // Cool code goes now. Invoking each api to get their length and
            // too choose number of the days in the final forecast
            var weatherAPIArray = new Dictionary<IApiDataHandler, List<WeatherModelDay>>();
            foreach (var dataHandler in _dataHandlers)
            {
                weatherAPIArray.Add(dataHandler.Key, (await dataHandler.Key.GetWeatherForecastForWeekAsync(city)).ToList());
            }
            
            foreach (var dataHandler in _dataHandlers)
            {
                //var weatherModel =
                //    await dataHandler.GetWeatherForecastForWeekAsync(city);
                var weatherModel = weatherAPIArray[dataHandler.Key];

                // If any API returns the forecast for less than 7 days
                if (daysNumber > weatherModel.ToList().Count)
                {
                    daysNumber = weatherModel.ToList().Count;
                }

                for (int i = 0; i < daysNumber; i++)
                {
                    weatherModel[i].AvgHumidity *= _dataHandlers[dataHandler.Key];
                    weatherModel[i].AvgTemp *= (int)_dataHandlers[dataHandler.Key];
                    weatherModel[i].ChanceOfRain *= _dataHandlers[dataHandler.Key];
                    weatherModel[i].ChanceOfSnow *= _dataHandlers[dataHandler.Key];
                    weatherModel[i].TemperatureMax *= (int)_dataHandlers[dataHandler.Key];
                    weatherModel[i].TemperatureMin *= (int)_dataHandlers[dataHandler.Key];
                    weatherModel[i].WindSpeed *= _dataHandlers[dataHandler.Key];

                    weatherModels.Add(weatherModel[i]);
                }
            }

            var resultWeather = _weatherEvaluation.GetCalculatedWeatherModelWeek(
                weatherModels, daysNumber: daysNumber);
            return resultWeather;
        }

        public async Task<IEnumerable<WeatherModelHour>> DayHourlyWeatherForecast(
            DateTime requestedDay, string city)
        {
            // If currently no api isn't set up by admin
            if (_dataHandlers.Count == 0)
            {
                SetDefault();
            }

            var weatherModels = new List<WeatherModelHour>();
            int hoursNumber = 24;

            foreach (var dataHandler in _dataHandlers.Keys)
            {
                var weatherModel = (await dataHandler.GetWeatherForecastHourlyForDayAsync(requestedDay, city)).ToList();

                for (int i = 0; i < hoursNumber; i++)
                {
                    weatherModel[i].Humidity *= _dataHandlers[dataHandler];
                    weatherModel[i].ChanceOfRain *= _dataHandlers[dataHandler];
                    weatherModel[i].ChanceOfSnow *= _dataHandlers[dataHandler];
                    weatherModel[i].Temp *= (int) _dataHandlers[dataHandler];
                    weatherModel[i].FeelsLikeTemp *= (int) _dataHandlers[dataHandler];
                    weatherModel[i].WindSpeed *= _dataHandlers[dataHandler];
                    weatherModel[i].WindDegree *= _dataHandlers[dataHandler];

                    weatherModels.Add(weatherModel[i]);
                }
            }

            var resultWeather = 
                _weatherEvaluation.GetCalculatedWeatherModelHour(weatherModels);

            return resultWeather;
        }
    }
}