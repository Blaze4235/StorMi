using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StorMi.DalModels;
using StorMi.Interfaces;

namespace StorMi.Controllers
{
    [Route("api/cities/")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CityController(ICityService cityService, UserManager<ApplicationUser> userManager)
        {
            _cityService = cityService;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Area>> GetAllCities()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cities = _cityService.GetAll();
            return cities;
        }

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddNewCity(string cityName)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var city = _cityService.GetByName(cityName);
            if (city == null)
            {
                Area area = new Area()
                {
                    Name = cityName,
                    Region = "None",
                    TimeZone = 0,
                };
                
                //area.UserProfiles.Add(new UserProfile() {UserId = userId});
                await _cityService.AddAsync(area);
            }

            return Ok();
        }

        [HttpPost]
        [Route("remove")]
        public async Task<IActionResult> RemoveCity(string cityName)
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var city = _cityService.GetByName(cityName);

            if (city != null)
            {
                await _cityService.DeleteByIdAsync(city.Id);
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
