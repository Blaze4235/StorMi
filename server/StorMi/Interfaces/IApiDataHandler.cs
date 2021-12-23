using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StorMi.Models.WeatherAPI;

namespace StorMi.Interfaces
{
    public interface IApiDataHandler
    {
        public Task<WeatherModelDay> GetWeatherForecastForDayAsync(DateTime requestedDay, string city);

        public Task<IEnumerable<WeatherModelDay>> GetWeatherForecastForWeekAsync(string city);
        
        public Task<IEnumerable<WeatherModelHour>> GetWeatherForecastHourlyForDayAsync(DateTime requestedDay, string city);
    }
}