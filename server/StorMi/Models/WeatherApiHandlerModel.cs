using System;
using System.Collections.Generic;
using System.Linq;
using StorMi.Interfaces;
using System.Threading.Tasks;

namespace StorMi.Models
{
    public class WeatherApiHandlerModel
    {
        public IApiDataHandler Api { get; set; }
        public bool IsActive { get; set; }
        public float Koef { get; set; }
    }
}
