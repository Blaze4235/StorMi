using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StorMi.Models;

namespace StorMi.Services
{
    public class WeatherApiAccessor
    {
        public List<WeatherApiHandlerModel> list = new List<WeatherApiHandlerModel>();

        public WeatherApiAccessor()
        {
            list = new List<WeatherApiHandlerModel>();
            SetDefault();
        }

        public void SetDefault()
        {
            WeatherApiHandlerModel weatherApiHandlerModel1 = new WeatherApiHandlerModel();

            weatherApiHandlerModel1.Api = new ApiDataHandler1(new ApiInvoker());
            weatherApiHandlerModel1.IsActive = true;
            weatherApiHandlerModel1.Koef = 1;

            list.Add(weatherApiHandlerModel1);

            WeatherApiHandlerModel weatherApiHandlerModel2 = new WeatherApiHandlerModel();

            weatherApiHandlerModel2.Api = new ApiDataHandler2(new ApiInvoker(), new GeoAPIHandler(new ApiInvoker()));
            weatherApiHandlerModel2.IsActive = true;
            weatherApiHandlerModel2.Koef = 1;

            list.Add(weatherApiHandlerModel2);
        }

        public void AddWeatherDataSource(WeatherApiHandlerModel weatherApiHandlerModel)
        {
            list.Add(weatherApiHandlerModel);
        }

        public void RemoveWeatherDataSource(WeatherApiHandlerModel weatherApiHandlerModel)
        {
            list.Remove(weatherApiHandlerModel);
        }
        public void EnableWeatherDataSource(WeatherApiHandlerModel weatherApiHandlerModel)
        {
            list.Find(value => value.Equals(weatherApiHandlerModel)).IsActive = true;
        }
        public void DisableWeatherDataSource(WeatherApiHandlerModel weatherApiHandlerModel)
        {
            list.Find(value => value.Equals(weatherApiHandlerModel)).IsActive = false;
        }
    }
}
