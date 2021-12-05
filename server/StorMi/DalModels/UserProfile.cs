using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StorMi.DalModels
{
    public class UserProfile
    {
        [Key]
        public string UserId { get; set; }

        public string Name { get; set; }

        public string PlatformType { get; set; }

        public short TimeZone { get; set; }

        public ICollection<Area> Areas { get; set; }
    }
}