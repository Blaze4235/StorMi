using System.Collections.Generic;
using System.Threading.Tasks;

namespace StorMi.Interfaces
{
    public interface IGeoAPIHandler
    {
        public Task<IEnumerable<double>> GetCityCoordsByName(string cityName);
    }
}