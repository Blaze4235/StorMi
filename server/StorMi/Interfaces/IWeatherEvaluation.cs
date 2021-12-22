using System.Collections.Generic;
using StorMi.Models.WeatherAPI;

namespace StorMi.Interfaces
{
    public interface IWeatherEvaluation
    {
        public WeatherModelDay GetCalculatedWeatherModelDay(IEnumerable<WeatherModelDay> weatherModels);

        public IEnumerable<WeatherModelDay> GetCalculatedWeatherModelWeek(
            IEnumerable<WeatherModelDay> weatherModels, int apiNumber = 2, int daysNumber = 7);

        public IEnumerable<WeatherModelHour> GetCalculatedWeatherModelHour(
            IEnumerable<WeatherModelHour> weatherModels, int hourNumbr = 24, int apiNumber = 2);
    }
}