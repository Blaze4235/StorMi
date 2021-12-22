using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StorMi.DalModels;
using StorMi.EF;
using StorMi.Interfaces;

namespace StorMi.Services
{
    public class CityServices : ICityService
    {
        private readonly StormiContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public CityServices(StormiContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        
        public IEnumerable<Area> GetAll()
        {
            return _db.Areas;
        }

        public async Task<IEnumerable<Area>> GetUserAll(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userCities = _db.Areas
                .Include(a => a.UserProfiles)
                .Where(a => a.UserProfiles.Any(u => u.UserId == user.Id));
            return userCities.ToList();
        }

        public Area GetById(int id)
        {
            return _db.Areas.First(a => a.Id == id);
        }

        public Area GetByName(string name)
        {
            return _db.Areas.FirstOrDefault(a => a.Name == name);
        }

        public async Task AddAsync(Area area)
        {
            if (area.UserProfiles != null)
            {
                var user = area.UserProfiles.First().UserId;
                var userProfile = _db.UserProfiles.First(up => up.UserId == user);
                area.UserProfiles = new List<UserProfile>() { userProfile };
            }

            await _db.Areas.AddAsync(area);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Area area)
        {
            _db.Entry<Area>(area).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Area area)
        {
            _db.Remove(area);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int areaId)
        {
            var area = _db.Areas.First(a => a.Id == areaId);
            _db.Remove(area);
            await _db.SaveChangesAsync();
        }
    }
}