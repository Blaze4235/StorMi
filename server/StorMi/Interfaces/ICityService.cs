using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using StorMi.DalModels;

namespace StorMi.Interfaces
{
    public interface ICityService
    {
        public IEnumerable<Area> GetAll();

        public Task<IEnumerable<Area>> GetUserAll(string userId);

        public Area GetById(int id);

        public Area GetByName(string name);

        public Task AddAsync(Area area);

        public Task EditAsync(Area area);

        public Task DeleteAsync(Area area);

        public Task DeleteByIdAsync(int areaId);

        public Task DeleteByIdUserAsync(int areaId, string userId);
    }
}