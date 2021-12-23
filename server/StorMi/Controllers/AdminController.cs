using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoMi.ViewModels;
using StorMi.DalModels;
using StorMi.EF;
using StorMi.Models;
using StorMi.ViewModels;
using StorMi.Services;

namespace StorMi.Controllers
{
    [Route("/api")]
    public class AdminContoller : Controller
    {
        [HttpGet]
        [Route("/apis")]
        public async Task<IEnumerable<WeatherApiHandlerModel>> GetAll()
        {
            return Program.weatherApiAccessor.list;
        }

        [HttpPut]
        [Route("/change")]
        public async Task<IActionResult> ChangeApiSource(int id, bool value)
        {
            Program.weatherApiAccessor.list[id].IsActive = value;
            return Ok();
        }
    }
}
