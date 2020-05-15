using System;
using System.Collections.Generic;

namespace dotnet_test.Models
{
    public partial class Platforms
    {
        public Platforms()
        {
            Crafts = new HashSet<Crafts>();
        }

        public int PlatformId { get; set; }
        public string Type { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Topspeed { get; set; }
        public decimal? Maxload { get; set; }
        public string Dimensions { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Crafts> Crafts { get; set; }
    }
}
