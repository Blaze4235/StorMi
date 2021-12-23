using Microsoft.AspNetCore.Identity;
using StorMi.DalModels;

namespace StorMi.DalModels
{
    public class ApplicationUser : IdentityUser
    {
        public virtual UserProfile UserProfile { get; set; }
    }
}