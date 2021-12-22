using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StorMi.Models.WeatherAPI;

namespace StorMi.Interfaces
{
    public interface IWeatherService
    {
        public void AddWeatherDataSource(IApiDataHandler apiDataHandler, float coef);

        public void RemoveWeatherDataSource(IApiDataHandler apiDataHandler, float coef);

        public void SetDefault();

        public Task<WeatherModelDay> DayWeatherForecast(DateTime requestedDate, string city);

        public Task<IEnumerable<WeatherModelDay>> WeekWeatherForecast(string city);

        public Task<IEnumerable<WeatherModelHour>> DayHourlyWeatherForecast(DateTime requestedDay, string city);
    }
}