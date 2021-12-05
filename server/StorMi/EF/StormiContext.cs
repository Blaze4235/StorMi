using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StorMi.DalModels;
using System.Collections.Generic;

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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    List<UserProfile> users = new List<UserProfile>();

        //    users.Add(new UserProfile
        //    {
        //        UserId = "1",
        //        Name = "john@mail.com",
        //        PlatformType = "Android",
        //        TimeZone = -5
        //    });
        //    users.Add(new UserProfile
        //    {
        //        UserId = "2",
        //        Name = "alice@mail.com",
        //        PlatformType = "iOS",
        //        TimeZone = 7
        //    });

        //    users.Add(new UserProfile
        //    {
        //        UserId = "3",
        //        Name = "harris@gmail.com",
        //        PlatformType = "Android",
        //        TimeZone = 5
        //    });

        //    var context = modelBuilder.Entity<UserProfile>().GetType().GetProperties();

        //    foreach (UserProfile user1 in users)
        //    {

        //        modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
        //        {
        //            Id = user1.UserId,
        //            Email = user1.Name,
        //            UserName = user1.Name
        //        });
        //    }
        //}
    }
}