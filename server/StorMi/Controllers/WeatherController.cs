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
        [Route("/weather")]
        public async Task<IActionResult> WeatherForecast()
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
                    var hour = forecastDay[0];

                    var weatherParams = hour["day"];
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
    }
}
