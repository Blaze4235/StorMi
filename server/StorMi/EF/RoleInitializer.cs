using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StorMi.DalModels;

namespace StorMi.EF
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "12345Qq_";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                ApplicationUser admin = new ApplicationUser
                {
                    Email = adminEmail,
                    UserName = adminEmail
                };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }

                ApplicationUser user = new ApplicationUser
                {
                    Email = "user@gmail.com",
                    UserName = "user@gmail.com",
                };
                IdentityResult result2 = await userManager.CreateAsync(admin, "12345Qq_");
                if (result2.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }
        }
    }
}