using StorMi.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorMi.Services
{
    public class GeoAPIHandler : IGeoAPIHandler
    {
        private readonly IApiInvoker _apiInvoker;
        private readonly string _apiSource;

        public GeoAPIHandler(IApiInvoker apiInvoker)
        {
            _apiSource = "http://api.openweathermap.org/geo/1.0/direct?";
            _apiInvoker = apiInvoker;
        }
        
        public async Task<IEnumerable<int>> GetCityCoordsByName(string cityName)
        {
            var res = await _apiInvoker.Invoke(_apiSource +
                                               $"q={cityName}&limit=1&appid=a0f92c05a3498558cf9952d561be2cf1");
            List<int> coords = new List<int>();

            var city = res[0];
            coords.Add(Convert.ToInt32(city["lon"]));
            coords.Add(Convert.ToInt32(city["lat"]));
            
            return coords;
        }

    }
}