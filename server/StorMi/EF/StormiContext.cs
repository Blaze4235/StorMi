using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StorMi.DalModels;
using StorMi.DalModels;

namespace StorMi.EF
{
    public class StormiContext : IdentityDbContext<ApplicationUser>
    {
        public StormiContext()
        {
        }

        public StormiContext(DbContextOptions<StormiContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Area> Areas { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //}
    }
}