using System;
using System.Collections.Generic;

namespace dotnet_test.Models
{
    public partial class Crafts
    {
        public Crafts()
        {
            Tests = new HashSet<Tests>();
        }

        public int SerialNum { get; set; }
        public int? PlatformId { get; set; }
        public DateTime CommisionDate { get; set; }
        public DateTime? DecommisionDate { get; set; }
        public decimal? TopSpeed { get; set; }
        public decimal? Torque { get; set; }
        public int? Status { get; set; }

        public virtual Platforms Platform { get; set; }
        public virtual ICollection<Tests> Tests { get; set; }
    }
}
