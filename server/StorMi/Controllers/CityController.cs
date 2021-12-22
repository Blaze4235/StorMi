using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using StorMi.DalModels;
using StorMi.Interfaces;

namespace StorMi.Controllers
{
    [Route("api/cities/")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Area>> GetAllCities()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cities = await _cityService.GetUserAll(userId);
            return cities;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddNewCity(string cityName)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var city = _cityService.GetByName(cityName);
            if (city == null)
            {
                Area area = new Area()
                {
                    Name = cityName,
                    Region = "None",
                    TimeZone = 0,
                    UserProfiles = new List<UserProfile>(),
                };
                
                area.UserProfiles.Add(new UserProfile() {UserId = userId});
                await _cityService.AddAsync(area);
            }

            return Ok();
        }
    }
}
