using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorMi.Models.WeatherAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using StorMi.Interfaces;
using StorMi.Services;

namespace StorMi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        [Route("/weather/day")]
        public async Task<IActionResult> DayWeatherForecast(string city)
        {
            var res = await _weatherService.DayWeatherForecast(DateTime.Today, city);
            return Json(res);
        }

        [HttpGet]
        [Route("/weather/week")]
        public async Task<IActionResult> WeekWeatherForecast(string city)
        {
            var res = await _weatherService.WeekWeatherForecast(city);
            return Json(res);
        }

        [HttpGet]
        [Route("/weather/day/hourly")]
        public async Task<IActionResult> DayHourlyWeatherForecast(string city)
        {
            var res = await _weatherService.DayHourlyWeatherForecast(city);
            return Json(res);
        }
    }
}
