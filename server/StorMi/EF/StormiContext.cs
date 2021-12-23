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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().HasData(new List<Area>()
            {
                new Area()
                {
                    Id = 1,
                    Name = "Kharkiv",
                    Region = "Region1",
                    TimeZone = 2,
                },
                new Area()
                {
                    Id = 2,
                    Name = "Kiev",
                    Region = "Region2",
                    TimeZone = 2,
                },
                new Area()
                {
                    Id = 3,
                    Name = "Dniprorudne",
                    Region = "Region3",
                    TimeZone = 2,
                },
                new Area()
                {
                    Id = 4,
                    Name = "Lviv",
                    Region = "Region4",
                    TimeZone = 2,
                },
                new Area()
                {
                    Id = 5,
                    Name = "Chernihiv",
                    Region = "Region5",
                    TimeZone = 2,
                },
                new Area()
                {
                    Id = 6,
                    Name = "Sevastopol",
                    Region = "Region6",
                    TimeZone = 2,
                },
                new Area()
                {
                    Id = 7,
                    Name = "Sumy",
                    Region = "Region7",
                    TimeZone = 2,
                },
                new Area()
                {
                    Id = 8,
                    Name = "Poltava",
                    Region = "Region8",
                    TimeZone = 2,
                },
                new Area()
                {
                    Id = 9,
                    Name = "Odessa",
                    Region = "Region9",
                    TimeZone = 2,
                },
                new Area()
                {
                    Id = 10,
                    Name = "Kherson",
                    Region = "Region10",
                    TimeZone = 2,
                },
            });

            base.OnModelCreating(modelBuilder);
        }

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