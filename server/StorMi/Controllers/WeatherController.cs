using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorMi.Models.WeatherAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StorMi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {


        [HttpGet]
        [Route("/weather/day")]
        public async Task<IActionResult> DayWeatherForecast()
        {
            // First API: https://api.weatherapi.com
            dynamic res = null;
            WeatherModelDay model = new WeatherModelDay();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.weatherapi.com/v1/forecast.json?key=2f3b18240aca47f9a5e131759211112&q=Kharkiv&days=1&aqi=no&alerts=no"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //dynamic data = System.Web.Helpers.Json.Decode(apiResponse);
                    res = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(apiResponse);
                    var location = res["location"];
                    var forecast = res["forecast"];
                    var forecastDay = forecast["forecastday"];
                    var day = forecastDay[0];

                    var weatherParams = day["day"];
                    //var weatherParams = hour["day"].avghumidity;
                    var condition = weatherParams["condition"];

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
                }
            }

            return Json(model);
        }

        [HttpGet]
        [Route("/weather/week")]
        public async Task<IActionResult> WeekWeatherForecast()
        {
            // First API: https://api.weatherapi.com
            dynamic res = null;
            List<WeatherModelDay> model = new List<WeatherModelDay>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api.weatherapi.com/v1/forecast.json?key=2f3b18240aca47f9a5e131759211112&q=Kharkiv&days=7&aqi=no&alerts=no"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //dynamic data = System.Web.Helpers.Json.Decode(apiResponse);
                    res = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(apiResponse);
                    var location = res["location"];
                    var forecast = res["forecast"];
                    var forecastDay = forecast["forecastday"];
                    for (int i = 0; i < forecastDay.Count; i++)
                    {
                        var node = new WeatherModelDay();
                        var day = forecastDay[i];
                        var weatherParams = day["day"];
                        //var weatherParams = hour["day"].avghumidity;
                        var condition = weatherParams["condition"];

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
                }
            }

            return Json(model);
        }
    }
}
