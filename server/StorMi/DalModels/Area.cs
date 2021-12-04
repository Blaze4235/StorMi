using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StorMi.DalModels
{
    public class Area
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }

        public short TimeZone { get; set; }

        public ICollection<UserProfile> UserProfiles { get; set; }
    }
}